using board;

namespace chess
{
    class King : Piece
    {
        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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

        private bool rookToKingTest(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && qtyMovements == 0;
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

            // #Special Move Castling
            if(qtyMovements==0 && !match.check)
            {
                // #Special Move Little Castling
                Position posR1 = new Position(position.row, position.column + 3);
                if (rookToKingTest(posR1))
                {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if(board.piece(p1)==null && board.piece(p2) == null)
                    {
                        mat[position.row, position.column + 2] = true;
                    }
                }

                // #Special Move Big Castling
                Position posR2 = new Position(position.row, position.column - 4);
                if (rookToKingTest(posR2))
                {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            }
            return mat;

        }
    }
}
