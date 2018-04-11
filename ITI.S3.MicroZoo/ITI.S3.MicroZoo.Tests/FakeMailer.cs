using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.S3.MicroZoo.Tests
{
    class FakeMailer : IMailer
    {
        public void SendMail( string subject, string content )
        {
        }
    }
}
