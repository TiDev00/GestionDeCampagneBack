using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class ListeDiffusionService : IListeDiffussion

    {
        private DbcontextGC _dbcontextGC;

        public ListeDiffusionService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddListeDeDiffusion(ListeDeDiffusion ListeDeDiffusion)
        {

            if (ListeDeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ListeDeDiffusion));

            }
            else
            {
                ListeDeDiffusion.Etat = true;
                ListeDeDiffusion.Statut = true;

                _dbcontextGC.ListeDeDiffusions.Add(ListeDeDiffusion);
               

            }

        }

        public ListeDeDiffusion EditListeDeDiffusion(ListeDeDiffusion ListeDeDiffusion, int Id)
        {
            var listeDeDiffusion = _dbcontextGC.ListeDeDiffusions.Find(Id);
            listeDeDiffusion.Titre = ListeDeDiffusion.Titre;
            listeDeDiffusion.Reference = ListeDeDiffusion.Reference;

            return ListeDeDiffusion;

        }

        public void DeleteListeDeDiffusion(ListeDeDiffusion ListeDeDiffusion)
        {
            if (ListeDeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ListeDeDiffusion));

            }
            _dbcontextGC.ListeDeDiffusions.Remove(ListeDeDiffusion);
        }

        public ListeDeDiffusion GetListeDiffusionByID(int id)
        {
            var ListeDeDiffusion = _dbcontextGC.ListeDeDiffusions.Find(id);
            return ListeDeDiffusion;
        }
        public List<Contact> GetContacts()
        {
            return _dbcontextGC.Contacts.ToList();


        }
        public List<ContactListeDiffusion> GetContactSelected()
        {
            return _dbcontextGC.ContactListeDiffusions.ToList();
        }

        public List<ListeDeDiffusion> GetListeDeDiffusions()
        {
            return _dbcontextGC.ListeDeDiffusions.ToList();


        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }

    }

}

