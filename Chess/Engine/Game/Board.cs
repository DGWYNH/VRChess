using System;
using System.Collections.Generic;
using ChessGame.Engine;
using ChessGame.Engine.Pieces;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Game;

/*
        [8, 8]
[   ... h8]
[   ...   ]
:
:
[a1 ...   ]
[0, 0]
*/
namespace ChessGame.Engine.Game
{
    
    public class Board : IBoard
    {
        private readonly Piece[,] m_board;

        public Board()
        {
            m_board = new Piece[8, 8];
        }

        public void Init()
        {
            Array.Clear(m_board, 0, m_board.Length);
            //Player 1
            // Pawn
            for(int n = 0; n < 8; n++)
            {
                m_board[1, n] = new Pawn(new Position(n, 1), Player.Player1, Direction.Up);
            }
            // Knight
            m_board[0, 1] = new Knight(new Position(1, 0), Player.Player1);
            m_board[0, 6] = new Knight(new Position(6, 0), Player.Player1);
            // Bishop
            m_board[0, 2] = new Bishop(new Position(2, 0), Player.Player1);
            m_board[0, 5] = new Bishop(new Position(5, 0), Player.Player1);
            // Rook
            m_board[0, 0] = new Rook(new Position(0, 0), Player.Player1);
            m_board[0, 7] = new Rook(new Position(7, 0), Player.Player1);
            // Queen
            m_board[0, 3] = new Queen(new Position(3, 0), Player.Player1);
            // King
            m_board[0, 4] = new King(new Position(4, 0), Player.Player1);

            //Player 1
            // Pawn
            for (int n = 0; n < 8; n++)
            {
                m_board[6, n] = new Pawn(new Position(n, 6), Player.Player2, Direction.Down);
            }
            // Knight
            m_board[7, 1] = new Knight(new Position(1, 7), Player.Player2);
            m_board[7, 6] = new Knight(new Position(6, 7), Player.Player2);
            // Bishop
            m_board[7, 2] = new Bishop(new Position(2, 7), Player.Player2);
            m_board[7, 5] = new Bishop(new Position(5, 7), Player.Player2);
            // Rook
            m_board[7, 0] = new Rook(new Position(0, 7), Player.Player2);
            m_board[7, 7] = new Rook(new Position(7, 7), Player.Player2);
            // Queen
            m_board[7, 3] = new Queen(new Position(3, 7), Player.Player2);
            // King
            m_board[7, 4] = new King(new Position(4, 7), Player.Player2);

        }

        public void Clear()
        {
            Array.Clear(m_board, 0, m_board.Length);
        }

        public void Print()
        {
            System.Console.Write("1: Pawn   2: Knight  3: Bishop\n");
            System.Console.Write("4: Rook   5: Queen   6: King\n");
            System.Console.Write("   A  B  C  D  E  F  G  H\n");
            for (int n = 7; n >= 0; n--)
            {
                System.Console.Write("{0} ", n + 1);
                for (int i = 0; i < 8; i++)
                {
                    if(m_board[n, i] != null)
                    {
                        System.Console.Write("[{0}]", (int)m_board[n, i].Type());
                    }
                    else
                    {
                        System.Console.Write("[ ]");
                    }
                }
                System.Console.Write("\n");
            }
            System.Console.Write("\n");
        }

        public Board Copy()
        {
            Board newBoard = new Board();

            for (int n = 0; n < 8; n++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if(m_board[n, i] != null) {

                        newBoard.m_board[n, i] = m_board[n, i].Copy();
                    }
                }
            }

            return newBoard;
        }

        public bool Move(Position fromPos, Position toPos, bool tempMove = false)
        {
            if(At(fromPos).Owner() != Game.currentPlayer) {
                System.Console.Write("Error: Cannot select opposing piece!\n");
                return false;
            }
            if (!IsOccupied(fromPos))
            {
                System.Console.Write("Error: No piece selected!\n");
                return false;
            }
            if (At(fromPos).IsValidMove(toPos))
            {
                At(fromPos).Move(toPos, tempMove);
                // Piece tempPiece = m_board[fromPos.Y(), fromPos.X()];
                // m_board[fromPos.Y(), fromPos.X()] = m_board[toPos.Y(), toPos.X()];
                // m_board[toPos.Y(), toPos.X()] = tempPiece;
                m_board[toPos.Y(), toPos.X()] = m_board[fromPos.Y(), fromPos.X()];
                m_board[fromPos.Y(), fromPos.X()] = null;
                return true;
            }
            else
            {
                // System.Console.Write("Error: Invalid Move\n");
                return false;
            }
        }

        public bool Move(Move move, bool tempMove = false) {
            return Move(move.From(), move.To(), tempMove);
        }

        public bool IsOccupied(Position pos)
        {
            if(m_board[pos.Y(), pos.X()] == null)
            {
                return false;
            }
            return true;
        }
        public Piece At(Position pos)
        {
            if (m_board[pos.Y(), pos.X()] == null)
            {
                // System.Console.Write("Warning: Null piece returned at: {0}\n", pos.AsText());
                return new Piece();
            }
            return m_board[pos.Y(), pos.X()];
        }

        public bool IsEmpty(Position pos)
        {
            if(m_board[pos.Y(), pos.X()] == null)
            {
                return true;
            }
            return false;
        }

        public List<Piece> PlayerPieces(Player player){
            List<Piece> playerPieces = new List<Piece>();
            for (int n = 0; n < 8; n++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Position currentPos = new Position(i, n);
                    Piece currentPiece = Game.board.At(currentPos);
                    if (currentPiece.Owner() == player)
                    {
                        playerPieces.Add(currentPiece);
                    }
                }
            }
            return playerPieces;
        }

        public double PlayerScore(Player player) {
            List<Piece> playerPieces = PlayerPieces(player);
            double scoreSum = 0.0;
            foreach(var piece in playerPieces) {
                scoreSum += piece.Score();
            }
            return scoreSum;
        }

        public List<Move> PlayerMoves(Player player) {
            List<Move> playerMoves = new List<Move>();

            for (int n = 0; n < 8; n++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Position currentPos = new Position(i, n);
                    Piece currentPiece = Game.board.At(currentPos);
                    if (currentPiece.Owner() == player)
                    {
                        List<Position> currentPieceMoves = currentPiece.GetValidMoves();
                        foreach(var move in currentPieceMoves) {
                            playerMoves.Add(new Move(currentPos, move));
                        }
                    }
                }
            }
            return playerMoves;
        }

        private List<Piece> GetKings() {
            List<Piece> kingList = new List<Piece>();

            for (int n = 0; n < 8; n++)
            {
                for (int i = 0; i < 8; i++) {
                    Piece tempPiece = Game.board.At(new Position(i, n));
                    if(tempPiece.Type() == PieceType.King) {
                        kingList.Add(tempPiece);
                    }   
                }
            }
            return kingList;
        }


        public bool Check() {
            List<Piece> kingList = GetKings();
            foreach(var king in kingList) {
                Position kingPos = king.Position();
                // QueenCheck
                foreach (var dir in Enum.GetValues(typeof(Direction))) {
                    if((Direction)dir != Direction.NULL) {
                        if(kingPos.CheckDirPiece((Direction)dir).Type() == PieceType.Queen) {
                            TogglePlayerCheck(king.Owner());
                            return true;
                        }
                    }
                }

                // RookCheck

                // BishopCheck

                // KnightCkeck

                // PawnCheck

            }
            return false;
        }

        public bool CheckMate() {
            List<Piece> kingList = GetKings();
            // TODO: Check if checkmate check is necessary
            return false;
        }
    }
}
