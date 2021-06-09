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
    public class ContactListeDiffusionsController : ControllerBase
    {
        private IContactListeDiffusion _ContactListeDiffusionData;
        private IContact _ContactData;
        private INiveauDeVisibilite _NiveauVisibiliteData;

        public ContactListeDiffusionsController(IContactListeDiffusion ContactListeDiffusionData, IContact ContactData, INiveauDeVisibilite NiveauVisibiliteData)
        {
            _ContactListeDiffusionData = ContactListeDiffusionData;
            _ContactData = ContactData;
            _NiveauVisibiliteData = NiveauVisibiliteData;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllContactListeDiffusions()
        {
            return Ok(_ContactListeDiffusionData.GetContactListeDiffusions());
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
        public IActionResult GetContactListeDiffusionByEmail(string Code)
        {
            var code = _ContactListeDiffusionData.GetContactListeDiffusionByCode(Code);
            if (code != null)
            {
                return Ok(code);

            }
            return NotFound($"Un ContactListeDiffusion avec l'email : {code} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<ContactListeDiffusion> AddContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion)
        {

            var contact = _ContactData.GetContactById(ContactListeDiffusion.IdContact);
            if (contact != null)
            {
                var verifiId = _ContactListeDiffusionData.GetContactListeDiffusionById(ContactListeDiffusion.Id);
                var verifiCode = _ContactListeDiffusionData.GetContactListeDiffusionByCode(ContactListeDiffusion.Code);

                if (verifiId == null)
                {
                    if (verifiCode == null)
                    {
                        return CreatedAtRoute(nameof(GetContactListeDiffusionById), new { Id = ContactListeDiffusion.Id }, ContactListeDiffusion);
                    }
                    else return NotFound($"Un ContactListeDiffusion avec l'email : {ContactListeDiffusion.Code} existe déjà");

                }
                else
                {
                    return NotFound($"Un ContactListeDiffusion avec le login : {ContactListeDiffusion.Id} existe déjà");

                }

            }
            else
                return NotFound($"Un contact avec l'id : {ContactListeDiffusion.IdContact} n'existe pas");


            // return Ok(categorireadDto);
        }

        [HttpPut("put/{id}")]
        public ActionResult<ContactListeDiffusion> PutContactListeDiffusion(ContactListeDiffusion contact, int id)
        {
            var ContactListeDiffusion = _ContactListeDiffusionData.GetContactListeDiffusionById(id);
            if (ContactListeDiffusion != null)
            {
                _ContactListeDiffusionData.EditContactListeDiffusion(contact, id);
                _ContactListeDiffusionData.SaveChanges();
                return CreatedAtRoute(nameof(GetContactListeDiffusionById), new { Id = ContactListeDiffusion.Id }, ContactListeDiffusion);
            }
            return NotFound($"Un ContactListeDiffusion avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
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
    }
}
