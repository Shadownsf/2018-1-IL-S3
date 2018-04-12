using System;

namespace ITI.S3.MicroZoo
{
    public struct Vector
    {
        double _x;
        double _y;

        public Vector( double x, double y )
        {
            _x = x;
            _y = y;
        }

        public double X => _x;

        public double Y => _y;

        public Vector Sub( Vector v ) => new Vector( _x - v._x, _y - v._y );

        public double Magnitude => Math.Sqrt( _x * _x + _y * _y );

        public Vector Mul( double n ) => new Vector( _x * n, _y * n );

        public Vector Add( Vector v ) => new Vector( _x + v._x, _y + v._y );
    }
}
