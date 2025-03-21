using MyFirstWebApplication;
using NUnit.Framework;
using System;

namespace TestSchool
{
    public class PersonTests
    {
        private Person _person;

        [SetUp]
        public void Setup()
        {
            _person = new Person(new DateTime(2000, 1, 1), "männlich");
        }

        [Test]
        public void Geschlecht_ValidMale_SetsCorrectly()
        {
            _person = new Person(DateTime.Now, "männlich");

            var geschlecht = _person.Geschlecht;

            Assert.AreEqual("männlich", geschlecht);
        }

        [Test]
        public void Geschlecht_ValidFemale_SetsCorrectly()
        {
            _person = new Person(DateTime.Now, "weiblich");

            var geschlecht = _person.Geschlecht;

            Assert.AreEqual("weiblich", geschlecht);
        }

        [Test]
        public void Geschlecht_InvalidValue_SetsToUnbekannt()
        {
            _person = new Person(DateTime.Now, "invalid");

            var geschlecht = _person.Geschlecht;

            Assert.AreEqual("unbekannt", geschlecht);
        }

        [Test]
        public void Geburtstag_SetCorrectly()
        {
            var birthDate = new DateTime(2000, 1, 1);
            _person = new Person(birthDate, "männlich");

            var result = _person.Geburtstag;

            Assert.AreEqual(birthDate, result);
        }
    }
}