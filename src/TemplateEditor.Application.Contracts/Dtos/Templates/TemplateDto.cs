using System;

namespace TemplateEditor.Dtos.Templates;

public class TemplateDto
{
    public Guid Id { get; set; }
    public Guid? TemplateTypeId { get; set; }
    public string? Content { get; set; }
}