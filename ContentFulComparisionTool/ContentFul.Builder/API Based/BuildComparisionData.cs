using ContentFulComparisionTool.Models;

namespace ContentFulComparisionTool.ContentFul.Builder;
internal class BuildComparisionData
{
    public static void CompareUatAndDevNoFeilds(string FundName)
    {
        UpDateFieldsInfo();
        UpdateSummary();

        FundName = FundName.ToLower();
    }
    public static void UpdateSummary()
    {
        string summary = "";
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        var awareData = BuildMasterData.data.Funds.Where(x => x.FundName.Equals(FundNames.AwareSuper.ToString())).Select(x => x).FirstOrDefault();


        summary = "No Of Fields in Dev :" + awareData?.ListOfFeildsInDev.Distinct().Count();
        summary += "\n\r No Of Fields in UAT:" + awareData?.ListOfFieldsInUat.Distinct().Count();

        BuildMasterData.data.summary = summary;
    }
    public static void UpDateFieldsInfo()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        var fields = BuildMasterData.data.Funds.Where(x => x.FundName.Equals(FundNames.AwareSuper.ToString()) && x.Environment.Equals("Development"))
          .Select(x => x.Fields);


        var Values = ConvertToFieldValues(fields);

        foreach (var fund in BuildMasterData.data.Funds)
        {
            foreach (var field in Values)
#pragma warning disable CS8604 // Possible null reference argument.
                fund.ListOfFeildsInDev?.Add(field.FieldName);

        }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        fields = BuildMasterData.data.Funds.Where(x => x.FundName.Equals(FundNames.AwareSuper.ToString()) && x.Environment.Equals("UAT"))
          .Select(x => x.Fields);


        Values = ConvertToFieldValues(fields);

        foreach (var fund in BuildMasterData.data.Funds)
        {
            foreach (var field in Values)
#pragma warning disable CS8604 // Possible null reference argument.
                fund.ListOfFieldsInUat?.Add(field.FieldName);

        }


    }
    public static List<FieldValues> ConvertToFieldValues(dynamic fields)
    {
        var returnValue = new List<FieldValues>();
        foreach (var field in fields)
        {
            foreach (var f in field)
            {
                var obj = new FieldValues
                {
                    FeildsValue = f.Value.ToString(),
                    FieldName = f.Name
                };
                returnValue.Add(obj);
            }

        }
        return returnValue;

    }
}
public class FieldValues
{
    public string? FieldName { get; set; }
    public string? FeildsValue { get; set; }
}
