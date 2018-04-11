using System;
using NUnit.Framework;

namespace ITI.S3.MicroZoo.Tests
{
    [TestFixture]
    public class ZooTests
    {
        [Test]
        public void create_some_birds()
        {
            Zoo sut = new Zoo( new FakeMailer() );

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
            Zoo sut = new Zoo( new FakeMailer() );
            Bird jean = sut.CreateBird( "Jean" );
            Bird pierre = sut.CreateBird( "Pierre" );
            Bird titi = sut.CreateBird( "Titi" );

            Assert.That( sut.FindBird( "Pierre" ), Is.SameAs( pierre ) );
            Assert.That( sut.FindBird( "Jean" ), Is.SameAs( jean ) );
            Assert.That( sut.FindBird( "Titi" ), Is.SameAs( titi ) );
        }

        [Test]
        public void create_some_cats()
        {
            Zoo sut = new Zoo( new FakeMailer() );

            Cat robert = sut.CreateCat( "Robert" );
            Cat marie = sut.CreateCat( "Marie" );
            Cat denis = sut.CreateCat( "Denis" );

            Assert.That( robert.Name, Is.EqualTo( "Robert" ) );
            Assert.That( marie.Name, Is.EqualTo( "Marie" ) );
            Assert.That( denis.Name, Is.EqualTo( "Denis" ) );
        }

        [Test]
        public void find_cat_by_name()
        {
            Zoo sut = new Zoo( new FakeMailer() );
            Cat robert = sut.CreateCat( "Robert" );
            Cat marie = sut.CreateCat( "Marie" );
            Cat denis = sut.CreateCat( "Denis" );

            Assert.That( sut.FindCat( "Robert" ), Is.SameAs( robert ) );
            Assert.That( sut.FindCat( "Marie" ), Is.SameAs( marie ) );
            Assert.That( sut.FindCat( "Denis" ), Is.SameAs( denis ) );
        }

        [Test]
        public void rename_animals()
        {
            Zoo sut = new Zoo( new FakeMailer() );
            Cat cat1 = sut.CreateCat( "Robert" );
            Cat cat2 = sut.CreateCat( "Marie" );
            Bird bird1 = sut.CreateBird( "Pierre" );
            Bird bird2 = sut.CreateBird( "Titi" );

            cat1.Name = "Georges";
            bird1.Name = "Alban";

            Assert.That( cat1.Name, Is.EqualTo( "Georges" ) );
            Assert.That( bird1.Name, Is.EqualTo( "Alban" ) );

            Assert.That( sut.FindCat( "Georges" ), Is.SameAs( cat1 ) );
            Assert.That( sut.FindBird( "Alban" ), Is.SameAs( bird1 ) );
            Assert.Throws<ArgumentException>( () => sut.FindCat( "Robert" ) );
            Assert.Throws<ArgumentException>( () => sut.FindBird( "Pierre" ) );
        }
    }
}
