using System;

namespace ITI.S3.MicroZoo
{
    static class MathHelpers
    {
        internal static Vector MoveTo( Vector position, Vector direction, double speed )
        {
            return position.Add( direction.Mul( speed ) );
        }

        internal static Vector Limit( Vector v, double min, double max )
        {
            return new Vector( Limit( v.X, min, max ), Limit( v.Y, min, max ) );
        }

        internal static double Limit( double n, double min, double max )
        {
            return Math.Min( Math.Max( n, min ), max );
        }

        internal static float Limit( float n, float min, float max )
        {
            return Math.Min( Math.Max( n, min ), max );
        }
    }
}
