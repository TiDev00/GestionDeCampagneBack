using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuiviCampagnesController : ControllerBase
    {
        private ISuiviCampagne _SuiviCampagneData;
    

        public SuiviCampagnesController(ISuiviCampagne SuiviCampagneData, IContact ContactData)
        {
            _SuiviCampagneData = SuiviCampagneData;
          
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllSuiviCampagnes()
        {
            return Ok(_SuiviCampagneData.GetSuiviCampagnes());
        }

        [HttpGet("{id}", Name = "GetSuiviCampagneById")]
        public IActionResult GetSuiviCampagneById(int id)
        {
            var SuiviCampagne = _SuiviCampagneData.GetSuiviCampagneById(id);
            if (SuiviCampagne != null)
            {
                return Ok(SuiviCampagne);

            }
            return NotFound($"Un SuiviCampagne avec l'id : {id} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<SuiviCampagne> AddSuiviCampagne(SuiviCampagne SuiviCampagne)
        {

            var verifiId = _SuiviCampagneData.GetSuiviCampagneById(SuiviCampagne.Id);

            if (verifiId == null)
            {
                _SuiviCampagneData.AddSuiviCampagne(SuiviCampagne);
                _SuiviCampagneData.SaveChanges();

                return CreatedAtRoute(nameof(GetSuiviCampagneById), new { Id = SuiviCampagne.Id }, SuiviCampagne);
            }
            else
            {
                return NotFound($"Un SuiviCampagne avec le Id : {SuiviCampagne.Id} existe déjà");

            }


            // return Ok(categorireadDto);
        }

        [HttpPut("put/{id}")]
        public ActionResult<SuiviCampagne> PutSuiviCampagne(SuiviCampagne Suivi, int id)
        {
            var SuiviCampagne = _SuiviCampagneData.GetSuiviCampagneById(id);
            if (SuiviCampagne != null)
            {
                _SuiviCampagneData.EditSuiviCampagne(Suivi, id);
                _SuiviCampagneData.SaveChanges();
                return CreatedAtRoute(nameof(GetSuiviCampagneById), new { Id = SuiviCampagne.Id }, SuiviCampagne);
            }
            return NotFound($"Un SuiviCampagne avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<SuiviCampagne> DeleteSuiviCampagne(int id)
        {

            var SuiviCampagne = _SuiviCampagneData.GetSuiviCampagneById(id);
            if (SuiviCampagne != null)
            {
                _SuiviCampagneData.DeleteSuiviCampagne(SuiviCampagne);
                _SuiviCampagneData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un SuiviCampagne avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
