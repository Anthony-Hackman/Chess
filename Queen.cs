using System;

namespace chess
{
	public class Queen: ChessPiece
	{
		private int pColor;
		private const int type = 5;
		private int[] location;
		private int id;
		public Queen(int num, int c)
		{
			id = num;
			pColor = c;
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

		public int[] move(int[] board){
			return location;
		}

		public void setLocation(int L1, int L2)
		{
			int[] L = {L1, L2};
			location = L;
		}
		
		public int getID(){
			return id;
		}
	}
}
