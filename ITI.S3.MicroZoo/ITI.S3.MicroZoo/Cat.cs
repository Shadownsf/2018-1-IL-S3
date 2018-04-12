using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.S3.MicroZoo
{
    public class Cat : Animal
    {

        internal Cat( Zoo context, string name )
            : base( context, name )
        {
        }

        protected internal override void Update()
        {
            Bird closestBird = GetClosestBird();
            if( closestBird != null )
            {
                double distance = closestBird.Position.Sub( Position ).Magnitude;
                if( !closestBird.IsFlying && distance < Context.Options.CatJumpDistance )
                {
                    Position = closestBird.Position;
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
            Vector target = bird.Position.Sub( Position );
            Vector direction = target.Mul( 1.0 / target.Magnitude );
            Position = MathHelpers.MoveTo( Position, direction, Context.Options.CatSpeed );
            Position = MathHelpers.Limit( Position, -1.0, 1.0 );
        }

        Bird GetClosestBird()
        {
            List<Bird> birds = Context.Birds;
            double closest = double.MaxValue;
            Bird closestBird = null;
            foreach( Bird bird in birds )
            {
                Vector v = bird.Position.Sub( Position );
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
