using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.S3.MicroZoo
{
    public interface IMailer
    {
        void SendMail( string subject, string content );
    }
}
