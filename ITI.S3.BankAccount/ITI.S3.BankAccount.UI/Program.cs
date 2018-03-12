using System;

namespace ITI.S3.BankAccount.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account( "123456789", "1234", 1000 );
            int balance = account.GetBalance( "1234" );
            Console.WriteLine( "Balance: {0}", balance );
            account.Credit( 2000 );
            balance = account.GetBalance( "1234" );
            Console.WriteLine( "Balance: {0}", balance );
            balance = account.GetBalance( "0000" );
            Console.WriteLine( "With wrong pass, balance is: {0}", balance );

            Account invalidAccount = new Account( "4321", "0000", -1000 );
            Console.WriteLine( "Balance: {0}", invalidAccount.GetBalance( "0000" ) );

            account.Debit( "1234", 1500 );
            balance = account.GetBalance( "1234" );
            Console.WriteLine( "Balance: {0}", balance );

            account.Debit( "12345", 1500 );
            balance = account.GetBalance( "1234" );
            Console.WriteLine( "Balance: {0}", balance );

            account.ChangePassword( "1234", "4321" );
            Console.WriteLine( "Password changed: {0}", account.GetBalance( "4321" ) == 1500 );

            account.ChangePassword( "0000", "5555" );
            Console.WriteLine( "Password changed: {0}", account.GetBalance( "5555" ) != -1 );
        }
    }
}
