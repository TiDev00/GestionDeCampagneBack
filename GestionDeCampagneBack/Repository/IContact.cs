using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IContact
    {
        bool SaveChanges();
        List<Contact> GetContacts();

        Contact GetContactById(int Id);

        /*Contact GetContactByNom(string Nom);
        Contact GetContactByAdresse(string Adresse);
        Contact GetContactByPays(string Pays);
        Contact GetContactByRegion(string Region);
        Contact GetContactByDateDeNaissance(DateTime DateNaissance);
        Contact GetContactBySexe(bool Sexe);
        Contact GetContactBySituation(bool Situation);
        Contact GetContactByProfession(string Profession);*/
        Contact GetContactByMatricul(string Matricule);

        void AddContact(Contact Contact);

        void DeleteContact(Contact Contact);

        Contact EditContact(Contact Contact, int Id);
    }
}
