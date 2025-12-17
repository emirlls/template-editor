using TemplateEditor.Entities.Templates;
using TemplateEditor.Models.Templates;

namespace TemplateEditor.Interfaces.Managers.Templates;

public interface ITemplateManager : ICustomDomainService<Template>
{
    Template Create(TemplateCreateModel createModel);
    Template Update(Template template, TemplateUpdateModel updateModel);
}