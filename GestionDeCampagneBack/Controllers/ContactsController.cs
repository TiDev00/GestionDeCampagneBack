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

        private IUtilisateur _UtilisateurData;

        private INiveauDeVisibilite _NiveauDeVisibilite;

        public ContactsController(DbcontextGC dbcontextGC, IContact ContactData, IUtilisateur UtilisateurData, INiveauDeVisibilite NiveauDeVisibilite)
        {
            _ContactData = ContactData;
            _UtilisateurData = UtilisateurData;
            _dbcontextGC = dbcontextGC;
            _NiveauDeVisibilite = NiveauDeVisibilite;

        }
        // GET: api/<ValuesController>
        [HttpGet("all/{id}")]
        public IActionResult GetAllContacts(int id)
        {
            return Ok(_ContactData.GetContacts(id));
        }

        [HttpGet("matricule/{matricule}", Name = "GetContactByMatricule")]
        public IActionResult GetContactMatricule(string matricule)
        {
            var mat = _ContactData.GetContactByMatricul(matricule);
            if (mat != null)
            {
                return Ok(mat);

            }
            return NotFound($"Un Contact avec le matricule : {matricule} n'existe pas");
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

            List<object> nnn = new List<object>();


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
            var niveauDevisibilite = _NiveauDeVisibilite.GetNiveauDeVisibiliteById(Contact.IdNiveauVisibilite);
            if (niveauDevisibilite != null)
            {
                var user = _UtilisateurData.GetUtilisateurById(Contact.IdUser);
                if (user != null)
                {
                    var verifiMatricule = _ContactData.GetContactByMatricul(Contact.Matricule);


                    if (verifiMatricule == null)
                    {
                        _ContactData.AddContact(Contact);

                        _ContactData.SaveChanges();

                        return CreatedAtRoute(nameof(GetContactById), new { Id = Contact.Id }, Contact);
                    }
                    else return NotFound($"Un Contact avec le matricule : {Contact.Matricule} n'existe pas");
                }
                else
                {
                    return NotFound($"Un utilisateur avec l'id : {Contact.IdUser} n'existe pas");
                }
            }
            else return NotFound($"Un niveau de visibilité avec l'id : {Contact.IdNiveauVisibilite} n'existe pas");

        }


        [HttpPut("put/{id}")]
        public ActionResult<Contact> PutContact(Contact contact, int id)
        {
            var niveauDevisibilite = _NiveauDeVisibilite.GetNiveauDeVisibiliteById(contact.IdNiveauVisibilite);
            if (niveauDevisibilite != null)
            {
                var con = _ContactData.GetContactById(id);
                if (con != null)
                {
                    var user = _UtilisateurData.GetUtilisateurById(contact.IdUser);
                    if (user != null)
                    {
                        var verifiMatricule = _ContactData.GetContactByMatricul(contact.Matricule);

                        if (verifiMatricule == null)
                        {
                            _ContactData.EditContact(contact, id);
                            _ContactData.SaveChanges();
                            return CreatedAtRoute(nameof(GetContactById), new { Id = con.Id }, con);
                        }
                        else if (verifiMatricule.Id == con.Id)
                        {
                            _ContactData.EditContact(contact, id);
                            _ContactData.SaveChanges();
                            return CreatedAtRoute(nameof(GetContactById), new { Id = con.Id }, con);

                        }
                        else
                        {
                            return NotFound($"Un contact avec le matricule : {contact.Matricule} existe déjà");
                        }
                    }
                    else
                        return NotFound($"Un contact avec l'id : {contact.IdUser} n'existe pas");
                }
                else
                    return NotFound($"Un contact avec l'id : {id} n'existe pas");
            }
            else return NotFound($"Un niveau de visibilité avec l'id : {contact.IdNiveauVisibilite} n'existe pas");


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
