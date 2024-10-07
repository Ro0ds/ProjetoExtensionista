using Api.Enums.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Api.Dados
{
    public class InicializacaoPermissoes
    {
        private readonly ModelBuilder _modelBuilder;

        public InicializacaoPermissoes(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            // 
        }
    }
}