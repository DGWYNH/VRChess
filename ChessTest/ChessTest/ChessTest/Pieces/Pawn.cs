using System;
using System.Collections.Generic;
using ChessUtils.Misc;
using ChessUtils.Game;

namespace ChessUtils.Pieces
{
    class Pawn: Piece
    {
        readonly Direction m_direction;
        bool m_moved;
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

        public override bool Move(Position toPos)
        {
            if (!toPos.IsBounded())
            {
                System.Console.Write("Error: Selection out of bounds!\n");
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
                System.Console.Write("Error: Selection out of bounds!\n");
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
                    return true;
                }
                else if (m_pos.IsForward(toPos, m_direction)
                    && m_pos.IsAdjacent(toPos)
                    && m_moved)
                {
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if (m_pos.IsDiagonal(toPos)
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
            int dir = 0;
            Position checkPos;
            if(m_direction == Direction.Up)
            {
                dir = 1;
            }
            else if(m_direction == Direction.Down)
            {
                dir = -1;
            }
            if (!m_moved)
            {
                checkPos = new Position(m_pos.X(), m_pos.Y() + dir * 2);
                if (IsValidMove(checkPos))
                {
                    validMoves.Add(checkPos);
                }
            }
            checkPos = new Position(m_pos.X(), m_pos.Y() + dir);
            if (IsValidMove(checkPos))
            {
                validMoves.Add(checkPos);
            }
            return validMoves;
        }
    }
}
