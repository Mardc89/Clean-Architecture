using App.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Validators
{
    public class CreatePersonDTOValidator:AbstractValidator<CreatePersonDTO>
    {
        public CreatePersonDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
        }
    }
}



