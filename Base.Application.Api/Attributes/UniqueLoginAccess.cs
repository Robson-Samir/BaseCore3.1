using System;
using Base.Infrastructure.CrossCutting.Enums;

namespace Base.Application.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class UniqueLoginAccess : Attribute
    {
        /// <summary>
        /// Tipo de Acesso
        /// </summary>
        public TipoAcesso _TipoAcesso { get; set; }

        /// <summary>
        /// Tipo de Permissao
        /// </summary>
        public TipoDePermissao _TipoDePermissao { get; set; }

        /// <summary>
        /// Funcionalidade
        /// </summary>
        public Funcionalidade _Funcionalidade { get; set; }

        /// <summary>
        /// Acesso
        /// </summary>
        /// <param name="funcionalidade">Funcionalidade</param>
        /// <param name="tipoPermissao">Tipo de Permissão</param>
        public UniqueLoginAccess(Funcionalidade funcionalidade, TipoDePermissao tipoPermissao)
        {
            _TipoAcesso = TipoAcesso.Acesso;
            _Funcionalidade = funcionalidade;
            _TipoDePermissao = tipoPermissao;
        }

        /// <summary>
        /// Acesso
        /// </summary>
        /// <param name="tipoAcesso">Tipo de Acesso</param>
        /// <param name="funcionalidade">Funcionalidade</param>
        /// <param name="tipoPermissao">Tipo de Permissão</param>
        public UniqueLoginAccess(TipoAcesso tipoAcesso, Funcionalidade funcionalidade, TipoDePermissao tipoPermissao)
        {
            _TipoAcesso = tipoAcesso;
            _Funcionalidade = funcionalidade;
            _TipoDePermissao = tipoPermissao;
        }
    }
}
