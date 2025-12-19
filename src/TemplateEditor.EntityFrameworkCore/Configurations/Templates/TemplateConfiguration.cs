using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateEditor.Constants;
using TemplateEditor.Entities.Templates;
using TemplateEditor.Extensions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TemplateEditor.Configurations.Templates;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable(builder.GetTableName(),DatabaseConstants.SchemaName);
        builder.ConfigureByConvention();

        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.Content).IsRequired(false);

        builder
            .HasOne(x => x.TemplateType)
            .WithMany(x => x.Templates)
            .HasForeignKey(x => x.TemplateTypeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}