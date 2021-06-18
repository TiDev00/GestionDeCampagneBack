using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.ModelsRequets;
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
        private DbcontextGC _dbcontextGC;
        public ListeDeDiffusionController(IListeDeDiffusion ListeDeDiffusionData, DbcontextGC dbcontextGC)
        {
            _listeListeData = ListeDeDiffusionData;
            _dbcontextGC = dbcontextGC;
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


        [HttpGet("changeEtat/{id}")]
        public IActionResult ChangeetatCanalEnvoiById(int id)
        {
            var ListeDiff = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiff != null)
            {
                if (ListeDiff.Etat == true)
                {
                    ListeDiff.Etat = false;
                    _listeListeData.SaveChanges();
                    return Ok(ListeDiff);
                }
                else
                {
                    ListeDiff.Etat = true;
                    _listeListeData.SaveChanges();
                    return Ok(ListeDiff);
                }


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

            if (verifiTitre == null)
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


        [HttpGet("donneescontact/{id}")]
        public IQueryable<ContactListDeDiffusion> GetDonneesContactByListeDiffusion(int id)
        {
            var query = (from x in _dbcontextGC.ContactListeDiffusions
                         join y in _dbcontextGC.Contacts on x.IdContact equals y.Id
                         join z in _dbcontextGC.ListeDeDiffusions on x.IdListeDiffusion equals z.Id
                         where z.Id == id
                         select new ContactListDeDiffusion()
                         {
                             Nom = y.Nom,
                             Prenom = y.Prenom,
                             Sexe = y.Sexe 
                         }
                             ).AsQueryable();

            return query;

        }

  
    }
}
