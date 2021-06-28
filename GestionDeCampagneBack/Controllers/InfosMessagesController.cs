using Microsoft.AspNetCore.Mvc;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfosMessagesController : ControllerBase
    {
        private IInfosMessage _infosMessageData;
        private ICampagne _icampagne;

        public InfosMessagesController(IInfosMessage infosMessageData, ICampagne iCampagne)
        {
            _infosMessageData = infosMessageData;
            _icampagne = iCampagne;
        }

        [HttpGet]
        public IActionResult GetAllInfosMessages()
        {
            return Ok(_infosMessageData.GetInfosMessages());
        }

        [HttpGet("{id}", Name = "GetInfosMessageById")]
        public IActionResult GetInfosMessageById(int id)
        {
            var infosMessage = _infosMessageData.GetInfosMessageById(id);
            if (infosMessage != null)
            {
                return Ok(infosMessage);

            }
            return NotFound($"Un infosMessage avec l'id : {id} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<InfosMessage> AddInfosMessage(InfosMessage infosMessage)
        {
            var camp = _icampagne.GetCampagneById(infosMessage.IdCampagne);
            if (camp != null)
            {

                _infosMessageData.AddInfosMessage(infosMessage);
                _infosMessageData.SaveChanges();

                return CreatedAtRoute(nameof(GetInfosMessageById), new { Id = infosMessage.Id }, infosMessage);
            }
            else
            {
                return NotFound($"Une campagne avec l'id : {infosMessage.IdCampagne} n'existe pas");
            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<InfosMessage> PutInfosMessage(InfosMessage infMes, int id)
        {
            var camp = _icampagne.GetCampagneById(infMes.IdCampagne);
            if (camp != null)
            {
                var infosMessage = _infosMessageData.GetInfosMessageById(id);
                if (infosMessage != null)
                {
                    _infosMessageData.EditInfosMessage(infMes, id);
                    _infosMessageData.SaveChanges();
                    return CreatedAtRoute(nameof(GetInfosMessageById), new { Id = infosMessage.Id }, infosMessage);
                }
                return NotFound($"Un infosMessage avec l'id : {id} n'existe pas");
            }
            else
                return NotFound($"Une campagne avec l'id : {infMes.IdCampagne} n'existe pas");
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<InfosMessage> DeleteInfosMessage(int id)
        {
            var infosMessage = _infosMessageData.GetInfosMessageById(id);
            if (infosMessage != null)
            {
                _infosMessageData.DeleteInfosMessage(infosMessage);
                _infosMessageData.SaveChanges();
                return Accepted();
            }
            return NotFound($"Un infosMessage avec l'id : {id} n'existe pas");
        }
    }
}
