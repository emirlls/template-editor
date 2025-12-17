using Microsoft.EntityFrameworkCore;
using TemplateEditor.Entities.Lookups;
using TemplateEditor.Entities.Templates;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateEditor.EntityFrameworkCore;

[ConnectionStringName(TemplateEditorDbProperties.ConnectionStringName)]
public class TemplateEditorDbContext : AbpDbContext<TemplateEditorDbContext>, ITemplateEditorDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public TemplateEditorDbContext(DbContextOptions<TemplateEditorDbContext> options)
        : base(options)
    {

    }

    public DbSet<Template> Templates { get; set; }
    public DbSet<TemplateType> TemplateTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureTemplateEditor();
        builder.ToSnakeCase();
    }
}
