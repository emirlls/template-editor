using System;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Extensions.Localization;
using TemplateEditor.Localization;

namespace TemplateEditor.Extensions;

public static class LocalizationProvider
{
    private static IStringLocalizer<TemplateEditorResource> StringLocalizer;

    public static string? GetDescription(this Enum value)
    {
        if (StringLocalizer == null)
        {
            throw new NotImplementedException("String localizer not initialized!");
        }

        Type type = value.GetType();
        string? name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo? field = type.GetField(name);
            if (field != null && Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attr)
            {
                return StringLocalizer[$"{attr.Description}"];
            }
        }

        return null;
    }

    public static void SetLocalizer(IStringLocalizer<TemplateEditorResource> stringLocalizer)
    {
        StringLocalizer = stringLocalizer;
    }
}