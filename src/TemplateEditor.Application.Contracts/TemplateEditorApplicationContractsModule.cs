using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TemplateEditor;

[DependsOn(
    typeof(TemplateEditorDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class TemplateEditorApplicationContractsModule : AbpModule
{

}
