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
        private IEntite _entiteData;
        private ICampagne _campagneData;


        public UtilisateursController(IUtilisateur UtilisateurData, ICampagne campagneData, IRole roleData, IEntite entite)
        {
            _entiteData = entite;
            _campagneData = campagneData;
            _utilisateurData = UtilisateurData;
            _roleData = roleData;
        }
        // GET: api/<ValuesController>
        [HttpGet("all/{id}")]
        // [Authorize]
        public IActionResult GetAllUtilisateurs(int id)
        {
            return Ok(_utilisateurData.GetUtilisateurs(id));
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

        [HttpGet("changestatut/{id}")]
        public IActionResult ChangeStatutUser(int id)
        {
            var Utilisateur = _utilisateurData.GetUtilisateurById(id);
            if (Utilisateur != null)
            {
                if (Utilisateur.Statut == true)
                {
                    Utilisateur.Statut = false;
                    _utilisateurData.SaveChanges();
                    return Ok(Utilisateur);
                }
                else
                {
                    Utilisateur.Statut = true;
                    _utilisateurData.SaveChanges();
                    return Ok(Utilisateur);
                }


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
            if (user == null || user.Etat == false)

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

        [HttpPut("changepassword/{id}")]
        public IActionResult GetUserByIdForChangePassword(int id, Changerpassword chm)
        {
            var user = _utilisateurData.GetUtilisateurById(id);
            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(chm.Amp, user.Password);
                if (verified == true)
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(chm.Nmp);
                    user.Password = passwordHash;
                    user.Ischange = true;
                    _utilisateurData.SaveChanges();
                    return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = user.Id }, user);
                }
                else
                {
                    return NotFound($"Le mot de passe est incorrecte");

                }



            }
            return NotFound($"Un utilisateur avec l'email : {id} n'existe pas");
        }


        [HttpPost("add")]
        public ActionResult<Utilisateur> AddUtilisateur(Utilisateur Utilisateur)
        {
            Random rnd = new Random();
            var entite = _entiteData.GetEntiteById(Utilisateur.IdEntite);
            if (entite != null)
            {
                var role = _roleData.GetRoleById(Utilisateur.IdRole);
                if (role != null)
                {
                    var verifiLogin = _utilisateurData.GetUtilisateurByLogin(Utilisateur.Login);

                    if (verifiLogin == null)
                    {
                        int card = rnd.Next(10000, 99999);
                        string passwordHash = BCrypt.Net.BCrypt.HashPassword(card.ToString());

                        Utilisateur.Password = passwordHash;
                        Utilisateur.ConfirmPassword = passwordHash;
                        Utilisateur.Ischange = false;
                        _utilisateurData.AddUtilisateur(Utilisateur);
                        _utilisateurData.SaveChanges();
                        role.Utilisateurs.Add(Utilisateur);
                        _roleData.SaveChanges();
                        _campagneData.SendMail(Utilisateur.Email, "Votre code de vérification est le suivant : "+ card +" "+ "\r\n" + "Votre compte n’est pas accessible sans ce code de vérification, même si vous n’avez pas soumis cette requête.");
                        return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = Utilisateur.Id }, Utilisateur);
                    }
                    else
                    {
                        return NotFound($"Un Utilisateur avec le login : {Utilisateur.Login} existe déjà");

                    }

                }
                else
                    return NotFound($"Un role avec l'id : {Utilisateur.IdRole} n'existe pas");
            }
            else return NotFound($"Une entité avec l'id : {Utilisateur.IdEntite} n'existe pas");
        }

        [HttpPut("put/{id}")]
        public ActionResult<Utilisateur> PutUtilisateur(Utilisateur user, int id)
        {
            var entite = _entiteData.GetEntiteById(user.IdEntite);
            if (entite != null)
            {
                var role = _roleData.GetRoleById(user.IdRole);
                if (role != null)
                {
                    var utilisateur = _utilisateurData.GetUtilisateurById(id);
                    if (utilisateur != null)
                    {
                        var verifiLogin = _utilisateurData.GetUtilisateurByLogin(user.Login);

                        if (verifiLogin == null)
                        {
                            _utilisateurData.EditUtilisateur(user, id);
                            _utilisateurData.SaveChanges();
                            return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = utilisateur.Id }, utilisateur);
                        }
                        else if (verifiLogin.Id == utilisateur.Id)
                        {
                            _utilisateurData.EditUtilisateur(user, id);
                            _utilisateurData.SaveChanges();
                            return CreatedAtRoute(nameof(GetUtilisateurById), new { Id = utilisateur.Id }, utilisateur);
                        }

                        else

                            return NotFound($"Un utilisateur avec le login : {user.Login} existe déjà");
                    }
                    return NotFound($"Un Utilisateur avec l'id : {id} n'existe pas");
                }
                else
                    return NotFound($"Un role avec l'id : {user.IdRole} n'existe pas");
            }
            else return NotFound($"Une entité avec l'id : {user.IdEntite} n'existe pas");
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
