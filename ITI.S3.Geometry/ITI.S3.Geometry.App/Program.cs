using System;

namespace ITI.S3.Geometry.App
{
    class Program
    {
        static void Main( string[] args )
        {
            Segment segment = new Segment( 0, 10 );
            DisplaySegment( segment );

            segment.Move( 2 );
            DisplaySegment( segment );

            Console.WriteLine( "Segment (2, 12) contains the point 4: {0}", segment.Contains( 4 ) );
            Console.WriteLine( "Segment (2, 12) contains the point 12: {0}", segment.Contains( 12 ) );
            Console.WriteLine( "Segment (2, 12) contains the point 0: {0}", segment.Contains( 12 ) );

            segment = new Segment( 0, 10 );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [0, 10[  : {0} - should be True", segment.Overlaps( new Segment( 0, 10 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [-6, 5[  : {0} - should be True", segment.Overlaps( new Segment( -6, 11 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [8, 15[  : {0} - should be True", segment.Overlaps( new Segment( 8, 7 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [-10, -5[: {0} - should be False", segment.Overlaps( new Segment( -10, 5 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [5, 8[   : {0} - should be True", segment.Overlaps( new Segment( 5, 3 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [11, 16[ : {0} - should be False", segment.Overlaps( new Segment( 11, 5 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [-5, 15[ : {0} - should be True", segment.Overlaps( new Segment( -5, 20 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [10, 20[ : {0} - should be False", segment.Overlaps( new Segment( 10, 10 ) ) );
            Console.WriteLine( "Segment [0, 10[ overlaps segment [-10, 0[ : {0} - should be False", segment.Overlaps( new Segment( -10, 10 ) ) );

            Segment intersection = segment.Intersection( new Segment( -6, 11 ) );
            Console.WriteLine("Intersection between [0, 10[ and [-6, 5[:");
            DisplaySegment( intersection );

            intersection = segment.Intersection( new Segment( 8, 7 ) );
            Console.WriteLine("Intersection between [0, 10[ and [8, 15[:");
            DisplaySegment( intersection );

            intersection = segment.Intersection( new Segment( 10, 2 ) );
            Console.WriteLine("Intersection between [0, 10[ and [10, 12[ is null: {0}", intersection == null);
        }

        static void DisplaySegment( Segment segment )
        {
            Console.WriteLine( "Left: {0}", segment.Left );
            Console.WriteLine( "Right: {0}", segment.Right );
            Console.WriteLine( "Length: {0}", segment.Length );
        }
    }
}
