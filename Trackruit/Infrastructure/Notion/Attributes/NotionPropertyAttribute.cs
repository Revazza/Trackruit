namespace Trackruit.Infrastructure.Notion.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NotionPropertyAttribute(string name, NotionPropertyType type) : Attribute
{
    public string Name { get; } = name;
    public NotionPropertyType Type { get; } = type;
}

public enum NotionPropertyType
{
    Title,
    RichText,
    Number,
    Date,
    Url,
    Status
}