using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace TemplateEditor.MongoDB;

[ConnectionStringName(TemplateEditorDbProperties.ConnectionStringName)]
public interface ITemplateEditorMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
