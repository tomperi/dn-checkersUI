﻿namespace checkers
{
    public struct Position
    {
        private readonly int r_Row;
        private readonly int r_Col;

        public Position(int i_Row, int i_Col)
        {
            r_Row = i_Row;
            r_Col = i_Col;
        }

        public int Row
        {
            get
            {
                return r_Row;
            }
        }

        public int Col
        {
            get
            {
                return r_Col;
            }
        }

        public override string ToString()
        {
            return string.Format(Strings.PositionFormat, r_Col, r_Row);
        }
    }
}