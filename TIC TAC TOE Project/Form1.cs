using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIC_TAC_TOE_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int player = 2; // two players
        public int moves = 0;
        
        public int red_scores = 0;
        public int blue_scores = 0;
        public int draw = 0;

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "")
            {
                if (player == 2) // To have alternate moves between two players
                {

                    btn.Text = "X";
                    btn.Enabled = false;
                    btn.BackColor = Color.IndianRed;
                    moves = moves + 1;
                    player = player + 1; // For the statement to be false
                }
                else if (player == 3) 
                {
                    btn.Text = "O";
                    btn.Enabled = false;
                    btn.BackColor = Color.CadetBlue;
                    moves = moves + 1;
                    player = player - 1; // For the statement to be true since player is now equal to 2 again
                }
                if (CheckForWinner() == true)
                {
                    if (btn.Text == "X")
                    {
                        red_scores = red_scores + 1; // Adding scores in X
                        MessageBox.Show("RED WINS", "We have a Winner!", MessageBoxButtons.OK);
                        MessageBox.Show("Red: " + red_scores + "Blue: " + blue_scores + "Draw: " + draw, "Current Score");
                        NewGame();
                    }
                    else if (btn.Text == "O") 
                    {
                        blue_scores = blue_scores + 1; // Adding scores in O
                        MessageBox.Show("BLUE WINS", "We have a Winner!", MessageBoxButtons.OK);
                        MessageBox.Show("Red: " + red_scores + "- Blue: " + blue_scores + " Draw: " + draw, "Current Score");
                        NewGame();
                    }

                }
                if (CheckForDraw() == true)
                {
                    draw = draw + 1; // Adding scores in Draw
                    MessageBox.Show("DRAW", "It is a Draw!", MessageBoxButtons.OK);
                    MessageBox.Show("Red: " + red_scores + "- Blue: " + blue_scores + " Draw: " + draw, "Current Score");
                    NewGame();

                }
            }
        }


        private void btnHowToPlay_Click(object sender, EventArgs e) //How To Play
        {
            DialogResult dialogResult = MessageBox.Show("Tic Tac Toe has the objective to be the first player to get three in a row", "Tutorial", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show("It has two symbols, X and O. Alternating moves, each player pick an empty space out of 9 spaces. The first player to get three in a row Horizontally, Diagonally, and Vertically wins. " +
                    "If there after 9 moves and there is no winner, it is considered as a Draw.", "Tutorial");
            }
            else
            {
                // It closes the Message Box
            }
        }

        void NewGame() // New Game Button
        {
            player = 2;
            moves = 0;

            // Returning from red or blue color to the original color

            btn1.BackColor = Color.WhiteSmoke;
            btn2.BackColor = Color.WhiteSmoke;
            btn3.BackColor = Color.WhiteSmoke;
            btn4.BackColor = Color.WhiteSmoke;
            btn5.BackColor = Color.WhiteSmoke;
            btn6.BackColor = Color.WhiteSmoke;
            btn7.BackColor = Color.WhiteSmoke;
            btn8.BackColor = Color.WhiteSmoke;
            btn9.BackColor = Color.WhiteSmoke;

            // Returning from X or O to the blank button

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            // Scoresheet

            lblRedWins.Text = "" + red_scores;
            lblBlueWins.Text = "" + blue_scores;
            lblDraw.Text = "" + draw;

            // Enabling buttons again for another round

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
        }
        private void btnExit_Click(object sender, EventArgs e) // Exit
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) // Setting the scoreboard
        {
            lblRedWins.Text = "" + red_scores;
            lblBlueWins.Text = "" + blue_scores;
            lblDraw.Text = "" + draw;
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            red_scores = 0;
            blue_scores = 0;
            draw = 0;
             
            NewGame();
        }

        bool CheckForWinner() // Scoring; Checking if Red wins or Blue Wins
        {
            if ((btn1.Text == btn4.Text && btn4.Text == btn7.Text && btn7.Text != "") || (btn2.Text == btn5.Text && btn5.Text == btn8.Text && btn8.Text != "") || (btn3.Text == btn6.Text && btn6.Text == btn9.Text && btn9.Text != ""))
                return true; // Horizontal
            else if ((btn1.Text == btn2.Text && btn2.Text == btn3.Text && btn2.Text != "") || (btn4.Text == btn5.Text && btn5.Text == btn6.Text && btn6.Text != "") || (btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && btn9.Text != "")
                return true; // Vertical

            else if ((btn1.Text == btn5.Text && btn5.Text == btn9.Text && btn9.Text != "") || (btn3.Text == btn5.Text && btn5.Text == btn7.Text && btn7.Text != "") || (btn7.Text == btn5.Text && btn5.Text == btn3.Text && btn3.Text != "") || (btn9.Text == btn5.Text && btn5.Text == btn1.Text && btn1.Text != ""))
                return true; // Diagonal
            else
                return false; // If not horizontal, vertical, or diagonal 
        }
        bool CheckForDraw() // If there is no winner after 9 moves
        {
            if ((CheckForWinner() == false) && ((moves == 9) == true)) // Since we need to return a value
                return true;
            else
                return false;
        }
        private void lblRedWins_Click(object sender, EventArgs e)
        {

        }
    }
}