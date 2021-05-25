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
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NiveauDeVisibilitesController : ControllerBase
    {
        private INiveauDeVisibilite _NiveauDeVisibiliteData;

        public NiveauDeVisibilitesController(INiveauDeVisibilite NiveauDeVisibiliteData)
        {
            _NiveauDeVisibiliteData = NiveauDeVisibiliteData;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllNiveauDeVisibilites()
        {
            return Ok(_NiveauDeVisibiliteData.GetNiveauDeVisibilites());
        }

        [HttpGet("{id}", Name = "GetNiveauDeVisibiliteById")]
        public IActionResult GetNiveauDeVisibiliteById(int id)
        {
            var NiveauDeVisibilite = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteById(id);
            if (NiveauDeVisibilite != null)
            {
                return Ok(NiveauDeVisibilite);

            }
            return NotFound($"Un NiveauDeVisibilite avec l'id : {id} n'existe pas");
        }

        [HttpGet("libelle/{libelle}", Name = "GetNiveauDeVisibiliteByLibelle")]
        public IActionResult GetNiveauDeVisibiliteByLibelle(string libelle)
        {
            var NiveauDeVisibilite = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteByLibelle(libelle);
            if (NiveauDeVisibilite != null)
            {
                return Ok(NiveauDeVisibilite);

            }
            return NotFound($"Un NiveauDeVisibilite avec le libelle : {libelle} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<NiveauDeVisibilite> AddNiveauDeVisibilite(NiveauDeVisibilite NiveauDeVisibilite)
        {
            var verifiLibelle = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteByLibelle(NiveauDeVisibilite.Libelle);

            if (verifiLibelle == null)
            {
                _NiveauDeVisibiliteData.AddNiveauDeVisibilite(NiveauDeVisibilite);
                _NiveauDeVisibiliteData.SaveChanges();

                return CreatedAtRoute(nameof(GetNiveauDeVisibiliteById), new { Id = NiveauDeVisibilite.Id }, NiveauDeVisibilite);
            }
            else
            {
                return NotFound($"Un NiveauDeVisibilite avec le libelle : {NiveauDeVisibilite.Libelle} existe déjà");

            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<NiveauDeVisibilite> PutNiveauDeVisibilite(NiveauDeVisibilite Niv, int id)
        {
            var NiveauDeVisibilite = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteById(id);
            if (NiveauDeVisibilite != null)
            {
                var verifiLibelle = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteByLibelle(Niv.Libelle);
                if (verifiLibelle == null)
                {
                    _NiveauDeVisibiliteData.EditNiveauDeVisibilite(Niv, id);
                    _NiveauDeVisibiliteData.SaveChanges();
                    return CreatedAtRoute(nameof(GetNiveauDeVisibiliteById), new { Id = NiveauDeVisibilite.Id }, NiveauDeVisibilite);
                }
                else
                if (verifiLibelle.Id == NiveauDeVisibilite.Id)
                {
                    _NiveauDeVisibiliteData.EditNiveauDeVisibilite(Niv, id);
                    _NiveauDeVisibiliteData.SaveChanges();
                    return CreatedAtRoute(nameof(GetNiveauDeVisibiliteById), new { Id = NiveauDeVisibilite.Id }, NiveauDeVisibilite);
                }
                else
                {
                    return NotFound($"Un NiveauDeVisibilite avec le libelle : {Niv.Libelle} existe déjà");

                }

            }
            return NotFound($"Un NiveauDeVisibilite avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<NiveauDeVisibilite> DeleteNiveauDeVisibilite(int id)
        {

            var NiveauDeVisibilite = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteById(id);
            if (NiveauDeVisibilite != null)
            {
                _NiveauDeVisibiliteData.DeleteNiveauDeVisibilite(NiveauDeVisibilite);
                _NiveauDeVisibiliteData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un NiveauDeVisibilite avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
