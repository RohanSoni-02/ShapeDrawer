using System;
using SplashKitSDK;
using System.IO;
namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private int _length;
        public MyLine(Color c, int l)
        {
            _length = l;
        }

        public MyLine() : this(Color.Cyan, 100) { }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(color, X, Y, X + Length, Y);
        }

        public override bool IsAt(Point2D pt)
        {
            Point2D pt1 = new Point2D();
            pt1.X = X;
            pt1.Y = Y;
            Point2D pt2 = new Point2D();
            pt2.X = X + Length;
            pt2.Y = Y;
            SplashKitSDK.Line myLine = SplashKit.LineFrom(pt1, pt2);
            return SplashKit.PointOnLine(pt, myLine);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 10);
            SplashKit.DrawCircle(Color.Black, X + Length, Y, 10);
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(Length);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Length = reader.ReadInteger();
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }
        
    }
}
