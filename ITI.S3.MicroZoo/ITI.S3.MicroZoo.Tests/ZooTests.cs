using NUnit.Framework;

namespace ITI.S3.MicroZoo.Tests
{
    [TestFixture]
    public class ZooTests
    {
        [Test]
        public void create_some_birds()
        {
            Zoo sut = new Zoo();

            Bird jean = sut.CreateBird( "Jean" );
            Bird pierre = sut.CreateBird( "Pierre" );
            Bird titi = sut.CreateBird( "Titi" );

            Assert.That( jean.Name, Is.EqualTo( "Jean" ) );
            Assert.That( pierre.Name, Is.EqualTo( "Pierre" ) );
            Assert.That( titi.Name, Is.EqualTo( "Titi" ) );
        }

        [Test]
        public void find_bird_by_name()
        {
            Zoo sut = new Zoo();
            Bird jean = sut.CreateBird( "Jean" );
            Bird pierre = sut.CreateBird( "Pierre" );
            Bird titi = sut.CreateBird( "Titi" );

            Assert.That( sut.FindBird( "Pierre" ), Is.SameAs( pierre ) );
            Assert.That( sut.FindBird( "Jean" ), Is.SameAs( jean ) );
            Assert.That( sut.FindBird( "Titi" ), Is.SameAs( titi ) );
        }
    }
}
