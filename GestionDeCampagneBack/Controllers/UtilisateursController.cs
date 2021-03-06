using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private IUtilisateur _utilisateurData;
        private IRole _roleData;

        public UtilisateursController(IUtilisateur UtilisateurData, IRole roleData)
        {
            _utilisateurData = UtilisateurData;
            _roleData = roleData;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllUtilisateurs()
        {
            return Ok(_utilisateurData.GetUtilisateurs());
        }

        [HttpGet("{id}", Name = "GetUtilisateurById")]
        public IActionResult GetUtilisateurById(int id)
        {
            var Utilisateur = _utilisateurData.GetUtilisateurById(id);
            if (Utilisateur != null)
            {
                return Ok(Utilisateur);

            }
            return NotFound($"Un Utilisateur avec l'id : {id} n'existe pas");
        }

        [HttpGet("login/{login}", Name = "GetUtilisateurByLogin")]
        public IActionResult GetUtilisateurByLogin(string login)
        {
            var user = _utilisateurData.GetUtilisateurByLogin(login);
            if (user != null)
            {
                return Ok(user);

            }
            return NotFound($"Un utilisateur avec le login : {login} n'existe pas");
        }

        [HttpGet("email/{email}", Name = "GetUtilisateurByEmail")]
        public IActionResult GetUtilisateurByEmail(string email)
        {
            var user = _utilisateurData.GetUtilisateurByEmail(email);
            if (user != null)
            {
                return Ok(user);

            }
            return NotFound($"Un utilisateur avec l'email : {email} n'existe pas");
        }

        [HttpPost("add")]
        public ActionResult<Utilisateur> AddUtilisateur(Utilisateur Utilisateur)
        {
 
            var role = _roleData.GetRoleById(Utilisateur.IdRole);
            if (role != null)
            {
                var verifiLogin = _utilisateurData.GetUtilisateurByLogin(Utilisateur.Login);
                var verifiEmail = _utilisateurData.GetUtilisateurByEmail(Utilisateur.Email);

                if (verifiLogin == null)
                {
                    if(verifiEmail == null)
                    {
                        string passwordHash = BCrypt.Net.BCrypt.HashPassword(Utilisateur.Password);
                        Utilisateur.Password = passwordHash;
                        Utilisateur.ConfirmPassword = passwordHash;
                        _utilisateurData.AddUtilisateur(Utilisateur);
                        _utilisateurData.SaveChanges();
                        role.Utilisateurs.Add(Utilisateur);
                        _roleData.SaveChanges();
                        return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = Utilisateur.Id }, Utilisateur);
                    }
                    else return NotFound($"Un Utilisateur avec l'email : {Utilisateur.Email} existe déjà");

                }
                else
                {
                    return NotFound($"Un Utilisateur avec le login : {Utilisateur.Login} existe déjà");

                }

            }
            else
            return NotFound($"Un role avec l'id : {Utilisateur.IdRole} n'existe pas");


            // return Ok(categorireadDto);
        }

        [HttpPut("put/{id}")]
        public ActionResult<Utilisateur> PutUtilisateur(Utilisateur user, int id)
        {
            var Utilisateur = _utilisateurData.GetUtilisateurById(id);
            if (Utilisateur != null)
            {
                _utilisateurData.EditUtilisateur(user, id);
                _utilisateurData.SaveChanges();
                return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = Utilisateur.Id }, Utilisateur);
            }
            return NotFound($"Un Utilisateur avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<Utilisateur> DeleteUtilisateur(int id)
        {

            var Utilisateur = _utilisateurData.GetUtilisateurById(id);
            if (Utilisateur != null)
            {
                _utilisateurData.DeleteUtilisateur(Utilisateur);
                _utilisateurData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un Utilisateur avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
