using Microsoft.AspNetCore.Mvc;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegleDEnvoiController : ControllerBase
    {
        private IRegleDEnvoi _regleDEnvoiData;

        public RegleDEnvoiController(IRegleDEnvoi regleDEnvoiData)
        {
            _regleDEnvoiData = regleDEnvoiData;
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
            return NotFound($"Un regleDEnvoi avec l'id : {id} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<RegleDEnvoi> AddRegleDEnvoi(RegleDEnvoi regleDEnvoi)
        {
            var _regleDEnvoi = _regleDEnvoiData.GetRegleDEnvoiById(regleDEnvoi.Id);
         
             if (_regleDEnvoi == null)
             {
                _regleDEnvoiData.AddRegleDEnvoi(regleDEnvoi);
                _regleDEnvoiData.SaveChanges();

                return CreatedAtRoute(nameof(GetRegleDEnvoiById), new { Id = regleDEnvoi.Id }, regleDEnvoi);
             }
             else { 
                return NotFound($"Un regleDEnvoi avec le libelle : {regleDEnvoi.Id} existe déjà");

            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<RegleDEnvoi> PutRegleDEnvoi(RegleDEnvoi rde,int id)
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
                return NotFound($"Un regleDEnvoi avec l'id : {id} n'existe pas");   
            }
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
            return NotFound($"Un regleDEnvoi avec l'id : {id} n'existe pas");
        }
    }
}
