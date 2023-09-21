using System.Globalization;
using ContentfulComparisionWeb.Models;

namespace ContentfulComparisionWeb.ContentFul.Core.Report;
public static class GenerateReportForContentChanges
{
    public static UATSyncReport? report = new UATSyncReport();


    public static Task<string> GenerateReportHtmlforContentChanges()
    {
        string reportData = "";
        string borderStyle = "style=\"border-color:black;background-color:#D6EEEE;border-style:solid;border-width:thin;\"";
        string borderStyle2 = "style=\"border-color:orange;border-style:solid;border-width:thick;\"";
        //Add header
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
#pragma warning disable CS8604 // Possible null reference argument.
        reportData += "<H2>" + "Moldel selected: " + ti.ToTitleCase(report?.ContentModel) + "</H2>";
#pragma warning restore CS8604 // Possible null reference argument.

        reportData += "<H3>" + "Sync option selected: " + report?.Operation + "</H3>";
        reportData += "<br>";

        //Add feilds in an html.
        reportData += "<html>";
        reportData += "<head>";
        reportData += "</head>";
        reportData += "<body>";
        reportData += "<Table " + borderStyle + "> ";
        reportData += "<th>";
        reportData += "FieldName";
        reportData += "</th>";
        reportData += "<th>";
        reportData += "Status";
        reportData += "</th>";
        reportData += "<th>";
        reportData += "Value Before Sync";
        reportData += "</th>";
        reportData += "<th>";
        reportData += "Value After Sync";
        reportData += "</th>";
        reportData += "<th>";
        reportData += "FundName";
        reportData += "</th>";

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        foreach (var fld in report?.Content?.Select(x => x).ToList())
        {
            reportData += "\n";
            reportData += "<tr>";
            reportData += "<td >";
            reportData += fld.FieldName;
            reportData += "</td>";
            reportData += "<td " + borderStyle + " >";
            reportData += fld.FieldStatus.ToString();
            reportData += "</td>";
            reportData += "<td " + borderStyle + " > ";
            reportData += fld.ValueBeforeSync;
            reportData += "</td>";
            if (fld.ValueAfterSync.Equals(fld.ValueBeforeSync))
                reportData += "<td  " + borderStyle + " >";
            else
                reportData += "<td  " + borderStyle2 + " >";
            reportData += fld.ValueAfterSync;
            reportData += "</td>";
            reportData += "<td  " + borderStyle + " >";
            reportData += report.FundName.ToString();
            reportData += "</td>";
            reportData += "</tr>";
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        reportData += "</Table>";
        reportData += "</body>";

        //Add summary.
        return Task.FromResult(reportData);
    }
    public static void UpdateFieldsInReport(string modelName, dynamic tags, dynamic fieldsPrevValue, dynamic fieldsDest, ContentStatus contentstatus, string SynOption)
    {
        if (report != null)
        {
            report.ContentModel = modelName;
            report.Operation = contentstatus.ToString();
        }


        if (report != null && tags != null)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            report.FundName = tags?.ToString();
        report.Operation = SynOption;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        var preList = new List<FieldParam>();
        foreach (var val in fieldsPrevValue)
        {
            var obj = new FieldParam();
            string str = val.ToString();

            var arr = str.Split(":");
            obj.name = arr[0];
            obj.value = arr[2];
            preList.Add(obj);

        }

        foreach (var fld in fieldsDest)
        {
            string str = fld.ToString();
            var arr = str.Split(":");

            var obj = new UATSyncReportFields
            {
                FieldName = arr[0],
                ValueAfterSync = arr[2],
                ValueBeforeSync = fieldsPrevValue == null ? "" : "someData",
                FieldStatus = fieldsPrevValue == null ? ContentStatus.CREATED : ContentStatus.UPDATED
            };
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            obj.ValueBeforeSync = preList.Where(x => x.name.Equals(obj.FieldName)).Select(x => x.value).FirstOrDefault();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            report?.Content?.Add(obj);

        }
    }

} 
public class FieldParam
{
    public string? name { get; set; }
    public string? value { get; set; }
}
