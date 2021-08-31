using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategorie _CategorieData;

        public CategoriesController(ICategorie CategorieData)
        {
            _CategorieData = CategorieData;
        }

        [HttpGet("all/{id}")]
        public IActionResult GetAllCategories(int id)
        {
            return Ok(_CategorieData.GetCategories(id));
        }

        [HttpGet("{id}", Name = "GetCategorieById")]
        public IActionResult GetCategorieById(int id)
        {
            var Categorie = _CategorieData.GetCategorieById(id);
            if (Categorie != null)
            {
                return Ok(Categorie);

            }
            return NotFound($"Un type de campagne avec l'id : {id} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<Categorie> AddCategorie(Categorie Categorie)
        {

            _CategorieData.AddCategorie(Categorie);
            _CategorieData.SaveChanges();

            return CreatedAtRoute(nameof(GetCategorieById), new { Id = Categorie.Id }, Categorie);



        }

        [HttpPut("put/{id}")]
        public ActionResult<Categorie> PutCategorie(Categorie tdc, int id)
        {
            var Categorie = _CategorieData.GetCategorieById(id);
            if (Categorie != null)
            {

                _CategorieData.EditCategorie(tdc, id);
                _CategorieData.SaveChanges();
                return CreatedAtRoute(nameof(GetCategorieById), new { Id = Categorie.Id }, Categorie);

            }
            else
                return NotFound($"Un type de campagne avec l'id : {id} n'existe pas");
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<Categorie> DeleteCategorie(int id)
        {

            var Categorie = _CategorieData.GetCategorieById(id);
            if (Categorie != null)
            {
                _CategorieData.DeleteCategorie(Categorie);
                _CategorieData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un Categorie avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}