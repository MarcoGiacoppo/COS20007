using System;
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

            float startX = 0;
            float startY = 0;
            float endX = 0;
            float endY = 0;

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
                        if (startX == 0 && startY == 0)
                        {
                            startX = SplashKit.MouseX();
                            startY = SplashKit.MouseY();
                        }
                        else if (endX == 0 && endY == 0)
                        {
                            endX = SplashKit.MouseX();
                            endY = SplashKit.MouseY();

                            MyLine myLine = new MyLine();
                            myLine.X = startX;
                            myLine.Y = startY;
                            myLine.Xx = endX;
                            myLine.Yy = endY;
                            drawing.AddShape(myLine);

                            startX = 0;
                            startY = 0;
                            endX = 0;
                            endY = 0;
                        }
                    }
                }
                //delete
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    drawing.RemoveShape();
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
            } while (!window.CloseRequested);
        }
    }
}


            
