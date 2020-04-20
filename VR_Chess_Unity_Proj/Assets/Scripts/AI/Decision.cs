using UnityEngine;
using UnityEditor;
using ChessGame.Engine.Misc;

namespace ChessGame.AI
{
    public class Decision : MonoBehaviour
    {
        private readonly Move m_move;
        private readonly double m_score; 

        public Decision() {
        }

        public Decision(Move move, double score) {
            m_move = move;
            m_score = score;
        }

        public Move Move() {
            return m_move;
        }

        public double Score(){
            return m_score;
        }
        public void Print() {
            System.Console.Write("{0}, Score: {1}\n", m_move.AsText(), m_score);
        }

    }
}