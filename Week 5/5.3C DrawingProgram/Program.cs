using System;
using System.IO;
using SplashKitSDK;

namespace DrawingProgram
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
            ShapeKind kindToAdd = ShapeKind.Circle;

            Drawing drawing = new Drawing();

            Window window = new Window("Shape Drawer", 800, 600);

            //event loop
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                //shape depending on key
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                //new shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {

                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle ShapeDrawn = new MyRectangle();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawing.AddShape(ShapeDrawn);
                    }
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle ShapeDrawn = new MyCircle();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawing.AddShape(ShapeDrawn);
                    }
                    if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine ShapeDrawn = new MyLine();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawing.AddShape(ShapeDrawn);
                    }
                }
                //delete
                List<Shape> select = new();
                select = drawing.SelectedShapes;
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape s in select)
                    {
                        drawing.RemoveShape(s);
                    }
                }

                //select
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                //background color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }
                drawing.Draw();
                SplashKit.RefreshScreen();

                //save
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.Save("TestDrawing.txt");
                }

                //load
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine($"Error loading file: {e.Message}");
                    }
                }
            } while (!window.CloseRequested);
        }
    }
}



