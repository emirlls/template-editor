using System.Collections.Generic;

namespace TemplateEditor.Filtering;

public interface IQueryFilters
{
    List<FilterItems> Filters { get; set; }
    int Page { get; set; }
    int PageSize { get; set; }
}