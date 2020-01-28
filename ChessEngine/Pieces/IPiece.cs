using System.Collections.Generic;
using ChessEngine.Misc;
namespace ChessEngine.Pieces
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

    public interface IPiece
    {

        void Print();
        PieceType Type();
        int Score();
        Player Owner();
        bool Move(Position toPos);
        bool IsValidMove(Position toPos);
        List<Position> GetValidMoves();
        bool IsOpponent();
    }
}