
using System;

namespace Lab4_Tasks6_7
{
    internal class LineSegment
    {
        private double _x;
        private double _y;

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public LineSegment()
        {
            _x = 0;
            _y = 0;
        }

        public LineSegment(double value)
        {
            _x = value;
            _y = value;
        }

        public LineSegment(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public LineSegment FindIntersection(
            LineSegment other)
        {
            if (other == null)
            {
                return null;
            }

            double start = Math.Max(_x, other._x);
            double end = Math.Min(_y, other._y);

            if (start > end)
            {
                return null;
            }

            return new LineSegment(start, end);
        }

        public override string ToString()
        {
            return "[" + _x + "; " + _y + "]";
        }

        public static LineSegment operator !(
            LineSegment segment)
        {
            if (segment == null)
            {
                return null;
            }

            double x = segment._x;
            double y = segment._y;

            if (x <= y)
            {
                return new LineSegment(x, y);
            }

            if (x > 0 && y > 0)
            {
                return new LineSegment(0, y);
            }

            if (x < 0 && y < 0)
            {
                return new LineSegment(x, 0);
            }

            return new LineSegment(0, 0);
        }

        public static implicit operator int(
            LineSegment segment)
        {
            return (int)segment._y;
        }

        public static explicit operator double(
            LineSegment segment)
        {
            return segment._x;
        }

        public static LineSegment operator +(
            LineSegment segment, int value)
        {
            double x = segment._x + value;
            double y = segment._y;

            if (x <= y)
            {
                return new LineSegment(x, y);
            }

            return new LineSegment(y, x);
        }

        public static LineSegment operator +(
            int value, LineSegment segment)
        {
            double x = segment._x;
            double y = segment._y + value;

            if (x <= y)
            {
                return new LineSegment(x, y);
            }

            return new LineSegment(y, x);
        }

        public static bool operator >(
            LineSegment first, LineSegment second)
        {
            if (first == null || second == null)
            {
                return false;
            }

            return first._x <= second._x &&
                first._y >= second._y;
        }

       
    }
}
