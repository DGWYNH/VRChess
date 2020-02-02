using System;
using System.Collections.Generic;

using ChessGame.Engine.Game;
using ChessGame.Engine.Misc;
using ChessGame.AI;


namespace ChessGame
{
    class Program
    {
        static void Main()
        {
            IGame game = new Game();
            game.Init();
            Game.board.Print();

            Console.Write("------------------------\n");
            for(int n = 0; n < 10; n++) {
                Ai testAI = new Ai();
                testAI.GetTopMoves();
                Move testMove = testAI.ChooseMove();
                Move newMove = new Move(new Position("B1"), new Position("C3"));
                testMove.Print();
                Game.board.Move(newMove);
                game.PlayerSwap();
                Game.board.Print();
            }

            // List<Move> testList = Game.board.PlayerMoves(Game.currentPlayer);
            // foreach(var each in testList) {
            //     each.Print();
            // }

            // Console.Write("------------------------\n");
            // Move newMove = new Move(new Position("B1"), new Position("A3"));
            // Game.board.Move(newMove);
            // Game.board.Print();


            // Decision testDec1 = new Decision(new Move(), 7);
            // testAI.AddToDecisions(testDec1);

            // Decision testDec2 = new Decision(new Move(), 5);
            // testAI.AddToDecisions(testDec2);

            // Decision testDec3 = new Decision(new Move(), 4);
            // testAI.AddToDecisions(testDec3);

            // Decision testDec4 = new Decision(new Move(), 3);
            // testAI.AddToDecisions(testDec4);

            // Decision testDec5 = new Decision(new Move(), 1);
            // testAI.AddToDecisions(testDec5);

            // Decision testDec6 = new Decision(new Move(), -24);
            // testAI.AddToDecisions(testDec6);

            // testAI.PrintTopMoves();
            // Console.Write("------------------------\n");



            Console.WriteLine("Done!");
        }
    }
}
