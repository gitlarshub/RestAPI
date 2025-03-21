using MyFirstWebApplication;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestSchool
{
    public class SchuelerTests
    {
        private Schueler _schueler;

        [SetUp]
        public void Setup()
        {
            _schueler = new Schueler("10A", DateTime.Today.AddYears(-15), "männlich");
        }

        [Test]
        public void Alter_CalculatesCorrectly()
        {
            var alter = _schueler.Alter;

            Assert.AreEqual(15, alter);
        }

        [Test]
        public void AddKlasse_AddsNewClass()
        {
            _schueler.AddKlasse("10B");
            var classCount = _schueler.klassen.Count;

            Assert.AreEqual(2, classCount);
            Assert.IsTrue(_schueler.klassen.Contains("10B"));
        }

        [Test]
        public void AddKlasse_DoesNotAddDuplicate()
        {
            _schueler.AddKlasse("10A");
            var classCount = _schueler.klassen.Count;

            Assert.AreEqual(1, classCount); 
        }

        [Test]
        public void ZähleSchülerProKlasse_CountsCorrectly()
        {
            // Arrange
            var schueler1 = new Schueler("10A", DateTime.Now, "männlich");
            var schueler2 = new Schueler("10A", DateTime.Now, "weiblich");
            var schueler3 = new Schueler("10B", DateTime.Now, "männlich");
            var schuelerList = new List<Schueler> { schueler1, schueler2, schueler3 };

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                _schueler.ZähleSchülerProKlasse(schuelerList);
                var result = sw.ToString();

                // Assert
                Assert.IsTrue(result.Contains("Klasse 10B: 1 Schüler"));
            }
        }
    }
}