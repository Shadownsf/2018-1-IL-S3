using System.IO;
using System.Text;

namespace ITI.S3.MicroZoo
{
    class FileSystemMailer : IMailer
    {
        public void SendMail( string subject, string text )
        {
            string content = new StringBuilder().Append( subject )
                                                .AppendLine()
                                                .Append( text )
                                                .AppendLine()
                                                .AppendLine()
                                                .ToString();
            File.AppendAllText( @"<file path>", content );
        }
    }
}
