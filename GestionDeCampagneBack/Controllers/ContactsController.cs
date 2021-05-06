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

        public ContactsController(IContact ContactData, INiveauDeVisibilite NiveauDeVisibiliteData)
        {
            _ContactData = ContactData;
            _NiveauDeVisibiliteData = NiveauDeVisibiliteData;
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

        

        [HttpPost("add")]
        public ActionResult<Contact> AddContact(Contact Contact)
        {
            var verifiMatricul = _ContactData.GetContactByMatricul(Contact.Matricule);

            if (verifiMatricul == null)
            {
                _ContactData.AddContact(Contact);
                _ContactData.SaveChanges();

                return CreatedAtRoute(nameof(GetContactById), new { Id = Contact.Id }, Contact);
            }
            else
            {
                return NotFound($"Un Contact avec le Matricule : {Contact.Matricule} existe déjà");

            }
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
