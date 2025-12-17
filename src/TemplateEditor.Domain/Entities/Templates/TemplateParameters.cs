using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace TemplateEditor.Entities.Templates;

public class TemplateParameters : FullAuditedEntity<Guid>
{
    public string Param { get; set; }
    public Guid TemplateId { get; set; }

    public virtual Template Template { get; set; }

    public TemplateParameters(
        Guid id,
        Guid templateId,
        string param,
        Guid? creatorId,
        DateTime creationTime
    )
    {
        Id = id;
        TemplateId = templateId;
        Param = param;
        CreatorId = creatorId;
        CreationTime = creationTime;
    }
}