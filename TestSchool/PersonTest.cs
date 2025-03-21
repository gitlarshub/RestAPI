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
            _person = new Person(new DateTime(2000, 1, 1), "m�nnlich");
        }

        [Test]
        public void Geschlecht_ValidMale_SetsCorrectly()
        {
            _person = new Person(DateTime.Now, "m�nnlich");

            var geschlecht = _person.Geschlecht;

            Assert.AreEqual("m�nnlich", geschlecht);
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
            _person = new Person(birthDate, "m�nnlich");

            var result = _person.Geburtstag;

            Assert.AreEqual(birthDate, result);
        }
    }
}