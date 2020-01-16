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
            /*
            Game.board.Move(new Position("a2"), new Position("a4"));
            Game.board.Print();

            Game.board.Move(new Position("b1"), new Position("c3"));
            Game.board.Print();

            Game.board.Move(new Position("a1"), new Position("a3"));
            Game.board.Print();
            */
            Position testPos = new Position(10, 5);
            Console.WriteLine("Done!");
        }
    }
}
