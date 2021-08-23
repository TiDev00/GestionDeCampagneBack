using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class VariableService : IVariable
    {
        private DbcontextGC _dbcontextGC;

        public VariableService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddVariable(Variable Variable)
        {
            if (Variable == null)
            {
                throw new ArgumentNullException(nameof(Variable));

            }

            _dbcontextGC.Variables.Add(Variable);
        }

        public void DeleteVariable(Variable Variable)
        {
            if (Variable == null)
            {
                throw new ArgumentNullException(nameof(Variable));

            }
            _dbcontextGC.Variables.Remove(Variable);
            // _dbcontextGC.Variables.Remove(Variable);

        }

        public Variable EditVariable(Variable Variable, int id)
        {
            var variable = _dbcontextGC.Variables.Find(id);
            variable.NomAffichage = Variable.NomAffichage;
            variable.IdContact = Variable.IdContact;
            variable.NomTechnique = Variable.NomTechnique;
            variable.TailleMax = Variable.TailleMax;
            variable.Type = Variable.Type;
            variable.Valeur = Variable.Valeur;
            return variable;
        }

        public Variable GetVariableById(int id)
        {
            var value = _dbcontextGC.Variables.Find(id);
            return value;
        }



        public List<Variable> GetVariables()
        {
            return _dbcontextGC.Variables.ToList();
        }
        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }

       
    }
}
