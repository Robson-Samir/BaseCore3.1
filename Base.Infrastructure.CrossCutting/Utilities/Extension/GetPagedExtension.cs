using Base.Infrastructure.CrossCutting.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Infrastructure.CrossCutting.Utilities.Extension
{
    /// <summary>
    /// GetPagedExtension
    /// </summary>
    public static class GetPagedExtension
    {
        /// <summary>
        /// GetPaged
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="query">Query</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Return ResultadoPesquisa</returns>
        public static ResultadoPesquisa<IEnumerable<T>> ResultadoPesquisa<T>(this IEnumerable<T> query, int? page = 0, int? pageSize = 0) where T : class
        {
            int itensPerPage = pageSize <= 0 ? query.Count() : Convert.ToInt32(pageSize);
            int paginaNumber = page <= 0 ? 1 : Convert.ToInt32(page);

            var paginacao = new Paginacao
            {
                PaginaAtual = paginaNumber,
                PrimeiraPagina = paginaNumber == 1,
                TamanhoPagina = itensPerPage,
            };

            paginacao.TotalRegistros = query.Count();
            var pageCount = (double)paginacao.TotalRegistros / itensPerPage;
            paginacao.TotalPaginas = (int)Math.Ceiling(pageCount);

            return new ResultadoPesquisa<IEnumerable<T>>
            {
                Resultado = query,
                PaginaAtual = paginacao.PaginaAtual,
                PrimeiraPagina = paginacao.PrimeiraPagina ?? false,
                TamanhoPagina = paginacao.TamanhoPagina,
                TotalPaginas = paginacao.TotalPaginas,
                TotalRegistros = paginacao.TotalRegistros,
                UltimaPagina = paginacao.PaginaAtual == paginacao.TotalPaginas ? true : false
            };
        }

        public static ResultadoPesquisa<IEnumerable<T>> ResultadoPesquisa<T>(this IEnumerable<T> query) where T : class
        {
            var paginacao = new Paginacao
            {
                PaginaAtual = 1,
                PrimeiraPagina = true,
                TamanhoPagina = 1,
            };

            paginacao.TotalRegistros = 1;
            paginacao.TotalPaginas = 1;

            return new ResultadoPesquisa<IEnumerable<T>>
            {
                Resultado = query,
                PaginaAtual = paginacao.PaginaAtual,
                PrimeiraPagina = paginacao.PrimeiraPagina ?? false,
                TamanhoPagina = paginacao.TamanhoPagina,
                TotalPaginas = paginacao.TotalPaginas,
                TotalRegistros = paginacao.TotalRegistros,
                UltimaPagina = paginacao.PaginaAtual == paginacao.TotalPaginas ? true : false
            };
        }

        public static ResultadoPesquisa<T> ResultadoPesquisa<T>(this T query) where T : class
        {
            var paginacao = new Paginacao
            {
                PaginaAtual = 1,
                PrimeiraPagina = true,
                TamanhoPagina = 1,
            };

            paginacao.TotalRegistros = 1;
            paginacao.TotalPaginas = 1;

            return new ResultadoPesquisa<T>
            {
                Resultado = query,
                PaginaAtual = paginacao.PaginaAtual,
                PrimeiraPagina = paginacao.PrimeiraPagina ?? false,
                TamanhoPagina = paginacao.TamanhoPagina,
                TotalPaginas = paginacao.TotalPaginas,
                TotalRegistros = paginacao.TotalRegistros,
                UltimaPagina = paginacao.PaginaAtual == paginacao.TotalPaginas ? true : false
            };
        }
    }
}
