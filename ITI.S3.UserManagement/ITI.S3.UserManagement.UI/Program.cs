using System;

namespace ITI.S3.UserManagement.UI
{
    class Program
    {
        static void Main( string[] args )
        {
            User john = new User( "John", "ù**^$^rzer" );

            Console.WriteLine( "User name: " + john.UserName );
            if( john.PasswordMatch( "ù**^$^rzer" ) )
            {
                Console.WriteLine( "Password matched" );
            }
            else
            {
                Console.WriteLine( "Password didn't match" );
            }

            Console.ReadKey();
        }
    }
}
