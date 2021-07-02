﻿using GestionDeCampagneBack.Models;
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
    public class ListeDeDiffusionController : ControllerBase
    {
        private IListeDeDiffusion _listeListeData;
        private DbcontextGC _dbcontextGC;
        private IEntite _entiteData;
        private INiveauDeVisibilite _NiveauDeVisibiliteData;
        private IContactListeDiffusion _ContactListeDiffusionData;
        public ListeDeDiffusionController(IListeDeDiffusion ListeDeDiffusionData, IContactListeDiffusion contactListeDiffusion, DbcontextGC dbcontextGC, IEntite entite, INiveauDeVisibilite niveauDeVisibilite)
        {
            _listeListeData = ListeDeDiffusionData;
            _dbcontextGC = dbcontextGC;
            _entiteData = entite;
            _NiveauDeVisibiliteData = niveauDeVisibilite;
            _ContactListeDiffusionData = contactListeDiffusion;
        }
        // GET: api/<ValuesController>
        [HttpGet("all/{id}")]
        public IActionResult GetAllListeDeDiffusions(int id)
        {
            return Ok(_listeListeData.GetListeDiffusion(id));
        }

        [HttpGet("{id}", Name = "GetListeDiffusionById")]
        public IActionResult GetListeDiffusionById(int id)
        {
            var ListeDiffusion = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiffusion != null)
            {
                return Ok(ListeDiffusion);

            }
            return NotFound($"Une Liste de Diffusion avec l'id : {id} n'existe pas");
        }


        [HttpGet("listeDiffusion/{id}")]
        public IActionResult getListeDiffusionById(int id)
        {
            var ListeDiff = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiff != null)
            {
                    return Ok(ListeDiff);
                }
                
            return NotFound($"Une Liste de Diffusion avec l'id : {id} n'existe pas");
        }

        [HttpGet("reference/{reference}", Name = "GetListeDiffusionByReference")]
        public IActionResult GetListediffusionByRef(string reference)
        {
            var ListeDiffusion = _listeListeData.GetListeDiffusionByReference(reference);
            if (ListeDiffusion != null)
            {
                return Ok(ListeDiffusion);

            }
            return NotFound($"Une Liste de Diffusion avec la référence : {reference} n'existe pas");
        }

        [HttpGet("changes/{id}")]
        public IActionResult Changes(int id)
        {
            var ListeDiff = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiff != null)
            {
                if (ListeDiff.Statut == true)
                {
                    ListeDiff.Statut = false;
                    _listeListeData.SaveChanges();
                    return Ok(ListeDiff);
                }
                else
                {
                    ListeDiff.Statut = true;
                    _listeListeData.SaveChanges();
                    return Ok(ListeDiff);
                }


            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");
        }

        [HttpGet("contactListeDiff")]
        public IActionResult GetAllContactListeDiffusions(int id)
        {
            return Ok(_ContactListeDiffusionData.GetContactListeDiffusions(id));
        }
        [HttpPost("add")]
        public ActionResult<ListeDeDiffusion> AddListeDiffusion(ListeDeDiffusion ListeDiff)
        {
            var niveauDevisibilite = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteById(ListeDiff.IdNiveauVisibilite);
            if (niveauDevisibilite != null)
            {
                var entite = _entiteData.GetEntiteById(ListeDiff.IdEntite);
                if (entite != null)
                {
                    var verify = _listeListeData.GetListeDiffusionByReference(ListeDiff.Reference);

                    if (verify == null)
                    {
                        _listeListeData.AddListeDiffusion(ListeDiff);
                        _listeListeData.SaveChanges();

                        return CreatedAtRoute(nameof(GetListeDiffusionById), new { Id = ListeDiff.Id }, ListeDiff);
                    }
                    else
                    {
                        return NotFound($"Une Liste de Diffusion avec la référence : {ListeDiff.Reference} existe déjà");

                    }
                }
                else
                    return NotFound($"Une entité avec l'id : {ListeDiff.IdEntite} n'existe pas");
            }
            else return NotFound($"Un niveau de visibilité avec l'id : {ListeDiff.IdNiveauVisibilite} n'existe pas");
        }

        [HttpPut("put/{id}")]
        public ActionResult<ListeDeDiffusion> PutListeDeDiffusion(ListeDeDiffusion rol, int id)
        {
            var niveauDevisibilite = _NiveauDeVisibiliteData.GetNiveauDeVisibiliteById(rol.IdNiveauVisibilite);
            if (niveauDevisibilite != null)
            {
                var entite = _entiteData.GetEntiteById(rol.IdEntite);
                if (entite != null)
                {
                    var ListeDiffusion = _listeListeData.GetListeDiffusionById(id);
                    if (ListeDiffusion != null)
                    {
                        var verifiRef = _listeListeData.GetListeDiffusionByReference(rol.Reference);
                        if (verifiRef == null)
                        {
                            _listeListeData.EditListeDiffusion(rol, id);
                            _listeListeData.SaveChanges();
                            return CreatedAtRoute(nameof(GetListeDiffusionById), new { Id = ListeDiffusion.Id }, ListeDiffusion);
                        }
                        else
                        if (verifiRef.Id == ListeDiffusion.Id)
                        {
                            _listeListeData.EditListeDiffusion(rol, id);
                            _listeListeData.SaveChanges();
                            return CreatedAtRoute(nameof(GetListeDiffusionById), new { Id = ListeDiffusion.Id }, ListeDiffusion);
                        }
                        else
                        {
                            return NotFound($"Une Liste de diffusion avec la référence : {rol.Reference} existe déjà");

                        }

                    }
                    return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");

                }
                else
                    return NotFound($"Une entité avec l'id : {rol.IdEntite} n'existe pas");
            }
            return NotFound($"Un niveau de visibilité avec l'id : {rol.IdEntite} n'existe pas");
            // return Ok(categorireadDto);
        }


        [HttpDelete("delete/{id}")]
        public ActionResult<ListeDeDiffusion> DeleteListeDiffusion(int id)
        {

            var ListeDiff = _listeListeData.GetListeDiffusionById(id);
            if (ListeDiff != null)
            {
                _listeListeData.DeleteListeDiffusion(ListeDiff);
                _listeListeData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Une Liste de diffusion avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }


        [HttpGet("donneescontact/{id}")]
        public IQueryable<ContactListDeDiffusion> GetDonneesContactByListeDiffusion(int id)
        {
            var query = (from x in _dbcontextGC.ContactListeDiffusions
                         join y in _dbcontextGC.Contacts on x.IdContact equals y.Id
                         join z in _dbcontextGC.ListeDeDiffusions on x.IdListeDiffusion equals z.Id
                         where z.Id == id
                         select new ContactListDeDiffusion()
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
