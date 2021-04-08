#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaParamConfiguration : IEntityTypeConfiguration<BaParam>
    {
        public void Configure(EntityTypeBuilder<BaParam> builder)
        {
            builder.HasKey(c => c.Chave);
        }
    }
}