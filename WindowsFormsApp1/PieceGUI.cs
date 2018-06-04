using System.Windows.Forms;

namespace checkersGUI
{
    public class PieceGUI : PictureBox
    {
        private const string k_Player1Regular = "player1regular";
        private const string k_Player1King = "player2king";
        private const string k_Player2Regular = "player2regular";
        private const string k_Player2King = "player2king";

        private ePieceSymbol m_pieceSymbol;

        public PieceGUI(ePieceSymbol i_PieceSymbol)
        {
            setPieceSymbol(i_PieceSymbol);
        }

        private void setPieceSymbol(ePieceSymbol i_PieceSymbol)
        {
            switch (i_PieceSymbol)
            {
                case ePieceSymbol.Player1Regular:
                    ImageLocation = k_Player1Regular;
                    break;
                case ePieceSymbol.Player1King:
                    ImageLocation = k_Player1King;
                    break;
                case ePieceSymbol.Player2Regular:
                    ImageLocation = k_Player2Regular;
                    break;
                case ePieceSymbol.Player2King:
                    ImageLocation = k_Player2King;
                    break;
            }
        }

        private void Move(Position i_Position)
        {
            // Move the piece to a new position
        }
    }
}