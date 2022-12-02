using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWebEmpleado.Validations
{
    public class CheckLegajo:ValidationAttribute
    {
        public CheckLegajo()
        {
            ErrorMessage="Ingrese en formato LEGAJO: AA y 5 num";
        }
        public override bool IsValid(object value)
        {
            string legajo = (string)value;
            if (legajo != null &&
                legajo.Length == 7 &&
                legajo.StartsWith("AA") &&
                legajo.Substring(2, 5).All(char.IsDigit))
            {

                return true;
            }
            else
            {
                return false;
            }
            
         

        }
    }
}
