using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanalEnvoisController : ControllerBase
    {
        private ICanalEnvoi _canalEnvoiData;
        private IEntite _entiteData;

        public CanalEnvoisController(ICanalEnvoi CanalEnvoiData, IEntite entite)
        {
            _canalEnvoiData = CanalEnvoiData;
            _entiteData = entite;
        }
        // GET: api/<ValuesController>
        [HttpGet("all/{id}")]
        public IActionResult GetAllCanalEnvois(int id)
        {
            return Ok(_canalEnvoiData.GetCanalEnvois(id));
        }

        [HttpGet("{id}", Name = "GetCanalEnvoiById")]
        public IActionResult GetCanalEnvoiById(int id)
        {
            var CanalEnvoi = _canalEnvoiData.GetCanalEnvoiById(id);
            if (CanalEnvoi != null)
            {
                return Ok(CanalEnvoi);

            }
            return NotFound($"Un CanalEnvoi avec l'id : {id} n'existe pas");
        }

        [HttpGet("changeEtat/{id}")]
        public IActionResult ChangeetatCanalEnvoiById(int id)
        {
            var CanalEnvoi = _canalEnvoiData.GetCanalEnvoiById(id);
            if (CanalEnvoi != null)
            {
                if (CanalEnvoi.Etat == true)
                {
                    CanalEnvoi.Etat = false;
                    _canalEnvoiData.SaveChanges();
                    return Ok(CanalEnvoi);
                }
                else
                {
                    CanalEnvoi.Etat = true;
                    _canalEnvoiData.SaveChanges();
                    return Ok(CanalEnvoi);
                }


            }
            return NotFound($"Un CanalEnvoi avec l'id : {id} n'existe pas");
        }


        [HttpGet("code/{code}", Name = "GetCanalEnvoiByCode")]
        public IActionResult GetCanalEnvoiByCode(string code)
        {
            var CanalEnvoi = _canalEnvoiData.GetCanalEnvoiByCode(code);
            if (CanalEnvoi != null)
            {
                return Ok(CanalEnvoi);

            }
            return NotFound($"Un CanalEnvoi avec le code : {code} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<CanalEnvoi> AddCanalEnvoi(CanalEnvoi CanalEnvoi)
        {
            var entite = _entiteData.GetEntiteById(CanalEnvoi.IdEntite);
            if (entite != null)
            {
                var Canal = _canalEnvoiData.GetCanalEnvoiByCode(CanalEnvoi.Code);
                if (Canal == null)
                {
                    _canalEnvoiData.AddCanalEnvoi(CanalEnvoi);
                    _canalEnvoiData.SaveChanges();
                    return CreatedAtRoute(nameof(GetCanalEnvoiById), new { Id = CanalEnvoi.Id }, CanalEnvoi);
                }
                else
                {
                    return NotFound($"Un CanalEnvoi avec le code : {CanalEnvoi.Code} existe déjà");
                }
            }
            else
                return NotFound($"Une entité avec l'id : {CanalEnvoi.IdEntite} n'existe pas");

        }

        [HttpPut("put/{id}")]
        public ActionResult<CanalEnvoi> PutCanalEnvoi(CanalEnvoi canal, int id)
        {
            var entite = _entiteData.GetEntiteById(canal.IdEntite);
            if (entite != null)
            {
                var can = _canalEnvoiData.GetCanalEnvoiById(id);
                if (can != null)
                {

                    var verifiCode = _canalEnvoiData.GetCanalEnvoiByCode(canal.Code);

                    if (verifiCode == null)
                    {
                        _canalEnvoiData.EditCanalEnvoi(canal, id);
                        _canalEnvoiData.SaveChanges();
                        return CreatedAtRoute(nameof(GetCanalEnvoiById), new { Id = can.Id }, can);
                    }
                    else if (verifiCode.Id == can.Id)
                    {
                        _canalEnvoiData.EditCanalEnvoi(canal, id);
                        _canalEnvoiData.SaveChanges();
                        return CreatedAtRoute(nameof(GetCanalEnvoiById), new { Id = can.Id }, can);

                    }
                    else
                        return NotFound($"Un Canal avec le code : {canal.Code} n'existe déjà");
                }
                return NotFound($"Un Canal avec l'id : {id} n'existe pas");
            }
            else
                return NotFound($"Une Entité avec l'id : {canal.IdEntite} n'existe pas");

        }


        [HttpDelete("delete/{id}")]
        public ActionResult<CanalEnvoi> DeleteCanalEnvoi(int id)
        {

            var CanalEnvoi = _canalEnvoiData.GetCanalEnvoiById(id);
            if (CanalEnvoi != null)
            {
                _canalEnvoiData.DeleteCanalEnvoi(CanalEnvoi);
                _canalEnvoiData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un CanalEnvoi avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
