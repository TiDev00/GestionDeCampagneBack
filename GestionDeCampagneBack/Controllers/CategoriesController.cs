using Microsoft.AspNetCore.Mvc;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategorie _categorieData;

        public CategoriesController(ICategorie categorieData)
        {
            _categorieData = categorieData;
        }
      
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categorieData.GetCategories());
        }

        [HttpGet("{id}", Name = "GetCategorieById")]
        public IActionResult GetCategorieById(int id)
        {
            var categorie = _categorieData.GetCategorieById(id);
            if (categorie != null)
            {
                return Ok(categorie);

            }
            return NotFound($"Un categorie avec l'id : {id} n'existe pas");
        }

        [HttpGet("libelle/{libelle}", Name = "GetCategorieByLibelle")]
        public IActionResult GetCategorieByLibelle(string libelle)
        {
            var categorie = _categorieData.GetCategorieByLibelle(libelle);
            if (categorie != null)
            {
                return Ok(categorie);

            }
            return NotFound($"Un categorie avec le libelle : {libelle} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<Categorie> AddCategorie(Categorie categorie)
        {
            var verifiLibelle = _categorieData.GetCategorieByLibelle(categorie.Libelle);
         
             if (verifiLibelle == null)
             {
                _categorieData.AddCategorie(categorie);
                _categorieData.SaveChanges();

                return CreatedAtRoute(nameof(GetCategorieById), new { Id = categorie.Id }, categorie);
             }
             else { 
                return NotFound($"Un categorie avec le libelle : {categorie.Libelle} existe déjà");

            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<Categorie> PutCategorie(Categorie cat,int id)
        {
            var categorie = _categorieData.GetCategorieById(id);
            if (categorie != null)
            {
                var verifiLibelle = _categorieData.GetCategorieByLibelle(cat.Libelle);
                if (verifiLibelle == null)
                {
                    _categorieData.EditCategorie(cat, id);
                    _categorieData.SaveChanges();
                    return CreatedAtRoute(nameof(GetCategorieById), new { Id = categorie.Id }, categorie);
                }
                else 
                if (verifiLibelle.Id == categorie.Id)
                {
                    _categorieData.EditCategorie(cat, id);
                    _categorieData.SaveChanges();
                    return CreatedAtRoute(nameof(GetCategorieById), new { Id = categorie.Id }, categorie);
                }
                else
                {
                    return NotFound($"Un categorie avec le libelle : {cat.Libelle} existe déjà");

                }
               
            }
            return NotFound($"Un categorie avec l'id : {id} n'existe pas");
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<Categorie> DeleteCategorie(int id)
        {

            var categorie = _categorieData.GetCategorieById(id);
            if (categorie != null)
            {
                _categorieData.DeleteCategorie(categorie);
                _categorieData.SaveChanges();
                return Accepted(); 

            }
            return NotFound($"Un categorie avec l'id : {id} n'existe pas");
        }
    }
}
