using System;
using ChessUtils.Misc;
using ChessUtils.Game;

namespace ChessUtils.Pieces
{
    class King : Piece
    {
        public King()
        {
            m_score = 0;
            m_type = PieceType.King;
            m_pos = new Position();
            m_owner = Player.NULL;
        }

        public King(Position pos, Player player)
        {
            m_score = 0;
            m_type = PieceType.King;
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
                    m_pos = toPos;
                    return true;
                }
            }
            return false;
        }
    }

}
