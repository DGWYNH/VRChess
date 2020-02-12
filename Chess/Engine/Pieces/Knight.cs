using System;
using System.Collections.Generic;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Game;

namespace ChessGame.Engine.Pieces
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

        public override bool Move(Position toPos, bool tempMove)
        {
            if (!toPos.IsBounded())
            {
                // System.Console.Write("Error: Selection out of bounds!\n");
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
            int[] x_offsets = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] y_offsets = { 1, 2, 2, 1, -1, -2, -2, -1 };
            Position pos = new Position(m_pos.X(), m_pos.Y());
            for(int n = 0; n < 8; n++)
            {
                Position newPos = pos + new Position(x_offsets[n], y_offsets[n]);
                if (IsValidMove(newPos))
                {
                    validMoves.Add(newPos);
                }
            }
            return validMoves;
        }

        public override Piece Copy()
        {
            return new Knight(m_pos, m_owner);
        }

        public override void Captured()
        {
            m_pos = new Position();
        }
    }
}
