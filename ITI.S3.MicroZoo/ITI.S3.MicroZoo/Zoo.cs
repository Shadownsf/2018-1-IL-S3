using System;
using System.Collections.Generic;

namespace ITI.S3.MicroZoo
{
    public class Zoo
    {
        readonly Dictionary<string, Animal> _animals;
        readonly Random _random;
        readonly ZooOptions _options;
        readonly IMailer _mailer;

        internal List<Bird> Birds
        {
            get
            {
                List<Bird> birds = new List<Bird>();
                foreach( Animal animal in _animals.Values )
                {
                    Bird bird = animal as Bird;
                    if( bird != null ) birds.Add( bird );
                }
                return birds;
            }
        }

        public Zoo()
            : this( null, null )
        {
        }

        public Zoo( ZooOptions options )
            : this( options, null )
        {
        }

        public Zoo( IMailer mailer )
            : this( null, mailer )
        {
        }

        public Zoo( ZooOptions options, IMailer mailer )
        {
            _animals = new Dictionary<string, Animal>();
            _random = new Random();
            // _options = options != null ? options : new ZooOptions();
            _options = options ?? new ZooOptions();
            _mailer = mailer ?? new Mailer();
        }

        public Bird CreateBird( string name )
        {
            Bird bird = new Bird( this, name );
            _animals.Add( name, bird );
            return bird;
        }

        public Bird FindBird( string name )
        {
            return FindAnimal<Bird>( name );
        }

        public Cat CreateCat( string name )
        {
            Cat cat = new Cat( this, name );
            _animals.Add( name, cat );
            return cat;
        }

        public Cat FindCat( string name )
        {
            return FindAnimal<Cat>( name );
        }

        T FindAnimal<T>( string name ) where T : Animal
        {
            Animal animal;
            if( !_animals.TryGetValue( name, out animal ) ) throw new ArgumentException( "Unknown animal.", nameof( name ) );
            if( !( animal is T ) ) throw new ArgumentException( "Unknown animal.", nameof( name ) );
            return ( T )animal;
        }

        internal void OnRename( Animal animal, string newName )
        {
            _animals.Remove( animal.Name );
            _animals.Add( newName, animal );
        }

        internal void OnDie( Animal animal )
        {
            _animals.Remove( animal.Name );
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
            List<Animal> animals = new List<Animal>();
            foreach( Animal a in _animals.Values ) animals.Add( a );
            foreach( Animal a in animals ) a.Update();
        }

        public ZooOptions Options
        {
            get { return _options; }
        }

        internal IMailer Mailer
        {
            get { return _mailer; }
        }
    }
}
