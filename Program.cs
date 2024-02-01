using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Shape.RegisterShape("Rectangle", typeof(MyRectangle));
            Shape.RegisterShape("Circle", typeof(MyCircle));
            Shape.RegisterShape("Line", typeof(MyLine));

            ShapeKind kindToAdd = new ShapeKind();
            kindToAdd = ShapeKind.Circle;
            Drawing DrawShape = new Drawing();
            new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                DrawShape.Draw();

                if (SplashKit.KeyTyped(KeyCode.RKey) == true)
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey) == true)
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey) == true)
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyTyped(KeyCode.SKey) == true)
                {
                    DrawShape.Save("/Users/rohansoni/Desktop/Test/TestDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey) == true)
                {
                    try
                    {
                        DrawShape.Load("/Users/rohansoni/Desktop/Test/TestDrawing.txt");
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton) == true)
                {
                    Shape myShape;

                    if(kindToAdd== ShapeKind.Circle)
                    {
                        MyCircle circ = new MyCircle();
                        myShape = circ;
                    }

                    else if(kindToAdd == ShapeKind.Line)
                    {
                        MyLine li = new MyLine();
                        myShape = li;
                    }
                    else
                    {
                        MyRectangle rect = new MyRectangle();
                        myShape = rect;
                    }
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    myShape.color = SplashKit.RandomRGBColor(255);
                    DrawShape.AddShape(myShape);
                }
                if(SplashKit.KeyTyped(KeyCode.SpaceKey)==true)
                {
                    DrawShape.Background = SplashKit.RandomRGBColor(255);
                }
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    DrawShape.SelectShapesAt(SplashKit.MousePosition());
                }
                if(SplashKit.KeyTyped(KeyCode.DeleteKey)|| SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    foreach(Shape s in DrawShape.SelectedShapes)
                    {
                        DrawShape.RemoveShape(s);
                    }
                }

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }

}

