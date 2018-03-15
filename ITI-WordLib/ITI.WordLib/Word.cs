using System;

namespace ITI.WordLib
{
    public class Word
    {
        readonly string _original;

        public Word( string word )
        {
            if( string.IsNullOrWhiteSpace( word ) ) throw new ArgumentException( "The word must be not null nor white space.", nameof( word ) );
            foreach( var c in word )
            {
                if( !char.IsLetter( c ) ) throw new ArgumentException( "The word must contain only letters.", nameof( word ) );
            }

            _original = word;
        }

        public bool IsPalindrome
        {
            get
            {
                string value = Value;
                for( int i = 0; i < _original.Length / 2; i++ )
                {
                    if( value[ i ] != value[ value.Length - i - 1 ] ) return false;
                }

                return true;
            }
        }

        public int Length => _original.Length;

        public string Original => _original;

        public string Value => _original.ToLower();

        public int GetCharacterCount( char c )
        {
            char c1 = char.ToLower( c );
            string value = Value;
            int count = 0;
            foreach( char c2 in value )
            {
                if( c1 == c2 ) count++;
            }

            return count;
        }

        public bool IsRhymingWith( Word candidate )
        {
            int length = Length;
            int candidateLength = candidate.Length;
            string value = Value;
            string candidateValue = candidate.Value;
            int max = Math.Min( 3, Math.Min( length, candidateLength ) );
            for( int i = 0; i < max; i++ )
            {
                if( candidateValue[ candidateLength - i - 1 ] != value[ length - i - 1 ] ) return false;
            }

            return true;
        }

        public bool IsAnagramOf( Word candidate )
        {
            string value = Value;
            string candidateValue = candidate.Value;
            foreach( char c in value )
            {
                if( GetCharacterCount( c ) != candidate.GetCharacterCount( c ) ) return false;
            }

            return Length == candidate.Length;
        }

        public Word ToJavanais()
        {
            throw new NotImplementedException();
        }
    }
}
