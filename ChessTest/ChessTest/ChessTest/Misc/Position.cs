using System;

namespace ChessUtils.Misc
{
    public enum Direction
    {
        NULL,
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
    }
    class Position
    {
        readonly int m_x;
        readonly int m_y;

        public Position()
        {
            m_x = 0;
            m_y = 0;
        }

        public Position(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public Position(string location)
        {
            bool validPos = true;
            if(location.Length <= 2)
            {

                if(Char.ToLower(location[0]) >= 'a' && Char.ToLower(location[0]) <= 'h')
                {
                    m_x = Char.ToLower(location[0]) - 'a';
                }
                else
                {
                    validPos = false;
                }

                if(Char.IsNumber(location[1]))
                {
                    m_y = location[1] - '1';
                }
                else
                {
                    validPos = false;
                }

            }
            else
            {
                validPos = false;
            }

            if (!validPos)
            {
                System.Console.Write("Warning: Invalid position!\n");
                m_x = -1;
                m_y = -1;
            }
        }

        public int X()
        {
            return m_x;
        }

        public int Y()
        {
            return m_y;
        }


        public void Print()
        {
            Console.Write("X: {0}, Y: {1}\n", m_x, m_y);
        }

        public string AsText()
        {
            return "(" + m_x + "," + m_y + ")";
        }

        public bool IsBounded()
        {
            if(m_x >= 0 && m_x < 8 && m_y >= 0 && m_y < 8)
            {
                return true;
            }
            return false;
        }

        public bool IsForward(Position other, Direction direction)
        {
            if(direction == Direction.Up && m_y < other.m_y)
            {
                return true;
            }
            if(direction == Direction.Down && m_y > other.m_y)
            {
                return true;
            }
            return false;
        }

        public bool IsStraight(Position other)
        {
            if (m_x == other.m_x && m_y != other.m_y)
            {
                return true;
            }
            if (m_x != other.m_x && m_y == other.m_y)
            {
                return true;
            }
            return false;
        }
        public bool IsDiagonal(Position other)
        {
            int xDiff = other.m_x - m_x;
            int yDiff = other.m_y - m_y;

            if(Math.Abs(xDiff) == Math.Abs(yDiff))
            {
                return true;
            }

            return false;
        }

        public bool IsAdjacent(Position other)
        {
            if (Math.Abs(m_x - other.m_x) == 1 || Math.Abs(m_y - other.m_y) == 1)
            {
                return true;
            }
            return false;
        }
        public bool IsL(Position other)
        {
            if ((Math.Abs(m_x - other.m_x) == 2 && Math.Abs(m_y - other.m_y) == 1) ||
                (Math.Abs(m_x - other.m_x) == 1 && Math.Abs(m_y - other.m_y) == 2))
            {
                return true;
            }
            return false;
        }

        public bool IsOpenPath(Position other)
        {
            int xDiff = other.m_x - m_x;
            int yDiff = other.m_y - m_y;
            if (IsDiagonal(other))
            {
                for(int n = 1; n < Math.Abs(xDiff); n++)
                {
                    int testX = m_x + n * Math.Sign(xDiff);
                    int testY = m_y + n * Math.Sign(yDiff);
                    Position testPos = new Position(testX, testY);
                    if (Game.Game.board.IsOccupied(testPos))
                    {
                        return false;
                    }
                }
            }
            if (IsStraight(other))
            {
                if(xDiff == 0)
                {
                    for (int n = 1; n < yDiff; n++)
                    {
                        int testY = m_y + n * Math.Sign(yDiff);
                        Position testPos = new Position(m_x, testY);
                        if (Game.Game.board.IsOccupied(testPos))
                        {
                            return false;
                        }
                    }
                }
                if (yDiff == 0)
                {
                    for (int n = 1; n < xDiff; n++)
                    {
                        int testX = m_x + n * Math.Sign(xDiff);
                        Position testPos = new Position(testX, m_y);
                        if (Game.Game.board.IsOccupied(testPos))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        public bool Equals(Position other)
        {
            if(m_x == other.m_x && m_y == other.m_y){
                return true;
            }
            return false;
        }
    }
}
