using Microsoft.AspNetCore.Mvc;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;


namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDeCampagnesController : ControllerBase
    {
        private ITypeDeCampagne _typeDeCampagneData;

        public TypeDeCampagnesController(ITypeDeCampagne typeDeCampagneData)
        {
            _typeDeCampagneData = typeDeCampagneData;
        }

        [HttpGet("all/{id}")]
        public IActionResult GetAllTypeDeCampagnes(int id)
        {
            return Ok(_typeDeCampagneData.GetTypeDeCampagnes(id));
        }

        [HttpGet("{id}", Name = "GetTypeDeCampagneById")]
        public IActionResult GetTypeDeCampagneById(int id)
        {
            var typeDeCampagne = _typeDeCampagneData.GetTypeDeCampagneById(id);
            if (typeDeCampagne != null)
            {
                return Ok(typeDeCampagne);

            }
            return NotFound($"Un type de campagne avec l'id : {id} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<TypeDeCampagne> AddTypeDeCampagne(TypeDeCampagne typeDeCampagne)
        {

            _typeDeCampagneData.AddTypeDeCampagne(typeDeCampagne);
            _typeDeCampagneData.SaveChanges();

            return CreatedAtRoute(nameof(GetTypeDeCampagneById), new { Id = typeDeCampagne.Id }, typeDeCampagne);



        }

        [HttpPut("put/{id}")]
        public ActionResult<TypeDeCampagne> PutTypeDeCampagne(TypeDeCampagne tdc, int id)
        {
            var typeDeCampagne = _typeDeCampagneData.GetTypeDeCampagneById(id);
            if (typeDeCampagne != null)
            {

                _typeDeCampagneData.EditTypeDeCampagne(tdc, id);
                _typeDeCampagneData.SaveChanges();
                return CreatedAtRoute(nameof(GetTypeDeCampagneById), new { Id = typeDeCampagne.Id }, typeDeCampagne);

            }
            else
                return NotFound($"Un type de campagne avec l'id : {id} n'existe pas");
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<TypeDeCampagne> DeleteTypeDeCampagne(int id)
        {

            var typeDeCampagne = _typeDeCampagneData.GetTypeDeCampagneById(id);
            if (typeDeCampagne != null)
            {
                _typeDeCampagneData.DeleteTypeDeCampagne(typeDeCampagne);
                _typeDeCampagneData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un typeDeCampagne avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
