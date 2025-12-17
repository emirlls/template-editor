using System;
using System.Threading;
using System.Threading.Tasks;
using TemplateEditor.Dtos.Templates;
using TemplateEditor.Filtering.Templates;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TemplateEditor.Services.Templates;

public interface ITemplateAppService : IApplicationService
{
    Task<bool> CreateAsync(
        TemplateCreateDto templateCreateDto,
        CancellationToken cancellationToken = default
    );

    Task<bool> UpdateAsync(
        Guid id,
        TemplateUpdateDto templateUpdateDto,
        CancellationToken cancellationToken = default
    );

    Task<PagedResultDto<TemplateDto>> GetPagedListAsync(
        TemplateFilters templateFilters,
        CancellationToken cancellationToken = default
    );
}