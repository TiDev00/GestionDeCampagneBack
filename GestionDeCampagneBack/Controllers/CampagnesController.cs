using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Mvc;
using GestionDeCampagneBack.ModelsRequets;
using System;
using System.Net;
using System.Net.Mail;
using System.Linq;
using DotnetOrangeSms;
using System.Threading.Tasks;
using DotnetOrangeSms.Extensions;

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
        private DbcontextGC _dbcontextGC;
        private IModele _modelData;

        public CampagnesController(IModele ModeleData, DbcontextGC dbcontextGC, ICanalEnvoi CanalEnvoiData, IEntite entite, ICampagne campagne, INiveauDeVisibilite niveauDeVisibilite)
        {
            _canalEnvoiData = CanalEnvoiData;
            _entiteData = entite;
            _campagneData = campagne;
            _niveauDeVisibiliteData = niveauDeVisibilite;
            _dbcontextGC = dbcontextGC;
            _modelData = ModeleData;

        }
    

        [HttpGet("all/{id}")]
        public async Task<IActionResult> GetAllCampagneAsync(int id)
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

        [HttpPost("sendEmail/{id}/{idModel}")]
        public IActionResult SendEmailAsync( int id,int idModel)
        {
            var model = _modelData.GetModeleById(idModel);

            Response r = new Response();
            var query = (from x in _dbcontextGC.ContactCanals
                         where x.IdEntite == id && x.CanalDuContatct == "Mail"
                         select new LienounumeroRequet()
                         {
                             Lieuounumero = x.Lieuounumero
                         }
                        ).AsQueryable();

            foreach(LienounumeroRequet l in query)
            {
                _campagneData.SendMail(l.Lieuounumero,model.Contenu);

            }
            r.Status = "200";
            r.Message = "Email Send avec Success";
            return Ok(r);


        }
        [HttpPost("SendSms/{id}/{idModel}")]
        public async Task<IActionResult> SendSms(int id, int idModel)
        {
            var smsClient = await SmsClient.Authenticate();
            var model = _modelData.GetModeleById(idModel);

            Response r = new Response();
            var query = (from x in _dbcontextGC.ContactCanals
                         where x.IdEntite == id && x.CanalDuContatct == "Téléphone"
                         select new LienounumeroRequet()
                         {
                             Lieuounumero = x.Lieuounumero
                         }
                        ).AsQueryable();

            foreach (LienounumeroRequet l in query)
            {
                try
                {
                    await _campagneData.SendingSms(smsClient,l.Lieuounumero,model.Contenu);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception:{ex.Message}");
                }

            }
            r.Status = "200";
            r.Message = "Mess Send avec Success";
            return Ok(r);

        }
        


[HttpPost("add")]
        public ActionResult<Campagne> AddCanalEnvoi(Campagne Campagne)
        {
            var entite = _entiteData.GetEntiteById(Campagne.IdEntite);
            if (entite != null)
            {
                var Camp = _campagneData.GetCampagneByCode(Campagne.Code);
                if (Camp == null)
                {

                    _campagneData.AddCampagne(Campagne);
                    _campagneData.SaveChanges();
                    return CreatedAtRoute(nameof(GetCampagneById), new { Id = Campagne.Id }, Campagne);
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