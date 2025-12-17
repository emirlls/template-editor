using System;
using Microsoft.Extensions.Localization;
using TemplateEditor.Constants;
using TemplateEditor.Entities.Templates;
using TemplateEditor.Interfaces.Managers.Templates;
using TemplateEditor.Localization;
using TemplateEditor.Models.Templates;
using TemplateEditor.Repositories;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace TemplateEditor.Managers.Templates;

public class TemplateManager : CustomDomainService<Template>, ITemplateManager
{
    private readonly IAbpLazyServiceProvider _abpLazyServiceProvider;

    private ICurrentUser CurrentUser =>
        _abpLazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

    public TemplateManager(ICustomRepository<Template> customRepository,
        IStringLocalizer<TemplateEditorResource> stringLocalizer, IAbpLazyServiceProvider abpLazyServiceProvider) :
        base(
            customRepository,
            stringLocalizer,
            ExceptionCodes.Template.NotFound,
            ExceptionCodes.Template.AlreadyExists
        )
    {
        _abpLazyServiceProvider = abpLazyServiceProvider;
    }

    public Template Create(TemplateCreateModel createModel)
    {
        var entity = new Template(
            GuidGenerator.Create(),
            CurrentTenant.Id,
            createModel.TemplateTypeId,
            CurrentUser.Id,
            createModel.Content,
            DateTime.Now
        );

        return entity;
    }

    public Template Update(Template template, TemplateUpdateModel updateModel)
    {
        template.TemplateTypeId = updateModel.TemplateTypeId;
        template.Content = updateModel.Content;
        return template;
    }
}