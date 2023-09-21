using Newtonsoft.Json;

namespace ContentfulComparisionWeb.Models;
public class ContentModelTagsAndIds
{
    public string Id { get; set; }
    [JsonProperty("tags")]
    public List<Tag>? tags { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ContentModelTagsAndIds()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        tags = new List<Tag>();
    }
}

public class Sys
{
    public string? type { get; set; }
    public string? linkType { get; set; }
    public string? id { get; set; }
}

public class Tag
{
    public Sys? sys { get; set; }
}

