﻿using System;
using System.Collections.Generic;
using ChessUtils.Misc;
using ChessUtils.Game;

namespace ChessUtils.Pieces
{
    class Piece
    {
        public enum PieceType
        {
            NULL,
            Pawn,
            Knight,
            Bishop,
            Rook,
            Queen,
            King,
        }

        protected PieceType m_type;
        protected int m_score;
        protected Position m_pos;
        protected Player m_owner;

        public Piece()
        {
        }

        public PieceType Type()
        {
            return m_type;
        }
        public Position Position()
        {
            return m_pos;
        }
        public int Score()
        {
            return m_score;
        }


        public virtual bool Move(Position toPos)
        {
            return false;
        }

        public virtual bool IsValidMove(Position toPos)
        {
            return false;
        }

        public virtual List<Position> GetValidMoves()
        {
            return new List<Position>();
        }

        public bool IsOpponent()
        {
            if(m_owner != Game.Game.currentPlayer)
            {
                return true;
            }
            return false;

        }

    }
}
