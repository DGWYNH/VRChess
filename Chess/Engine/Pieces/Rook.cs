﻿using System;
using System.Collections.Generic;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Game;

namespace ChessGame.Engine.Pieces
{
    class Rook : Piece
    {
        public Rook()
        {
            m_score = 5;
            m_type = PieceType.Rook;
            m_pos = new Position();
            m_owner = Player.NULL;
        }

        public Rook(Position pos, Player player)
        {
            m_score = 5;
            m_type = PieceType.Rook;
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
                if (m_pos.IsStraight(toPos)
                    && m_pos.IsOpenPath(toPos))
                {
                    m_pos = toPos;
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if(m_pos.IsStraight(toPos)
                    && m_pos.IsOpenPath(toPos))
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

        public override List<Position> GetValidMoves()
        {
            List<Position> validMoves = new List<Position>();
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.Right));
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.Up));
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.Left));
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.Down));
            return validMoves;
        }

        public override Piece Copy()
        {
            return new Bishop(m_pos, m_owner);
        }

        public override void Captured()
        {
            m_pos = new Position();
        }
    }
}
