using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{

    public class ContactCanalService : IContactCanal
    {
        private DbcontextGC _dbcontextGC;

        public ContactCanalService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddContactCanal(ContactCanal ContactCanal)
        {
            if (ContactCanal == null)
            {
                throw new ArgumentNullException(nameof(ContactCanal));

            }
            ContactCanal.Etat = true;
            _dbcontextGC.ContactCanals.Add(ContactCanal);
        }

        public void DeleteContactCanal(ContactCanal ContactCanal)
        {
            if (ContactCanal == null)
            {
                throw new ArgumentNullException(nameof(ContactCanal));

            }
            _dbcontextGC.ContactCanals.Remove(ContactCanal);
            // _dbcontextGC.ContactCanals.Remove(ContactCanal);

        }

        public ContactCanal EditContactCanal(ContactCanal ContactCanal, int id)
        {
            var contactCanal = _dbcontextGC.ContactCanals.Find(id);
            contactCanal.Etat = ContactCanal.Etat;
            contactCanal.CanalDuContatct = ContactCanal.CanalDuContatct;
            contactCanal.DateDesabonnement = ContactCanal.DateDesabonnement;
            contactCanal.IdCanalEnvoi = ContactCanal.IdCanalEnvoi;
            contactCanal.IdContact = ContactCanal.IdContact;
            contactCanal.Raison = ContactCanal.Raison;
            contactCanal.IdEntite = ContactCanal.IdEntite;
            return contactCanal;
        }

        public ContactCanal GetContactCanalById(int id)
        {
            var value = _dbcontextGC.ContactCanals.Find(id);
            return value;
        }


        public List<ContactCanal> GetContactCanals(int id)
        {
            return _dbcontextGC.ContactCanals.Where(r => r.IdEntite == id).ToList();
        }
        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }


    }
}
