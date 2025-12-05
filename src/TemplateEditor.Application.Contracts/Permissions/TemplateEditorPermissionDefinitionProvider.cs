using TemplateEditor.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TemplateEditor.Permissions;

public class TemplateEditorPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TemplateEditorPermissions.GroupName, L("Permission:TemplateEditor"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TemplateEditorResource>(name);
    }
}
