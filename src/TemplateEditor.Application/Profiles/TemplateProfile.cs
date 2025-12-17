using AutoMapper;
using TemplateEditor.Dtos.Templates;
using TemplateEditor.Entities.Templates;
using TemplateEditor.Models.Templates;

namespace TemplateEditor.Profiles;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<TemplateCreateDto, TemplateCreateModel>();
        CreateMap<Template, TemplateDto>();
    }
}