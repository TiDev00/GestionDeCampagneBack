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
    public class ContactCanalsController : ControllerBase
    {
        private IContactCanal _ContactCanalData;
        private IContact _ContactData;
        private INiveauDeVisibilite _CanalEnvoiData;

        public ContactCanalsController(IContactCanal ContactCanalData, IContact ContactData, INiveauDeVisibilite CanalEnvoiData)
        {
            _ContactCanalData = ContactCanalData;
            _ContactData = ContactData;
            _CanalEnvoiData = CanalEnvoiData;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllContactCanals()
        {
            return Ok(_ContactCanalData.GetContactCanals());
        }

        [HttpGet("{id}", Name = "GetContactCanalById")]
        public IActionResult GetContactCanalById(int id)
        {
            var ContactCanal = _ContactCanalData.GetContactCanalById(id);
            if (ContactCanal != null)
            {
                return Ok(ContactCanal);

            }
            return NotFound($"Un ContactCanal avec l'id : {id} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<ContactCanal> AddContactCanal(ContactCanal ContactCanal)
        {

            var contact = _ContactData.GetContactById(ContactCanal.IdContact);
            if (contact != null)
            {
                var verifiId = _ContactCanalData.GetContactCanalById(ContactCanal.Id);
                

                if (verifiId == null)
                {
                   
                        return CreatedAtRoute(nameof(GetContactCanalById), new { Id = ContactCanal.Id }, ContactCanal);
                }
                else
                {
                    return NotFound($"Un ContactCanal avec l'Id : {ContactCanal.Id} existe déjà");

                }

            }
            else
                return NotFound($"Un contact avec l'id : {ContactCanal.IdContact} n'existe pas");


            // return Ok(categorireadDto);
        }

        [HttpPut("put/{id}")]
        public ActionResult<ContactCanal> PutContactCanal(ContactCanal contact, int id)
        {
            var ContactCanal = _ContactCanalData.GetContactCanalById(id);
            if (ContactCanal != null)
            {
                _ContactCanalData.EditContactCanal(contact, id);
                _ContactCanalData.SaveChanges();
                return CreatedAtRoute(nameof(GetContactCanalById), new { Id = ContactCanal.Id }, ContactCanal);
            }
            return NotFound($"Un ContactCanal avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<ContactCanal> DeleteContactCanal(int id)
        {

            var ContactCanal = _ContactCanalData.GetContactCanalById(id);
            if (ContactCanal != null)
            {
                _ContactCanalData.DeleteContactCanal(ContactCanal);
                _ContactCanalData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un ContactCanal avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
