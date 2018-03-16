﻿using System.Collections.Generic;

namespace ITI.S3.MicroZoo
{
    public class Zoo
    {
        readonly Dictionary<string, Bird> _birds;
        readonly Dictionary<string, Cat> _cats;

        public Zoo()
        {
            _birds = new Dictionary<string, Bird>();
            _cats = new Dictionary<string, Cat>();
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

        public Cat CreateCat( string name )
        {
            Cat cat = new Cat( name );
            _cats.Add( name, cat );
            return cat;
        }

        public Cat FindCat(string name)
        {
            return _cats[ name ];
        }
    }
}
