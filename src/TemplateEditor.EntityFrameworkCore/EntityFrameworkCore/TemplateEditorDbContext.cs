using Microsoft.EntityFrameworkCore;
using TemplateEditor.Entities.Lookups;
using TemplateEditor.Entities.Templates;
using TemplateEditor.Extensions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Applications;
using Volo.Abp.OpenIddict.Authorizations;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Scopes;
using Volo.Abp.OpenIddict.Tokens;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace TemplateEditor.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ReplaceDbContext(typeof(IOpenIddictDbContext))]
[ReplaceDbContext(typeof(IPermissionManagementDbContext))]
[ConnectionStringName(TemplateEditorDbProperties.ConnectionStringName)]
public class TemplateEditorDbContext : 
    AbpDbContext<TemplateEditorDbContext>,
    ITemplateEditorDbContext,
    IIdentityDbContext,
    ITenantManagementDbContext,
    IOpenIddictDbContext,
    IPermissionManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public TemplateEditorDbContext(DbContextOptions<TemplateEditorDbContext> options)
        : base(options)
    {

    }

    public DbSet<Template> Templates { get; set; }
    public DbSet<TemplateType> TemplateTypes { get; set; }
    
    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityUserRole> UserRoles { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; }
    public DbSet<IdentityLinkUser> LinkUsers { get; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; }

    // Permission
    public DbSet<PermissionGroupDefinitionRecord> PermissionGroups { get; }
    public DbSet<PermissionDefinitionRecord> Permissions { get; }
    public DbSet<PermissionGrant> PermissionGrants { get; }
    // Tenant
    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<TenantConnectionString> TenantConnectionStrings { get; }

    // Open Iddict
    public DbSet<OpenIddictApplication> Applications { get; }
    public DbSet<OpenIddictAuthorization> Authorizations { get; }
    public DbSet<OpenIddictScope> Scopes { get; }
    public DbSet<OpenIddictToken> Tokens { get; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SetAbpTablePrefix();
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(TemplateEditorDbContext).Assembly);

        builder.ConfigureTemplateEditor();
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        
        builder.ToSnakeCase();
    }
}
