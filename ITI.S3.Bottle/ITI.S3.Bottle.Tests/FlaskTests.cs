using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.S3.Bottle.Tests
{
    [TestFixture]
    public class FlaskTests
    {
        [TestCase( 0, 0 )]
        [TestCase( 1, 1 )]
        [TestCase( 3, 2 )]
        public void fill_a_flask( int volume, int expected )
        {
            Flask sut = new Flask( 2 );
            sut.Fill( volume );
            Assert.AreEqual( expected, sut.Volume );
        }

        [Test]
        public void empty_flask()
        {
            Flask sut = new Flask( 3 );
            sut.Fill( 2 );

            sut.Empty( 1 );

            Assert.That( sut.Volume, Is.EqualTo( 1 ) );
        }

        [Test]
        public void total_empty()
        {
            Flask sut = new Flask( 3 );
            sut.Fill( 2 );

            sut.Empty();

            Assert.That( sut.Volume, Is.EqualTo( 0 ) );
        }

        [TestCase( 0 )]
        [TestCase( -1 )]
        [TestCase( -100 )]
        public void initializes_an_invalid_flask_throws_an_exception( int maxCapacity )
        {
            Assert.Throws<ArgumentException>( () => new Flask( maxCapacity ) );
        }

        [Test]
        public void fill_with_negative_volume_should_throws_an_exception()
        {
            Flask sut = new Flask( 3 );
            Assert.Throws<ArgumentException>( () => sut.Fill( -1 ) );
        }
    }
}
