using ContentfulComparisionWeb.Models;
using ContentfulComparisionWeb.Services.ContentfulServices;
using ContentfulComparisionWebl.Models.API_Based;

namespace ContentfulComparisionWeb.ContentFul.Builder;
public static class BuildMasterData
{
    public static string? ModelName { get; set; }
    public static List<dynamic>? Fields { get; set; }
    public static ContentAndModelData? data { get; set; }

    public static async void InitDataAsync(string ModelName)
    {
        data?.Funds?.Clear();
       

        var result = await BuildMasterDataPerModelAsync(ModelName);
    }
    public static async Task<bool> BuildMasterDataPerModelAsync(string ModelName)
    {
        data?.Funds?.Clear();
        data = new ContentAndModelData
        {
            ModelName = ModelName
        };
        var clientDev = ContentFulAPIServices.GetDevClient();
        var contentIds = await ContentFulAPIServices.GetAllContentsOneStepAsync(ModelName, "Devevelopment");
        Fields = new List<dynamic>();
        foreach (var content in contentIds.Items)
        {
            var details = new FundLevelDetails();
            var entryid = content?.SelectToken("sys.id")?.ToObject<dynamic>();
            var con = await clientDev.GetEntry(entryid);

            var fields = con.Fields;
            details.Environment = "Development";
            details.Fields = fields;

            var tags = content?.SelectToken("$metadata.tags")?.ToObject<dynamic>();
            string? tagData = tags?.ToString();
            details.FundName = GetFundName(tagData);
            //.Tags = tags;
            details.EntryId = entryid;
            data?.Funds?.Add(details);
        }
        //UAT dATA
        var clientUat = ContentFulAPIServices.GetUATClient();
        contentIds = await ContentFulAPIServices.GetAllContentsOneStepAsync(ModelName, "UAT");
        foreach (var content in contentIds.Items)
        {
            var details = new FundLevelDetails();
            var entryid = content?.SelectToken("sys.id")?.ToObject<dynamic>();
            var con = await clientUat.GetEntry(entryid);

            var fields = con.Fields;
            details.Environment = "UAT";
            details.Fields = fields;

            var tags = content?.SelectToken("$metadata.tags")?.ToObject<dynamic>();
            string? tagData = tags?.ToString();
            details.FundName = GetFundName(tagData);
            //.Tags = tags;
            details.EntryId = entryid;
            data?.Funds?.Add(details);
        }
        return true;
    }
    public static string GetFundName(string? tags)
    {
        if (tags != null)
        {
            if (tags.Contains("awr"))
                return FundNames.AwareSuper.ToString();
            if (tags.Contains("gpm") || tags.Contains("asg"))
                return FundNames.GPM.ToString();
            if (tags.Contains("cbu"))
                return FundNames.CBUS.ToString();

        }
        return "";
    }
}



