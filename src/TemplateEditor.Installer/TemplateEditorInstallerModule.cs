using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TemplateEditor;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class TemplateEditorInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TemplateEditorInstallerModule>();
        });
    }
}
