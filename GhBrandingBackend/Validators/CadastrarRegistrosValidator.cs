using FluentValidation;
using GhBrandingBackend.Models;
using GhBrandingBackend.Service;

namespace GhBrandingBackend.Validators
{
    public class CadastrarRegistrosValidator
        : AbstractValidator<Registros>
    {
        public CadastrarRegistrosValidator() 
        {
            TimeSpan limiteHoras = TimeSpan.FromHours(8.75);
            RuleFor(t => t.HorasDia).LessThan(limiteHoras)
                .WithMessage("O limite de horas diárias é 08h45min, caso precise de mais horas, entre com contato com o seu gestor");
        }
    }
}
