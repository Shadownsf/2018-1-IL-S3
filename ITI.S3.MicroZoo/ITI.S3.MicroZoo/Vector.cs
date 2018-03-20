using System;

namespace ITI.S3.MicroZoo
{
    struct Vector
    {
        double _x;
        double _y;

        internal Vector( double x, double y )
        {
            _x = x;
            _y = y;
        }

        internal double X => _x;

        internal double Y => _y;

        internal Vector Sub( Vector v ) => new Vector( _x - v._x, _y - v._y );

        internal double Magnitude => Math.Sqrt( _x * _x + _y * _y );

        internal Vector Mul( double n ) => new Vector( _x * n, _y * n );

        internal Vector Add( Vector v ) => new Vector( _x + v._x, _y + v._y );
    }
}
