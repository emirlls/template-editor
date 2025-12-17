using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateEditor.Constants;
using TemplateEditor.Entities.Templates;
using TemplateEditor.Extensions;

namespace TemplateEditor.Configurations.Templates;

public class TemplateParametersConfiguration: IEntityTypeConfiguration<TemplateParameters>
{
    public void Configure(EntityTypeBuilder<TemplateParameters> builder)
    {
        builder.ToTable(builder.GetTableName(),DatabaseConstants.SchemaName);

        builder.HasOne(x => x.Template)
            .WithMany(x => x.TemplatesParametersCollection)
            .HasForeignKey(x => x.TemplateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}