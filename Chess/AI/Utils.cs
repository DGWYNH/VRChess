using System.Collections.Generic;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Game;

namespace ChessGame.AI
{
    class Ai {
        
        private List<Decision> m_topDecisions;
        private readonly int m_numDecisions = 5;

        public Ai() {
            m_topDecisions = new List<Decision>();
        }

        // Decision making algorithm
        public void GetTopMoves(){
            List<Move> possibleMoves = Game.board.PlayerMoves(Game.currentPlayer);
            foreach(var currentMove in possibleMoves) {
                Board tempBoard = Game.board.Copy();
                tempBoard.Move(currentMove);
                tempBoard.Print();
                double playerScore = tempBoard.PlayerScore(Game.currentPlayer);
                double otherPlayerScore = tempBoard.PlayerScore(Game.otherPlayer);
                Decision currentDecision = new Decision(currentMove, playerScore - otherPlayerScore);
                AddToDecisions(currentDecision);
            }
        }

        public void PrintTopMoves() {
            foreach(var each in m_topDecisions) {
                each.Print();
            }
        }

        // Picks between top n moves with weighted prob based on score
        public Move ChooseMove(){
            System.Random random = new System.Random();
            int choiceIndex = 0;
            int decisionCount = m_topDecisions.Count;

            double[] scores = new double[decisionCount];
            double minScore = System.Double.MaxValue;
            for (int n = 0; n < decisionCount; n++) {
                scores[n] = m_topDecisions[n].Score() + random.NextDouble();
                if(m_topDecisions[n].Score() < minScore) {
                    minScore = m_topDecisions[n].Score();
                }
            }
            for (int n = 0; n < decisionCount; n++)
            {
                scores[n] -= minScore;
            }

            // Get max score to normalize between [0, 1]
            double scoreSum = 0;
            for(int n = 0; n < decisionCount; n++) {
                scoreSum += scores[n];
            }

            // Normalize score and move to array of probabilities probability
            double[] pmf = new double[decisionCount];
            for(int n = 0; n < decisionCount; n++) {
                pmf[n] = m_topDecisions[n].Score()/scoreSum;
            }

            // Convert pmf (probability mass function) to cmf (cumulative mass)
            double[] cdf = new double[decisionCount];
            double currentSum = 0;
            for (int n = decisionCount - 1; n >= 0; n--) {
                currentSum += pmf[n];
                cdf[n] = currentSum;
            }

            // Generate random number to choose decision
            double rand = random.NextDouble();


            // Start from end of decision array and move to start (lowest prob to highest)
            for(int n = decisionCount; n >= 0; n--) {
                if(n == 0) {
                    choiceIndex = 0;
                }
                else if(rand < cdf[n - 1]) {
                    choiceIndex = n-1;
                    break;
                }
            }
            return m_topDecisions[choiceIndex].Move();
        } 

        // Adds move to priority queue and clamps to n elements
        public void AddToDecisions(Decision decision) {
            if(m_topDecisions.Count == 0) {
                m_topDecisions.Add(decision);
            }
            else {
                bool inserted = false;
                for(int n = 0; n < m_topDecisions.Count; n++) {
                    if(decision.Score() > m_topDecisions[n].Score()) {
                        m_topDecisions.Insert(n, decision);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    m_topDecisions.Add(decision);
                }
                m_topDecisions = m_topDecisions.GetRange(0, System.Math.Min(m_numDecisions, m_topDecisions.Count));
            }
        }

    }

}