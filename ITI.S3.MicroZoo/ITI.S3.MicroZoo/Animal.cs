using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.S3.MicroZoo
{
    public abstract class Animal
    {
        readonly Zoo _context;
        string _name;
        Vector _position;
        bool _isAlive;

        protected Animal( Zoo context, string name )
        {
            _context = context;
            _name = name;
            _position = context.GetNextRandomPosition();
            _isAlive = true;
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

        public double X => _position.X;

        public double Y => _position.Y;

        public bool IsAlive
        {
            get { return _isAlive; }
            protected set { _isAlive = value; }
        }

        protected internal abstract void Update();

        protected Zoo Context => _context;

        protected internal Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }


    }
}
