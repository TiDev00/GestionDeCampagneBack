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
    public class ContactListeDiffusionsController : ControllerBase
    {
        private IContactListeDiffusion _ContactListeDiffusionData;
        private DbcontextGC _dbcontextGC;
        private IContact _ContactData;
        private IListeDeDiffusion _ListeDiffusionData;

        public ContactListeDiffusionsController(DbcontextGC dbcontextGC, IContactListeDiffusion ContactListeDiffusionData, IContact ContactData, IListeDeDiffusion ListeDeDiffusionData)
        {
            _ContactListeDiffusionData = ContactListeDiffusionData;
            _ContactData = ContactData;
            _ListeDiffusionData = ListeDeDiffusionData;
            _dbcontextGC = dbcontextGC;
        }
        // GET: api/<ValuesController>
        [HttpGet("all/{id}")]
        public IActionResult GetAllContactListeDiffusions(int id)
        {
            return Ok(_ContactListeDiffusionData.GetContactListeDiffusions(id));
        }

        [HttpGet("{id}", Name = "GetContactListeDiffusionById")]
        public IActionResult GetContactListeDiffusionById(int id)
        {
            var ContactListeDiffusion = _ContactListeDiffusionData.GetContactListeDiffusionById(id);
            if (ContactListeDiffusion != null)
            {
                return Ok(ContactListeDiffusion);

            }
            return NotFound($"Un ContactListeDiffusion avec l'id : {id} n'existe pas");
        }


        [HttpGet("code/{code}", Name = "GetContactListeDiffusionByCode")]
        public IActionResult GetContactListeDiffusionByCode(string Code)
        {
            var code = _ContactListeDiffusionData.GetContactListeDiffusionByCode(Code);
            if (code != null)
            {
                return Ok(code);

            }
            return NotFound($"Un ContactListeDiffusion avec le code : {code} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<ContactListeDiffusion> AddContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion)
        {

            var listeDiff = _ListeDiffusionData.GetListeDiffusionById(ContactListeDiffusion.IdListeDiffusion);
            if (listeDiff != null)
            {
                var cont = _ContactData.GetContactById(ContactListeDiffusion.IdContact);
                if (cont != null)
                {

                    var verifiCode = _ContactListeDiffusionData.GetContactListeDiffusionByCode(ContactListeDiffusion.Code);


                    if (verifiCode == null)
                    {
                        _ContactListeDiffusionData.AddContactListeDiffusion(ContactListeDiffusion);
                        _ContactListeDiffusionData.SaveChanges();
                        return CreatedAtRoute(nameof(GetContactListeDiffusionById), new { Id = ContactListeDiffusion.Id }, ContactListeDiffusion);
                    }
                    else return NotFound($"Un ContactListeDiffusion avec code : {ContactListeDiffusion.Code} existe déjà");


                }
                else
                {

                    return NotFound($"Une contact avec l'id : {ContactListeDiffusion.IdContact} n'existe pas");
                }
            }
            else
            {
                return NotFound($"Une liste avec l'id : {ContactListeDiffusion.IdListeDiffusion} n'existe pas");
            }



        }

        [HttpPut("put/{id}")]
        public ActionResult<ContactListeDiffusion> PutContactListeDiffusion(ContactListeDiffusion contact, int id)
        {

            var listeDiff = _ListeDiffusionData.GetListeDiffusionById(contact.IdListeDiffusion);
            if (listeDiff != null)
            {
                var cont = _ContactData.GetContactById(contact.IdContact);
                if (cont != null)
                {

                    var con = _ContactListeDiffusionData.GetContactListeDiffusionById(id);
                    if (con != null)
                    {

                        var verifiCode = _ContactListeDiffusionData.GetContactListeDiffusionByCode(contact.Code);

                        if (verifiCode == null)
                        {
                            _ContactListeDiffusionData.EditContactListeDiffusion(contact, id);
                            _ContactListeDiffusionData.SaveChanges();
                            return CreatedAtRoute(nameof(GetContactListeDiffusionById), new { Id = con.Id }, con);
                        }
                        else if (verifiCode.Id == con.Id)
                        {
                            _ContactListeDiffusionData.EditContactListeDiffusion(contact, id);
                            _ContactListeDiffusionData.SaveChanges();
                            return CreatedAtRoute(nameof(GetContactListeDiffusionById), new { Id = con.Id }, con);

                        }
                        else
                            return NotFound($"Un ContactListeDiffusion avec le code : {contact.Code} n'existe déjà");
                    }
                    else
                        return NotFound($"Un contact liste de diffusion avec l'id : {contact.Id} n'existe pas");

                }
                else
                {

                    return NotFound($"Une contact avec l'id : {contact.IdContact} n'existe pas");
                }
            }
            else
            {
                return NotFound($"Une liste avec l'id : {contact.IdListeDiffusion} n'existe pas");
            }


        }

        [HttpDelete("delete/{id}")]
        public ActionResult<ContactListeDiffusion> DeleteContactListeDiffusion(int id)
        {

            var ContactListeDiffusion = _ContactListeDiffusionData.GetContactListeDiffusionById(id);
            if (ContactListeDiffusion != null)
            {
                _ContactListeDiffusionData.DeleteContactListeDiffusion(ContactListeDiffusion);
                _ContactListeDiffusionData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un ContactListeDiffusion avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }

        [HttpGet("donneescontact/{id}")]
        public IQueryable<ContactListDeDiffusionRequet> GetDonneesContactByListeDiffusion(int id)
        {
            var query = (from x in _dbcontextGC.ContactListeDiffusions
                         join y in _dbcontextGC.Contacts on x.IdContact equals y.Id
                         join z in _dbcontextGC.ListeDeDiffusions on x.IdListeDiffusion equals z.Id
                         where z.Id == id
                         select new ContactListDeDiffusionRequet()
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
