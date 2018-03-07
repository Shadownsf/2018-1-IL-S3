namespace ITI.S3.UserManagement
{
    public class User
    {
        string _userName;
        string _password;

        public User( string userName, string password )
        {
            _userName = userName;
            _password = password;
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public void SetPassword( string password )
        {
            _password = password;
        }

        public bool PasswordMatch( string candidate )
        {
            return _password == candidate;
        }
    }
}
