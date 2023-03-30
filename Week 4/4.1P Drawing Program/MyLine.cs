using System;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyLine : Shape
	{
		private float _x2;
		private float _y2;

		public float Xx
		{
			get
			{
				return _x2;
			}
			set
			{
				_x2 = value;
			}
		}
		public float Yy
		{
			get
			{
				return _y2;
			}
			set
			{
				_y2 = value;
			}
		}

		public MyLine(Color clr, float x2, float y2) : base(clr)
		{
			_x2 = x2;
			_y2 = y2;
		}

        public MyLine()
        {
        }

        public override void Draw()
		{
			if (Selected)
			{
				DrawOutLine();
			}
			SplashKit.DrawLine(COLOR, X, Y, Xx, Yy);
		}

        public override void DrawOutLine()
        {
			int radius = 2;
			SplashKit.FillCircle(Color.Black, X, Y, radius);
            SplashKit.FillCircle(Color.Black, Xx, Yy, radius);
        }

        public override bool IsAt(Point2D pt)
        {
			return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, Xx, Yy), 5);
        }
    }
}

