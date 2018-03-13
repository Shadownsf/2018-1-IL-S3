using System;

namespace ITI.S3.LightAndSwitch.UI
{
    class Program
    {
        static void Main( string[] args )
        {
            Switch s = new Switch( 3 );
            Light l1 = new Light();
            Light l2 = new Light();
            Light l3 = new Light();
            Light l4 = new Light();

            Console.WriteLine( "Attach l1: {0}", s.Attach( l1 ) );
            Console.WriteLine( "Attach l2: {0}", s.Attach( l2 ) );
            Console.WriteLine( "Attach l2: {0}", s.Attach( l2 ) );
            Console.WriteLine( "Attach l3: {0}", s.Attach( l3 ) );
            Console.WriteLine( "Attach l4: {0}", s.Attach( l4 ) );

            Console.WriteLine();

            Console.WriteLine( "Detach l3: {0}", s.Detach( l3 ) );
            Console.WriteLine( "Detach l3: {0}", s.Detach( l3 ) );

            Console.WriteLine();

            s.Toggle();

            Console.WriteLine( "l1.IsOn: {0}", l1.IsOn );
            Console.WriteLine( "l2.IsOn: {0}", l2.IsOn );
            Console.WriteLine( "l3.IsOn: {0}", l3.IsOn );
            Console.WriteLine( "l4.IsOn: {0}", l4.IsOn );

            Console.WriteLine();

            Console.WriteLine( "Detach l4: {0}", s.Detach( l4 ) );
            Console.WriteLine( "Detach l1: {0}", s.Detach( l1 ) );
            Console.WriteLine( "Detach l2: {0}", s.Detach( l2 ) );

            Console.WriteLine();

            Console.WriteLine( "l1.IsOn: {0}", l1.IsOn );
            Console.WriteLine( "l2.IsOn: {0}", l2.IsOn );
            Console.WriteLine( "l3.IsOn: {0}", l3.IsOn );
            Console.WriteLine( "l4.IsOn: {0}", l4.IsOn );
            
        }
    }
}
