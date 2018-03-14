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
        [Test]
        public void fill_a_flask()
        {
            Flask sut = new Flask( 2 );
            sut.Fill( 1 );
            Assert.AreEqual( 1, sut.Volume );
        }

        [Test]
        public void empty_flask()
        {
            Flask sut = new Flask( 3 );
            sut.Fill( 2 );

            sut.Empty( 1 );

            Assert.That( sut.Volume, Is.EqualTo( 1 ) );
        }
    }
}
