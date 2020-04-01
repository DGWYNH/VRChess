using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Game;

namespace ChessGame.Engine.Pieces
{
    class Pawn: Piece
    {
        private Direction m_direction;
        private bool m_moved;
        public Pawn()
        {
            m_score = 1;
            m_type = PieceType.Pawn;
            m_pos = new Position();
            m_owner = Player.NULL;
            m_direction = Direction.NULL;
            m_moved = false;
        }

        public Pawn(Position pos, Player player, Direction direction)
        {
            m_score = 1;
            m_type = PieceType.Pawn;
            m_pos = pos;
            m_owner = player;
            m_direction = direction;
            m_moved = false;
        }
        public override void Print()
        {
            base.Print();

            Console.Write("Direction: {0}\n", Enum.GetName(typeof(Direction), (int)m_direction));
            Console.Write("Has Moved: {0}\n", m_moved);
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
                if (!m_pos.IsOpenPath(toPos))
                {
                    return false;
                }
                if (m_pos.IsForward(toPos, m_direction)
                    && Math.Abs(toPos.Y() - m_pos.Y()) <= 2
                    && !m_moved)
                {
                    m_pos = toPos;
                    m_moved = true;
                    return true;
                }
                else if (m_pos.IsForward(toPos, m_direction)
                    && m_pos.IsAdjacent(toPos)
                    && m_moved)
                {
                    m_pos = toPos;
                    m_moved = true;
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if (m_pos.IsDiagonal(toPos)
                    && m_pos.IsAdjacent(toPos))
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

        public override bool IsValidMove(Position toPos)
        {
            if (!toPos.IsBounded())
            {
                // System.Console.Write("Error: Selection out of bounds!\n");
                return false;
            }
            if (Game.Game.board.IsEmpty(toPos))
            {
                if (!m_pos.IsOpenPath(toPos))
                {
                    return false;
                }
                if (m_pos.IsForward(toPos, m_direction)
                    && Math.Abs(toPos.Y() - m_pos.Y()) <= 2
                    && m_pos.IsStraight(toPos)
                    && !m_moved)
                {
                    return true;
                }
                else if (m_pos.IsForward(toPos, m_direction)
                    && m_pos.IsAdjacent(toPos)
                    && m_pos.IsStraight(toPos)
                    && m_moved)
                {
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if (m_pos.IsDiagonal(toPos)
                    && m_pos.IsForward(toPos, m_direction)
                    && m_pos.IsAdjacent(toPos))
                {
                    return true;
                }
            }
            return false;
        }

        public override List<Position> GetValidMoves()
        {
            List<Position> validMoves = new List<Position>();
            if (IsValidMove(m_pos + new Position(0, 2)))
            {
                validMoves.Add(m_pos + new Position(0, 2));
            }
            for (int n = -1; n <= 1; n++)
            {
                if (IsValidMove(m_pos + new Position(n, 1)))
                {
                    validMoves.Add(m_pos + new Position(n, 1));
                }
            }
            for (int n = -1; n <= 1; n++)
            {
                if (IsValidMove(m_pos + new Position(n, -1)))
                {
                    validMoves.Add(m_pos + new Position(n, -1));
                }
            }
            if (IsValidMove(m_pos + new Position(0, -2)))
            {
                validMoves.Add(m_pos + new Position(0, 2));
            }
            return validMoves;
        }

        public override Piece Copy()
        {
            return new Pawn(m_pos, m_owner, m_direction);
        }

        public override void Captured()
        {
            m_pos = new Position();
            m_direction = Direction.NULL;
            m_moved = false;
        }

        // TODO: private bool CanPromote
    }
}
