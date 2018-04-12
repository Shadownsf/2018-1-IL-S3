namespace ITI.S3.MicroZoo
{
    public interface IMailer
    {
        void SendMail( string subject, string content );
    }
}
