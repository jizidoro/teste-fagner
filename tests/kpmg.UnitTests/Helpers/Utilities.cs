﻿#region

using System.Reflection;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Extensions;

#endregion

namespace kpmg.UnitTests.Helpers
{
    public static class Utilities
    {
        private const string JsonPath = "kpmg.Infrastructure.SeedData";

        #region DadosIniciais

        public static void InitializeDbForTests(KpmgContext db)
        {
            var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

            db.Airplanes.AddRange(
                JsonUtilities.GetListFromJson<Airplane>(
                    assembly.GetManifestResourceStream($"{JsonPath}.airplane.json")));

            db.UsuarioSistemas.AddRange(
                JsonUtilities.GetListFromJson<UsuarioSistema>(
                    assembly.GetManifestResourceStream($"{JsonPath}.usuarioSistema.json")));

            db.SaveChanges();
        }

        #endregion
    }
}