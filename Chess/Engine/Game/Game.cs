using System;
using System.Collections.Generic;
using ChessGame.Engine.Pieces;
public enum Player
{
    NULL,
    Player1,
    Player2,
}
namespace ChessGame.Engine.Game
{

    class Game : IGame
    {
        public static Board board;
        public static Player currentPlayer;
        public static Player otherPlayer;
        public static List<Piece> capturedPieces;

        public void Init()
        {
            board = new Board();
            board.Init();
            currentPlayer = Player.Player1;
            otherPlayer = Player.Player2;
            capturedPieces = new List<Piece>();
        }


        public void PlayerSwap()
        {
            if(currentPlayer == Player.Player1)
            {
                currentPlayer = Player.Player2;
                otherPlayer = Player.Player1;
            }
            else
            {
                currentPlayer = Player.Player1;
                otherPlayer = Player.Player2;
            }
        }
    }
}
