using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class ContactCanalEnvoiService : IContactCanalEnvoi
    {

        private DbcontextGC _dbcontextGC;

        public ContactCanalEnvoiService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddContactCanal(ContactCanal ContactCanal)
        {

            if (ContactCanal == null)
            {
                throw new ArgumentNullException(nameof(ContactCanal));

            }
            else
            {
                        ContactCanal.Etat = true;

                    _dbcontextGC.ContactCanals.Add(ContactCanal);
                }


            
        }

        public void DeleteContactCanal(ContactCanal ContactCanal)
        {
            if (ContactCanal == null)
            {
                throw new ArgumentNullException(nameof(ContactCanal));

            }
            _dbcontextGC.ContactCanals.Remove(ContactCanal);
        }

        public ContactCanal EditContactCanal(ContactCanal ContactCanal, int Id)
        {
            var can = _dbcontextGC.ContactCanals.Find(Id);

            can.CanalDuContatct = ContactCanal.CanalDuContatct;
            can.DateDesabonnement = ContactCanal.DateDesabonnement;
            can.Etat = ContactCanal.Etat;
            can.IdCanalEnvoi = ContactCanal.IdCanalEnvoi;
            can.IdContact = ContactCanal.IdContact;
            can.Raison = ContactCanal.Raison;
            can.IdCanalEnvoiNavigation = ContactCanal.IdCanalEnvoiNavigation;
            can.IdContactNavigation = ContactCanal.IdContactNavigation;
            return can;

        }

        public ContactCanal GetContactCanalById(int Id)
        {
            var ContactCanal = _dbcontextGC.ContactCanals.Find(Id);
            return ContactCanal;
        }

        public List<ContactCanal> GetContactCanalCanals()
        {
            return _dbcontextGC.ContactCanals.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);   
        }
    }
}
