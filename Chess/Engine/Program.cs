using System;
using System.Collections.Generic;

using ChessEngine.Pieces;
using ChessEngine.Misc;
using ChessEngine.Game;

namespace ChessTest
{
    class Program
    {
        static void Main()
        {
            IGame game = new Game();
            game.Init();
            Game.board.Print();

            Console.Write("------------------------\n");

            // List<Piece> playerPieces = new List<Piece>();
            // playerPieces = Game.board.PlayerPieces(Game.currentPlayer);
            // foreach (var piece in playerPieces)
            // {
            //     Position currentPos = piece.Position();
            //     Piece currentPiece = Game.board.At(currentPos);
            //     List<Position> currentPieceMoves = currentPiece.GetValidMoves();
            //     if (currentPieceMoves.Count > 0)
            //     {
            //         Console.Write("------------------------\n");
            //         currentPiece.Print();
            //         foreach (var each in currentPieceMoves)
            //         {
            //             each.Print();
            //         }
            //         Console.Write("------------------------\n");
            //     }
            // }

            List<Move> testMoves = Game.board.PlayerMoves(Game.currentPlayer);
            foreach(var move in testMoves) {
                move.Print();
            } 

            Console.WriteLine("Done!");
        }
    }
}
