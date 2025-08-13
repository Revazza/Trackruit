namespace Trackruit.Infrastructure.Notion.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NotionPropertyAttribute(string propertyName, NotionPropertyType propertyType) : Attribute
{
    public string PropertyName { get; } = propertyName;
    public NotionPropertyType PropertyType { get; } = propertyType;
}

public enum NotionPropertyType
{
    Title,
    RichText,
    Number,
    Date,
    Url,
}