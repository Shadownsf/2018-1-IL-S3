using System;

namespace ITI.S3.MicroZoo
{
    public class Bird : Animal
    {
        bool _isFlying;
        Vector _direction;
        float _stamina;

        internal Bird( Zoo context, string name )
            : base( context, name )
        {
            _isFlying = true;
            _stamina = 1.0f;
        }

        Vector GetRandomDirection()
        {
            double x = Context.GetNextRandomDouble( -1.0, 1.0 );
            double y = Math.Sqrt( 1 - x * x );
            if( Context.GetNextRandomDouble( 0, 1 ) < 0.5 ) y = -y;

            return new Vector( x, y );
        }

        protected internal override void Update()
        {
            if( _isFlying )
            {
                Position = MathHelpers.MoveTo( Position, _direction, Context.Options.BirdSpeed );
                Position = MathHelpers.Limit( Position, -1.0, 1.0 );
                UpdateDirection();
                _stamina -= Context.Options.ExhaustionRate;
                _stamina = MathHelpers.Limit( _stamina, 0.0f, 1.0f );
                if( _stamina == 0.0f ) _isFlying = false;
            }
            else
            {
                _stamina += Context.Options.ExhaustionRate;
                _stamina = MathHelpers.Limit( _stamina, 0.0f, 1.0f );
                if( _stamina == 1.0f ) _isFlying = true;
            }
        }

        internal void Kill()
        {
            Context.OnDie( this );
            IsAlive = false;

            Context.Mailer.SendMail( "A bird is dead", string.Format( "{0} is dead.", Name ) );
        }

        void UpdateDirection()
        {
            double beta = Context.GetNextRandomDouble( Math.PI / -8.0, Math.PI / 8.0 );
            double alpha = Math.Acos( _direction.X );
            double x = Math.Cos( alpha + beta );

            alpha = Math.Asin( _direction.Y );
            double y = Math.Sin( alpha + beta );

            _direction = new Vector( x, y );
        }

        public bool IsFlying => _isFlying;
    }
}
