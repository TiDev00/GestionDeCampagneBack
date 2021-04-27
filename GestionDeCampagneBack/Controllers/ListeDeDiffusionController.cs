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
    public class ListeDeDiffusionController : ControllerBase
    {
        private IListeDeDiffusion _listeListeData;

        public ListeDeDiffusionController(IListeDeDiffusion ListeDeDiffusionData)
        {
            _listeListeData = ListeDeDiffusionData;
        }
    // GET: api/<ValuesController>
    [HttpGet]
        public IActionResult GetAllListeDeDiffusions()
        {
            return Ok(_listeListeData.GetListeDiffusion());
        }

    [HttpGet("{id}", Name = "GetListeDiffusionById")]
        public IActionResult GetListeDiffusionById(int id)
        {
            var ListeDiffusion = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiffusion != null)
            {
                return Ok(ListeDiffusion);

            }
            return NotFound($"Une Liste de Diffusion avec l'id : {id} n'existe pas");
        }

    [HttpGet("titre/{titre}", Name = "GetListeDiffusionByTitre")]
        public IActionResult GetListeDiffusionByTitre(string titre)
        {
            var ListeDiffusion = _listeListeData.GetListeDiffusionByTitre(titre);
            if (ListeDiffusion != null)
            {
                return Ok(ListeDiffusion);

            }
            return NotFound($"Une liste de Diffusion avec le titre : {titre} n'existe pas");
        }

        [HttpGet("reference/{reference}", Name = "GetListeDiffusionByReference")]
        public IActionResult GetListediffusionByRef(string reference)
        {
            var ListeDiffusion = _listeListeData.GetListeDiffusionByReference(reference);
            if (ListeDiffusion != null)
            {
                return Ok(ListeDiffusion);

            }
            return NotFound($"Une Liste de Diffusion avec la référence : {reference} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<ListeDeDiffusion> AddListeDiffusion(ListeDeDiffusion ListeDiff)
        {
            var verifiTitre = _listeListeData.GetListeDiffusionByTitre(ListeDiff.Titre);
            var verify = _listeListeData.GetListeDiffusionByReference(ListeDiff.Reference);

            if (verifiTitre == null && verify == null)
            {
                _listeListeData.AddListeDiffusion(ListeDiff);
                _listeListeData.SaveChanges();

                return CreatedAtRoute(nameof(GetListeDiffusionById), new { Id = ListeDiff.Id }, ListeDiff);
            }
            else
            {
                return NotFound($"Une Liste de Diffusion avec le titre : {ListeDiff.Titre} existe déjà");

            }
            
 
        }

        [HttpPut("put/{id}")]
        public ActionResult<ListeDeDiffusion> PutListeDeDiffusion(ListeDeDiffusion rol, int id)
        {
            var ListeDiffusion = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiffusion != null)
            {
                var verifiTitre = _listeListeData.GetListeDiffusionByTitre(rol.Titre);
                if (verifiTitre == null)
                {
                    _listeListeData.EditListeDiffusion(rol, id);
                    _listeListeData.SaveChanges();
                    return CreatedAtRoute(nameof(GetListeDiffusionById), new { Id = ListeDiffusion.Id }, ListeDiffusion);
                }
                else
                if (verifiTitre.Id == ListeDiffusion.Id)
                {
                    _listeListeData.EditListeDiffusion(rol, id);
                    _listeListeData.SaveChanges();
                    return CreatedAtRoute(nameof(GetListeDiffusionById), new { Id = ListeDiffusion.Id }, ListeDiffusion);
                }
                else
                {
                    return NotFound($"Une Liste de diffusion avec le titre : {rol.Titre} existe déjà");

                }

            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");

            // return Ok(categorireadDto);
        }


    [HttpDelete("delete/{id}")]
        public ActionResult<ListeDeDiffusion> DeleteListeDiffusion(int id)
        {

            var ListeDiff = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiff != null)
            {
                _listeListeData.DeleteListeDiffusion(ListeDiff);
                _listeListeData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
