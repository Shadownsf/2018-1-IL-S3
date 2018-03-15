using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.WordLib.Tests
{
    [TestFixture]
    public class WordTests
    {
        [TestCase( "word" )]
        [TestCase( "Word" )]
        [TestCase( "WoRd" )]
        public void T01_Original_ShouldReturnTheOriginalString( string input )
        {
            Word sut = new Word( input );
            string original = sut.Original;
            Assert.That( original, Is.EqualTo( input ) );
        }

        [TestCase( null )]
        [TestCase( "" )]
        [TestCase( " " )]
        [TestCase( "word containing whitespaces" )]
        [TestCase( "wordContainingNotLetterCharacter." )]
        [TestCase( "w0rdContainingN0tLetterCharacter" )]
        public void T02_Constructor_WithInvalidInput_ShoudThrowArgumentException( string invalidInput )
        {
            Assert.Throws<ArgumentException>( () => new Word( invalidInput ) );
        }

        [TestCase( "word" )]
        [TestCase( "Word" )]
        [TestCase( "WoRd" )]
        public void T03_Value_ShouldReturnLowercasedWord( string input )
        {
            Word sut = new Word( input );
            string value = sut.Value;
            Assert.That( value, Is.EqualTo( "word" ) );
        }

        [TestCase( "word", 4 )]
        [TestCase( "Honorificabilitudinitatibus", 27 )]
        public void T04_Length_ShouldReturnTheLengthOfTheWord( string input, int expectedLength )
        {
            Word sut = new Word( input );
            int length = sut.Length;
            Assert.That( length, Is.EqualTo( expectedLength ) );
        }

        [TestCase( "Noon", true )]
        [TestCase( "noon", true )]
        [TestCase( "noon", true )]
        [TestCase( "Kayak", true )]
        [TestCase( "kayAk", true )]
        [TestCase( "Palindrome", false )]
        public void T05_IsPalindrome_ShouldReturnTheCorrectResult( string input, bool expected )
        {
            Word sut = new Word( input );
            bool isPalindrome = sut.IsPalindrome;
            Assert.That( isPalindrome, Is.EqualTo( expected ) );
        }

        [TestCase( "Word", 'W', 1 )]
        [TestCase( "Word", 'w', 1 )]
        [TestCase( "passengers", 'S', 3 )]
        [TestCase( "passengers", 's', 3 )]
        public void T06_GetCharacterCount_ShouldReturnTheCorrectResult( string word, char c, int expectedCount )
        {
            Word sut = new Word( word );
            int count = sut.GetCharacterCount( c );
            Assert.That( count, Is.EqualTo( expectedCount ) );
        }

        [TestCase( "Sound", "Bound", true )]
        [TestCase( "Sound", "BOUND", true )]
        [TestCase( "Sound", "wound", true )]
        [TestCase( "Sound", "found", true )]
        [TestCase( "In", "Bin", true )]
        [TestCase( "Bin", "in", true )]
        [TestCase( "I", "Hi", true )]
        [TestCase( "Hi", "I", true )]
        [TestCase( "Sound", "find", false )]
        [TestCase( "Sound", "and", false )]
        [TestCase( "Sound", "Rhyme", false )]
        public void T07_IsRhymingWith_ShouldReturnTheCorrectResult( string word1, string word2, bool expected )
        {
            Word sut = new Word( word1 );
            Word candidate = new Word( word2 );

            bool isRhyming = sut.IsRhymingWith( candidate );

            Assert.That( isRhyming, Is.EqualTo( expected ) );
        }

        [TestCase( "Dictionary", "Indicatory", true )]
        [TestCase( "Elvis", "Lives", true )]
        [TestCase( "Dictionary", "Anagram", false )]
        [TestCase( "Dictionary", "Anagram", false )]
        [TestCase( "Anagram", "Anagrams", false )]
        public void T08_IsAnagramOf_ShouldReturnTheCorrectResult( string word1, string word2, bool expected )
        {
            Word sut = new Word( word1 );
            Word candidate = new Word( word2 );

            bool isAnagram = sut.IsAnagramOf( candidate );

            Assert.That( isAnagram, Is.EqualTo( expected ) );
        }

        [TestCase( "test", "tavest" )]
        [TestCase( "essai", "avessavai" )]
        [TestCase( "bonjour", "bavonjavour" )]
        [TestCase( "javanais", "javavavanavais" )]
        [TestCase( "papaye", "pavapavayave" )]
        public void T09_ToJavanais_ShouldReturnJavanizedWord( string word, string javanizedWord )
        {
            Word sut = new Word( word );

            Word javanized = sut.ToJavanais();

            Word expected = new Word( javanizedWord );
            Assert.That( javanized.Value, Is.EqualTo( expected.Value ) );
        }
    }
}
