using System;
using ChessEngine.Misc;
using ChessEngine.Pieces;

namespace ChessEngine.Game
{

    public interface IBoard
    {
        void Clear();
        void Print();
        void Init();
        Board Copy();
        bool Move(Position fromPos, Position toPos);
        bool IsOccupied(Position pos);
        Piece At(Position pos);
        bool IsEmpty(Position pos);
    }
}