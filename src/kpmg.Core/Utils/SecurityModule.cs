#region

using System;
using kpmg.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

#endregion

namespace kpmg.Core.Utils
{
    public static class SecurityModule
    {
        public static void RegisterPolicies(AuthorizationOptions options)
        {
            foreach (EnumRecursos recurso in Enum.GetValues(typeof(EnumRecursos)))
                options.AddPolicy(recurso.ToString(), policy =>
                    policy.RequireClaim("Recurso", recurso.ToString()));
        }
    }
}