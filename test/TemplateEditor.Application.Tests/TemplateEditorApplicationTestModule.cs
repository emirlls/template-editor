using Volo.Abp.Modularity;

namespace TemplateEditor;

[DependsOn(
    typeof(TemplateEditorApplicationModule),
    typeof(TemplateEditorDomainTestModule)
    )]
public class TemplateEditorApplicationTestModule : AbpModule
{

}
