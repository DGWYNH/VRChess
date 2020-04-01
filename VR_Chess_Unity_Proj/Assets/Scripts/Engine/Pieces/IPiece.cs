using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using ChessGame.Engine.Misc;
namespace ChessGame.Engine.Pieces
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
        Position Position();
        int Score();
        Player Owner();
        bool Move(Position toPos, bool tempMove);
        bool IsValidMove(Position toPos);
        List<Position> GetValidMoves();
        bool IsOpponent();
        Piece Copy();
        void Captured();
    }
}   