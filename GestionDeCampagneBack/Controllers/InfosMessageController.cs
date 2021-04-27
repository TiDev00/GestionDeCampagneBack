using Microsoft.AspNetCore.Mvc;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfosMessageController : ControllerBase
    {
        private IInfosMessage _infosMessageData;

        public InfosMessageController(IInfosMessage infosMessageData)
        {
            _infosMessageData = infosMessageData;
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
            var _infosMessage = _infosMessageData.GetInfosMessageById(infosMessage.Id);
         
            if (_infosMessage == null)
            {
                _infosMessageData.AddInfosMessage(infosMessage);
                _infosMessageData.SaveChanges();

                return CreatedAtRoute(nameof(GetInfosMessageById), new { Id = infosMessage.Id }, infosMessage);
            }
            else 
            { 
                return NotFound($"Un infosMessage avec le libelle : {infosMessage.Id} existe déjà");
            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<InfosMessage> PutInfosMessage(InfosMessage infMes,int id)
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
