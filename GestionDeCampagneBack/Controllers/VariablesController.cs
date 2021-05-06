using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariablesController : ControllerBase
    {
        private IVariable _VariableData;
        private IContact _ContactData;

        public VariablesController(IVariable VariableData, IContact ContactData)
        {
            _VariableData = VariableData;
            _ContactData = ContactData;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAllVariables()
        {
            return Ok(_VariableData.GetVariables());
        }

        [HttpGet("{id}", Name = "GetVariableById")]
        public IActionResult GetVariableById(int id)
        {
            var Variable = _VariableData.GetVariableById(id);
            if (Variable != null)
            {
                return Ok(Variable);

            }
            return NotFound($"Un Variable avec l'id : {id} n'existe pas");
        }



        [HttpPost("add")]
        public ActionResult<Variable> AddVariable(Variable Variable)
        {

            var verifiNomAffichage = _VariableData.GetVariableById(Variable.Id);

            if (verifiNomAffichage == null)
            {
                _VariableData.AddVariable(Variable);
                _VariableData.SaveChanges();

                return CreatedAtRoute(nameof(GetVariableById), new { Id = Variable.Id }, Variable);
            }
            else
            {
                return NotFound($"Un Variable avec le NomAffichage : {Variable.NomAffichage} existe déjà");

            }


            // return Ok(categorireadDto);
        }

        [HttpPut("put/{id}")]
        public ActionResult<Variable> PutVariable(Variable vari, int id)
        {
            var Variable = _VariableData.GetVariableById(id);
            if (Variable != null)
            {
                _VariableData.EditVariable(vari, id);
                _VariableData.SaveChanges();
                return CreatedAtRoute(nameof(GetVariableById), new { Id = Variable.Id }, Variable);
            }
            return NotFound($"Un Variable avec l'id : {id} n'existe pas");



            // return Ok(categorireadDto);
        }



        [HttpDelete("delete/{id}")]
        public ActionResult<Variable> DeleteVariable(int id)
        {

            var Variable = _VariableData.GetVariableById(id);
            if (Variable != null)
            {
                _VariableData.DeleteVariable(Variable);
                _VariableData.SaveChanges();
                return Accepted();

            }
            return NotFound($"Un Variable avec l'id : {id} n'existe pas");
            // return Ok(categorireadDto);
        }
    }
}
