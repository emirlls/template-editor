using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TemplateEditor;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TemplateEditorHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class TemplateEditorConsoleApiClientModule : AbpModule
{

}
