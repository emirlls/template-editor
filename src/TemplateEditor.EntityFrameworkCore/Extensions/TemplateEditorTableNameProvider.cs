using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateEditor.Entities.Lookups;
using TemplateEditor.Entities.Templates;

namespace TemplateEditor.Extensions;

public static class TemplateEditorTableNameProvider
{
    public static string GetTableName<T>(this EntityTypeBuilder<T> entityTypeBuilder) 
        where T : class
    {
        TableNames!.TryGetValue(nameof(T), out var name);
        return name!;
    }

    private static readonly Dictionary<string, string>? TableNames = new()
    {
        {nameof(Template),"Templates"},
        {nameof(TemplateParameters),"TemplateParameters"},
        {nameof(TemplateType),"TemplateTypes"}
    };
}