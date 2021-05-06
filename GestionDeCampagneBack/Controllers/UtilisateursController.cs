using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
       // [Authorize]
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

        [HttpPost("auth", Name = "GetUtilisateurByloginAndPassword")]
        public IActionResult GetUtilisateurByloginAndPassword(Authentification aut)
        {
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(aut.Password);
            var user = _utilisateurData.GetUtilisateurByLogin(aut.Login);
            if (user == null)
                
                return BadRequest(new { message = "Login ou mot de passe invalide" });
            else
            {
                bool verified = BCrypt.Net.BCrypt.Verify(aut.Password, user.Password);
                if (verified == true)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superGCSecretKey@11"));
                    var signingCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:44332",
                        audience: "https://localhost:44332",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signingCredential
                        );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    return Ok(new { Token = tokenString, user });
                }
                else
                {
                    return BadRequest(new { message = "Login ou mot de passe invalide" });
                }
            }
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
                    if (verifiEmail == null)
                    {
                        string passwordHash = BCrypt.Net.BCrypt.HashPassword("passer");

                        Utilisateur.Password = passwordHash;
                        Utilisateur.ConfirmPassword = passwordHash;
                        Utilisateur.Etat = true;
                        Utilisateur.Statut = true;
                        Utilisateur.Ischange = false;
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
            var role = _roleData.GetRoleById(user.IdRole);
            if (role != null)
            {
                var utilisateur = _utilisateurData.GetUtilisateurById(id);
                if (utilisateur != null)
                {
                    var verifiEmail = _utilisateurData.GetUtilisateurByEmail(user.Email);
                    var verifiLogin = _utilisateurData.GetUtilisateurByLogin(user.Login);

                    if (verifiLogin == null && verifiEmail == null)
                    {

                        _utilisateurData.EditUtilisateur(user, id);
                        _utilisateurData.SaveChanges();
                        return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = utilisateur.Id }, utilisateur);
                    }
                    else if (verifiEmail.Id == utilisateur.Id && verifiLogin.Id == utilisateur.Id)
                    {
                        _utilisateurData.EditUtilisateur(user, id);
                        _utilisateurData.SaveChanges();
                        return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = utilisateur.Id }, utilisateur);
                    }
                    else if (verifiEmail.Id != utilisateur.Id && verifiLogin.Id == utilisateur.Id)

                    {
                        return NotFound($"Un utilisateur avec l'email : {user.Email} existe déjà");
                    }
                    else

                        return NotFound($"Un utilisateur avec le login : {user.Login} existe déjà");



                }
                return NotFound($"Un Utilisateur avec l'id : {id} n'existe pas");
            }
            else
                return NotFound($"Un role avec l'id : {user.IdRole} n'existe pas");


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
