using System.Reflection;
using Trackruit.Infrastructure.Notion.Attributes;
using Trackruit.Infrastructure.Notion.Models;

namespace Trackruit.Infrastructure.Notion.Extensions;

public static class NotionRequestExtensions
{
    public static Dictionary<string, object> GetNotionProperties<T>(this T dto)
    {
        var properties = new Dictionary<string, object>();

        foreach (var prop in typeof(T).GetProperties())
        {
            var attr = prop.GetCustomAttribute<NotionPropertyAttribute>();
            if (attr == null)
            {
                continue;
            }

            var value = prop.GetValue(dto);
            if (value == null)
            {
                continue;
            }

            object obj = attr.Type switch
            {
                NotionPropertyType.Title => new NotionTitleProperty
                {
                    Title = new List<NotionRichText>
                    {
                        new NotionRichText
                        {
                            Text = new NotionText { Content = value.ToString()! }
                        }
                    }
                },
                NotionPropertyType.RichText => new NotionRichTextProperty
                {
                    RichText = new List<NotionRichText>
                    {
                        new NotionRichText
                        {
                            Text = new NotionText { Content = value.ToString()! }
                        }
                    }
                },
                NotionPropertyType.Number => new NotionNumberProperty
                {
                    Number = Convert.ToDouble(value)
                },
                NotionPropertyType.Date => new NotionDateProperty
                {
                    Date = new NotionDate
                    {
                        Start = ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ssZ")
                    }
                },
                NotionPropertyType.Url => new NotionUrlProperty
                {
                    Url = value.ToString()
                },
                NotionPropertyType.Status => new NotionSelectProperty()
                {
                    Select = new NotionSelect
                    {
                        Name = value.ToString()!
                    }
                },
                _ => throw new NotSupportedException($"Notion property type {attr.Type} not supported")
            };

            properties.Add(attr.Name, obj);
        }

        return properties;
    }
}