using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

using ChessGame.Engine.Game;
using ChessGame.Engine.Misc;
using ChessGame.AI;


namespace ChessGame
{
    class Program : MonoBehaviour
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
                switch(Game.currentPlayer) {
                    case Player.Player1: 
                        System.Console.Write("Turn: Player 1:\n");
                        break;
                    case Player.Player2: 
                        System.Console.Write("Turn: Player 2:\n");
                        break;
                }
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
            System.Console.Write("Game Over:\n");
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
