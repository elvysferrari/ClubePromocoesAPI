using ClubePromocoesAPI.Commands.PromocaoModule.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.PromocaoModule.Validations
{
    public class AdicionarPromocaoCommandValidator : AbstractValidator<AdicionarPromocaoCommand> 
    {
        public AdicionarPromocaoCommandValidator()
        {
            RuleFor(x => x.Titulo).MaximumLength(150).WithMessage("Título deve ter no máximo 150 caracteres")
                                  .NotNull().WithMessage("Título não pode ser nulo");
        }
    }
}
