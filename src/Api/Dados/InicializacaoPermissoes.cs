//using Microsoft.OpenApi.Extensions;
using Api.Helpers.Enums;
using Microsoft.EntityFrameworkCore;
using Api.Enums.Usuario;
using Api.Models;

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
            var enums = Enum.GetValues<EPERMISSAO>();

            string[] names = new string[enums.Length];
            string[] descriptions = new string[enums.Length];
            int index = 0;

            foreach(var enumType in enums)
            {
                names[index] = EnumHelper.GetDisplayName(enumType);
                descriptions[index] = EnumHelper.GetEnumDescription(enumType);
                index++;
            }

            _modelBuilder.Entity<PERMISSAO>()
                .HasData(
                    
                    names, 
                    descriptions
                );
        }
    }
}