using System;
using System.Collections.Generic;
using TemplateEditor.Entities.Templates;

namespace TemplateEditor.Entities.Lookups;

public class TemplateType : LookupBaseEntity
{
    public TemplateType(Guid id, string name, int code) : base(id, name, code)
    {
    }
    
    public virtual ICollection<Template> Templates { get; set; }
}