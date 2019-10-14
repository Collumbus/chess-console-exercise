using System;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Whithe;
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

        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.Whithe), new ChessPosition('c', 1).toPosition());
            board.putPiece(new Rook(board, Color.Whithe), new ChessPosition('c', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whithe), new ChessPosition('d', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whithe), new ChessPosition('e', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whithe), new ChessPosition('e', 1).toPosition());
            board.putPiece(new King(board, Color.Whithe), new ChessPosition('d', 1).toPosition());

            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
