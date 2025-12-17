using System;

namespace TemplateEditor.Models.Templates;

public class TemplateBaseModel
{
    public Guid? TemplateTypeId { get; set; }
    public string? Content { get; set; }
}