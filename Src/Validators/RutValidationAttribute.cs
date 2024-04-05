using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ayudantia_IDWM.Src.Validators
{
    public class RutValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value){
            if(value != null){
                return true;
            }
            return false;

        }
    }
}