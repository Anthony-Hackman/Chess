/*
 * Created by SharpDevelop.
 * User: Pharlex
 * Date: 7/10/2019
 * Time: 11:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

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
		public int[] move(int[] board, int[]curLocation){
			
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
		void setPColor(int c){
			pColor = c;
		}
		void setLocation(int[] L){
			location = L;
		}
	}
}
