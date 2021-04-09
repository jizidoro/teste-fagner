#region

using System.Reflection;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Extensions;

#endregion

namespace kpmg.IntegrationTests.Helpers
{
    public static class Utilities
    {
        private const string JsonPath = "kpmg.Infrastructure.SeedData";

        #region DadosIniciais

        public static void InitializeDbForTests(KpmgContext db)
        {
            var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

            if (assembly is not null)
            {
                db.Airplanes.AddRange(
                    JsonUtilities.GetListFromJson<Airplane>(
                        assembly.GetManifestResourceStream($"{JsonPath}.airplane.json")));

                db.UsuarioSistemas.AddRange(
                    JsonUtilities.GetListFromJson<UsuarioSistema>(
                        assembly.GetManifestResourceStream($"{JsonPath}.usuarioSistema.json")));
            }

            db.SaveChanges();
        }

        #endregion
    }
}