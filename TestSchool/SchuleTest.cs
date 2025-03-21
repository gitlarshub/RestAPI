using MyFirstWebApplication;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestSchool
{
    public class SchuleTests
    {
        private Schule _schule;

        [SetUp]
        public void Setup()
        {
            _schule = new Schule();
        }

        [Test]
        public void AddSchuelerToSchule_IncreasesCount()
        {
            var schueler = new Schueler("10A", DateTime.Now, "männlich");

            _schule.AddSchuelerToSchule(schueler);

            Assert.AreEqual(1, _schule.AnzahlSchueler);
            Assert.IsTrue(_schule.SchuelerList.Contains(schueler));
        }

        [Test]
        public void AddKlassenraumToSchule_IncreasesCount()
        {
            var klassenraum = new Klassenraum(50.5f, 30, true);

            _schule.AddKlassenraumToSchule(klassenraum);

            Assert.AreEqual(1, _schule.AnzahlKlassenRaum);
            Assert.IsTrue(_schule.KlassenraumList.Contains(klassenraum));
        }

        [Test]
        public void AnzahlRauemeCynap_ReturnsCorrectRooms()
        {
            var room1 = new Klassenraum(50.5f, 30, true);
            var room2 = new Klassenraum(60f, 40, false);
            var room3 = new Klassenraum(70f, 50, true);
            _schule.AddKlassenraumToSchule(room1);
            _schule.AddKlassenraumToSchule(room2);
            _schule.AddKlassenraumToSchule(room3);

            var cynapRooms = _schule.AnzahlRauemeCynap();

            Assert.AreEqual(2, cynapRooms.Count);
            Assert.IsTrue(cynapRooms.Contains(room1));
            Assert.IsTrue(cynapRooms.Contains(room3));
        }

        [Test]
        public void DurchschnittsalterSchueler_CalculatesCorrectly()
        {
            var schueler1 = new Schueler("10A", DateTime.Today.AddYears(-15), "männlich"); 
            var schueler2 = new Schueler("10B", DateTime.Today.AddYears(-16), "weiblich"); 
            _schule.AddSchuelerToSchule(schueler1);
            _schule.AddSchuelerToSchule(schueler2);

            var avgAge = _schule.DurchschnittsalterSchueler();

            Assert.AreEqual(15.5f, avgAge);
        }

        [Test]
        public void BerechneFrauenanteilInProzent_CalculatesCorrectly()
        {
            var schueler1 = new Schueler("10A", DateTime.Now, "männlich");
            var schueler2 = new Schueler("10A", DateTime.Now, "weiblich");
            var schueler3 = new Schueler("10B", DateTime.Now, "männlich");
            var schuelerList = new List<Schueler> { schueler1, schueler2, schueler3 };

            var frauenanteil = _schule.BerechneFrauenanteilInProzent(schuelerList, "10A");

            Assert.AreEqual(50.0, frauenanteil); 
        }

        [Test]
        public void BerechneFrauenanteilInProzent_ReturnsZero_WhenNoStudentsInClass()
        {
            var schuelerList = new List<Schueler>();

            var frauenanteil = _schule.BerechneFrauenanteilInProzent(schuelerList, "10A");

            Assert.AreEqual(0, frauenanteil);
        }

        [Test]
        public void KannKlasseUnterrichten_ReturnsTrue_WhenEnoughSeats()
        {
            var schueler1 = new Schueler("10A", DateTime.Now, "männlich");
            var schueler2 = new Schueler("10A", DateTime.Now, "weiblich");
            var klassenraum = new Klassenraum(50f, 5, true);
            _schule.AddSchuelerToSchule(schueler1);
            _schule.AddSchuelerToSchule(schueler2);
            _schule.AddKlassenraumToSchule(klassenraum);

            var result = _schule.KannKlasseUnterrichten("10A", "50");

            Assert.IsTrue(result); 
        }

        [Test]
        public void KannKlasseUnterrichten_ReturnsFalse_WhenNotEnoughSeats()
        {
            var schueler1 = new Schueler("10A", DateTime.Now, "männlich");
            var schueler2 = new Schueler("10A", DateTime.Now, "weiblich");
            var klassenraum = new Klassenraum(50f, 1, true); 
            _schule.AddSchuelerToSchule(schueler1);
            _schule.AddSchuelerToSchule(schueler2);
            _schule.AddKlassenraumToSchule(klassenraum);

            var result = _schule.KannKlasseUnterrichten("10A", "50");

            Assert.IsFalse(result); 
        }

        [Test]
        public void KannKlasseUnterrichten_ReturnsFalse_WhenRoomNotFound()
        {
            var schueler1 = new Schueler("10A", DateTime.Now, "männlich");
            _schule.AddSchuelerToSchule(schueler1);

            var result = _schule.KannKlasseUnterrichten("10A", "50");

            Assert.IsFalse(result); 
        }

        [Test]
        public void AnzahlSchuelerGeschlecht_ReturnsCorrectString()
        {
            var schueler1 = new Schueler("10A", DateTime.Now, "männlich");
            var schueler2 = new Schueler("10A", DateTime.Now, "weiblich");
            _schule.AddSchuelerToSchule(schueler1);
            _schule.AddSchuelerToSchule(schueler2);

            var result = _schule.AnzahlSchuelerGeschlecht;

            Assert.AreEqual("männliche: 1 / weibliche: 1", result);
        }

        [Test]
        public void AnzahlKlassen_ReturnsCorrectCount()
        {
            var schueler = new Schueler("10A", DateTime.Now, "männlich");
            schueler.AddKlasse("10B");

            var result = _schule.AnzahlKlassen(schueler);

            Assert.AreEqual(2, result); 
        }
    }
}