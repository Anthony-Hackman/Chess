using System;

namespace chess
{
	public class King: ChessPiece
	{
		private int pColor;
		private const int type = 6;
		private int[] location;
		private int id;
		private int firstMove = -1;//set to -1 because it gets updated by set location which is called once at the start of the game for every piece
		//firstMove is used for special case of castling move
		public King(int num, int c)
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

		public int[][] moves(ChessPiece[,] board, int colorSel){
			int[][] locations = new int[8][];
			int j = 0;
			//location[1] is up and down
			if(location[0]+1<=7){//edge check
				if(board[location[0]+1,location[1]]==null){
					int[] newLoc = {location[0]+1,location[1]};
					if(!isCheck(newLoc, board)){//can't move into check and can't move passed check when castling
						locations[j] = newLoc;
						j++;
						if(firstMove==0&&((Rook)board[7,location[1]]).isfirstMove()==0){//check if the king and rook have not been moved
							if(board[location[0]+2,location[1]]==null&&board[7,location[1]]!=null){//check for possible castling move
								int[] loc = {location[0]+2,location[1]};
								if(board[7,location[1]].getType()==4){//check if the piece is a rook, color doesn't matter since firstMove takes care of if it is an enemy piece
								   if(!isCheck(loc, board)&&!isCheck(location, board)){//check if the location will be check and if the king is already in check
										locations[j] = loc;
										j++;
									}
								}
							}
						}
					}
				}
				else if(board[location[0]+1,location[1]].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
					int[] newLoc = {location[0]+1,location[1]};
					if(!isCheck(newLoc, board)){//can't move into check
						locations[j] = newLoc;
						j++;
					}
				}
			}
			if(location[0]-1>=0){//edge check
				if(board[location[0]-1,location[1]]==null){
					int[] newLoc = {location[0]-1,location[1]};
					if(!isCheck(newLoc, board)){//can't move into check and can't move passed check when castling
						locations[j] = newLoc;
						j++;
						if(firstMove==0&&((Rook)board[0,location[1]]).isfirstMove()==0){//check if the king and rook have not been moved
							if(board[location[0]-2,location[1]]==null&&board[0,location[1]]!=null){//check for possible castling move
								int[] loc = {location[0]-2,location[1]};
								if(board[0,location[1]].getType()==4){//check if the piece is a rook, color doesn't matter since firstMove takes care of if it is an enemy piece
								   if(!isCheck(loc, board)&&!isCheck(location, board)){//check if the location will be check and if the king is already in check
										locations[j] = loc;
										j++;
									}
								}
							}
						}
					}
				}
				else if(board[location[0]-1,location[1]].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
					int[] newLoc = {location[0]-1,location[1]};
					if(!isCheck(newLoc, board)){//can't move into check
						locations[j] = newLoc;
						j++;
					}
				}
			}
			if(location[1]+1<=7){//edge check
				if(board[location[0],location[1]+1]==null){
					int[] newLoc = {location[0],location[1]+1};
					if(!isCheck(newLoc, board)){//can't move into check
						locations[j] = newLoc;
						j++;
					}
				}
				else if(board[location[0],location[1]+1].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
					int[] newLoc = {location[0],location[1]+1};
					if(!isCheck(newLoc, board)){//can't move into check
						locations[j] = newLoc;
						j++;
					}
				}
				
				if(location[0]-1>=0){
					if(board[location[0]-1,location[1]+1]==null){
						int[] newLoc = {location[0]-1,location[1]+1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
					else if(board[location[0]-1,location[1]+1].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
						int[] newLoc = {location[0]-1,location[1]+1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
				}
				
				if(location[0]+1<=7){
					if(board[location[0]+1,location[1]+1]==null){
						int[] newLoc = {location[0]+1,location[1]+1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
					else if(board[location[0]+1,location[1]+1].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
						int[] newLoc = {location[0]+1,location[1]+1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
				}
			}
			if(location[1]-1>=0){//edge check
				if(board[location[0],location[1]-1]==null){
					int[] newLoc = {location[0],location[1]-1};
					if(!isCheck(newLoc, board)){//can't move into check
						locations[j] = newLoc;
						j++;
					}
				}
				else if(board[location[0],location[1]-1].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
					int[] newLoc = {location[0],location[1]-1};
					if(!isCheck(newLoc, board)){//can't move into check
						locations[j] = newLoc;
						j++;
					}
				}
				
				if(location[0]-1>=0){
					if(board[location[0]-1,location[1]-1]==null){
						int[] newLoc = {location[0]-1,location[1]-1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
					else if(board[location[0]-1,location[1]-1].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
						int[] newLoc = {location[0]-1,location[1]-1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
				}
				
				if(location[0]+1<=7){
					if(board[location[0]+1,location[1]-1]==null){
						int[] newLoc = {location[0]+1,location[1]-1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
					else if(board[location[0]+1,location[1]-1].getPColor()!=pColor){//enemy piece still valid as long as its not guarded by another piece
						int[] newLoc = {location[0]+1,location[1]-1};
						if(!isCheck(newLoc, board)){//can't move into check
							locations[j] = newLoc;
							j++;
						}
					}
				}
			}
			return locations;
		}

		public void setLocation(int L1, int L2)
		{
			int[] L = {L1, L2};
			firstMove++;
			location = L;
		}
		
		public int getID(){
			return id;
		}
		
		public bool isCheck(int[] loc, ChessPiece[,] board){//check if a move is going to be check or it if the king is in check
			return false;
		}
		
		public bool isCheckmate(){//call after every turn 
			return false;
		}
	}
}
