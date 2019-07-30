using System;

namespace chess
{
	public class Rook: ChessPiece
	{
		private int pColor;
		private const int type = 3;
		private int[] location;
		public Rook()
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
