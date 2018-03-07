using System;

namespace ITI.S3.UserManagement.UI
{
    class Program
    {
        static void Main( string[] args )
        {
            User john = new User();
            john.UserName = "John";

            john.SetPassword( "ù**^$^rzer" );
            if( john.PasswordMatch( "wrong pass" ) )
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
