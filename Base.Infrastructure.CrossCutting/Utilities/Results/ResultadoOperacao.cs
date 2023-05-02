using System.Collections.Generic;

namespace Base.Infrastructure.CrossCutting.Utilities.Results
{
    public class ResultadoOperacao<T> : ResultadoBase
    {
        public ResultadoOperacao()
        {
            Resultado = default(T);
        }

        public ResultadoOperacao(T data)
        {
            Resultado = data;
        }

        #region Propriedades

        /// <summary>
        /// Objeto de Retorno
        /// </summary>
        public T Resultado { get; set; }

        #endregion
    }

    /// <summary>
    /// Classe Resultado Operação
    /// </summary>
    public class ResultadoOperacao : ResultadoBase
    {
        #region Construtores

        public ResultadoOperacao()
        {
            Excecao = new List<Excecao>();
        }

        #endregion       

    }
}

