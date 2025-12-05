using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TemplateEditor.EntityFrameworkCore;

public class TemplateEditorHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<TemplateEditorHttpApiHostMigrationsDbContext>
{
    public TemplateEditorHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<TemplateEditorHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("TemplateEditor"));

        return new TemplateEditorHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
