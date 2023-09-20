using Newtonsoft.Json.Linq;

namespace ContentFulComparisionTool.Models.API_Based;

public class ContentAndModelData
{

    public string? ModelName { get; set; }
    public string? summary { get; set; }
    public List<FundLevelDetails>? Funds { get; set; }
    public string? MicrositeName { get; set; }
    public string? EntryIdDev { get; set; }
    public string? EntryIdUat { get; set; }
    public ContentAndModelData()
    {
        Funds = new List<FundLevelDetails>();
    }


}
public class FundLevelDetails
{
    public string? Environment { get; set; }
    public string? FundName { get; set; }
    public string? EntryId { get; set; }
    public int NoOfFieldsDiffernt { get; set; }
    public JObject? Fields { get; set; }
    public JObject? Tags { get; set; }
    public int NoOfFieldsWithContentDiffernt { get; set; }

    public List<string>? ListOfFeildsInDev { get; set; }
    public List<string>? ListOfFieldsInUat { get; set; }
    public FundLevelDetails()
    {
        ListOfFeildsInDev = new List<string>();
        ListOfFieldsInUat = new List<string>();
    }
}
