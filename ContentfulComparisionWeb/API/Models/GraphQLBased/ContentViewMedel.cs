namespace ContentfulComparisionWeb.Models.GraphQLBased;
internal class CFContentModel
{
    public List<ContentDisplayModelItem> ViewModelData = new List<ContentDisplayModelItem>();
}
public class ContentDisplayModelItem
{
    public string? Environment { set; get; }
    public string? CollectionName { set; get; }
    public string? FieldName { get; set; }
    public string? FieldValue { get; set; }
    public string? FundName { get; set; }

}
