using GestionDeCampagneBack.ModeleRequete;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListeDiffusionsController : ControllerBase
    {
        private IListeDiffussion _ListeDiffusionData;
        private IContact _ContactData;
        private IContactCanalEnvoi _ContactListeDiffusionData;
        private DbcontextGC _dbcontextGC;
        public ListeDiffusionsController(IListeDiffussion ListeDiffusionData , IContact ContactData , DbcontextGC _dbcontextGC
            ) 
        {
            _ListeDiffusionData = ListeDiffusionData;
            _ContactData = ContactData;
            

        }
        [HttpGet]
        public IActionResult GetAllListeDiffusion()
        {
            return Ok(_ListeDiffusionData.GetListeDeDiffusions());
        }

        [HttpGet("{id}", Name = "GetListeDiffusionByID")]
        public IActionResult GetListeDiffusionByID(int id)
        {
            var ListeDiffusion = _ListeDiffusionData.GetListeDiffusionByID(id);
            if (ListeDiffusion != null)
            {
                return Ok(ListeDiffusion);

            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");
        }

        [HttpGet ("ListeContacts")]
        public IActionResult GetAllContacts()
        {
            return Ok(_ContactData.GetContacts());
        }

        [HttpGet("changes/{id}")]
        public IActionResult ChangeStatutListeDiffusion(int id)
        {
            var ListeDiffusion = _ListeDiffusionData.GetListeDiffusionByID(id);
            if (ListeDiffusion != null)
            {
                if (ListeDiffusion.Statut == true)
                {
                    ListeDiffusion.Statut = false;
                    _ListeDiffusionData.SaveChanges();
                    return Ok(ListeDiffusion);
                }
                else
                {
                    ListeDiffusion.Statut = true;
                    _ListeDiffusionData.SaveChanges();
                    return Ok(ListeDiffusion);
                }


            }
            return NotFound($"Une liste de diffusion  avec l'id : {id} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<ListeDeDiffusion> AddListeDeDiffusion(ListeDeDiffusion ListeDeDiffusion)
        {

            _ListeDiffusionData.AddListeDeDiffusion(ListeDeDiffusion);
            _ListeDiffusionData.SaveChanges();
             
            return CreatedAtRoute(nameof(GetListeDiffusionByID), new { Id = ListeDeDiffusion.Id }, ListeDeDiffusion);
        }

        [HttpPut("put/{id}")]
        public ActionResult<ListeDeDiffusion> PutContact(ListeDeDiffusion ListeDeDiffusion, int id)
        {
            var ListeDiffusion = _ListeDiffusionData.GetListeDiffusionByID(id);
            if (ListeDiffusion != null)
            {
                _ListeDiffusionData.EditListeDeDiffusion(ListeDeDiffusion ,  id);
                _ListeDiffusionData.SaveChanges();
                return CreatedAtRoute(nameof(GetListeDiffusionByID), new { Id = ListeDeDiffusion.Id }, ListeDeDiffusion);
            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");

        }

        [HttpDelete("delete/{id}")]
        public ActionResult<ListeDeDiffusion> DeleteListeDeDiffusion(int id)
        {

            var ListeDiffusion = _ListeDiffusionData.GetListeDiffusionByID(id);
            if (ListeDiffusion != null)
            {
                _ListeDiffusionData.DeleteListeDeDiffusion(ListeDiffusion );
                _ListeDiffusionData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");
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
                             id = y.Id
                         }
                             ).AsQueryable();



            return query;



        }
    }


}
