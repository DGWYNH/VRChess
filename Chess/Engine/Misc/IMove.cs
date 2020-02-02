namespace ChessGame.Engine.Misc
{
    public interface IMove
    {
        Position From();
        Position To();
        void Print();
        string AsText();
    }
}