#region

using System.Text;

#endregion

namespace kpmg.Core.Helpers.Extensions
{
    /// <summary>
    ///     Provê funções auxiliares de integração com o Itec
    /// </summary>
    public static class ItecIntegrationExtensions
    {
        /// <summary>
        ///     Criptografa um texto utilizando o algoritmo de cifragem do Itec.
        /// </summary>
        /// <param name="texto">Texto a ser cifrado.</param>
        /// <returns></returns>
        public static string Cifrar(string texto)
        {
            texto = texto.ToUpper();

            var constantes = new[] {-4, 6, 1, 7, 0, 2};
            var cifrado = "";
            var ix = 0;

            for (var i = 0; i < texto.Length; i++, ix++)
            {
                int c = Encoding.ASCII.GetBytes(new[] {texto[i]})[0];
                cifrado += ((char) (c + constantes[ix])).ToString();

                if (ix == constantes.Length - 1)
                    ix = -1;
            }

            return cifrado;
        }

        /// <summary>
        ///     Descriptografa um texto utilizando o algoritmo de cifragem do Itec.
        /// </summary>
        /// <param name="texto">Texto a ser decifrado.</param>
        /// <returns></returns>
        public static string Decifrar(string texto)
        {
            var constantes = new[] {-4, 6, 1, 7, 0, 2};
            var cifrado = "";
            var ix = 0;

            for (var i = 0; i < texto.Length; i++, ix++)
            {
                int c = Encoding.ASCII.GetBytes(new[] {texto[i]})[0];
                cifrado += ((char) (c - constantes[ix])).ToString();

                if (ix == constantes.Length - 1)
                    ix = -1;
            }

            return cifrado;
        }
    }
}