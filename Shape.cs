using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.IO;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type>();

        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }

        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistry[name]);
        }

        public static string GetKey(Type keyType)
        {
            foreach (string key in _ShapeClassRegistry.Keys)
            {
                if (_ShapeClassRegistry[key] == keyType)
                {
                    return key;
                }
            }
            return null;
        }

        private Color _color;
        private float _x, _y;
        private bool _selected;

        public Shape(Color c)
        {
            _color = c;
        }
        public Shape(): this(Color.Yellow){}

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);
      
        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
            writer.WriteLine(GetKey(this.GetType()));
        }
        public virtual void LoadFrom(StreamReader reader)
        {
            color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }

        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public float X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }
        
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        

    }
}