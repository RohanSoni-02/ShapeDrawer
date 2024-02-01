using System;
using System.IO;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public MyCircle(Color clr, int r)
        {
            _radius = r;
        }

        public MyCircle() : this(Color.Blue, 50) { }

        public override void Draw()
        {
            if(Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(color, X, Y, _radius);
        }

        public override bool IsAt(Point2D pt)
        {
            Point2D point = new Point2D();
            point.X = X;
            point.Y = Y;
            Circle circle = SplashKit.CircleAt(point, Radius);
            return SplashKit.PointInCircle(pt, circle);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, Radius + 2);
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }


    }
}
