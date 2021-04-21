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

        public CanalEnvoisController(ICanalEnvoi CanalEnvoiData)
        {
            _canalEnvoiData = CanalEnvoiData;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllCanalEnvois()
        {
            return Ok(_canalEnvoiData.GetCanalEnvois());
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

        [HttpGet("titre/{titre}", Name = "GetCanalEnvoiByTitre")]
        public IActionResult GetCanalEnvoiByLibelle(string titre)
        {
            var CanalEnvoi = _canalEnvoiData.GetCanalEnvoiByTitre(titre);
            if (CanalEnvoi != null)
            {
                return Ok(CanalEnvoi);

            }
            return NotFound($"Un CanalEnvoi avec le titre : {titre} n'existe pas");
        }

        [HttpGet("code/{code}", Name = "GetCanalEnvoiByCode")]
        public IActionResult GetCanalEnvoiByCode(string code)
        {
            var CanalEnvoi = _canalEnvoiData.GetCanalEnvoiByCode(code);
            if (CanalEnvoi != null)
            {
                return Ok(CanalEnvoi);

            }
            return NotFound($"Un CanalEnvoi avec le titre : {code} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<CanalEnvoi> AddCanalEnvoi(CanalEnvoi CanalEnvoi)
        {
            var verifiTitre = _canalEnvoiData.GetCanalEnvoiByTitre(CanalEnvoi.Titre);

            if (verifiTitre == null)
            {
                _canalEnvoiData.AddCanalEnvoi(CanalEnvoi);
                _canalEnvoiData.SaveChanges();

                return CreatedAtRoute(nameof(GetCanalEnvoiById), new { Id = CanalEnvoi.Id }, CanalEnvoi);
            }
            else
            {
                return NotFound($"Un CanalEnvoi avec le libelle : {CanalEnvoi.Titre} existe déjà");

            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<CanalEnvoi> PutCanalEnvoi(CanalEnvoi rol, int id)
        {
            var CanalEnvoi = _canalEnvoiData.GetCanalEnvoiById(id);
            if (CanalEnvoi != null)
            {
                var verifiTitre = _canalEnvoiData.GetCanalEnvoiByTitre(rol.Titre);
                if (verifiTitre == null)
                {
                    _canalEnvoiData.EditCanalEnvoi(rol, id);
                    _canalEnvoiData.SaveChanges();
                    return CreatedAtRoute(nameof(GetCanalEnvoiById), new { Id = CanalEnvoi.Id }, CanalEnvoi);
                }
                else
                if (verifiTitre.Id == CanalEnvoi.Id)
                {
                    _canalEnvoiData.EditCanalEnvoi(rol, id);
                    _canalEnvoiData.SaveChanges();
                    return CreatedAtRoute(nameof(GetCanalEnvoiById), new { Id = CanalEnvoi.Id }, CanalEnvoi);
                }
                else
                {
                    return NotFound($"Un CanalEnvoi avec le titre : {rol.Titre} existe déjà");

                }

            }
            return NotFound($"Un CanalEnvoi avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
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
