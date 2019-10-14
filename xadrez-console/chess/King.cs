using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "K";
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
            pos.setValues(position.row - 1, position.column - 1);
            if(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //northeast movement
            pos.setValues(position.row - 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //east movement
            pos.setValues(position.row, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //southeast movement
            pos.setValues(position.row + 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //south movement
            pos.setValues(position.row + 1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //south-west movement
            pos.setValues(position.row + 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //west movement
            pos.setValues(position.row, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            //northwest movement
            pos.setValues(position.row - 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            return mat;

        }
    }
}
