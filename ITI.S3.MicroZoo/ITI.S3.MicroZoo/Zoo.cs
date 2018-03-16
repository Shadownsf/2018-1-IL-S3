using System.Collections.Generic;

namespace ITI.S3.MicroZoo
{
    public class Zoo
    {
        readonly Dictionary<string, Bird> _birds;

        public Zoo()
        {
            _birds = new Dictionary<string, Bird>();
        }

        public Bird CreateBird( string name )
        {
            Bird bird = new Bird( name );
            _birds.Add( name, bird );
            return bird;
        }

        public Bird FindBird( string name )
        {
            return _birds[ name ];
        }
    }
}
