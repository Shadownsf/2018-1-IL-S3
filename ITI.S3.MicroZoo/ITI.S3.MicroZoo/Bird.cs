using System;

namespace ITI.S3.MicroZoo
{
    public class Bird
    {
        readonly Zoo _context;
        string _name;
        Vector _position;
        bool _isAlive;
        bool _isFlying;
        Vector _direction;
        float _stamina;

        internal Bird( Zoo context, string name )
        {
            _context = context;
            _name = name;
            _position = context.GetNextRandomPosition();
            _isAlive = true;
            _isFlying = true;
            _direction = GetRandomDirection();
            _stamina = 1.0f;
        }

        Vector GetRandomDirection()
        {
            double x = _context.GetNextRandomDouble( -1.0, 1.0 );
            double y = Math.Sqrt( 1 - x * x );
            if( _context.GetNextRandomDouble( 0, 1 ) < 0.5 ) y = -y;

            return new Vector( x, y );
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
            if( _isFlying )
            {
                _position = MathHelpers.MoveTo( _position, _direction, _context.Options.BirdSpeed );
                _position = MathHelpers.Limit( _position, -1.0, 1.0 );
                UpdateDirection();
                _stamina -= _context.Options.ExhaustionRate;
                _stamina = MathHelpers.Limit( _stamina, 0.0f, 1.0f );
                if( _stamina == 0.0f ) _isFlying = false;
            }
            else
            {
                _stamina += _context.Options.ExhaustionRate;
                _stamina = MathHelpers.Limit( _stamina, 0.0f, 1.0f );
                if( _stamina == 1.0f ) _isFlying = true;
            }
        }

        internal void Kill()
        {
            _context.OnDie( this );
            _isAlive = false;

            _context.Mailer.SendMail( "A bird is dead", string.Format( "{0} is dead.", _name ) );
        }

        void UpdateDirection()
        {
            double beta = _context.GetNextRandomDouble( Math.PI / -8.0, Math.PI / 8.0 );
            double alpha = Math.Acos( _direction.X );
            double x = Math.Cos( alpha + beta );

            alpha = Math.Asin( _direction.Y );
            double y = Math.Sin( alpha + beta );

            _direction = new Vector( x, y );
        }

        internal Vector Position => _position;

        public bool IsFlying => _isFlying;
    }
}
