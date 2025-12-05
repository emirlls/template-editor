using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TemplateEditor;

[DependsOn(
    typeof(TemplateEditorApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class TemplateEditorHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(TemplateEditorApplicationContractsModule).Assembly,
            TemplateEditorRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TemplateEditorHttpApiClientModule>();
        });

    }
}
