using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using checkersGUI.Properties;

namespace checkersGUI
{
    public class Square : Button
    {
        private bool m_MoveStart;
        private bool m_MoveEnd;
        private bool m_Active;
        private readonly Position m_Position;
        private PieceGUI m_PieceGUI;
        private readonly Image r_DefaultImage = Resources.lightTile;
        private readonly Image r_DeactivatedTile = Resources.darkTile;
        private readonly Image r_ChoosenImage = Resources.choosenTile;
        private readonly Image r_MoveableImage = Resources.moveableTile;

        public PieceGUI PieceGUI
        {
            get => m_PieceGUI;
            set => m_PieceGUI = value;
        }

        public Position Position
        {
            get
            {
                return m_Position;
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
            m_Position = i_Position;
            PieceGUI = null;
            m_MoveStart = false;
            m_MoveEnd = false;
            m_Active = i_Active;
            initializeComponent();
        }

        private void initializeComponent()
        {
            SuspendLayout();
            Enabled = false;
            Top = m_Position.Row * MainGame.k_ButtonSize;
            Left = m_Position.Col * MainGame.k_ButtonSize;
            Name = "Square" + m_Position.Row + m_Position.Col;
            Width = MainGame.k_ButtonSize;
            Height = Width;
            BackgroundImage = m_Active ? r_DefaultImage : r_DeactivatedTile;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        internal void AssignPiece(PieceGUI i_PieceGui)
        {
            m_PieceGUI = i_PieceGui;
        }

        internal void squareStartPossible(List<Move> i_PossibleMoves)
        {
            Enabled = false;
            m_MoveStart = false;
            foreach (Move move in i_PossibleMoves)
            {
                if (move.Begin.Row == m_Position.Row &&
                    move.Begin.Col == m_Position.Col)
                {
                    Enabled = true;
                    m_MoveStart = true;
                    //Debug.WriteLine("Enable square");
                }
            }
        }

        public void moveEnd()
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

        internal void removePiece(Position i_Position)
        {
            if (i_Position.Row == m_Position.Row && i_Position.Col == m_Position.Col)
            {
                m_PieceGUI?.Hide();
                m_PieceGUI = null;
            }
        }

        internal void setKing()
        {
            m_PieceGUI?.SetKing();
        }
    }

}