namespace ContentfulComparisionWeb.Models.GraphQLBased;
internal class ContentModelAndFields
{
    public string ContentModel { get; set; }
    public string json { get; set; }
    public List<string> Fields { get; set; }
    public List<string> Ids { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ContentModelAndFields()
    {
        Fields = new List<string>();
        Ids = new List<string>();
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
