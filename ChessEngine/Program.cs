using System;
using System.Collections.Generic;

using ChessUtils.Pieces;
using ChessUtils.Misc;
using ChessUtils.Game;

namespace ChessTest
{
    class Program
    {
        static void Main()
        {
            Game game = new Game();
            game.Init();
            Game.board.Print();
            Game.board.Move(new Position("a2"), new Position("a4"));
            Game.board.Print();
            Game.board.Move(new Position("a1"), new Position("a3"));
            Game.board.Print();
            Game.board.Move(new Position("a3"), new Position("c3"));
            Game.board.Print();
            Game.board.Move(new Position("c3"), new Position("c5"));
            Game.board.Print();

            Console.Write("------------------------\n");
            List<Position> testList;
            testList = Game.board.At(new Position("c5")).GetValidMoves();
            foreach (var pos in testList)
            {
                pos.Print();
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
