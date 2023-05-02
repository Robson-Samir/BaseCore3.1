using System.Collections.Generic;

namespace Base.Infrastructure.CrossCutting.Utilities.Results
{
    public class ResultadoBase
    {
        #region Construtores

        public ResultadoBase()
        {
            Excecao = new List<Excecao>();
        }

        public ResultadoBase(string codigo, string mensagem, string rastreamento)
        {
            var excecao = new Excecao
            {
                Codigo = codigo,
                Mensagem = mensagem,
                Rastreamento = rastreamento
            };

            if (Excecao == null)
                Excecao = new List<Excecao>();

            Excecao.Add(excecao);
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Obejto de Exceção
        /// </summary>
        public List<Excecao> Excecao { get; set; }

        #endregion

        #region Métodos

        #endregion
    }
}
