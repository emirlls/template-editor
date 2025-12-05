using Localization.Resources.AbpUi;
using TemplateEditor.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TemplateEditor;

[DependsOn(
    typeof(TemplateEditorApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class TemplateEditorHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TemplateEditorHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TemplateEditorResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
