using System;

namespace TemplateEditor.Filtering.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class FilterAttribute : Attribute
{
    public string FilteredColumn { get; private set; }
    public Type PropertyType { get; set; }

    public FilterAttribute
    (
        string filteredColumn,
        Type propertyType
    )
    {
        FilteredColumn = filteredColumn;
        PropertyType = propertyType;
    }
}