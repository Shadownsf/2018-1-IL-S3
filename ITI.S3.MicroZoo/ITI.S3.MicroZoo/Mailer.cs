using MailKit.Net.Smtp;
using MimeKit;

namespace ITI.S3.MicroZoo
{
    class Mailer : IMailer
    {
        public void SendMail( string subject, string text )
        {
            var message = new MimeMessage();
            message.From.Add( new MailboxAddress( "<recipient name>", "<recipient email>" ) );
            message.To.Add( new MailboxAddress( "<to name>", "to email" ) );
            message.Subject = subject;

            message.Body = new TextPart( "plain" )
            {
                Text = text
            };

            using( SmtpClient client = new SmtpClient() )
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = ( s, c, h, e ) => true;

                client.Connect( "<host>", 465, true );

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate( "<username>", "<password>" );

                client.Send( message );
                client.Disconnect( true );
            }
        }
    }
}
