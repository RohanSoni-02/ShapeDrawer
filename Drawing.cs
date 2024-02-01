using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing():this (Color.White)
        {

        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveShape(Shape s)
        {
                _shapes.Remove(s);
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape s in _shapes)
            {
                s.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach(Shape s in _shapes)
            {
                if(s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }
        public void Save(string filename)
        {
            StreamWriter writer;

            writer = new StreamWriter(filename);
            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);

            try
            {
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader;
            int count;
            Shape s;
            string kind;

            reader = new StreamReader(filename);
            Background = reader.ReadColor();
            count = reader.ReadInteger();
            _shapes.Clear();

            try
            {
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    s = Shape.CreateShape(kind);

                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }

            finally
            {
                reader.Close();
            }
        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public Color Background
        {
           get
            {
                return _background;
            }

            set
            {
                _background = value;
            }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach(Shape s in _shapes)
                {
                    if(s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }


    }
}
