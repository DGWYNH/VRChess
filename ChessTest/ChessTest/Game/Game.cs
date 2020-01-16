using System;
using System.Collections.Generic;
using ChessUtils.Pieces;

namespace ChessUtils.Game
{
    public enum Player
    {
        NULL,
        Player1,
        Player2,
    }
    class Game
    {
        public static Board board;
        public static Player currentPlayer;
        public static List<Piece> capturedPieces;

        public void Init()
        {
            board = new Board();
            board.Init();
            currentPlayer = Player.Player1;
            capturedPieces = new List<Piece>();
        }

        public void PlayerSwap()
        {
            if(currentPlayer == Player.Player1)
            {
                currentPlayer = Player.Player2;
            }
            else
            {
                currentPlayer = Player.Player2;
            }
        }
    }
}
