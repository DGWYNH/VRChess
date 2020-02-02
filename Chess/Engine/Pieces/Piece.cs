using System;
using System.Collections.Generic;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Game;

namespace ChessGame.Engine.Pieces
{
    public class Piece : IPiece
    {


        protected PieceType m_type;
        protected int m_score;
        protected Position m_pos;
        protected Player m_owner;

        public Piece()
        {
        }

        public virtual void Print()
        {
            if (m_type == PieceType.NULL){
                return;
            }
            Console.Write("Type: {0}\n", Enum.GetName(typeof(PieceType), (int)m_type));
            Console.Write("Score: {0}\n", m_score);
            Console.Write("Position: {0}\n", m_pos.AsText());
            Console.Write("Owner: {0}\n", Enum.GetName(typeof(Player), (int)m_owner));
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

        public Player Owner(){
            return m_owner;
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

        public virtual Piece Copy() {
            return new Piece();
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
