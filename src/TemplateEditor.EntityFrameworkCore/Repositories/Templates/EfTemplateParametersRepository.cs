using TemplateEditor.Entities.Templates;
using TemplateEditor.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateEditor.Repositories.Templates;

public class EfTemplateParametersRepository : EfCustomRepository<TemplateParameters>, ITemplateParametersRepository
{
    public EfTemplateParametersRepository(IDbContextProvider<TemplateEditorDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}