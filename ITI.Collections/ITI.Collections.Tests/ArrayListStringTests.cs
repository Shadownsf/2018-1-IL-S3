using System;
using NUnit.Framework;

namespace ITI.Collections.Tests
{
    [TestFixture]
    public class ArrayListStringTests
    {
        [Test]
        public void add_items()
        {
            ArrayListString sut = new ArrayListString();
            Assert.That( sut.Count, Is.EqualTo( 0 ) );

            sut.Add( "W" );
            Assert.That( sut.Count, Is.EqualTo( 1 ) );

            sut.Add( "A" );
            Assert.That( sut.Count, Is.EqualTo( 2 ) );

            sut.Add( "B" );
            Assert.That( sut.Count, Is.EqualTo( 3 ) );

            sut.Add( "Z" );
            Assert.That( sut.Count, Is.EqualTo( 4 ) );

            Assert.That( sut.GetAt( 0 ), Is.EqualTo( "W" ) );
            Assert.That( sut.GetAt( 1 ), Is.EqualTo( "A" ) );
            Assert.That( sut.GetAt( 2 ), Is.EqualTo( "B" ) );
            Assert.That( sut.GetAt( 3 ), Is.EqualTo( "Z" ) );
        }

        [Test]
        public void resize_arraylist()
        {
            ArrayListString sut = new ArrayListString();
            const int Count = 1000;

            for( int i = 0; i < Count; i++ ) sut.Add( string.Format( "Test-{0}", i ) );

            Assert.That( sut.Count, Is.EqualTo( Count ) );
            for( int i = 0; i < Count; i++ ) Assert.That( sut.GetAt( i ), Is.EqualTo( string.Format( "Test-{0}", i ) ) );
        }
    }
}
