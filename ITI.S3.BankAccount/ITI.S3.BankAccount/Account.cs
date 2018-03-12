using System;

namespace ITI.S3.BankAccount
{
    /// <summary>
    /// Represents a bank account.
    /// </summary>
    public class Account
    {
        readonly string _accountNumber;
        string _password;
        int _balance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="password">The password.</param>
        /// <param name="balanceInCents">The balance in cents.</param>
        public Account( string accountNumber, string password, int balanceInCents )
        {
            _accountNumber = accountNumber;
            _password = password;
            _balance = Math.Max( 0, balanceInCents );
        }

        /// <summary>
        /// Credits the current account.
        /// </summary>
        /// <param name="amountInCents">The amount in cents.</param>
        public void Credit( int amountInCents )
        {
            _balance += Math.Max( 0, amountInCents );
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public int GetBalance( string password )
        {
            if( password == _password ) return _balance;
            return -1;
        }

        /// <summary>
        /// Debits the current account.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="amountInCents">The amount in cents.</param>
        public void Debit( string password, int amountInCents )
        {
            if( password == _password && amountInCents > 0 && amountInCents <= _balance ) _balance -= amountInCents;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        public void ChangePassword( string oldPassword, string newPassword )
        {
            if( _password == oldPassword ) _password = newPassword;
        }
    }
}
