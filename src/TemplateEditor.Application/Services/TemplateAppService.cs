using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TemplateEditor.Dtos.Templates;
using TemplateEditor.Entities.Templates;
using TemplateEditor.Filtering.Templates;
using TemplateEditor.Interfaces.Managers.Templates;
using TemplateEditor.Models.Templates;
using TemplateEditor.Repositories.Templates;
using TemplateEditor.Services.Templates;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace TemplateEditor.Services;

public class TemplateAppService : TemplateEditorAppService, ITemplateAppService
{
    private readonly IAbpLazyServiceProvider _abpLazyServiceProvider;

    public TemplateAppService(IAbpLazyServiceProvider abpLazyServiceProvider)
    {
        _abpLazyServiceProvider = abpLazyServiceProvider;
    }

    private ITemplateManager TemplateManager =>
        _abpLazyServiceProvider.LazyGetRequiredService<ITemplateManager>();

    private ITemplateRepository TemplateRepository =>
        _abpLazyServiceProvider.LazyGetRequiredService<ITemplateRepository>();

    public async Task<bool> CreateAsync(TemplateCreateDto templateCreateDto,
        CancellationToken cancellationToken = default)
    {
        var createModel = ObjectMapper.Map<TemplateCreateDto, TemplateCreateModel>(templateCreateDto);
        var entity = TemplateManager.Create(createModel);
        await TemplateRepository.InsertAsync(entity, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, TemplateUpdateDto templateUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var entity = await TemplateManager.TryGetByAsync(x => x.Id.Equals(id), throwIfNull: true,
            cancellationToken: cancellationToken);
        var updateModel = ObjectMapper.Map<TemplateUpdateDto, TemplateUpdateModel>(templateUpdateDto);
        var updatedEntity = TemplateManager.Update(entity, updateModel);
        await TemplateRepository.UpdateAsync(updatedEntity, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<PagedResultDto<TemplateDto>> GetPagedListAsync(TemplateFilters templateFilters,
        CancellationToken cancellationToken = default)
    {
        var entities = await TemplateRepository.GetFilteredListAsync(templateFilters, cancellationToken);
        var mapped = ObjectMapper.Map<List<Template>, List<TemplateDto>>(entities);
        var response = new PagedResultDto<TemplateDto>
        {
            Items = mapped,
            TotalCount = 0
        };
        return response;
    }
}