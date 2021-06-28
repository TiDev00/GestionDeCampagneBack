using Microsoft.AspNetCore.Mvc;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegleDEnvoisController : ControllerBase
    {
        private IRegleDEnvoi _regleDEnvoiData;
        private IEntite _entiteData;
        public RegleDEnvoisController(IRegleDEnvoi regleDEnvoiData, IEntite entite)
        {
            _regleDEnvoiData = regleDEnvoiData;
            _entiteData = entite;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllRegleDEnvois()
        {
            return Ok(_regleDEnvoiData.GetRegleDEnvois());
        }

        [HttpGet("{id}", Name = "GetRegleDEnvoiById")]
        public IActionResult GetRegleDEnvoiById(int id)
        {
            var regleDEnvoi = _regleDEnvoiData.GetRegleDEnvoiById(id);
            if (regleDEnvoi != null)
            {
                return Ok(regleDEnvoi);

            }
            return NotFound($"Une règle d'envoi avec l'id : {id} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<RegleDEnvoi> AddRegleDEnvoi(RegleDEnvoi regleDEnvoi)
        {

            var entite = _entiteData.GetEntiteById(regleDEnvoi.IdEntite);
            if (entite != null)
            {
                _regleDEnvoiData.AddRegleDEnvoi(regleDEnvoi);
                _regleDEnvoiData.SaveChanges();

                return CreatedAtRoute(nameof(GetRegleDEnvoiById), new { Id = regleDEnvoi.Id }, regleDEnvoi);
            }
            return NotFound($"Une entité avec l'id : {regleDEnvoi.IdEntite} n'existe pas");
        }

        [HttpPut("put/{id}")]
        public ActionResult<RegleDEnvoi> PutRegleDEnvoi(RegleDEnvoi rde, int id)
        {
            var entite = _entiteData.GetEntiteById(rde.IdEntite);
            if (entite != null)
            {
                var regleDEnvoi = _regleDEnvoiData.GetRegleDEnvoiById(id);
                if (regleDEnvoi != null)
                {
                    _regleDEnvoiData.EditRegleDEnvoi(rde, id);
                    _regleDEnvoiData.SaveChanges();
                    return CreatedAtRoute(nameof(GetRegleDEnvoiById), new { Id = regleDEnvoi.Id }, regleDEnvoi);
                }
                else
                {
                    return NotFound($"Une règle d'envoi avec l'id : {id} n'existe pas");
                }
            }
            return NotFound($"Une entité avec l'id : {rde.IdEntite} n'existe pas");
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<RegleDEnvoi> DeleteRegleDEnvoi(int id)
        {
            var regleDEnvoi = _regleDEnvoiData.GetRegleDEnvoiById(id);
            if (regleDEnvoi != null)
            {
                _regleDEnvoiData.DeleteRegleDEnvoi(regleDEnvoi);
                _regleDEnvoiData.SaveChanges();
                return Accepted();
            }
            return NotFound($"Une règle d'envoi avec l'id : {id} n'existe pas");
        }
    }
}
