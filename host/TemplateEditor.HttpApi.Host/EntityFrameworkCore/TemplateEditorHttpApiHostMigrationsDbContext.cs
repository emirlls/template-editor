using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateEditor.EntityFrameworkCore;

public class TemplateEditorHttpApiHostMigrationsDbContext : AbpDbContext<TemplateEditorHttpApiHostMigrationsDbContext>
{
    public TemplateEditorHttpApiHostMigrationsDbContext(DbContextOptions<TemplateEditorHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureTemplateEditor();
    }
}
