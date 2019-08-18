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
		
		public int[][] moves(ChessPiece[,] board, int colorSel){
			int[][] locations = new int[3][];
			int i = 0;
			if(pColor==0&&colorSel==0){//piece started on the bottom of the screen board
				if(board[location[0], location[1]-1]==null){
					int[] newLoc = {location[0] , location[1]-1};
					locations[i] = newLoc;
					i++;
				}
				if(location[0]!=7){
					if(board[location[0]+1, location[1]-1]!=null){
						if(board[location[0]+1, location[1]-1].getPColor()!=pColor){
							int[] newLoc = {location[0]+1 , location[1]-1};
							locations[i] = newLoc;
							i++;
						}
					}
				}
				if(location[0]!=0){
					if(board[location[0]-1, location[1]-1]!=null){
						if(board[location[0]-1, location[1]-1].getPColor()!=pColor){
							int[] newLoc = {location[0]-1 , location[1]-1};
							locations[i] = newLoc;
							i++;
						}
					}
				}
			}
			else{//piece started on the top of the screen board
				if(board[location[0], location[1]+1]==null){//checks for pieces in front of it
					int[] newLoc = {location[0] , location[1]+1};
					locations[i] = newLoc;
					i++;
				}
				if(location[0]!=7){//make sure the pawn isnt along the edge to avoid out of bounds
					if(board[location[0]+1, location[1]+1]!=null){//checks for pieces to its diagonal to attack
						if(board[location[0]+1, location[1]+1].getPColor()!=pColor){//makes sure the piece is an enemy
							int[] newLoc = {location[0]+1 , location[1]+1};
							locations[i] = newLoc;
							i++;
						}
					}
				}
				if(location[0]!=0){//make sure the pawn isnt along the edge to avoid out of bounds
					if(board[location[0]-1, location[1]+1]!=null){//checks for pieces to its diagonal to attack
						if(board[location[0]-1, location[1]+1].getPColor()!=pColor){//makes sure the piece is an enemy
							int[] newLoc = {location[0]-1 , location[1]+1};
							locations[i] = newLoc;
							i++;
						}
					}
				}
			}
			return locations;
		}
		
		public void setLocation(int L1, int L2){
			int[] L = {L1, L2};
			location = L;
		}
		
		public int getID(){
			return id;
		}
		
		public void changePieceType(int pType, ChessPiece[] pieces){
			if(pType==2){
				pieces[id] = new Knight(id, pColor);
			}
			if(pType==3){
				pieces[id] = new Bishop(id, pColor);
			}
			if(pType==4){
				pieces[id] = new Rook(id, pColor);
			}
			if(pType==5){
				pieces[id] = new Queen(id, pColor);
			}
		}
	}
}
