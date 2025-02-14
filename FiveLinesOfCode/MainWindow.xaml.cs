using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FiveLinesOfCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public const int TILE_SIZE = 30;
        public const int FPS = 30;
        public const double SLEEP = 1000 / FPS;
        public enum Tile
        {
            AIR,
            FLUX,
            UNBREAKABLE,
            PLAYER,
            STONE,
            FALLING_STONE,
            BOX,
            FALLING_BOX,
            KEY1,
            LOCK1,
            KEY2,
            LOCK2
        }

        public enum Input
        {
            UP, DOWN, LEFT, RIGHT
        }

        private int _playerX = 1;
        private int _playerY = 1;

        private Tile[][] _map = new Tile[][]
        {
            new Tile[] {Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE },
            new Tile[] {Tile.UNBREAKABLE, Tile.PLAYER, Tile.AIR, Tile.FLUX, Tile.FLUX, Tile.UNBREAKABLE, Tile.AIR, Tile.UNBREAKABLE },
            new Tile[] {Tile.UNBREAKABLE, Tile.STONE, Tile.UNBREAKABLE, Tile.BOX, Tile.FLUX, Tile.UNBREAKABLE, Tile.AIR, Tile.UNBREAKABLE },
            new Tile[] {Tile.UNBREAKABLE, Tile.KEY1, Tile.STONE, Tile.FLUX, Tile.FLUX, Tile.UNBREAKABLE, Tile.AIR, Tile.UNBREAKABLE },
            new Tile[] {Tile.UNBREAKABLE, Tile.STONE, Tile.FLUX, Tile.FLUX, Tile.FLUX, Tile.LOCK1, Tile.AIR, Tile.UNBREAKABLE },
            new Tile[] {Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE, Tile.UNBREAKABLE },
        };

        private Queue<Input> _inputs = new Queue<Input>();

        public void Remove(Tile tile)
        {
            for (int y = 0; y < _map.Length; y++)
            {
                for (int x = 0; x < _map[y].Length; x++)
                {
                    if (_map[y][x] == tile)
                    {
                        _map[y][x] = Tile.AIR;
                    }
                }
            }
        }

        public void MoveToTile(int newx, int newy)
        {
            _map[_playerY][_playerX] = Tile.AIR;
            _map[newy][newx] = Tile.PLAYER;
            _playerX = newx;
            _playerY = newy;
        }

        public void MoveHorizontal(int dx)
        {

            if (_map[_playerY][_playerX + dx] == Tile.FLUX
              || _map[_playerY][_playerX + dx] == Tile.AIR)
            {
                MoveToTile(_playerX + dx, _playerY);
            }
            else if ((_map[_playerY][_playerX + dx] == Tile.STONE
              || _map[_playerY][_playerX + dx] == Tile.BOX)
              && _map[_playerY][_playerX + dx + dx] == Tile.AIR
              && _map[_playerY + 1][_playerX + dx] != Tile.AIR)
            {
                _map[_playerY][_playerX + dx + dx] = _map[_playerY][_playerX + dx];
                MoveToTile(_playerX + dx, _playerY);
            }
            else if (_map[_playerY][_playerX + dx] == Tile.KEY1)
            {
                Remove(Tile.LOCK1);
                MoveToTile(_playerX + dx, _playerY);
            }
            else if (_map[_playerY][_playerX + dx] == Tile.KEY2)
            {
                Remove(Tile.LOCK2);
                MoveToTile(_playerX + dx, _playerY);
            }
        }



        public void MoveVertical(int dy)
        {
            if (_map[_playerY + dy][_playerX] == Tile.FLUX
              || _map[_playerY + dy][_playerX] == Tile.AIR)
            {
                MoveToTile(_playerX, _playerY + dy);
            }
            else if (_map[_playerY + dy][_playerX] == Tile.KEY1)
            {
                Remove(Tile.LOCK1);
                MoveToTile(_playerX, _playerY + dy);
            }
            else if (_map[_playerY + dy][_playerX] == Tile.KEY2)
            {
                Remove(Tile.LOCK2);
                MoveToTile(_playerX, _playerY + dy);
            }
        }

        public void Update()
        {
            HandleInputs();
            UpdateMap();
        }

        private void HandleInputs()
        {
            while (_inputs.Count > 0)
            {
                var current = _inputs.Dequeue();
                HandleInput(current);
            }
        }

        private void HandleInput(Input current)
        {
            if (current == Input.LEFT)
                MoveHorizontal(-1);
            else if (current == Input.RIGHT)
                MoveHorizontal(1);
            else if (current == Input.UP)
                MoveVertical(-1);
            else if (current == Input.DOWN)
                MoveVertical(1);
        }

        private void UpdateMap()
        {
            for (int y = _map.Length - 1; y >= 0; y--)
            {
                for (int x = 0; x < _map[y].Length; x++)
                {
                    UpdateTile(y, x);
                }
            }
        }

        private void UpdateTile(int y, int x)
        {
            if ((_map[y][x] == Tile.STONE || _map[y][x] == Tile.FALLING_STONE)
                                  && _map[y + 1][x] == Tile.AIR)
            {
                _map[y + 1][x] = Tile.FALLING_STONE;
                _map[y][x] = Tile.AIR;
            }
            else if ((_map[y][x] == Tile.BOX || _map[y][x] == Tile.FALLING_BOX)
              && _map[y + 1][x] == Tile.AIR)
            {
                _map[y + 1][x] = Tile.FALLING_BOX;
                _map[y][x] = Tile.AIR;
            }
            else if (_map[y][x] == Tile.FALLING_STONE)
            {
                _map[y][x] = Tile.STONE;
            }
            else if (_map[y][x] == Tile.FALLING_BOX)
            {
                _map[y][x] = Tile.BOX;
            }
        }

        public void Draw()
        {
            GraphicContext g = CreateGraphics();
            DrawMap(g);
            DrawPlayer(g);
        }

        private GraphicContext CreateGraphics()
        {
            var canvas = this.GameCanvas as HTMLCanvasElement;
            var g = canvas.GetContext("2d");

            g.ClearRect(0, 0, (int)canvas.Width, (int)canvas.Height);
            return g;
        }

        private void DrawMap(GraphicContext g)
        {
            for (int y = 0; y < _map.Length; y++)
            {
                for (int x = 0; x < _map[y].Length; x++)
                {
                    if (_map[y][x] == Tile.FLUX)
                        g.FillStyle = "#ccffcc";
                    else if (_map[y][x] == Tile.UNBREAKABLE)
                        g.FillStyle = "#999999";
                    else if (_map[y][x] == Tile.STONE || _map[y][x] == Tile.FALLING_STONE)
                        g.FillStyle = "#0000cc";
                    else if (_map[y][x] == Tile.BOX || _map[y][x] == Tile.FALLING_BOX)
                        g.FillStyle = "#8b4513";
                    else if (_map[y][x] == Tile.KEY1 || _map[y][x] == Tile.LOCK1)
                        g.FillStyle = "#ffcc00";
                    else if (_map[y][x] == Tile.KEY2 || _map[y][x] == Tile.LOCK2)
                        g.FillStyle = "#00ccff";

                    if (_map[y][x] != Tile.AIR && _map[y][x] != Tile.PLAYER)
                        g.FillRect(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                }
            }
        }

        private void DrawPlayer(GraphicContext g)
        {
            g.FillStyle = "#ff0000";
            g.FillRect(_playerX * TILE_SIZE, _playerY * TILE_SIZE, TILE_SIZE, TILE_SIZE);
        }


        private void GameLoop()
        {
            var before = DateTime.Now;
            Update();
            Draw();
            var after = DateTime.Now;
            var frameTime = after - before;
            var sleep = TimeSpan.FromMilliseconds(SLEEP) - frameTime;

            Task.Delay(sleep).ContinueWith(task => GameLoop());
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameLoop();
        }


        private const Key LEFT_KEY = Key.Left;
        private const Key UP_KEY = Key.Up;
        private const Key RIGHT_KEY = Key.Right;
        private const Key DOWN_KEY = Key.Down;


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == LEFT_KEY || e.Key == Key.A) _inputs.Enqueue(Input.LEFT);
            else if (e.Key == UP_KEY || e.Key == Key.W) _inputs.Enqueue(Input.UP);
            else if (e.Key == RIGHT_KEY || e.Key == Key.D) _inputs.Enqueue(Input.RIGHT);
            else if (e.Key == DOWN_KEY || e.Key == Key.S) _inputs.Enqueue(Input.DOWN);
        }
    }
}
