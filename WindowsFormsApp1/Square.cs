using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using checkersGUI.Properties;

namespace checkersGUI
{
    public class Square : Button
    {
        // Square Settings
        private readonly Image r_DefaultImage = Resources.lightTile;
        private readonly Image r_DeactivatedTile = Resources.darkTile;
        private readonly Image r_ChoosenImage = Resources.choosenTile;
        private readonly Image r_MoveableImage = Resources.moveableTile;

        private readonly Position r_Position;
        private readonly bool r_Active;
        private bool m_MoveStart;
        private bool m_MoveEnd;
        private PieceGui m_PieceGui;

        public PieceGui PieceGUI
        {
            get => m_PieceGui;
            set => m_PieceGui = value;
        }

        public Position Position
        {
            get
            {
                return r_Position;
            }
        }

        public bool MoveEnd
        {
            get
            {
                return m_MoveEnd;
            }

            set
            {
                m_MoveEnd = value;
            }
        }

        public bool MoveStart
        {
            get
            {
                return m_MoveStart;
            }

            set
            {
                m_MoveStart = value;
            }
        }

        public Square(Position i_Position, bool i_Active)
        {
            r_Position = i_Position;
            PieceGUI = null;
            m_MoveStart = false;
            m_MoveEnd = false;
            r_Active = i_Active;
            initializeComponent();
        }

        private void initializeComponent()
        {
            SuspendLayout();
            Enabled = false;
            Top = r_Position.Row * MainGame.k_ButtonSize;
            Left = r_Position.Col * MainGame.k_ButtonSize;
            Name = "Square" + r_Position.Row + r_Position.Col;
            Width = MainGame.k_ButtonSize;
            Height = Width;
            BackgroundImage = r_Active ? r_DefaultImage : r_DeactivatedTile;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        internal void AssignPiece(PieceGui i_PieceGui)
        {
            m_PieceGui = i_PieceGui;
        }

        internal void MoveStartPossible(List<Move> i_PossibleMoves)
        {
            Enabled = false;
            m_MoveStart = false;
            foreach (Move move in i_PossibleMoves)
            {
                if (move.Begin.Row != r_Position.Row || move.Begin.Col != r_Position.Col)
                {
                    continue;
                }

                Enabled = true;
                m_MoveStart = true;
            }
        }

        public void MoveEndPossible()
        {
            BackgroundImage = r_MoveableImage;
            Enabled = true;
            m_MoveEnd = true;
        }

        internal void Highlight()
        {
            BackgroundImage = r_ChoosenImage;
        }

        internal void DefaultBackground()
        {
            BackgroundImage = r_DefaultImage;
            if (!m_MoveStart)
            {
                Enabled = false;
            }
        }

        internal void BackToBasic()
        {
            BackgroundImage = r_DefaultImage;
            m_MoveEnd = false;
            m_MoveStart = false;
            Enabled = false;
        }

        internal void RemovePiece(Position i_Position)
        {
            if (i_Position.Row != r_Position.Row || i_Position.Col != r_Position.Col)
            {
                return;
            }

            m_PieceGui?.Hide();
            m_PieceGui = null;
        }

        internal void SetKing()
        {
            m_PieceGui?.SetKing();
        }
    }
}