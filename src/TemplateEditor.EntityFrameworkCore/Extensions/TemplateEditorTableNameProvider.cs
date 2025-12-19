using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateEditor.Constants;
using TemplateEditor.Entities.Lookups;
using TemplateEditor.Entities.Templates;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace TemplateEditor.Extensions;

public static class TemplateEditorTableNameProvider
{
    public static string GetTableName<T>(this EntityTypeBuilder<T> entityTypeBuilder) 
        where T : class
    {
        TableNames!.TryGetValue(nameof(T), out var name);
        return name!;
    }

    private static readonly Dictionary<string, string>? TableNames = new()
    {
        {nameof(Template),"Templates"},
        {nameof(TemplateParameters),"TemplateParameters"},
        {nameof(TemplateType),"TemplateTypes"}
    };
    
    public static void SetAbpTablePrefix(this ModelBuilder builder)
    {
        AbpIdentityDbProperties.DbTablePrefix = string.Empty;
        AbpIdentityDbProperties.DbSchema = DatabaseConstants.IdentitySchema;
        AbpTenantManagementDbProperties.DbTablePrefix = string.Empty;
        AbpTenantManagementDbProperties.DbSchema = DatabaseConstants.IdentitySchema;
        AbpSettingManagementDbProperties.DbTablePrefix = string.Empty;
        AbpSettingManagementDbProperties.DbSchema = DatabaseConstants.SettingSchema;
        AbpPermissionManagementDbProperties.DbTablePrefix = string.Empty;
        AbpPermissionManagementDbProperties.DbSchema = DatabaseConstants.IdentitySchema;
        AbpOpenIddictDbProperties.DbTablePrefix = string.Empty;
        AbpOpenIddictDbProperties.DbSchema = DatabaseConstants.OpenIddictSchema;

    }
}