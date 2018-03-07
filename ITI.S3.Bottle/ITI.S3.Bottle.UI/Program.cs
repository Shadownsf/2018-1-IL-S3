using System;

namespace ITI.S3.Bottle.UI
{
    class Program
    {
        static void Main( string[] args )
        {
            Flask flask = new Flask( 4 );
            DisplayFlask( flask );

            Console.WriteLine( "Calls flask.Fill( 3 )" );
            flask.Fill( 3 );
            DisplayFlask( flask );

            Console.WriteLine( "Calls flask.Fill( 2 )" );
            flask.Fill( 2 );
            DisplayFlask( flask );

            Console.WriteLine( "Calls flask.Empty( 1 )" );
            flask.Empty( 1 );
            DisplayFlask( flask );

            Console.WriteLine( "Calls flask.Empty()" );
            flask.Empty();
            DisplayFlask( flask );

            Console.WriteLine( "Calls flask.Fill()" );
            flask.Fill();
            DisplayFlask( flask );
        }

        static void DisplayFlask( Flask flask )
        {
            Console.WriteLine( "==================================" );
            Console.WriteLine( "Volume: {0}", flask.Volume );
            Console.WriteLine( "Max capacity: {0}", flask.MaxCapacity );
            Console.WriteLine( "Is full: {0}", flask.IsFull );
            Console.WriteLine( "Is empty: {0}", flask.IsEmpty );
            Console.WriteLine( "==================================" );
        }
    }
}
