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
    public class ModelesController : ControllerBase
    {
        private IModele _modelData;

        public ModelesController(IModele ModeleData)
        {
            _modelData = ModeleData;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllModeles()
        {
            return Ok(_modelData.GetModeles());
        }

        [HttpGet("{id}", Name = "GetModeleById")]
        public IActionResult GetModeleById(int id)
        {
            var Modele = _modelData.GetModeleById(id);
            if (Modele != null)
            {
                return Ok(Modele);

            }
            return NotFound($"Un Modele avec l'id : {id} n'existe pas");
        }

        [HttpGet("libelle/{libelle}", Name = "GetModeleByLille")]
        public IActionResult GetByLibelle(string libelle)
        {
            var Modele = _modelData.GetModeleByLibelle(libelle);
            if (Modele != null)
            {
                return Ok(Modele);

            }
            return NotFound($"Un Modele avec le libelle : {libelle} n'existe pas");
        }

        [HttpGet("code/{code}", Name = "GetModeleByCode")]
        public IActionResult GetModeleByCode(string code)
        {
            var Modele = _modelData.GetModeleByCode(code);
            if (Modele != null)
            {
                return Ok(Modele);

            }
            return NotFound($"Un Modele avec le code : {code} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<Modele> AddModele(Modele Modele)
        {
            var verifiLibelle = _modelData.GetModeleByLibelle(Modele.Libelle);

            if (verifiLibelle == null)
            {

                _modelData.AddModele(Modele);
                _modelData.SaveChanges();

                return CreatedAtRoute(nameof(GetModeleById), new { Id = Modele.Id }, Modele);
            }
            else
            {
                return NotFound($"Un Modele avec le libelle : {Modele.Libelle} existe déjà");

            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<Modele> PutModele(Modele mod, int id)
        {
            var Modele = _modelData.GetModeleById(id);
            if (Modele != null)
            {
                var verifiLibelle = _modelData.GetModeleByLibelle(mod.Libelle);
                if (verifiLibelle == null)
                {
                    _modelData.EditModele(mod, id);
                    _modelData.SaveChanges();
                    return CreatedAtRoute(nameof(GetModeleById), new { Id = Modele.Id }, Modele);
                }
                else
                if (verifiLibelle.Id == Modele.Id)
                {
                    _modelData.EditModele(mod, id);
                    _modelData.SaveChanges();
                    return CreatedAtRoute(nameof(GetModeleById), new { Id = Modele.Id }, Modele);
                }
                else
                {
                    return NotFound($"Un Modele avec le libelle : {mod.Libelle} existe déjà");

                }

            }
            return NotFound($"Un Modele avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<Modele> DeleteModele(int id)
        {

            var Modele = _modelData.GetModeleById(id);
            if (Modele != null)
            {
                _modelData.DeleteModele(Modele);
                _modelData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un Modele avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
