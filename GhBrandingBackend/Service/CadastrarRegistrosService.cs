using GhBrandingBackend.Dtos;
using GhBrandingBackend.Models;
using GhBrandingBackend.Validators;

namespace GhBrandingBackend.Service
{
    public class CadastrarRegistrosService
    {
        public static Registros CadastrarRegistros(CadastrarRegistrosDto request)
        {
            Registros registros = new()
            {
                Descricao = request.Descricao,
                RegistroInicial = request.RegistroInicial,
                RegistroFinal = request.RegistroFinal
            };
            registros.CalularHorasDia();

            return registros;
        }
    }
}
