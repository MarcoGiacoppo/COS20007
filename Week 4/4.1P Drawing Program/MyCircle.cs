using System;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyCircle : Shape
	{
		//local var
		private int _radius;

		//constructor
		public MyCircle(Color clr, int radius) : base(clr)
		{
			_radius = radius;
		}

		public MyCircle() : this(Color.Blue, 50) { }

        //methods
        public override void Draw()
        {
			if (Selected)
			{
				DrawOutLine();
			}
			SplashKit.FillCircle(COLOR, X, Y, _radius);
        }

        public override void DrawOutLine()
        {
			SplashKit.FillCircle(Color.Black, X, Y, _radius + 4);
        }

		public override bool IsAt(Point2D pt)
		{
			double a = (double)(pt.X - X);
			double b = (double)(pt.Y - Y);
			if (Math.Sqrt(a * a + b * b) < _radius)
			{
				return true;
			}
			return false;
		}
    }
}

