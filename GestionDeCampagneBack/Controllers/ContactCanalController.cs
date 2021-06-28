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
        private ICanalEnvoi _CanalEnvoiData;

        public ContactCanalsController(IContactCanal ContactCanalData, IContact ContactData, ICanalEnvoi CanalEnvoiData)
        {
            _ContactCanalData = ContactCanalData;
            _ContactData = ContactData;
            _CanalEnvoiData = CanalEnvoiData;
        }
        // GET: api/<ValuesController>
        [HttpGet("all/{id}")]
        public IActionResult GetAllContactCanals(int id)
        {
            return Ok(_ContactCanalData.GetContactCanals(id));
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
            var canalenvoi = _CanalEnvoiData.GetCanalEnvoiById(ContactCanal.IdCanalEnvoi);
            if (canalenvoi != null)
            {
                var cont = _ContactData.GetContactById(ContactCanal.IdContact);
                if (cont != null)
                {

                    _ContactCanalData.AddContactCanal(ContactCanal);
                    _ContactCanalData.SaveChanges();
                    return CreatedAtRoute(nameof(GetContactCanalById), new { Id = ContactCanal.Id }, ContactCanal);
                }
                else
                    return NotFound($"Un contact avec l'id : {ContactCanal.IdContact} n'existe pas");
            }
            else
                return NotFound($"Un canal envoi avec l'id : {ContactCanal.IdCanalEnvoi} n'existe pas");

        }

        [HttpPut("put/{id}")]
        public ActionResult<ContactCanal> PutContactCanal(ContactCanal contact, int id)
        {

            var canalenvoi = _CanalEnvoiData.GetCanalEnvoiById(contact.IdCanalEnvoi);
            if (canalenvoi != null)
            {
                var cont = _ContactData.GetContactById(contact.IdContact);
                if (cont != null)
                {

                    var ContactCanal = _ContactCanalData.GetContactCanalById(id);
                    if (ContactCanal != null)
                    {
                        _ContactCanalData.EditContactCanal(contact, id);
                        _ContactCanalData.SaveChanges();
                        return CreatedAtRoute(nameof(GetContactCanalById), new { Id = ContactCanal.Id }, ContactCanal);
                    }
                    else
                        return NotFound($"Un ContactCanal avec l'id : {id} n'existe pas");
                }
                else
                    return NotFound($"Un contact avec l'id : {contact.IdContact} n'existe pas");

            }
            else
            {
                return NotFound($"Un Canal avec l'id : {contact.IdCanalEnvoi} n'existe pas");
            }
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
