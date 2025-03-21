using Microsoft.AspNetCore.Mvc;
using MyFirstWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebApplication.Controller
{
    [ApiController]
    [Route("api/schule")]
    public class SchuleController : ControllerBase
    {
        private static Schule schule = new Schule();

        [HttpPost("addSchueler")]
        public IActionResult AddSchueler([FromBody] Schueler schueler)
        {
            if (schueler == null)
            {
                return BadRequest("Sch�lerdaten fehlen.");
            }
            try
            {
                schule.AddSchuelerToSchule(schueler);
                return Ok("Sch�ler hinzugef�gt!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fehler beim Hinzuf�gen: {ex.Message}");
            }
        }

        [HttpGet("getAllSchueler")]
        public IActionResult GetAllSchueler()
        {
            return Ok(schule.SchuelerList);
        }

        [HttpGet("getSchuelerByKlasse/{klasse}")]
        public IActionResult GetSchuelerByKlasse(string klasse)
        {
            var schuelerInKlasse = schule.SchuelerList.Where(s => s.Klasse == klasse).ToList();
            return Ok(schuelerInKlasse);
        }

        [HttpGet("kannUnterrichten/{klasse}/{raumName}")]
        public IActionResult KannUnterrichten(string klasse, string raumName)
        {
            bool kannUnterrichten = schule.KannKlasseUnterrichten(klasse, raumName);
            return Ok(kannUnterrichten ? "Ja, die Klasse kann unterrichtet werden." : "Nein, es gibt nicht genug Pl�tze.");
        }
    }
}