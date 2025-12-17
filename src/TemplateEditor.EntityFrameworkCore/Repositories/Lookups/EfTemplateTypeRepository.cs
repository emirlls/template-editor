using TemplateEditor.Entities.Lookups;
using TemplateEditor.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateEditor.Repositories.Lookups;

public class EfTemplateTypeRepository : EfCustomRepository<TemplateType>, ITemplateTypeRepository
{
    public EfTemplateTypeRepository(IDbContextProvider<TemplateEditorDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}