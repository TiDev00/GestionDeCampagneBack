﻿using DotnetOrangeSms;
using DotnetOrangeSms.Extensions;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class CampagneService : ICampagne
    {

        private DbcontextGC _dbcontextGC;

        public CampagneService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddCampagne(Campagne Campagne)
        {
            if (Campagne == null)
            {
                throw new ArgumentNullException(nameof(Campagne));

            }
            else
            {
                var countval = _dbcontextGC.Campagnes.Count();
                if (countval >= 1)
                {
                    var maxId = _dbcontextGC.Campagnes.Max(p => p.Id);

                    Campagne.Code = "CAMP0000" + (maxId + 1).ToString();
                    Campagne.Etat = true;
                    Campagne.Statut = true;

                    _dbcontextGC.Campagnes.Add(Campagne);
                }
                else
                {


                    Campagne.Code = "CAMP00001";
                    Campagne.Etat = true;
                    Campagne.Statut = true;
                    _dbcontextGC.Campagnes.Add(Campagne);
                }


            }

        }

        public void DeleteCampagne(Campagne Campagne)
        {
            if (Campagne == null)
            {
                throw new ArgumentNullException(nameof(Campagne));

            }
            _dbcontextGC.Campagnes.Remove(Campagne);
        }

        public Campagne EditCampagne(Campagne Campagne, int id)
        {
            var camp = _dbcontextGC.Campagnes.Find(id);
            camp.Code = Campagne.Code;
            camp.Description = Campagne.Description;
            camp.Etat = Campagne.Etat;
            camp.Titre = Campagne.Titre;
            camp.DateDeDebut = Campagne.DateDeDebut;
            camp.DateDeFin = Campagne.DateDeFin;
            camp.IdEntite = Campagne.IdEntite;
            camp.IdNiveauVisibilite = Campagne.IdNiveauVisibilite;
            camp.IdRegleEnvoi = Campagne.IdRegleEnvoi;
            camp.IdTypeCampagne = Campagne.IdTypeCampagne;
            camp.IdUtilisateur = Campagne.IdUtilisateur;
            camp.Statut = Campagne.Statut;
            return camp;

        }



        public Campagne GetCampagneByCode(string code)
        {
            var Campagne = _dbcontextGC.Campagnes.FirstOrDefault(r => r.Code == code);
            if (Campagne != null)
                return Campagne;
            else return null;
        }

        public Campagne GetCampagneById(int id)
        {
            var Campagne = _dbcontextGC.Campagnes.Find(id);
            return Campagne;
        }


        public List<Campagne> GetCampagnes(int id)
        {
            return _dbcontextGC.Campagnes.Where(r => r.IdEntite == id).ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }

        public void SendMail(string email,string body)
        {
            // Send Campagne mail
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("tikokane11@gmail.com", "Tikoneymar11");

            try
            {
                using (var message = new MailMessage("tikokane11@gmail.com", email))
                {
                    message.Subject = "Test";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {

                //to do: stockage dans une table pour un envoi antérieur
            }
        }

        //Sending SMS
        public async Task SendingSms(SmsClient smsClient, string numero, string contenu)
        {
            var response = await smsClient.SendSms(contenu, "2210000", "221"+ numero, "Tikokane");
            if (response.IsSuccess)
                Console.WriteLine($"Sms sent: {response.Value}");
            else
                Console.WriteLine($"Sending sms failed:{response.Error}");
        }


    }
}