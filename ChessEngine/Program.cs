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
            Game game = new Game();
            game.Init();
            Game.board.Print();
            // Game.board.Move(new Position("a2"), new Position("a4"));
            // Game.board.Print();
            // Game.board.Move(new Position("a1"), new Position("a3"));
            // Game.board.Print();
            // Game.board.Move(new Position("a3"), new Position("c3"));
            // Game.board.Print();
            // Game.board.Move(new Position("c3"), new Position("c5"));
            // Game.board.Print();

            Console.Write("------------------------\n");


            for (int n = 0; n < 8; n++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Position currentPos = new Position(n, i);
                    Piece currentPiece = Game.board.At(currentPos);
                    List<Position> currentPieceMoves = currentPiece.GetValidMoves();
                    if (currentPieceMoves.Count > 0)
                    {
                        Console.Write("------------------------\n");
                        currentPiece.Print();
                        foreach (var each in currentPieceMoves)
                        {
                            each.Print();
                        }
                        Console.Write("------------------------\n");
                    }
                }

            }
            /*
            Game.board.Move(new Position("a2"), new Position("a4"));
            Game.board.Print();

            Game.board.Move(new Position("b1"), new Position("c3"));
            Game.board.Print();

            Game.board.Move(new Position("a1"), new Position("a3"));
            Game.board.Print();
            */
            Console.WriteLine("Done!");
        }
    }
}
