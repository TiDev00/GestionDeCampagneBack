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
    public class ContactCanalEnvois : ControllerBase
    {
        private IContactCanalEnvoi _contactCanalEnvoiData;

        public ContactCanalEnvois(IContactCanalEnvoi ContactCanalEnvoiData)
        {
            _contactCanalEnvoiData = ContactCanalEnvoiData;
        }

        [HttpGet]
        public IActionResult GetAllContactCanalEnvoi()
        {
            return Ok(_contactCanalEnvoiData.GetContactCanalCanals());
        }

        [HttpGet("{id}", Name = "GetContactCanalEnvoiById")]
        public IActionResult GetContactCanalEnvoiById(int id)
        {
            var ContactCanal = _contactCanalEnvoiData.GetContactCanalById(id);
            if (ContactCanal != null)
            {
                return Ok(ContactCanal);

            }
            return NotFound($"Un contact canal avec l'id : {id} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<ContactCanal> AddContactCanal(ContactCanal ContactCanal)
        {

          

                _contactCanalEnvoiData.AddContactCanal(ContactCanal);
                _contactCanalEnvoiData.SaveChanges();

                return CreatedAtRoute(nameof(GetContactCanalEnvoiById), new { Id = ContactCanal.Id }, ContactCanal);
            }

        

    }
}
