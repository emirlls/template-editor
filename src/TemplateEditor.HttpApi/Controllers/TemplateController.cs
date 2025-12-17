using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateEditor.Dtos.Templates;
using TemplateEditor.Filtering.Templates;
using TemplateEditor.Services.Templates;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace TemplateEditor.Controllers;

//[Authorize]
[ApiController]
[Route("api/templates")]
public class TemplateController : TemplateEditorController
{
    private readonly IAbpLazyServiceProvider _abpLazyServiceProvider;

    public TemplateController(IAbpLazyServiceProvider abpLazyServiceProvider)
    {
        _abpLazyServiceProvider = abpLazyServiceProvider;
    }

    private ITemplateAppService TemplateAppService =>
        _abpLazyServiceProvider.LazyGetRequiredService<ITemplateAppService>();

    [HttpGet]
    public async Task<PagedResultDto<TemplateDto>> GetPagedListAsync(
        TemplateFilters templateFilters,
        CancellationToken cancellationToken = default
    )
    {
        return await TemplateAppService.GetPagedListAsync(templateFilters, cancellationToken);
    }

    /// <summary>
    /// Use to create template
    /// </summary>
    /// <param name="templateCreateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> CreateAsync(
        TemplateCreateDto templateCreateDto,
        CancellationToken cancellationToken = default
    )
    {
        return await TemplateAppService.CreateAsync(templateCreateDto, cancellationToken);
    }

    /// <summary>
    /// Use to update template
    /// </summary>
    /// <param name="id"></param>
    /// <param name="templateUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<bool> UpdateAsync(
        Guid id,
        TemplateUpdateDto templateUpdateDto,
        CancellationToken cancellationToken = default
    )
    {
        return await TemplateAppService.UpdateAsync(id, templateUpdateDto, cancellationToken);
    }
}