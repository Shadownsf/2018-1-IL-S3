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
            Copy( _values, newValues, 0, 0, _values.Length );
            _values = newValues;
        }

        public void Remove( int index )
        {
            for( int i = 0; i < _count - index - 1; i++ ) _values[ index + i ] = _values[ index + i + 1 ];
            _count--;
        }

        public void InsertAt( int index, string s )
        {
            string[] dest;
            if( _count >= _values.Length )
            {
                dest = new string[ _values.Length * 2 ];
                Copy( _values, dest, 0, 0, index );
            }
            else
            {
                dest = _values;
            }

            Copy( _values, dest, index, 1, _values.Length - index );

            if( _count >= _values.Length ) _values = dest;

            _values[ index ] = s;
            _count++;
        }

        void Copy( string[] src, string[] dest, int start, int offset, int length )
        {
            for( int i = 0; i < length; i++ )
            {
                dest[ start + length - 1 - i + offset ] = src[ start + length - 1 - i ];
            }
        }
    }
}
