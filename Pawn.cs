﻿using System;

namespace chess
{
	public class Pawn: ChessPiece
	{
		private int pColor;
		private const int type = 0;
		private int[] location;
		public Pawn()
		{
			
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
		
		public int[] move(int[] board, int[]curLocation){
			
		}
		
		void setPColor(int c){
			pColor = c;
		}
		
		void setLocation(int[] L){
			location = L;
		}
	}
}
