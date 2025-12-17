using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using TemplateEditor.Entities.Templates;
using TemplateEditor.EntityFrameworkCore;
using TemplateEditor.Extensions;
using TemplateEditor.Filtering.Templates;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace TemplateEditor.Repositories.Templates;

public class EfTemplateRepository : EfCustomRepository<Template>, ITemplateRepository
{
    private readonly IAbpLazyServiceProvider _abpLazyServiceProvider;

    private IDistributedCache DistributedCache =>
        _abpLazyServiceProvider.LazyGetRequiredService<IDistributedCache>();

    private ICurrentUser CurrentUser =>
        _abpLazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

    private ICurrentTenant CurrentTenant =>
        _abpLazyServiceProvider.LazyGetRequiredService<ICurrentTenant>();

    public EfTemplateRepository(IDbContextProvider<TemplateEditorDbContext> dbContextProvider,
        IAbpLazyServiceProvider abpLazyServiceProvider) : base(dbContextProvider)
    {
        _abpLazyServiceProvider = abpLazyServiceProvider;
    }

    public async Task<List<Template>> GetFilteredListAsync(
        TemplateFilters templateFilters,
        CancellationToken cancellationToken = default
    )
    {
        var dbSet = await GetDbSetAsync();
        var skipCount = templateFilters.Page == 1
            ? 0
            : (templateFilters.Page - 1) * templateFilters.PageSize;
        var filteredQuery = dbSet.ApplyFilters(templateFilters);
        var count = await filteredQuery.CountAsync(cancellationToken: cancellationToken);
        var cacheKey = CacheExtension.GenerateCacheKeyToCount(CultureInfo.CurrentCulture, CurrentTenant.Id,
            CurrentUser.Id, templateFilters.GetType().Name);
        await DistributedCache.SetStringAsync(cacheKey, count.ToString(), token: cancellationToken);
        return await filteredQuery
            .Skip(skipCount)
            .Take(templateFilters.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<long> GetFilteredCountAsync(TemplateFilters templateFilters,
        CancellationToken cancellationToken = default)
    {
        var cacheKey = CacheExtension.GenerateCacheKeyToCount(CultureInfo.CurrentCulture, CurrentTenant.Id,
            CurrentUser.Id, templateFilters.GetType().Name);
        var cachedData = await DistributedCache.GetStringAsync(cacheKey, token: cancellationToken);
        var count = Convert.ToInt32(cachedData);
        return count;
    }
}