﻿#region

using kpmg.Infrastructure.DataAccess;

#endregion

namespace kpmg.UnitTests.Helpers
{
    public class GetContextWithData
    {
        public KpmgContext Excute(KpmgContext context)
        {
            context.SaveChanges();

            return context;
        }
    }
}