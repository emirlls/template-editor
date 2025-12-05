using Volo.Abp;
using Volo.Abp.MongoDB;

namespace TemplateEditor.MongoDB;

public static class TemplateEditorMongoDbContextExtensions
{
    public static void ConfigureTemplateEditor(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
