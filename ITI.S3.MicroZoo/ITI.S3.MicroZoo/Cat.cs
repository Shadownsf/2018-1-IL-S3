using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.S3.MicroZoo
{
    public class Cat
    {
        readonly Zoo _context;
        string _name;

        internal Cat( Zoo context, string name )
        {
            _context = context;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _context.OnRename( this, value );
                _name = value;
            }
        }
    }
}
