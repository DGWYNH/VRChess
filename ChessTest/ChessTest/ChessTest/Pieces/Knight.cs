using System;
using System.Collections.Generic;
using ChessUtils.Misc;
using ChessUtils.Game;

namespace ChessUtils.Pieces
{
    class Knight : Piece
    {
        public Knight()
        {
            m_score = 3;
            m_type = PieceType.Knight;
            m_pos = new Position();
            m_owner = Player.NULL;
        }

        public Knight(Position pos, Player player)
        {
            m_score = 3;
            m_type = PieceType.Knight;
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
                if (m_pos.IsL(toPos))
                {
                    m_pos = toPos;
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if (m_pos.IsL(toPos))
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
                if (m_pos.IsL(toPos))
                {
                    return true;
                }
            }
            else if (Game.Game.board.At(toPos).IsOpponent())
            {
                if (m_pos.IsL(toPos))
                {
                    return true;
                }
            }
            return false;
        }

        public override List<Position> GetValidMoves()
        {
            List<Position> validMoves = new List<Position>();
            
            return validMoves;
        }
    }
}
