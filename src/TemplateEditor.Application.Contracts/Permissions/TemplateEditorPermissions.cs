using Volo.Abp.Reflection;

namespace TemplateEditor.Permissions;

public class TemplateEditorPermissions
{
    public const string GroupName = "TemplateEditor";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TemplateEditorPermissions));
    }
}
