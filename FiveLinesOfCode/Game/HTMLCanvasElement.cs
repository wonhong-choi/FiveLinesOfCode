using System;
using System.Windows.Controls;

namespace FiveLinesOfCode.Game
{
    public interface IHTMLCanvasElement
    {

    }

    public class HTMLCanvasElement : Canvas, IHTMLCanvasElement
    {
        public GraphicContext GetContext(string v)
        {
            return new GraphicContext();
        }
    }

    public class GraphicContext
    {
        public GraphicContext()
        {
        }

        public string FillStyle { get; set; }

        public void ClearRect(int v1, int v2, int width, int height)
        {
        }

        public void FillRect(int v1, int v2, int tILE_SIZE1, int tILE_SIZE2)
        {
        }
    }
}