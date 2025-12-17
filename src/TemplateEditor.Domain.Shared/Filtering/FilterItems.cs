using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateEditor.Filtering;

public class FilterItems
{
    public string Strategy { get; set; }
    public string Prop { get; set; }
    public string Type { get; set; }
    public List<string> Values { get; set; } = new List<string>();
    public bool IsFilled => Values != null && Values.Any() && !string.IsNullOrEmpty(Prop);
    
    public Type ParsedFieldType
    {
        get
        {
            switch (Type?.ToLower())
            {
                case "guid": return typeof(Guid);
                case "boolean":
                case "bool": return typeof(bool);
                case "int":
                case "int32": return typeof(int);
                case "string": return typeof(string);
                default: return null; 
            }
        }
    }
}