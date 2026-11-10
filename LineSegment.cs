using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Tasks6_7
{
    public class LineSegment
    {
        private double _x;
        private double _y;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
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
            double start = 0;
            double end = 0;

            if (other == null)
            {
                return null;
            }

            if (_x > other._x)
            {
                start = _x;
            }
            else
            {
                start = other._x;
            }

            if (_y < other._y)
            {
                end = _y;
            }
            else
            {
                end = other._y;
            }

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

            if (segment._x <= segment._y)
            {
                return new LineSegment(
                    segment._x, segment._y);
            }

            if (segment._x > 0 && segment._y > 0)
            {
                return new LineSegment(0, segment._y);
            }

            if (segment._x < 0 && segment._y < 0)
            {
                return new LineSegment(segment._x, 0);
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
            if (segment == null)
            {
                return null;
            }

            LineSegment result = new LineSegment(
                segment._x + value, segment._y);

            return !result;
        }

        public static LineSegment operator +(
    int value, LineSegment segment)
        {
            if (segment == null)
            {
                return null;
            }

            LineSegment result = new LineSegment(
                segment._x, segment._y + value);

            return !result;
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

        public static bool operator <(
            LineSegment first, LineSegment second)
        {
            if (first == null || second == null)
            {
                return false;
            }

            return first._x >= second._x &&
                first._y <= second._y;
        }
    }
}
