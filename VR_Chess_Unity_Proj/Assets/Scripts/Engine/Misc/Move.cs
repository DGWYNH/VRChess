using UnityEngine;
using UnityEditor;
using ChessGame.Engine.Misc;

namespace ChessGame.Engine.Misc
{
    public class Move : IMove
    {
        private readonly Position m_fromPos;
        private readonly Position m_toPos;

        public Move() {
            m_fromPos = new Position();
            m_toPos = new Position();
        }
        public Move(Position fromPos, Position toPos) {
            m_fromPos = fromPos;
            m_toPos = toPos;
        }

        public Position From() {
            return m_fromPos;
        }

        public Position To() {
            return m_toPos;    
        }

        public void Print() {
            System.Console.Write("From: {0}, To: {1}\n", m_fromPos.AsText(), m_toPos.AsText());
        }
        public string AsText(){
            return "From: " +  m_fromPos.AsText() + "To: " + m_toPos.AsText();
        }
    }
}