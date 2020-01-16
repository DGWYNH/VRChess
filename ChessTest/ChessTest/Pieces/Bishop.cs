using System;
using System.Collections.Generic;
using ChessUtils.Misc;
using ChessUtils.Game;

namespace ChessUtils.Pieces
{
    class Bishop : Piece
    {
        public Bishop()
        {
            m_score = 3;
            m_type = PieceType.Bishop;
            m_pos = new Position();
            m_owner = Player.NULL;
        }

        public Bishop(Position pos, Player player)
        {
            m_score = 3;
            m_type = PieceType.Bishop;
            m_pos = pos;
            m_owner = player;
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
                if (m_pos.IsDiagonal(toPos)
                    && m_pos.IsOpenPath(toPos))
                {
                    m_pos = toPos;
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if (m_pos.IsDiagonal(toPos)
                    && m_pos.IsOpenPath(toPos))
                {
                    Game.Game.capturedPieces.Add(Game.Game.board.At(toPos));
                    m_pos = toPos;
                    return true;
                }
            }
            return false;
        }

        public override List<Position> GetValidMoves()
        {
            List<Position> validMoves = new List<Position>();
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.UpRight));
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.UpLeft));
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.DownLeft));
            validMoves.AddRange(m_pos.CheckDirAvailability(Direction.DownRight));
            return validMoves;
        }

    }
}
