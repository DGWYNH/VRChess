using System;
using System.Collections.Generic;
using ChessGame.Engine.Misc;
using ChessGame.Engine.Pieces;

namespace ChessGame.Engine.Game
{

    public interface IBoard
    {
        void Clear();
        void Print();
        void Init();
        Board Copy();
        bool Move(Position fromPos, Position toPos);
        bool Move(Move move);
        bool IsOccupied(Position pos);
        Piece At(Position pos);
        bool IsEmpty(Position pos);
        List<Piece> PlayerPieces(Player player);
        double PlayerScore(Player player);
        List<Move> PlayerMoves(Player player);
    }
}