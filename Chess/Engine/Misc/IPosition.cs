using System.Collections.Generic;

namespace ChessEngine.Misc
{
    public interface IPosition
    {
        int X();
        int Y();
        void Print();
        string AsText();
        bool IsBounded();
        bool IsForward(Position other, Direction direction);
        bool IsStraight(Position other);
        bool IsDiagonal(Position other);
        bool IsAdjacent(Position other);
        bool IsL(Position other);
        bool IsOpenPath(Position other);
        bool Equals(Position other);
        Position NextInDir(Direction dir);
        List<Position> CheckDirAvailability(Direction dir, bool includeOpponents = true);

    }
}