using Microsoft.Extensions.DependencyInjection;

namespace Base.Infrastructure.CrossCutting.Utilities
{
    public static class Constants
    {
        public static ServiceProvider serviceProvider;
        public const string CHAVE_CODIGO_USUARIO = "CODIGO_USUARIO";
        public const string CHAVE_CODIGO_ORGANIZACAO = "PARAM_LOGIN";
    }
}
