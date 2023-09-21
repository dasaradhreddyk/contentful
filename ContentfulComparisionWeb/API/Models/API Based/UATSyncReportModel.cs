namespace ContentfulComparisionWeb.Models;
internal class UATSyncReportModel
{
}
public class UATSyncReport
{
    public string? ContentModel { get; set; }
    public string? FundName { get; set; }
    public List<UATSyncReportFields>? Content { get; set; }
    public string? Operation { get; set; }
    public int NoOfFieldsCreated { get; set; }
    public int NoOfFeidldsDeleted { get; set; }
    public int NoOfFieldsModifed { get; set; }

    public UATSyncReport()
    {
        Content = new List<UATSyncReportFields>();
    }

}
public class UATSyncReportFields
{
    public string? FieldName { get; set; }
    public string? Environment { get; set; }
    public string? ValueBeforeSync { get; set; }
    public string? ValueAfterSync { get; set; }
    public ContentStatus FieldStatus { get; set; }
}
public enum ContentStatus
{
    CREATED,
    DELETED,
    UPDATED,
    NOCHANGE
}

