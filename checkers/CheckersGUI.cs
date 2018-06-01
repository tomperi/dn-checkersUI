using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace checkers
{
    public class CheckersGUI
    {
        public void GetGameSettings()
        {
            // Create a form with the following options - 
            // Board size - 6x6, 8x8, 10x10 (Radio button)
            // Player 1 name
            // Player 2 checkbox (for computer) / name (for player)
        }

        public void PrintBoard(Piece[,] i_Board)
        {
            // Print the current board
        }

        public void PrintBoard(Piece[,] i_Board, List<Move> i_PossibleMovesForPiece)
        {
            // OPTIONAL: Print the current board, draw all possible moves for a choosen piece
        }

        public void DisplayMessageBox(string i_Message)
        {
            // Display a message box with some text
        }

        public void concludeSingleGame(GameManager.eGameStatus i_GameStatus, ePlayerPosition i_Winner)
        {

        }
    }
}