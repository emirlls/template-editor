using System;
using System.Collections.Generic;
using TemplateEditor.Entities.Lookups;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TemplateEditor.Entities.Templates;

public class Template : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public Guid? TemplateTypeId { get; set; }
    public Guid? CreatorId { get; }
    public string? Content { get; set; } //html content
    public bool IsActive { get; set; }

    public virtual TemplateType? TemplateType { get; set; }
    public virtual ICollection<TemplateParameters> TemplatesParametersCollection { get; set; }

    public Template(
        Guid id,
        Guid? tenantId,
        Guid? templateTypeId,
        Guid? creatorId,
        string? content,
        DateTime creationTime
    )
    {
        Id = id;
        TenantId = tenantId;
        TemplateTypeId = templateTypeId;
        CreatorId = creatorId;
        Content = content;
        CreationTime = creationTime;
    }
}