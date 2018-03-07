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

            new Flask( 2 );
            new Flask( 3 );
            Console.WriteLine( "Flasks created: {0}", Flask.TotalCount );

            new Flask( 1 );
            new Flask( 4 );
            Console.WriteLine( "Flasks created: {0}", Flask.TotalCount );
        }

        static void DisplayFlask( Flask @this )
        {
            Console.WriteLine( "==================================" );
            Console.WriteLine( "Volume: {0}", @this.Volume );
            Console.WriteLine( "Max capacity: {0}", @this.MaxCapacity );
            Console.WriteLine( "Is full: {0}", @this.IsFull );
            Console.WriteLine( "Is empty: {0}", @this.IsEmpty );
            Console.WriteLine( "==================================" );
        }
    }
}
