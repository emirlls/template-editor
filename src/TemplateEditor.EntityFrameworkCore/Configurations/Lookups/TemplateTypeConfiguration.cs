using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateEditor.Constants;
using TemplateEditor.Entities.Lookups;
using TemplateEditor.Extensions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TemplateEditor.Configurations.Lookups;

public class TemplateTypeConfiguration : IEntityTypeConfiguration<TemplateType>
{
    public void Configure(EntityTypeBuilder<TemplateType> builder)
    {
        builder.ToTable(builder.GetTableName(),DatabaseConstants.SchemaName);
        builder.ConfigureByConvention();

    }
}