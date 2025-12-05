using TemplateEditor.Localization;
using Volo.Abp.Application.Services;

namespace TemplateEditor;

public abstract class TemplateEditorAppService : ApplicationService
{
    protected TemplateEditorAppService()
    {
        LocalizationResource = typeof(TemplateEditorResource);
        ObjectMapperContext = typeof(TemplateEditorApplicationModule);
    }
}
