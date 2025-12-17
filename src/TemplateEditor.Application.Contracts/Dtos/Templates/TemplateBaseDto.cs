using System;

namespace TemplateEditor.Dtos.Templates;

public class TemplateBaseDto
{
    public Guid? TemplateTypeId { get; set; }
    public string? Content { get; set; }
}