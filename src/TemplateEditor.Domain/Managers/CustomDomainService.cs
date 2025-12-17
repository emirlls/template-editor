using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using TemplateEditor.Interfaces;
using TemplateEditor.Localization;
using TemplateEditor.Repositories;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;

namespace TemplateEditor.Managers;

public class CustomDomainService<TEntity> : DomainService, ICustomDomainService<TEntity>
    where TEntity : class, IEntity<Guid>
{
    private readonly ICustomRepository<TEntity> _customRepository;
    private readonly IStringLocalizer<TemplateEditorResource> _stringLocalizer;
    private readonly string NotFoundException;
    private readonly string AlreadyExistsException;

    public CustomDomainService(
        ICustomRepository<TEntity> customRepository,
        IStringLocalizer<TemplateEditorResource> stringLocalizer,
        string notFoundException,
        string alreadyExistsException
    )
    {
        _customRepository = customRepository;
        _stringLocalizer = stringLocalizer;
        NotFoundException = notFoundException;
        AlreadyExistsException = alreadyExistsException;
    }

    public async Task<TEntity> TryGetByAsync(Expression<Func<TEntity, bool>> expression, bool throwIfNull = false,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _customRepository.GetByAsync(expression, asNoTracking, cancellationToken)!;
        if (throwIfNull && response is null)
        {
            throw new UserFriendlyException(_stringLocalizer[NotFoundException]);
        }

        return response;
    }

    public async Task<List<TEntity>> TryGetListByAsync(Expression<Func<TEntity, bool>> expression, bool throwIfNull = false,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _customRepository.GetListByAsync(expression, asNoTracking, cancellationToken);
        if (throwIfNull && response is null)
        {
            throw new UserFriendlyException(_stringLocalizer[NotFoundException]);
        }

        return response;
    }

    public async Task<TEntity> TryGetQueryableAsync(IQueryable<TEntity> queryable, bool throwIfNull = false,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _customRepository.TryGetQueryableAsync(queryable, asNoTracking, cancellationToken);
        if (throwIfNull && response is null)
        {
            throw new UserFriendlyException(_stringLocalizer[NotFoundException]);
        }

        return response;
    }
}