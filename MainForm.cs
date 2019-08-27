﻿/*
 * User: Kyle Fadley
 * Date: 7/10/2019
 * Time: 10:56 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace chess
{
	public partial class MainForm : Form
	{
		Button[,] boardButtons = new Button[8,8];
		private Board game;
		private int turn = 0;//turn starts with white
		private int colorSel;
		private int pawnSel=0;
		private ChessPiece selectedPiece = null;//the most recently clicked piece
		private int[][] moves = null;//a list of the moves that the most recently clicked piece can make
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
					boardButtons[i,j].Paint +=button_Paint;
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
		
		private void changeTurn(){//handles all the turn change necessities
			
			/*call moves of pieces whose turn it is and null out any moves that are of a piece that is the same color
			check for moves that are not null if there are any enable the button for that piece otherwise don't
			find a way to only enable moves that get you out of check when you are in check*/
			
			turn++;
			turn = turn%2;
			for(int i=0; i<8; i++){
				for(int j=0; j<8; j++){
					boardButtons[i,j].Enabled = false;//disable all buttons to reset for next person's turn
					if(game.getBoard()[i,j]!=null){//can't call a function on a null object
						if(game.getBoard()[i,j].getPColor()==turn){//enable any buttons that have a current turn
							boardButtons[i,j].Enabled = true;
						}
					}
				}
			}
		}
		
		private int pieceSelect(){//piece selection menu for the pawn reaching end of board
			var popupForm = new Form();
			popupForm.ControlBox = false;
			Label label = new Label();
			label.Text = "Select a Piece";
			label.Location = new Point(20, 0);
			RadioButton kn = new RadioButton();
			kn.Text = "Knight";
			kn.CheckedChanged += radioButton_checkedChanged;
			kn.Location = new Point(10, 20);
			
			RadioButton bi = new RadioButton();
			bi.Text = "Bishop";
			bi.CheckedChanged += radioButton_checkedChanged;
			bi.Location = new Point(10, 40);
			
			RadioButton ro = new RadioButton();
			ro.Text = "Rook";
			ro.CheckedChanged += radioButton_checkedChanged;
			ro.Location = new Point(10, 60);
			
			RadioButton qu = new RadioButton();
			qu.Text = "Queen";
			qu.CheckedChanged += radioButton_checkedChanged;
			qu.Location = new Point(10, 80);
			
			popupForm.Controls.Add(label);
			popupForm.Controls.Add(kn);
			popupForm.Controls.Add(bi);
			popupForm.Controls.Add(ro);
			popupForm.Controls.Add(qu);
			popupForm.ShowDialog();
			int selection = pawnSel;
			pawnSel = 0;
			return selection;
		}
		
		
		//event handlers for the chess game
		
		private void radioButton_checkedChanged(object sender, System.EventArgs e)
		{
			if(((RadioButton)sender).Text=="Knight"){
				pawnSel = 2;
				((Form)((RadioButton)sender).GetContainerControl()).Close();
			}
			if(((RadioButton)sender).Text=="Bishop"){
				pawnSel = 3;
				((Form)((RadioButton)sender).GetContainerControl()).Close();
			}
			if(((RadioButton)sender).Text=="Rook"){
				pawnSel = 4;
				((Form)((RadioButton)sender).GetContainerControl()).Close();
			}
			if(((RadioButton)sender).Text=="Queen"){
				pawnSel = 5;
				((Form)((RadioButton)sender).GetContainerControl()).Close();
			}
		}
		
		private void button_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Button btn = (Button)sender;
			string buttonText = "";
			dynamic drawBrush = new SolidBrush(btn.ForeColor);
			dynamic sf = new StringFormat {
				Alignment = StringAlignment.Center,
    			LineAlignment = StringAlignment.Center };
			buttonText = btn.Text;
			e.Graphics.DrawString(buttonText, btn.Font, drawBrush, e.ClipRectangle, sf);
			drawBrush.Dispose();
			sf.Dispose();

		}
		
		private void button_Click(object sender, 
		System.EventArgs e){//handles when a button is clicked on the board
			int i=-1;
			int j=-1;
			int z=0;
			
			//handles finding the current button location numbers
			Button button = (Button)sender;
			while(i<7){//finding which button sent to know which piece it corresponds to on the board
				i++;
				j=0;
				while(j<8){
					if(button.GetHashCode()==boardButtons[i,j].GetHashCode()){//breaks out of the loop once the button is found
						break;
					}
					j++;
				}
				if(j==8){//to save from out of bounds issues while searching
					j=7;
				}
				if(button.GetHashCode()==boardButtons[i,j].GetHashCode()){//breaks out of the loop once the button is found
					break;
				}
			}
			
			
			//handles the movement of pieces on the board
			if(game.getBoard()[i,j]!=null){//a piece is selected on the board and not a blank space
				ChessPiece curPiece = game.getBoard()[i,j];//current piece
				z=0;
				if(moves==null||selectedPiece==null){//handles a weird case where selectedPiece somehow ends up null 
					//and moves isn't null and handles first piece clicked for the persons turn
					moves = null;//sets to null in weird case that moves isn't null and selectedPiece is null
					moves = curPiece.moves(game.getBoard(), colorSel);
					while(z<moves.Length&&moves[z]!=null){//once the possible moves are found set those locations to be clickable
						if(game.getBoard()[moves[z][0], moves[z][1]]==null){
							boardButtons[moves[z][0], moves[z][1]].Enabled = true;
							selectedPiece = curPiece;
							z++;
						}
						else if(game.getBoard()[moves[z][0], moves[z][1]].getPColor()!=curPiece.getPColor()){
							boardButtons[moves[z][0], moves[z][1]].Enabled = true;
							selectedPiece = curPiece;
							z++;
						}
						else{//null out any moves that are of the same color of the piece being moved, those are in the moves list for the isCheck function
							moves[z]=null;
							z++;
						}
					}
				}
				else if(selectedPiece.getPColor()==curPiece.getPColor()){//handles if the next click is another one of the same persons turn
					while(z<moves.Length){//set old moves list to unclickable
						if(moves[z]!=null){
							boardButtons[moves[z][0], moves[z][1]].Enabled = false;
						}
						z++;
					}
					moves = null;
					z=0;
					moves = curPiece.moves(game.getBoard(), colorSel);
					while(z<moves.Length&&moves[z]!=null){//once the possible moves are found set those locations to be clickable
						if(game.getBoard()[moves[z][0], moves[z][1]]==null){
							boardButtons[moves[z][0], moves[z][1]].Enabled = true;
							selectedPiece = curPiece;
							z++;
						}
						else if(game.getBoard()[moves[z][0], moves[z][1]].getPColor()!=curPiece.getPColor()){//only allow movement to locations that aren't your own pieces
							boardButtons[moves[z][0], moves[z][1]].Enabled = true;
							selectedPiece = curPiece;
							z++;
						}
						else{//null out any moves that are of the same color of the piece being moved, those are in the moves list for the isCheck function
							moves[z] = null;
							z++;
						}
					}
				}
				else{//enemy piece was selected after you selected a piece to move
					z=0;
					while(z<moves.Length){//set old moves list to unclickable since your piece is moving
						if(moves[z]!=null){
							boardButtons[moves[z][0], moves[z][1]].Enabled = false;
						}
						z++;
					}
					//set new location of selected piece to correct display
					if(selectedPiece.getType()==1){
						boardButtons[i,j].Text = "Pa";
						if(selectedPiece.getPColor()==0){
							boardButtons[i,j].ForeColor = Color.White;
						}
						else{
							boardButtons[i,j].ForeColor = Color.Black;
						}
						boardButtons[i,j].Enabled = true;
						if(j==0||j==7){//set to new piece type since you reached the end of the board with a pawn
							int k = selectedPiece.getID();
							int m = selectedPiece.getLocation()[0];
							int n = selectedPiece.getLocation()[1];
							int selection = pieceSelect();//select new piece
							((Pawn) selectedPiece).changePieceType(selection, game.getPieces());
							game.getBoard()[m, n]=game.getPieces()[k];
							selectedPiece = game.getPieces()[k];
							selectedPiece.setLocation(m,n);
						}
					}
					if(selectedPiece.getType()==2){
						boardButtons[i,j].Text = "Kn";
						if(selectedPiece.getPColor()==0){
							boardButtons[i,j].ForeColor = Color.White;
						}
						else{
							boardButtons[i,j].ForeColor = Color.Black;
						}
						boardButtons[i,j].Enabled = true;
					}
					if(selectedPiece.getType()==3){
						boardButtons[i,j].Text = "Bi";
						if(selectedPiece.getPColor()==0){
							boardButtons[i,j].ForeColor = Color.White;
						}
						else{
							boardButtons[i,j].ForeColor = Color.Black;
						}
						boardButtons[i,j].Enabled = true;
					}
					if(selectedPiece.getType()==4){
						boardButtons[i,j].Text = "Ro";
						if(selectedPiece.getPColor()==0){
							boardButtons[i,j].ForeColor = Color.White;
						}
						else{
							boardButtons[i,j].ForeColor = Color.Black;
						}
						boardButtons[i,j].Enabled = true;
					}
					if(selectedPiece.getType()==5){
						boardButtons[i,j].Text = "Qu";
						if(selectedPiece.getPColor()==0){
							boardButtons[i,j].ForeColor = Color.White;
						}
						else{
							boardButtons[i,j].ForeColor = Color.Black;
						}
						boardButtons[i,j].Enabled = true;
					}
					if(selectedPiece.getType()==6){
						boardButtons[i,j].Text = "Ki";
						if(selectedPiece.getPColor()==0){
							boardButtons[i,j].ForeColor = Color.White;
						}
						else{
							boardButtons[i,j].ForeColor = Color.Black;
						}
						boardButtons[i,j].Enabled = true;
					}
				
					//set all necessary things to unclickable and null and the piece to its new location
					boardButtons[selectedPiece.getLocation()[0], selectedPiece.getLocation()[1]].Enabled = false;
					boardButtons[selectedPiece.getLocation()[0], selectedPiece.getLocation()[1]].Text = "";
					moves = null;
					game.getBoard()[i,j] = selectedPiece;
					game.getBoard()[selectedPiece.getLocation()[0], selectedPiece.getLocation()[1]] = null;
					selectedPiece.setLocation(i,j);
					selectedPiece = null;
					changeTurn();
				}
			}
			else{//a blank space is selected on the board 'only occurs if there is a piece currently selected for movement'
				z=0;
				while(z<moves.Length&&moves[z]!=null){//set old moves list to unclickable since your piece is moving
					boardButtons[moves[z][0], moves[z][1]].Enabled = false;
					z++;
				}
				
				//set new location of selected piece to correct display mostly for color of piece and handles some special case moves
				if(selectedPiece.getType()==1){
					boardButtons[i,j].Text = "Pa";
					if(selectedPiece.getPColor()==0){
						boardButtons[i,j].ForeColor = Color.White;
					}
					else{
						boardButtons[i,j].ForeColor = Color.Black;
					}
					boardButtons[i,j].Enabled = true;
					if(j==0||j==7){//set to new piece type since you reached the end of the board with a pawn
						int k = selectedPiece.getID();
						int m = selectedPiece.getLocation()[0];
						int n = selectedPiece.getLocation()[1];
						int selection = pieceSelect();
						((Pawn) selectedPiece).changePieceType(selection, game.getPieces());
						game.getBoard()[m, n]=game.getPieces()[k];
						selectedPiece = game.getPieces()[k];
						selectedPiece.setLocation(m,n);
					}
				}
				if(selectedPiece.getType()==2){
					boardButtons[i,j].Text = "Kn";
					if(selectedPiece.getPColor()==0){
						boardButtons[i,j].ForeColor = Color.White;
					}
					else{
						boardButtons[i,j].ForeColor = Color.Black;
					}
					boardButtons[i,j].Enabled = true;
				}
				if(selectedPiece.getType()==3){
					boardButtons[i,j].Text = "Bi";
					if(selectedPiece.getPColor()==0){
						boardButtons[i,j].ForeColor = Color.White;
					}
					else{
						boardButtons[i,j].ForeColor = Color.Black;
					}
					boardButtons[i,j].Enabled = true;
				}
				if(selectedPiece.getType()==4){
					boardButtons[i,j].Text = "Ro";
					if(selectedPiece.getPColor()==0){
						boardButtons[i,j].ForeColor = Color.White;
					}
					else{
						boardButtons[i,j].ForeColor = Color.Black;
					}
					boardButtons[i,j].Enabled = true;
				}
				if(selectedPiece.getType()==5){
					boardButtons[i,j].Text = "Qu";
					if(selectedPiece.getPColor()==0){
						boardButtons[i,j].ForeColor = Color.White;
					}
					else{
						boardButtons[i,j].ForeColor = Color.Black;
					}
					boardButtons[i,j].Enabled = true;
				}
				if(selectedPiece.getType()==6){
					boardButtons[i,j].Text = "Ki";
					if(i-selectedPiece.getLocation()[0]>1){//castle move
						//sets the new location for the rook
						boardButtons[i-1,j].Text = "Ro";
						boardButtons[i-1,j].Enabled = true;
						game.getBoard()[7,j].setLocation(i-1,j);
						game.getBoard()[i-1,j] = game.getBoard()[7,j];
						game.getBoard()[7,j] = null;
						boardButtons[7,j].Text = "";
						boardButtons[7,j].Enabled = false;
					}
					if(selectedPiece.getLocation()[0]-i>1){//castle move
						//sets the new location for the rook
						boardButtons[i+1,j].Text = "Ro";
						boardButtons[i+1,j].Enabled = true;
						game.getBoard()[0,j].setLocation(i+1,j);
						game.getBoard()[i+1,j] = game.getBoard()[0,j];
						game.getBoard()[0,j] = null;
						boardButtons[0,j].Text = "";
						boardButtons[0,j].Enabled = false;
					}
					if(selectedPiece.getPColor()==0){
						boardButtons[i,j].ForeColor = Color.White;
					}
					else{
						boardButtons[i,j].ForeColor = Color.Black;
					}
					boardButtons[i,j].Enabled = true;
				}
				
				//set all necessary things to unclickable and null and the piece to its new location
				boardButtons[selectedPiece.getLocation()[0], selectedPiece.getLocation()[1]].Enabled = false;
				boardButtons[selectedPiece.getLocation()[0], selectedPiece.getLocation()[1]].Text = "";
				moves = null;
				game.getBoard()[i,j] = selectedPiece;
				game.getBoard()[selectedPiece.getLocation()[0], selectedPiece.getLocation()[1]] = null;
				selectedPiece.setLocation(i,j);
				selectedPiece = null;
				changeTurn();
				
			}
		}
		
	}
}
