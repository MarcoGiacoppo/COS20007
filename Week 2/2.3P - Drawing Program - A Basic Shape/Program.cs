using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Shape myShape = new Shape();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = (float)SplashKit.MousePosition().X;
                    myShape.Y = (float)SplashKit.MousePosition().Y;
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    if (myShape.IsAt(SplashKit.MousePosition()))
                    {
                        myShape.Color = Color.RandomRGB(255);
                    }
                }

                myShape.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
       
    }
}
