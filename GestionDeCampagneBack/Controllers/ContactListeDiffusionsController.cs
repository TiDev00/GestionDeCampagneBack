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
    public class ContactListeDiffusionsController : ControllerBase
    {
        private IListeDiffussion _ListeDiffusionData;
        private IContact _ContactData;
        private IContactListeDiffusion _ContactListeDiffusionData;
        private DbcontextGC _dbcontextGC;

        public ContactListeDiffusionsController(IListeDiffussion ListeDiffusionData, IContact ContactData,
            IContactListeDiffusion ContactListeDiffusionData, DbcontextGC _dbcontextGC
           )
        {
            _ListeDiffusionData = ListeDiffusionData;
            _ContactData = ContactData;
            _ContactListeDiffusionData = ContactListeDiffusionData;

        }
        [HttpGet]
        public IActionResult GetContactListeDeDiffusions()
        {
            return Ok(_ContactListeDiffusionData.GetContactListeDeDiffusions());
        }

        [HttpGet("{id}", Name = "GetContactListeDiffusionByID")]
        public IActionResult GetContactListeDiffusionByID(int id)
        {
            var ContactListeDiffusion = _ContactListeDiffusionData.GetContactListeDiffusionByID(id);
            if (ContactListeDiffusion != null)
            {
                return Ok(ContactListeDiffusion);

            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");
        }

        [HttpGet("ListeContacts")]
        public IActionResult GetAllContacts()
        {
            return Ok(_ContactData.GetContacts());
        }


        [HttpPost("add")]
        public ActionResult<ContactListeDiffusion> AddContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion)
        {

            _ContactListeDiffusionData.AddContactListeDeDiffusion(ContactListeDiffusion);
            _ContactListeDiffusionData.SaveChanges();

            return CreatedAtRoute(nameof(GetContactListeDiffusionByID), new { Id = ContactListeDiffusion.Id }, ContactListeDiffusion);
        }

        [HttpPut("put/{id}")]
        public ActionResult<ContactListeDiffusion> EditContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion, int Id) { 

            var ContactListeDeDiffusion = _ContactListeDiffusionData.GetContactListeDiffusionByID(Id);
            if (ContactListeDeDiffusion != null)
            {
                _ContactListeDiffusionData.EditContactListeDeDiffusion(ContactListeDiffusion, Id);
                _ContactListeDiffusionData.SaveChanges();

                return CreatedAtRoute(nameof(GetContactListeDiffusionByID), new { Id = ContactListeDiffusion.Id }, ContactListeDiffusion);
            }
            return NotFound($"Une Liste de diffusion avec l'id : {Id} n'existe pas");

        }

        [HttpDelete("delete/{id}")]
        public ActionResult<ContactListeDiffusion> DeleteContactListeDeDiffusion(int Id)
        {

            var ContactListeDeDiffusion = _ContactListeDiffusionData.GetContactListeDiffusionByID(Id);
            if (ContactListeDeDiffusion != null)
            {
                _ContactListeDiffusionData.DeleteContactListeDeDiffusion(ContactListeDeDiffusion);
                _ContactListeDiffusionData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Une Liste de diffusion avec l'id : {Id} n'existe pas");
        }

    }
}
