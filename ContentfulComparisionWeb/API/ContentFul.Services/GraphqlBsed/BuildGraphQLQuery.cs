using ContentfulComparisionWeb.Builder;
using ContentfulComparisionWeb.Models;

namespace ContentfulComparisionWeb.ContentFulQuery;
public class BuildGraphQLQuery
{
    public static string BuildQueryBasedOnCollection(string collectionName, string environment, string tpid)
    {
        string query = "";
        string listOfFields = " ";
        string name = collectionName.Replace("Collection", "").ToLower();
        var flds = GetContentModel.SchemaDataDev.Where(x => x.ContentModel.ToLower().Contains(name)).Select(x => x.Ids).FirstOrDefault();

        if (!environment.Equals(EnvironmentEnum.Development.ToString()))
            flds = GetContentModel.SchemaDataUAT.Where(x => x.ContentModel.ToLower().Contains(name)).Select(x => x.Ids).FirstOrDefault();

        if (flds != null)
        {
            foreach (var k in flds)
            {
                listOfFields += k + " ";
            }
        }

        if (collectionName == null)
            return "";
        query = "query {";
        // query += collectionName + "{    items    { " + listOfFields + "}}}";
     


        string condition = " (where: { contentfulMetadata: { tags: { id_contains_all: [\"" + tpid + "\" ]} } }) ";
        query += collectionName + condition + "{    items    { " + listOfFields + "}}} ";
        return query;
    }
}


