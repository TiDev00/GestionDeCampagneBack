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
        private DbcontextGC _dbcontextGC;

        private IContact _ContactData;
        private INiveauDeVisibilite _NiveauDeVisibiliteData;

        public ContactsController(DbcontextGC dbcontextGC,IContact ContactData, INiveauDeVisibilite NiveauDeVisibiliteData)
        {
            _ContactData = ContactData;
            _NiveauDeVisibiliteData = NiveauDeVisibiliteData;
            _dbcontextGC = dbcontextGC;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_ContactData.GetContacts());
        }


        [HttpGet("donneescontact/{id}")]
        public IActionResult GetDonnee(int id)
        {
            var data = _dbcontextGC.Contacts
       .Join(
           _dbcontextGC.ContactCanals,
           contact => contact.Id,
           contactcanal => contactcanal.IdContactNavigation.Id,
           (contact, contactcanal) => new
           {
               nomCanal = contactcanal.CanalDuContatct,
               contactName = contact.Nom,
               contactPrenom = contact.Prenom,
               contactId = contact.Id
           }
       ).ToList().Where(c => c.contactId == id);

            List <object> nnn = new List<object>();


            //Dictionary <List<string> myDic = new Dictionary<List<string>();
             //int i=0;
            foreach (var detail in data)
            {
                var contactObjet = new Dictionary<string, object>();

                contactObjet.Add("idContact", detail.contactId);
                contactObjet.Add("nomContact", detail.contactName);
                contactObjet.Add("prenomContact", detail.contactPrenom);
                contactObjet.Add("nomCanal", detail.nomCanal);

                nnn.Add(contactObjet);
            }

         
           
            return Ok(nnn);
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
