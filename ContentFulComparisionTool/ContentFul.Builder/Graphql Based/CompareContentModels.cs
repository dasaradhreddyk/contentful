namespace ContentFulComparisionTool.Builder;
internal class CompareContentModels
{
    public static List<string>? GetFieldsInDevAndNotInUat(string collectionName)
    {
        collectionName = collectionName.Replace("Collection", "").ToLower();
        var fieldsDev = GetContentModel.SchemaDataDev.Where(x => x.ContentModel.ToLower().Equals(collectionName)).Select(x => x.Fields).FirstOrDefault();
        var feildsUat = GetContentModel.SchemaDataUAT.Where(x => x.ContentModel.ToLower().Equals(collectionName)).Select(x => x.Fields).FirstOrDefault();
        if (fieldsDev != null && feildsUat != null)
            return fieldsDev.Except(feildsUat).ToList();
        return null;

    }
    public static List<string>? GetFieldsInUATAndNotInDev(string collectionName)
    {
        collectionName = collectionName.Replace("Collection", "").ToLower();
        var fieldsDev = GetContentModel.SchemaDataDev.Where(x => x.ContentModel.ToLower().Equals(collectionName)).Select(x => x.Fields).FirstOrDefault();
        var feildsUat = GetContentModel.SchemaDataUAT.Where(x => x.ContentModel.ToLower().Equals(collectionName)).Select(x => x.Fields).FirstOrDefault();
        if (fieldsDev != null && feildsUat != null)
            return feildsUat.Except(fieldsDev).ToList();
        return null;

    }
    public static List<string> GetFieldsWithDifferntValuesInUatAndDev(GraphQL.Client.Http.CFContentViewModel graphQLResponse)
    {
        var returnValue = new List<string>();
        var fields = graphQLResponse?.ViewModelData?.Select(x => x.FieldName).ToList();
        if (fields == null)
            return returnValue;

        for (int i = 0; i < fields.Count; i++)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string field = fields[i];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var values = graphQLResponse.ViewModelData.Where(x => x.FieldName.Equals(field) && x.FundName.Equals("Aware")).Select(x => x.FieldValue).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (!values.Distinct().Skip(1).Any())
            {
                if (field != null)
                    returnValue.Add(field);

            }
        }
        return returnValue;
    }
}
