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
        Vector _position;
        bool _isAlive;

        internal Cat( Zoo context, string name )
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

        public bool IsAlive => _isAlive;

        internal void Update()
        {
            Bird closestBird = GetClosestBird();
            if( closestBird != null )
            {
                double distance = closestBird.Position.Sub(_position).Magnitude;
                if( !closestBird.IsFlying && distance < _context.Options.CatJumpDistance)
                {
                    _position = closestBird.Position;
                    closestBird.Kill();
                }
                else
                {
                    MoveToBird( closestBird );
                }
            }
        }

        void MoveToBird( Bird bird )
        {
            Vector target = bird.Position.Sub( _position );
            Vector direction = target.Mul( 1.0 / target.Magnitude );
            _position = MathHelpers.MoveTo( _position, direction, _context.Options.CatSpeed );
            _position = MathHelpers.Limit( _position, -1.0, 1.0 );
        }

        Bird GetClosestBird()
        {
            List<Bird> birds = _context.Birds;
            double closest = double.MaxValue;
            Bird closestBird = null;
            foreach( Bird bird in birds )
            {
                Vector v = bird.Position.Sub( _position );
                if( v.Magnitude < closest )
                {
                    closestBird = bird;
                    closest = v.Magnitude;
                }
            }

            return closestBird;
        }
    }
}
