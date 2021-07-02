using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace GestionDeCampagneBack.Controllers

{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CampagnesController : ControllerBase
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        private ICanalEnvoi _canalEnvoiData;
        private IEntite _entiteData;
        private ICampagne _campagneData;
        private INiveauDeVisibilite _niveauDeVisibiliteData;

        public CampagnesController(ICanalEnvoi CanalEnvoiData, IEntite entite, ICampagne campagne, INiveauDeVisibilite niveauDeVisibilite)
        {
            _canalEnvoiData = CanalEnvoiData;
            _entiteData = entite;
            _campagneData = campagne;
            _niveauDeVisibiliteData = niveauDeVisibilite;

        }

        [HttpGet("all/{id}")]
        public IActionResult GetAllCampagne(int id)
        {

            return Ok(_campagneData.GetCampagnes(id));
        }

        [HttpGet("{id}", Name = "GetCampagneById")]
        public IActionResult GetCampagneById(int id)
        {
            var Campagne = _campagneData.GetCampagneById(id);
            if (Campagne != null)
            {
                return Ok(Campagne);

            }
            return NotFound($"Une Campagne avec l'id : {id} n'existe pas");
        }

        [HttpGet("changeEtat/{id}")]
        public IActionResult ChangeetatCampagneById(int id)
        {
            var campagne = _campagneData.GetCampagneById(id);
            if (campagne != null)
            {
                if (campagne.Etat == true)
                {
                    campagne.Etat = false;
                    _campagneData.SaveChanges();
                    return Ok(campagne);
                }
                else
                {
                    campagne.Etat = true;
                    _campagneData.SaveChanges();
                    return Ok(campagne);
                }


            }
            return NotFound($"Une Campagne avec l'id : {id} n'existe pas");
        }


        [HttpGet("code/{code}", Name = "GetCampagneByCode")]
        public IActionResult GetCampagneByCode(string code)
        {
            var Campagne = _campagneData.GetCampagneByCode(code);
            if (Campagne != null)
            {
                return Ok(Campagne);

            }
            return NotFound($"Une Campagne avec le code : {code} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<Campagne> AddCanalEnvoi(Campagne Campagne)
        {
            var entite = _entiteData.GetEntiteById(Campagne.IdEntite);
            if (entite != null)
            {
                var Camp = _campagneData.GetCampagneByCode(Campagne.Code);
                if (Camp != null)
                {
                    _campagneData.AddCampagne(Campagne);
                    _campagneData.SaveChanges();
                    // Send Campagne mail
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("tikokane11@gmail.com", "tikokane");

                    try
                    {
                        using (var message = new MailMessage("tikokane11@gmail.com", "diallo.thiernoabdourahmane@atos.net"))
                        {
                            message.Subject = "Test";
                            message.Body = "Nice Test";
                            message.IsBodyHtml = true;
                            smtp.Send(message);
                        }
                    }
                    catch (Exception ex)
                    {

                        //to do: stockage dans une table pour un envoi antérieur
                    }
                    return CreatedAtRoute(nameof(GetCampagneById), new { Id = Camp.Id }, Camp);
                }
                else
                {
                    return NotFound($"Une Camapgne avec le code : {Campagne.Code} n'existe pas");
                }
            }
            else
                return NotFound($"Une entité avec l'id : {Campagne.IdEntite} n'existe pas");

        }

        [HttpPut("put/{id}")]
        public ActionResult<CanalEnvoi> PutCampagneEnvoi(Campagne campagne, int id)
        {
            var entite = _entiteData.GetEntiteById(campagne.IdEntite);
            if (entite != null)
            {
                var camp = _campagneData.GetCampagneById(id);
                if (camp != null)
                {

                    var verifiCode = _campagneData.GetCampagneByCode(campagne.Code);

                    if (verifiCode == null)
                    {
                        _campagneData.EditCampagne(campagne, id);
                        _campagneData.SaveChanges();
                        return CreatedAtRoute(nameof(GetCampagneById), new { Id = camp.Id }, camp);
                    }
                    else if (verifiCode.Id == camp.Id)
                    {
                        _campagneData.EditCampagne(campagne, id);
                        _campagneData.SaveChanges();
                        return CreatedAtRoute(nameof(GetCampagneById), new { Id = camp.Id }, camp);

                    }
                    else
                        return NotFound($"Une Campagne avec le code : {campagne.Code} n'existe déjà");
                }
                return NotFound($"Une campagne avec l'id : {id} n'existe pas");
            }
            else
                return NotFound($"Une Entité avec l'id : {campagne.IdEntite} n'existe pas");

        }


        [HttpDelete("delete/{id}")]
        public ActionResult<Campagne> DeleteCampagne(int id)
        {

            var Campagne = _campagneData.GetCampagneById(id);
            if (Campagne != null)
            {
                _campagneData.DeleteCampagne(Campagne);
                _campagneData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Une Campagne avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}