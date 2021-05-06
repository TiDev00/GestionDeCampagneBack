using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IVariable
    {
        bool SaveChanges();
        List<Variable> GetVariables();

        Variable GetVariableById(int id);

        void AddVariable(Variable Variable);

        void DeleteVariable(Variable Variable);

        Variable EditVariable(Variable Variable, int id);
    }
}
