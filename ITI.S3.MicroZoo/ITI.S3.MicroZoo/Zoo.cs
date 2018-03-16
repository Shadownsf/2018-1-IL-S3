using System;
using System.Collections.Generic;

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
            Bird bird = new Bird( this, name );
            _birds.Add( name, bird );
            return bird;
        }

        public Bird FindBird( string name )
        {
            Bird bird;
            if( !_birds.TryGetValue( name, out bird ) ) throw new ArgumentException( "Unknown bird.", nameof( name ) );
            return bird;
        }

        public Cat CreateCat( string name )
        {
            Cat cat = new Cat( this, name );
            _cats.Add( name, cat );
            return cat;
        }

        public Cat FindCat( string name )
        {
            Cat cat;
            if( !_cats.TryGetValue( name, out cat ) ) throw new ArgumentException( "Unknown cat.", nameof( name ) );
            return cat;
        }

        internal void OnRename( Cat cat, string newName )
        {
            _cats.Remove( cat.Name );
            _cats.Add( newName, cat );
        }

        internal void OnRename( Bird bird, string newName)
        {
            _birds.Remove( bird.Name );
            _birds.Add( newName, bird );
        }
    }
}
