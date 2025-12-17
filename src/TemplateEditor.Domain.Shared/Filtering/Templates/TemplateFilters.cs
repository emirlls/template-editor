using System.Collections.Generic;

namespace TemplateEditor.Filtering.Templates;

public class TemplateFilters : IQueryFilters
{
    public List<FilterItems> Filters { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}