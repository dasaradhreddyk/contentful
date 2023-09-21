namespace ContentfulComparisionWeb.Models;
internal class Constants
{
}
public enum EnvironmentEnum
{
    Development,
    UAT,
    Demo
}
public enum FundTpidEnum
{
    awr,
    asg,
    cbu
}
public enum FundNames
{
    AwareSuper,
    GPM,
    CBUS
}
public static class TagNames
{
    public static List<string>? AwareTags { get; set; }
    public static List<string>? CbusTags { get; set; }
    public static List<string>? GpmTags { get; set; }
    public static void InitTags()
    {

        AwareTags = new List<string>()
        {
            "awr"
        };
        CbusTags = new List<string>()
        {
            "cbu"
        };
        GpmTags = new List<string>()
        {
            "asg"
        };



    }


}
