using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
