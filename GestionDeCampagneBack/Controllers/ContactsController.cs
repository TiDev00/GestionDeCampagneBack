using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContact _ContactData;
        private INiveauDeVisibilite _NiveauDeVisibiliteData;
        private IContactCanalEnvoi _contactCanalEnvoiData;

        public ContactsController(IContact ContactData, INiveauDeVisibilite NiveauDeVisibiliteData , IContactCanalEnvoi contactCanalEnvoi)
        {
            _ContactData = ContactData;
            _NiveauDeVisibiliteData = NiveauDeVisibiliteData;
            _contactCanalEnvoiData = contactCanalEnvoi;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_ContactData.GetContacts());
        }

        [HttpGet("{id}", Name = "GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var Contact = _ContactData.GetContactById(id);
            if (Contact != null)
            {
                return Ok(Contact);

            }
            return NotFound($"Un Contact avec l'id : {id} n'existe pas");
        }

        [HttpGet("CanalEnvoi")]
        public IActionResult GetAllContactCanalEnvoi()
        {
            return Ok(_contactCanalEnvoiData.GetContactCanalCanals());
        }

        [HttpGet("changes/{id}")]
        public IActionResult ChangeStatutContact(int id)
        {
            var Contact = _ContactData.GetContactById(id);
            if (Contact != null)
            {
                if (Contact.Statut == true)
                {
                    Contact.Statut = false;
                    _ContactData.SaveChanges();
                    return Ok(Contact);
                }
                else
                {
                    Contact.Statut = true;
                    _ContactData.SaveChanges();
                    return Ok(Contact);
                }


            }
            return NotFound($"Un Contact avec l'id : {id} n'existe pas");
        }
        [HttpPost("add")]
        public ActionResult<Contact> AddContact(Contact Contact)
        {
           
                _ContactData.AddContact(Contact);
                _ContactData.SaveChanges();

                return CreatedAtRoute(nameof(GetContactById), new { Id = Contact.Id }, Contact);
            
           
        }


        [HttpPut("put/{id}")]
        public ActionResult<Contact> PutContact(Contact contact, int id)
        {
            var Contact = _ContactData.GetContactById(id);
            if (Contact != null)
            {
                _ContactData.EditContact(contact, id);
                _ContactData.SaveChanges();
                return CreatedAtRoute(nameof(GetContactById), new { Id = Contact.Id }, Contact);
            }
            return NotFound($"Un Contact avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<Contact> DeleteContact(int id)
        {

            var Contact = _ContactData.GetContactById(id);
            if (Contact != null)
            {
                _ContactData.DeleteContact(Contact);
                _ContactData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un Contact avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
