namespace TemplateEditor;

public static class TemplateEditorDbProperties
{
    public static string DbTablePrefix { get; set; } = "TemplateEditor";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "TemplateEditor";
}
