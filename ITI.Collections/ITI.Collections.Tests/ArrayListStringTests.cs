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

        [Test]
        public void remove_items()
        {
            ArrayListString sut = new ArrayListString();
            sut.Add( "a" );
            sut.Add( "b" );
            sut.Add( "c" );
            sut.Add( "d" );
            sut.Add( "e" );
            sut.Add( "f" );

            sut.Remove( 2 );
            Assert.That( sut.Count, Is.EqualTo( 5 ) );
            Assert.That( sut.GetAt( 2 ), Is.EqualTo( "d" ) );

            sut.Remove( 0 );
            Assert.That( sut.Count, Is.EqualTo( 4 ) );
            Assert.That( sut.GetAt( 0 ), Is.EqualTo( "b" ) );

            sut.Remove( 3 );
            Assert.That( sut.Count, Is.EqualTo( 3 ) );
        }

        [Test]
        public void insert_item()
        {
            ArrayListString sut = new ArrayListString();
            sut.Add( "a" );
            sut.Add( "b" );
            sut.Add( "c" );

            sut.InsertAt( 0, "d" );
            sut.InsertAt( 4, "e" );
            sut.InsertAt( 2, "f" );

            Assert.That( sut.Count, Is.EqualTo( 6 ) );
            Assert.That( sut.GetAt( 0 ), Is.EqualTo( "d" ) );
            Assert.That( sut.GetAt( 1 ), Is.EqualTo( "a" ) );
            Assert.That( sut.GetAt( 2 ), Is.EqualTo( "f" ) );
            Assert.That( sut.GetAt( 3 ), Is.EqualTo( "b" ) );
            Assert.That( sut.GetAt( 4 ), Is.EqualTo( "c" ) );
            Assert.That( sut.GetAt( 5 ), Is.EqualTo( "e" ) );
        }
    }
}
