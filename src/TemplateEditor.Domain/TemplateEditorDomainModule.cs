using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TemplateEditor;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(TemplateEditorDomainSharedModule)
)]
public class TemplateEditorDomainModule : AbpModule
{

}
