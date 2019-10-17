using board;

namespace chess
{
    class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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
                Position p2 = new Position(position.row - 1, position.column);
                if (board.validPosition(p2) && movementFree(p2) && board.validPosition(pos) && movementFree(pos) && qtyMovements == 0)
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

                // #Special Move En Passant
                if(position.row == 3)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if(board.validPosition(left) && thereIsAnOpponent(left) && board.piece(left) == match.enPassantVulnerable)
                    {
                        mat[left.row -1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && thereIsAnOpponent(right) && board.piece(right) == match.enPassantVulnerable)
                    {
                        mat[right.row-1, right.column] = true;
                    }
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
                Position p2 = new Position(position.row + 1, position.column);
                if (board.validPosition(p2) && movementFree(p2) && board.validPosition(pos) && movementFree(pos) && qtyMovements == 0)
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
                // #Special Move En Passant
                if (position.row == 4)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && thereIsAnOpponent(left) && board.piece(left) == match.enPassantVulnerable)
                    {
                        mat[left.row+1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && thereIsAnOpponent(right) && board.piece(right) == match.enPassantVulnerable)
                    {
                        mat[right.row+1, right.column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
