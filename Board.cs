using System;

namespace chess
{
	public class Board
	{
		public Board(int colorSel)//player selected color
		{
			ChessPiece[] chessPieces = new ChessPiece[32];
			ChessPiece[,] chessBoard = new ChessPiece[8,8];
			int vertical = 0;//for setting up the board keeping track of which horizonal line it is on
			int pieceNum = 0;//for tracking which piece in pieces is being setup on the board
			if(colorSel==0){
				while(vertical<8){
					for(int i=0; i<8; i++){
						if(vertical==0){
							if(i==0||i==7){//rooks
								chessPieces[pieceNum] = new Rook(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==1||i==6){//knights
								chessPieces[pieceNum] = new Knight(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==2||i==5){//bishops
								chessPieces[pieceNum] = new Bishop(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==3){//queen
								chessPieces[pieceNum] = new Queen(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==4){//king
								chessPieces[pieceNum] = new King(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
						}
						else if(vertical==1){//pawns
							chessPieces[pieceNum] = new Pawn(pieceNum, 0);
							chessPieces[pieceNum].setLocation(vertical, i);
							chessBoard[vertical, i] = chessPieces[pieceNum];
							pieceNum++;
						}
						else if(vertical==6){//pawns
							chessPieces[pieceNum] = new Pawn(pieceNum, 1);
							chessPieces[pieceNum].setLocation(vertical, i);
							chessBoard[vertical, i] = chessPieces[pieceNum];
							pieceNum++;
						}
						else if(vertical==7){//rooks
							if(i==0||i==7){
								chessPieces[pieceNum] = new Rook(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==1||i==6){//knights
								chessPieces[pieceNum] = new Knight(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==2||i==5){//bishops
								chessPieces[pieceNum] = new Bishop(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==3){//queen
								chessPieces[pieceNum] = new Queen(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==4){//king
								chessPieces[pieceNum] = new King(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
						}
					}
					vertical++;
				}
			}
			else{
				while(vertical<8){
					for(int i=0; i<8; i++){
						if(vertical==0){
							if(i==0||i==7){//rooks
								chessPieces[pieceNum] = new Rook(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==1||i==6){//knights
								chessPieces[pieceNum] = new Knight(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==2||i==5){//bishops
								chessPieces[pieceNum] = new Bishop(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==3){//queen
								chessPieces[pieceNum] = new Queen(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==4){//king
								chessPieces[pieceNum] = new King(pieceNum, 1);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
						}
						else if(vertical==1){//pawns
							chessPieces[pieceNum] = new Pawn(pieceNum, 1);
							chessPieces[pieceNum].setLocation(vertical, i);
							chessBoard[vertical, i] = chessPieces[pieceNum];
							pieceNum++;
						}
						else if(vertical==6){//pawns
							chessPieces[pieceNum] = new Pawn(pieceNum, 0);
							chessPieces[pieceNum].setLocation(vertical, i);
							chessBoard[vertical, i] = chessPieces[pieceNum];
							pieceNum++;
						}
						else if(vertical==7){//rooks
							if(i==0||i==7){
								chessPieces[pieceNum] = new Rook(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==1||i==6){//knights
								chessPieces[pieceNum] = new Knight(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==2||i==5){//bishops
								chessPieces[pieceNum] = new Bishop(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==3){//queen
								chessPieces[pieceNum] = new Queen(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
							else if(i==4){//king
								chessPieces[pieceNum] = new King(pieceNum, 0);
								chessPieces[pieceNum].setLocation(vertical, i);
								chessBoard[vertical, i] = chessPieces[pieceNum];
								pieceNum++;
							}
						}
					}
					vertical++;
				}
			}
			
		}
		
		public void selectPiece(){//when a piece is clicked on the board call this function
			
		}
		
		
	}
}
