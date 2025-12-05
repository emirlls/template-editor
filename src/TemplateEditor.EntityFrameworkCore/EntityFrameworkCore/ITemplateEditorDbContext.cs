using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateEditor.EntityFrameworkCore;

[ConnectionStringName(TemplateEditorDbProperties.ConnectionStringName)]
public interface ITemplateEditorDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
