using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace TemplateEditor.MongoDB;

[DependsOn(
    typeof(TemplateEditorTestBaseModule),
    typeof(TemplateEditorMongoDbModule)
    )]
public class TemplateEditorMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
