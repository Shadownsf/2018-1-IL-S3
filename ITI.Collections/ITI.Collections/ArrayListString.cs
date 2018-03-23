using System;

namespace ITI.Collections
{
    public class ArrayListString
    {
        string[] _values;
        int _count;

        public ArrayListString()
        {
            _values = new string[ 4 ];
        }

        public void Add( string s )
        {
            if( _count >= _values.Length ) Resize();
            _values[ _count ] = s;
            _count++;
        }

        public int Count
        {
            get { return _count; }
        }

        public string GetAt( int index )
        {
            return _values[ index ];
        }

        void Resize()
        {
            string[] newValues = new string[ _values.Length * 2 ];
            for( int i = 0; i < _values.Length; i++ ) newValues[ i ] = _values[ i ];
            _values = newValues;
        }

        public void Remove( int index )
        {
            throw new NotImplementedException();
        }
    }
}
