using System;
using System.Windows.Media;

using System.Text;
using System.Windows;


namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgPathSegCurvetoCubicSmoothAbs.
	/// </summary>
	public class SvgPathSegCurvetoCubicSmoothRel : SvgPathSegCurvetoCubic, ISvgPathSegCurvetoCubicSmoothRel
	{
		internal SvgPathSegCurvetoCubicSmoothRel(double x, double y, double x2, double y2) : base(SvgPathSegType.CurveToCubicSmoothRel)
		{
			this.x = x;
			this.y = y;
			this.x2 = x2;
			this.y2 = y2;
		}

		private double x;
		public double X
		{
			get{return x;}
		}		  

		private double y;		
		public double Y
		{
			get{return y;}
		}		  

		private double x2;
		public double X2		
		{
			get{return x2;}
		}		  

		private double y2;		
		public double Y2
		{
			get{return y2;}
		}		  

		public override Point AbsXY
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				Point prevPoint;
				if(prevSeg == null) prevPoint = new Point(0,0);
				else prevPoint = prevSeg.AbsXY;
				return new Point(prevPoint.X + X, prevPoint.Y + Y);
			}
		}

		public override Point CubicX1Y1
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				if(prevSeg == null || !(prevSeg is SvgPathSegCurvetoCubic))
				{
					return prevSeg.AbsXY;
				}
				else
				{
					Point prevXY = prevSeg.AbsXY;
					Point prevX2Y2 = ((SvgPathSegCurvetoCubic)prevSeg).CubicX2Y2;

					return new Point(2 * prevXY.X - prevX2Y2.X, 2 * prevXY.Y - prevX2Y2.Y);
				}
			}
		}

		public override Point CubicX2Y2
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				Point prevPoint;
				if(prevSeg == null) prevPoint = new Point(0,0);
				else prevPoint = prevSeg.AbsXY;
				return new Point(prevPoint.X + X2, prevPoint.Y + Y2);
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(X2);
				sb.Append(",");
				sb.Append(Y2);
				sb.Append(",");
				sb.Append(X);
				sb.Append(",");
				sb.Append(Y);

				return sb.ToString();
			}
		}
	}
}