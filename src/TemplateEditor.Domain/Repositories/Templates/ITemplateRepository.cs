using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TemplateEditor.Entities.Templates;
using TemplateEditor.Filtering.Templates;

namespace TemplateEditor.Repositories.Templates;

public interface ITemplateRepository : ICustomRepository<Template>
{
    Task<List<Template>> GetFilteredListAsync(
        TemplateFilters templateFilters,
        CancellationToken cancellationToken = default
    );

    Task<long> GetFilteredCountAsync(
        TemplateFilters templateFilters,
        CancellationToken cancellationToken = default
    );
}