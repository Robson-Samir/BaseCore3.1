using System.Collections.Generic;

namespace Base.Infrastructure.CrossCutting.Utilities.Results
{
    /// <summary>
    /// Classe Resultado Pesquisa'1
    /// </summary>
    public class ResultadoPesquisa<T> : ResultadoBase
    {
        #region Construtores

        public ResultadoPesquisa()
        {
            Resultado = default(T);
            TotalPaginas = null;
            TotalRegistros = null;
            PrimeiraPagina = null;
            UltimaPagina = null;
            TamanhoPagina = null;
            PaginaAtual = null;
        }

        public ResultadoPesquisa(T data)
        {
            Resultado = data;
        }

        public ResultadoPesquisa(T item, Paginacao pag)
        {
            PaginaAtual = pag.PaginaAtual;
            TotalPaginas = pag.TotalPaginas;
            TotalRegistros = pag.TotalRegistros;
            PrimeiraPagina = pag.PrimeiraPagina;
            UltimaPagina = pag.UltimaPagina;
            TamanhoPagina = pag.TamanhoPagina;
            Resultado = item;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Objeto de Retorno
        /// </summary>
        public T Resultado { get; set; }

        /// <summary>
        /// Paginação Atual
        /// </summary>
        public int? PaginaAtual { get; set; }

        /// <summary>
        /// Total de Paginas
        /// </summary>
        public int? TotalPaginas { get; set; }

        /// <summary>
        /// Total de Registros
        /// </summary>
        public int? TotalRegistros { get; set; }

        /// <summary>
        /// Primeira Pagina
        /// </summary>
        public bool? PrimeiraPagina { get; set; }

        /// <summary>
        /// Última Pagina
        /// </summary>
        public bool? UltimaPagina { get; set; }

        /// <summary>
        /// Tamanho da Pagina
        /// </summary>
        public int? TamanhoPagina { get; set; }

        #endregion
    }

    /// <summary>
    /// Classe Resultado Pesquisa
    /// </summary>
    public class ResultadoPesquisa : ResultadoBase
    {
        #region Construtores

        public ResultadoPesquisa()
        {
            Excecao = new List<Excecao>();
        }

        #endregion
    }
}
