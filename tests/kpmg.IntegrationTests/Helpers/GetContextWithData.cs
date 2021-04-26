#region

using kpmg.Infrastructure.DataAccess;

#endregion

namespace kpmg.IntegrationTests.Helpers
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