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
    }
}
