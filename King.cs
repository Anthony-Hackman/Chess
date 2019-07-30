using System;

namespace chess
{
	public class King: ChessPiece
	{
		private int pColor;
		private const int type = 5;
		private int[] location;
		public King()
		{
			
		}

		public int getPColor()
		{
			return pColor;
		}

		public int[] getLocation()
		{
			return location;
		}

		public int getType()
		{
			return type;
		}

		public int[] move(int[] board, int[] curLocation)
		{
			
		}

		public void setPColor(int c)
		{
			pColor = c;
		}

		public void setLocation(int[] L)
		{
			location = L;
		}
	}
}
