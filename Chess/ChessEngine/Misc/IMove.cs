namespace ChessEngine.Misc
{
    public interface IMove
    {
        Position From();
        Position To();
        void Print();
    }
}