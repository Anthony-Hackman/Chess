/*
 * User: Kyle Fadley
 * Date: 7/10/2019
 * Time: 10:56 PM
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace chess
{
	public partial class MainForm : Form
	{
		Button[,] boardButtons = new Button[8,8];
		private Board game;
		private int turn = 0;//turn starts with white
		private int colorSel;
		public MainForm()
		{
			InitializeComponent();
			this.Height=500;
			this.Width=500;
			colorSel = 0;
			initializeGame();
		}
		
		private void initializeGame(){//call to set up the gameboard
			game = new Board(colorSel);
			ChessPiece[,] gameBoard = game.getBoard();
			for(int i=0; i<8; i++){//maps the gameboard to buttons for the ui
				for(int j=0; j<8; j++){
					boardButtons[i,j] = new Button();
					boardButtons[i,j].Location = new Point(i*50,j*50);
					boardButtons[i,j].Size = new Size(50,50);
					boardButtons[i,j].Enabled = false;
					if(gameBoard[i,j]!=null){
						if(gameBoard[i,j].getPColor()==0){
							if(gameBoard[i,j].getType()==1){
								boardButtons[i,j].Text = "Pa";
								boardButtons[i,j].ForeColor = Color.White;
								boardButtons[i,j].Enabled = true;
							}
							if(gameBoard[i,j].getType()==2){
								boardButtons[i,j].Text = "Kn";
								boardButtons[i,j].ForeColor = Color.White;
								boardButtons[i,j].Enabled = true;
							}
							if(gameBoard[i,j].getType()==3){
								boardButtons[i,j].Text = "Bi";
								boardButtons[i,j].ForeColor = Color.White;
								boardButtons[i,j].Enabled = true;
							}
							if(gameBoard[i,j].getType()==4){
								boardButtons[i,j].Text = "Ro";
								boardButtons[i,j].ForeColor = Color.White;
								boardButtons[i,j].Enabled = true;
							}
							if(gameBoard[i,j].getType()==5){
								boardButtons[i,j].Text = "Qu";
								boardButtons[i,j].ForeColor = Color.White;
								boardButtons[i,j].Enabled = true;
							}
							if(gameBoard[i,j].getType()==6){
								boardButtons[i,j].Text = "Ki";
								boardButtons[i,j].ForeColor = Color.White;
								boardButtons[i,j].Enabled = true;
							}
						}
						else{
							if(gameBoard[i,j].getType()==1){
								boardButtons[i,j].Text = "Pa";
							}
							if(gameBoard[i,j].getType()==2){
								boardButtons[i,j].Text = "Kn";
							}
							if(gameBoard[i,j].getType()==3){
								boardButtons[i,j].Text = "Bi";
							}
							if(gameBoard[i,j].getType()==4){
								boardButtons[i,j].Text = "Ro";
							}
							if(gameBoard[i,j].getType()==5){
								boardButtons[i,j].Text = "Qu";
							}
							if(gameBoard[i,j].getType()==6){
								boardButtons[i,j].Text = "Ki";
							}
						}
					}
					if((i+j)%2==0){
						boardButtons[i,j].BackColor = Color.Gray;
					}
					else{
						boardButtons[i,j].BackColor = Color.DarkGray;
					}
					boardButtons[i,j].Click += button_Click;
					Controls.Add(boardButtons[i,j]);
				}
			}
		}
		
		
		//event handlers for the chess game
		private void button_Click(object sender, 
		System.EventArgs e){//handles when a button is clicked on the board
			int i=-1;
			int j=-1;
			Button button = (Button)sender;
			while(i<7){
				i++;
				j=0;
				while(j<8){
					if(button.Location==boardButtons[i,j].Location){
						break;
					}
					j++;
				}
				if(j==8){//to save from out of bounds issues
					j=7;
				}
				if(button.Location==boardButtons[i,j].Location){
					break;
				}
			}
			int[][] moves = game.getBoard()[i,j].move(game.getBoard(), colorSel);
		}
		
	}
}
