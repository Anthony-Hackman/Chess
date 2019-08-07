using System;

namespace chess
{
	
	public interface ChessPiece
	{
		//piece type pawn = 1, knight = 2, bishop = 3, rook = 4, queen = 5, king = 6
		int getPColor();//0 for white 1 for black
		int[] getLocation();
		int getType(); //type of chess piece represented as an integer
		int[] move(int[] board);
		void setLocation(int L1, int L2);
		int getID();
	}
}
