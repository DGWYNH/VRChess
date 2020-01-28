using System.Collections.Generic;
using ChessEngine.Misc;
namespace ChessEngine.Pieces
{
    public interface IPiece
    {
        enum PieceType{};
        void Print();
        PieceType Type();
        int Score();
        bool Move(Position toPos);
        bool IsValidMove(Position toPos);
        List<Position> GetValidMoves();
        bool IsOpponent();
    }
}