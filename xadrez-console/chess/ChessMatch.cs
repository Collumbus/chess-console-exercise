using System;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            putPieces();
        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementQtyMovement();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
        }

        public void executePlay(Position origin, Position destiny)
        {
            executeMoviment(origin, destiny);
            turn++;
            changePlayer();
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
            
        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
