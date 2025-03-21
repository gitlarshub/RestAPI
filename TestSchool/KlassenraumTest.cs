using MyFirstWebApplication;
using NUnit.Framework;

namespace TestSchool
{
    public class KlassenraumTests
    {
        private Klassenraum _klassenraum;

        [SetUp]
        public void Setup()
        {
            _klassenraum = new Klassenraum(50.5f, 30, true);
        }

        [Test]
        public void Constructor_SetsPropertiesCorrectly()
        {
            Assert.AreEqual(50.5f, _klassenraum.RaumInQm);
            Assert.AreEqual(30, _klassenraum.Plaetze);
            Assert.IsTrue(_klassenraum.HasCynap);
            Assert.IsEmpty(_klassenraum.SchuelerImRaum);
        }

        [Test]
        public void SchuelerImRaum_CanAddSchueler()
        {
            var schueler = new Schueler("10A", DateTime.Now, "männlich");

            _klassenraum.SchuelerImRaum.Add(schueler);

            Assert.AreEqual(1, _klassenraum.SchuelerImRaum.Count);
            Assert.AreEqual(schueler, _klassenraum.SchuelerImRaum[0]);
        }
    }
}