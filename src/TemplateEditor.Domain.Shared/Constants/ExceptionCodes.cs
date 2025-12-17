namespace TemplateEditor.Constants;

public static class ExceptionCodes
{
    private const string ExceptionCodePrefix = "TemplateEditor:ExceptionCodes:";
    public const string UnexpectedException = $"{ExceptionCodePrefix}UnexpectedException:001";
    public const string Success = $"{ExceptionCodePrefix}Success:001";
    
    public static class Template
    {
        private const string Prefix = $"{ExceptionCodePrefix}:Template:";
        public const string NotFound = $"{Prefix}001";
        public const string AlreadyExists = $"{Prefix}002";
    }
}