﻿using FiveLinesOfCode.Domain.FallingState;
using FiveLinesOfCode.Domain.Input;
using FiveLinesOfCode.Domain.Tile;
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

        public const int FPS = 30;
        public const double SLEEP = 1000 / FPS;

        private int _playerX = 1;
        private int _playerY = 1;

        public enum RawTile
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


        private RawTile[][] _rawMap = new RawTile[][]
        {
            new RawTile[] { RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, },
            new RawTile[] { RawTile.UNBREAKABLE, RawTile.PLAYER, RawTile.AIR, RawTile.FLUX, RawTile.FLUX, RawTile.UNBREAKABLE, RawTile.AIR, RawTile.UNBREAKABLE },
            new RawTile[] { RawTile.UNBREAKABLE, RawTile.STONE, RawTile.UNBREAKABLE, RawTile.BOX, RawTile.FLUX, RawTile.UNBREAKABLE, RawTile.AIR, RawTile.UNBREAKABLE },
            new RawTile[] { RawTile.UNBREAKABLE, RawTile.KEY1, RawTile.STONE, RawTile.FLUX, RawTile.FLUX, RawTile.UNBREAKABLE, RawTile.AIR, RawTile.UNBREAKABLE },
            new RawTile[] { RawTile.UNBREAKABLE, RawTile.STONE, RawTile.FLUX, RawTile.FLUX, RawTile.FLUX, RawTile.LOCK1, RawTile.AIR, RawTile.UNBREAKABLE },
            new RawTile[] { RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, RawTile.UNBREAKABLE, },
        };

        private ITile[][] _map;


        public enum RawInput
        {
            UP, DOWN, LEFT, RIGHT
        }

        private Queue<IInput> _inputs = new Queue<IInput>();
    
        public void MoveToTile(int newx, int newy)
        {
            _map[_playerY][_playerX] = new AirTile();
            _map[newy][newx] = new PlayerTile();
            _playerX = newx;
            _playerY = newy;
        }

        public void MoveHorizontal(int dx)
        {
            _map[_playerY][_playerX + dx].MoveHorizontal(dx);
        }

        public void MoveVertical(int dy)
        {
            _map[_playerY + dy][_playerX].MoveVertical(dy);
        }

        public void RemoveLock1()
        {
            for (int y = 0; y < _map.Length; y++)
            {
                for (int x = 0; x < _map[y].Length; x++)
                {
                    if (_map[y][x].IsLOCK1())
                    {
                        _map[y][x] = new AirTile();
                    }
                }
            }
        }

        public void RemoveLock2()
        {
            for (int y = 0; y < _map.Length; y++)
            {
                for (int x = 0; x < _map[y].Length; x++)
                {
                    if (_map[y][x].IsLOCK2())
                    {
                        _map[y][x] = new AirTile();
                    }
                }
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
                var input = _inputs.Dequeue();
                input.Handle();
            }
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
            _map[y][x].Update(x, y);
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
                    _map[y][x].Draw(g, y, x);
                }
            }
        }

        private void DrawPlayer(GraphicContext g)
        {
            g.FillStyle = "#ff0000";
            g.FillRect(_playerX * TileConfig.TILE_SIZE, _playerY * TileConfig.TILE_SIZE, TileConfig.TILE_SIZE, TileConfig.TILE_SIZE);
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
            TransformMap();
            GameLoop();
        }

        private void TransformMap()
        {
            _map = new ITile[_rawMap.Length][];
            for (int y = 0; y < _rawMap.Length; y++)
            {
                _map[y] = new ITile[_rawMap[y].Length];
                for (int x = 0; x < _rawMap[y].Length; x++)
                {
                    _map[y][x] = TransformTile(_rawMap[y][x]);
                }
            }
        }

        private ITile TransformTile(RawTile tile)
        {
            switch (tile)
            {
                case RawTile.AIR: return new AirTile();
                case RawTile.FLUX: return new FluxTile();
                case RawTile.UNBREAKABLE: return new UnbreakableTile();
                case RawTile.PLAYER: return new PlayerTile();
                case RawTile.STONE: return new StoneTile(new RestingState());
                case RawTile.FALLING_STONE: return new StoneTile(new FallingState());
                case RawTile.BOX: return new BoxTile(new RestingState()) ;
                case RawTile.FALLING_BOX: return new BoxTile(new FallingState());
                case RawTile.KEY1: return new Key1Tile();
                case RawTile.LOCK1: return new Lock1Tile();
                case RawTile.KEY2: return new Key2Tile();
                case RawTile.LOCK2: return new Lock2Tile();
                default:
                    AssertExhausted(tile);
                    return null;
            }
        }
        private static void AssertExhausted(RawTile tile)
        {
            throw new Exception("Unexpected tileType");
        }

        private const Key LEFT_KEY = Key.Left;
        private const Key UP_KEY = Key.Up;
        private const Key RIGHT_KEY = Key.Right;
        private const Key DOWN_KEY = Key.Down;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == LEFT_KEY || e.Key == Key.A) _inputs.Enqueue(new LeftInput());
            else if (e.Key == UP_KEY || e.Key == Key.W) _inputs.Enqueue(new UpInput());
            else if (e.Key == RIGHT_KEY || e.Key == Key.D) _inputs.Enqueue(new RightInput());
            else if (e.Key == DOWN_KEY || e.Key == Key.S) _inputs.Enqueue(new DownInput());
        }
    }
}
