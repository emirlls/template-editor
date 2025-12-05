using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace TemplateEditor.MongoDB;

[ConnectionStringName(TemplateEditorDbProperties.ConnectionStringName)]
public class TemplateEditorMongoDbContext : AbpMongoDbContext, ITemplateEditorMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureTemplateEditor();
    }
}
