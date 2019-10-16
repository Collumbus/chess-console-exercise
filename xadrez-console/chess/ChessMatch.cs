using System.Collections.Generic;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece executeMoviment(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementQtyMovement();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMoviment(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decrementQtyMovement();
            if(capturedPiece != null)
            {
                board.putPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p,origin);
        }

        public void executePlay(Position origin, Position destiny)
        {
            Piece capturedPieces = executeMoviment(origin, destiny);

            if (isInCheck(currentPlayer))
            {
                undoMoviment(origin, destiny, capturedPieces);
                throw new BoardException("You cannot put yourself in check.");
            }
            if (isInCheck(opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (checkMateTest(opponent(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
        }

        public void validateOriginPosition(Position pos)
        {
            if(board.piece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen position.");
            }
            if(currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The chosen piece is not yours.");
            }
            if (!board.piece(pos).thereArePossibleMovements())
            {
                throw new BoardException("There are no possible moves for this piece.");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Invalid target position.");
            }
        }
        public void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }
            
        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
                return Color.White;
        }

        private Piece king(Color color)
        {
            foreach (Piece x in piecesInGame(color)){
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece K = king(color);
            if(K == null)
            {
                throw new BoardException("There is no king of " + color + " color on the board.");
            }
            foreach (Piece x in piecesInGame(opponent(color)))
            {
                bool[,] mat = x.possibleMovements();
                if(mat[K.position.row, K.position.column])
                {
                    return true;
                }
            }
            return false;
            {

            }
        }

        public bool checkMateTest(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMovements();
                for(int i=0; i<board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMoviment(origin, destiny);
                            bool checkTest = isInCheck(color);
                            undoMoviment(origin, destiny, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece (char column, int row, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }
        private void putPieces()
        {
            putNewPiece('c', 1, new Rook(board, Color.White));
            putNewPiece('c', 2, new Rook(board, Color.White));
            putNewPiece('d', 2, new Rook(board, Color.White));
            putNewPiece('e', 2, new Rook(board, Color.White));
            putNewPiece('e', 1, new Rook(board, Color.White));
            putNewPiece('d', 1, new King(board, Color.White));

            putNewPiece('c', 7, new Rook(board, Color.Black));
            putNewPiece('c', 8, new Rook(board, Color.Black));
            putNewPiece('d', 7, new Rook(board, Color.Black));
            putNewPiece('e', 7, new Rook(board, Color.Black));
            putNewPiece('e', 8, new Rook(board, Color.Black));
            putNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
