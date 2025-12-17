using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using TemplateEditor.Extensions;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using TemplateEditor.Localization;
using Volo.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace TemplateEditor;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpDddDomainSharedModule)
)]
public class TemplateEditorDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TemplateEditorDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<TemplateEditorResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/TemplateEditor");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("TemplateEditor", typeof(TemplateEditorResource));
        });

    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        LocalizationProvider.SetLocalizer(
            context.ServiceProvider.GetRequiredService<IStringLocalizer<TemplateEditorResource>>());
    }
}