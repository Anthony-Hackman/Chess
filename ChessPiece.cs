/*
 * Created by SharpDevelop.
 * User: Pharlex
 * Date: 7/10/2019
 * Time: 11:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace chess
{
	
	public interface ChessPiece
	{
		int getPColor();
		int[] getLocation();
		int getType(); //type of chess piece represented as an integer
		int[] move(int[] board, int[] curLocation);
		void setPColor(int c);
		void setLocation(int[] L);
	}
}
