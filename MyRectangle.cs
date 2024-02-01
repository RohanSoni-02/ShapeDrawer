using System;
using System.IO;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle(Color clr, float x,float y, int width, int height):base(clr)
        {
            X = x;
            Y = y;
            WIDTH = width;
            HEIGHT = height;
        }
        public MyRectangle(): this(Color.Green, 0, 0, 100, 100) { }

        public override void Draw()
        {
            if(Selected == true)
            {
               DrawOutline();
            }
            SplashKit.FillRectangle(color, X, Y, WIDTH, HEIGHT);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, WIDTH + 4, HEIGHT + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            if((pt.X >= X)&&(pt.X <= (X + WIDTH))&&(pt.Y >= Y)&&(pt.Y <= (Y + HEIGHT)))
            {
                return true;
            }
            else
            {
              return false;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(WIDTH);
            writer.WriteLine(HEIGHT);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            WIDTH = reader.ReadInteger();
            HEIGHT = reader.ReadInteger();
        }

        public int WIDTH
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int HEIGHT
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
    }
}
