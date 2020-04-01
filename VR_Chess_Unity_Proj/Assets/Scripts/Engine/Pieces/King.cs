using UnityEngine;
using UnityEditor;
using System;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Game;

namespace ChessGame.Engine.Pieces
{
    class King : Piece
    {
        public King()
        {
            m_score = 1000;
            m_type = PieceType.King;
            m_pos = new Position();
            m_owner = Player.NULL;
        }

        public King(Position pos, Player player)
        {
            m_score = 1000;
            m_type = PieceType.King;
            m_pos = pos;
            m_owner = player;
        }

        public override bool Move(Position toPos, bool tempMove)
        {
            if (!toPos.IsBounded())
            {
                // System.Console.Write("Error: Selection out of bounds!\n");
                return false;
            }
            if (Game.Game.board.IsEmpty(toPos))
            {
                if (m_pos.IsAdjacent(toPos))
                {
                    m_pos = toPos;
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if (m_pos.IsAdjacent(toPos))
                {
                    Game.Game.capturedPieces.Add(Game.Game.board.At(toPos));
                    if (!tempMove)
                    {
                        Game.Game.board.At(toPos).Captured();
                    }
                    m_pos = toPos;
                    return true;
                }
            }
            return false;
        }

        public override Piece Copy()
        {
            return new King(m_pos, m_owner);
        }

        // TODO: Check for check/Checkmate
        public override void Captured() {
            m_pos = new Position();
            Game.Game.gameflags.running = false;
            if(m_owner == Player.Player1) {
                Game.Game.gameflags.winner = Player.Player2;
            }
            else if(m_owner == Player.Player2) {
                Game.Game.gameflags.winner = Player.Player1;
            }
            else {
                Game.Game.gameflags.winner = Player.NULL;
            }
        }
    }
}
