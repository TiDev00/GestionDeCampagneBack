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
       
        [HttpGet]
        public IActionResult GetAllTypeDeCampagnes()
        {
            return Ok(_typeDeCampagneData.GetTypeDeCampagnes());
        }

        [HttpGet("{id}", Name = "GetTypeDeCampagneById")]
        public IActionResult GetTypeDeCampagneById(int id)
        {
            var typeDeCampagne = _typeDeCampagneData.GetTypeDeCampagneById(id);
            if (typeDeCampagne != null)
            {
                return Ok(typeDeCampagne);

            }
            return NotFound($"Un typeDeCampagne avec l'id : {id} n'existe pas");
        }

        [HttpGet("libelle/{libelle}", Name = "GetTypeDeCampagneByLibelle")]
        public IActionResult GetTypeDeCampagneByLibelle(string libelle)
        {
            var typeDeCampagne = _typeDeCampagneData.GetTypeDeCampagneByLibelle(libelle);
            if (typeDeCampagne != null)
            {
                return Ok(typeDeCampagne);

            }
            return NotFound($"Un typeDeCampagne avec le libelle : {libelle} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<TypeDeCampagne> AddTypeDeCampagne(TypeDeCampagne typeDeCampagne)
        {
            var verifiLibelle = _typeDeCampagneData.GetTypeDeCampagneByLibelle(typeDeCampagne.Libelle);
         
             if (verifiLibelle == null)
             {
                _typeDeCampagneData.AddTypeDeCampagne(typeDeCampagne);
                _typeDeCampagneData.SaveChanges();

                return CreatedAtRoute(nameof(GetTypeDeCampagneById), new { Id = typeDeCampagne.Id }, typeDeCampagne);
             }
             else { 
                return NotFound($"Un typeDeCampagne avec le libelle : {typeDeCampagne.Libelle} existe déjà");

            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<TypeDeCampagne> PutTypeDeCampagne(TypeDeCampagne tdc,int id)
        {
            var typeDeCampagne = _typeDeCampagneData.GetTypeDeCampagneById(id);
            if (typeDeCampagne != null)
            {
                var verifiLibelle = _typeDeCampagneData.GetTypeDeCampagneByLibelle(tdc.Libelle);
                if (verifiLibelle == null)
                {
                    _typeDeCampagneData.EditTypeDeCampagne(tdc, id);
                    _typeDeCampagneData.SaveChanges();
                    return CreatedAtRoute(nameof(GetTypeDeCampagneById), new { Id = typeDeCampagne.Id }, typeDeCampagne);
                }
                else 
                if (verifiLibelle.Id == typeDeCampagne.Id)
                {
                    _typeDeCampagneData.EditTypeDeCampagne(tdc, id);
                    _typeDeCampagneData.SaveChanges();
                    return CreatedAtRoute(nameof(GetTypeDeCampagneById), new { Id = typeDeCampagne.Id }, typeDeCampagne);
                }
                else
                {
                    return NotFound($"Un typeDeCampagne avec le libelle : {tdc.Libelle} existe déjà");

                }
               
            }
            return NotFound($"Un typeDeCampagne avec l'id : {id} n'existe pas");
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
