using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            //north movement
            pos.setValues(position.row - 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.row = pos.row - 1;
            }

            //east movement
            pos.setValues(position.row, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //south movement
            pos.setValues(position.row + 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.row = pos.row + 1;
            }

            //west movement
            pos.setValues(position.row, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }
    }
}
