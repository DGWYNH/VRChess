using UnityEngine;
using UnityEditor;
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
    public struct GameFlags {
        public bool running;
        public Player winner;
        public bool player1InCheck;
        public bool player2InCheck;

    }
    class Game : MonoBehaviour
    {
        public static Board board;
        public static Player currentPlayer;
        public static Player otherPlayer;
        public static List<Piece> capturedPieces;

        public static GameFlags gameflags;

        public VRTK.VRTK_InteractGrab grabL;
        public VRTK.VRTK_InteractGrab grabR;

        public void Init()
        {
            board = new Board();
            board.Init();
            currentPlayer = Player.Player1;
            otherPlayer = Player.Player2;
            capturedPieces = new List<Piece>();

            gameflags.running = true;
            gameflags.winner = Player.NULL;

        }


        public void PlayerSwap()
        {
            if(currentPlayer == Player.Player1)
            {
                currentPlayer = Player.Player2;
                otherPlayer = Player.Player1;
                grabL.enabled = false;
                grabR.enabled = false;
            }
            else
            {
                currentPlayer = Player.Player1;
                otherPlayer = Player.Player2;
                grabL.enabled = true;
                grabR.enabled = true;
            }
        }

        public void TogglePlayerCheck(Player player)
        {

            Game.gameflags.player1InCheck = false;
            Game.gameflags.player2InCheck = false;
            switch (player)
            {
                case Player.Player1:
                    Game.gameflags.player1InCheck = true;
                    break;
                case Player.Player2:
                    Game.gameflags.player2InCheck = true;
                    break;
            }
        }
    }
}
