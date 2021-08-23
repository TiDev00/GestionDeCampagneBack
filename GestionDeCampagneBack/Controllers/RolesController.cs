using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeCampagneBack.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRole _roleData;

        public RolesController(IRole roleData)
        {
            _roleData = roleData;
        }
        // GET: api/<ValuesController>
        // [Authorize]
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleData.GetRoles());
        }

        [HttpGet("{id}", Name = "GetRoleById")]
        public IActionResult GetRoleById(int id)
        {
            var role = _roleData.GetRoleById(id);
            if (role != null)
            {
                return Ok(role);

            }
            return NotFound($"Un role avec l'id : {id} n'existe pas");
        }

        [HttpGet("libelle/{libelle}", Name = "GetRoleByLibelle")]
        public IActionResult GetRoleByLibelle(string libelle)
        {
            var role = _roleData.GetRoleByLibelle(libelle);
            if (role != null)
            {
                return Ok(role);

            }
            return NotFound($"Un role avec le libelle : {libelle} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<Role> AddRole(Role role)
        {
            var verifiLibelle = _roleData.GetRoleByLibelle(role.Libelle);

            if (verifiLibelle == null)
            {
                _roleData.AddRole(role);
                _roleData.SaveChanges();

                return CreatedAtRoute(nameof(GetRoleById), new { Id = role.Id }, role);
            }
            else
            {
                return NotFound($"Un role avec le libelle : {role.Libelle} existe déjà");

            }
        }

        [HttpPut("put/{id}")]
        public ActionResult<Role> PutRole(Role rol, int id)
        {
            var role = _roleData.GetRoleById(id);
            if (role != null)
            {
                var verifiLibelle = _roleData.GetRoleByLibelle(rol.Libelle);
                if (verifiLibelle == null)
                {
                    _roleData.EditRole(rol, id);
                    _roleData.SaveChanges();
                    return CreatedAtRoute(nameof(GetRoleById), new { Id = role.Id }, role);
                }
                else
                if (verifiLibelle.Id == role.Id)
                {
                    _roleData.EditRole(rol, id);
                    _roleData.SaveChanges();
                    return CreatedAtRoute(nameof(GetRoleById), new { Id = role.Id }, role);
                }
                else
                {
                    return NotFound($"Un role avec le libelle : {rol.Libelle} existe déjà");

                }

            }
            return NotFound($"Un role avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<Role> DeleteRole(int id)
        {

            var role = _roleData.GetRoleById(id);
            if (role != null)
            {
                _roleData.DeleteRole(role);
                _roleData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un role avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
