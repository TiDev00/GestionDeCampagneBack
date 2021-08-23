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
    public class ModelesController : ControllerBase
    {
        private IModele _modelData;
        private ICanalEnvoi _canalEnvoi;

        public ModelesController(IModele ModeleData, ICanalEnvoi CanalEnvoiData)
        {
            _modelData = ModeleData;
            _canalEnvoi = CanalEnvoiData;
        }
        // GET: api/<ValuesController>
        [HttpGet("all/{id}")]
        public IActionResult GetAllModeles(int id)
        {
            return Ok(_modelData.GetModeles(id));
        }


        [HttpGet("all/{id}/{idCanal}")]
        public IActionResult GetAllModeles(int id, int idCanal)
        {
            return Ok(_modelData.GetModeleByCanalEnvoi(id,idCanal));
        }

        [HttpGet("{id}", Name = "GetModeleById")]
        public IActionResult GetModeleById(int id)
        {
            var Modele = _modelData.GetModeleById(id);
            if (Modele != null)
            {
                return Ok(Modele);

            }
            return NotFound($"Un Modele avec l'id : {id} n'existe pas");
        }


        [HttpGet("code/{code}", Name = "GetModeleByCode")]
        public IActionResult GetModeleByCode(string code)
        {
            var Modele = _modelData.GetModeleByCode(code);
            if (Modele != null)
            {
                return Ok(Modele);

            }
            return NotFound($"Un Modele avec le code : {code} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<Modele> AddModele(Modele Modele)
        {
            var canal = _canalEnvoi.GetCanalEnvoiById(Modele.IdCanalEnvoi);
            if (canal != null)
            {
                var verifiCode = _modelData.GetModeleByCode(Modele.Code);

                if (verifiCode == null)
                {

                    _modelData.AddModele(Modele);
                    _modelData.SaveChanges();

                    return CreatedAtRoute(nameof(GetModeleById), new { Id = Modele.Id }, Modele);
                }
                else
                {
                    return NotFound($"Un Modele avec le code : {Modele.Code} existe déjà");

                }
            }
            else return NotFound($"Un Modele avec l'id du canal : {Modele.IdCanalEnvoi} existe déjà");
        }

        [HttpPut("put/{id}")]
        public ActionResult<Modele> PutModele(Modele mod, int id)
        {
            var canal = _canalEnvoi.GetCanalEnvoiById(mod.IdCanalEnvoi);
            if (canal != null)
            {
                var Modele = _modelData.GetModeleById(id);
                if (Modele != null)
                {
                    var verificode = _modelData.GetModeleByCode(mod.Code);
                    if (verificode == null)
                    {
                        _modelData.EditModele(mod, id);
                        _modelData.SaveChanges();
                        return CreatedAtRoute(nameof(GetModeleById), new { Id = Modele.Id }, Modele);
                    }
                    else
                    if (verificode.Id == Modele.Id)
                    {
                        _modelData.EditModele(mod, id);
                        _modelData.SaveChanges();
                        return CreatedAtRoute(nameof(GetModeleById), new { Id = Modele.Id }, Modele);
                    }
                    else
                    {
                        return NotFound($"Un Modele avec le Code : {mod.Code} existe déjà");

                    }

                }
                return NotFound($"Un Modele avec l'id : {id} n'existe pas");

            }
            else return NotFound($"Un Modele avec l'id du canal : {mod.IdCanalEnvoi} n'existe pas");

            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<Modele> DeleteModele(int id)
        {

            var Modele = _modelData.GetModeleById(id);
            if (Modele != null)
            {
                _modelData.DeleteModele(Modele);
                _modelData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un Modele avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
