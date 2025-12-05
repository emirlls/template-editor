using TemplateEditor.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TemplateEditor;

public abstract class TemplateEditorController : AbpControllerBase
{
    protected TemplateEditorController()
    {
        LocalizationResource = typeof(TemplateEditorResource);
    }
}
