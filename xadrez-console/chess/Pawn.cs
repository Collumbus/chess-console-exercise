using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "P";
        }

        private bool thereIsAnOpponent(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool movementFree(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.setValues(position.row - 1, position.column);
                if (board.validPosition(pos) && movementFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValues(position.row - 2, position.column);
                if (board.validPosition(pos) && movementFree(pos) && qtyMovements == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValues(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && movementFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValues(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && movementFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(position.row + 1, position.column);
                if (board.validPosition(pos) && movementFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValues(position.row + 2, position.column);
                if (board.validPosition(pos) && movementFree(pos) && qtyMovements == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValues(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && movementFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.setValues(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && movementFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }
            return mat;
        }
    }
}
