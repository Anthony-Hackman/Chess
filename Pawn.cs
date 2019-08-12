using System;

namespace chess
{
	public class Pawn: ChessPiece
	{
		private int pColor;
		private const int type = 1;
		private int[] location;
		private int id;
		public Pawn(int num, int c)
		{
			id = num;
			pColor = c;
		}
		
		public int getPColor(){
			return pColor;
		}
		
		public int[] getLocation(){
			return location;
		}
		
		public int getType(){
			return type;
		}
		
		public int[][] move(ChessPiece[,] board, int colorSel){
			int[][] locations = new int[64][];
			return locations;
		}
		
		public void setLocation(int L1, int L2){
			int[] L = {L1, L2};
			location = L;
		}
		
		public int getID(){
			return id;
		}
	}
}
