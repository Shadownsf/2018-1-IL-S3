using System;
using System.Collections.Generic;

namespace ITI.S3.MicroZoo
{
    public class Zoo
    {
        readonly Dictionary<string, Bird> _birds;
        readonly Dictionary<string, Cat> _cats;
        readonly Random _random;
        readonly ZooOptions _options;

        internal List<Bird> Birds
        {
            get
            {
                List<Bird> birds = new List<Bird>();
                foreach( Bird bird in _birds.Values ) birds.Add( bird );
                return birds;
            }
        }

        public Zoo()
            : this( null )
        {
        }

        public Zoo( ZooOptions options )
        {
            _birds = new Dictionary<string, Bird>();
            _cats = new Dictionary<string, Cat>();
            _random = new Random();
            // _options = options != null ? options : new ZooOptions();
            _options = options ?? new ZooOptions();
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

        internal void OnRename( Bird bird, string newName )
        {
            _birds.Remove( bird.Name );
            _birds.Add( newName, bird );
        }

        internal double GetNextRandomDouble( double min, double max )
        {
            return _random.NextDouble() * ( max - min ) + min;
        }

        internal Vector GetNextRandomPosition()
        {
            double x = GetNextRandomDouble( -1.0, 1.0 );
            double y = GetNextRandomDouble( -1.0, 1.0 );
            return new Vector( x, y );
        }

        public void Update()
        {
            foreach( Cat cat in _cats.Values ) cat.Update();
            foreach( Bird bird in _birds.Values ) bird.Update();
        }

        public ZooOptions Options
        {
            get { return _options; }
        }
    }
}
