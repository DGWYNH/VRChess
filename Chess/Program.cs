﻿using System;
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
            // for(int n = 0; n < 1000000; n++) {
            double n = 0;
            while(Game.gameflags.running == true) {
                n++;
                Ai testAI = new Ai();
                testAI.GetTopMoves();
                Move testMove = testAI.ChooseMove();
                testMove.Print();
                Game.board.Move(testMove);
                game.PlayerSwap();
                if(n > 10000) {
                    break;
                }
                Game.board.Print();
            }
            Game.board.Print();

            switch(Game.gameflags.winner) {
                case Player.Player1:
                    System.Console.Write("Player 1 won in: {0} moves!\n", n);
                    break;
                case Player.Player2:
                    System.Console.Write("Player 2 won in: {0} moves!\n", n);
                    break;
                default:
                    System.Console.Write("Invalid winner in: {0} moves!\n", n);
                    break;

            }


            Console.WriteLine("Done!");
        }
    }
}
