using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Extensions;
using ContentfulComparisionWeb.Models;
using ContentfulComparisionWeb.Models.GraphQLBased;
using Newtonsoft.Json;

namespace ContentfulComparisionWeb.Builder;

internal static class GetContentModel
{
    public static List<ContentModelAndFields> SchemaDataDev = new List<ContentModelAndFields>();
    public static List<ContentModelAndFields> SchemaDataUAT = new List<ContentModelAndFields>();
    public static async void GetContentModelAsync(string environment)
    {
        var httpClient = new HttpClient();
        var options = new ContentfulOptions
        {
            ManagementApiKey = "CFPAT-4shYBeUOdEvAcUfrYT6a7JtOuTnH7ZcNVbNCyG__waA",
            SpaceId = "heqkjv7oz4lj",
            Environment = "Development"
        };
        var client = new ContentfulManagementClient(httpClient, options);

        var contentTypes = await client.GetContentTypes();

        foreach (var v in contentTypes)
        {
            var ct = new ContentModelAndFields
            {
                ContentModel = v.Name.Replace(" ", string.Empty),
                json = v.Metadata.ConvertObjectToJsonString()
            };
            foreach (var field in v.Fields)
            {
                var xx = field;
                //Some exceptions 
                if (xx.Name.ToLower().Equals("residentradiooption1text") || xx.Name.ToLower().Equals("residentradiooption2text")
                    || xx.Name.ToLower().Equals("modifyprofilehelptextvalue"))
                    continue;
                if (xx.Name.ToLower().Equals("thankyoupagenextitem1icon") || xx.Name.ToLower().Equals("thankyoupagenextitem2icon")
                    || xx.Name.ToLower().Equals("thankyoupagenextitem3icon") || xx.Name.ToLower().Equals("thankyoupagenextitem4icon"))
                    continue;
                ;
                if (field != null)
                {
                    var x = field.ConvertObjectToJsonString();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    dynamic fieldjson = JsonConvert.DeserializeObject(xx.ConvertObjectToJsonString());
                    var y = fieldjson?.type;
                    {

                        ct.Fields.Add(xx.Name);

                        ct.Ids.Add(xx.Id);
                    }
                }
            }
            if ((bool)(environment.ToLower().Equals("uat")))
            {
                SchemaDataUAT.Add(ct);
            }
            else
            {
                SchemaDataDev.Add(ct);
            }

        }
    }

    public static async Task<List<ContentModelTagsAndIds>> GetContentsAsync(string modelid, string environment)
    {
        var returnValue = new List<ContentModelTagsAndIds>();
        if (modelid != null && modelid?.Length < 1)
            return returnValue;
        try
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            modelid = char.ToLowerInvariant(modelid[0]) + modelid.Substring(1);
            modelid = modelid.Replace(" ", "");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            var httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                ManagementApiKey = "CFPAT-4shYBeUOdEvAcUfrYT6a7JtOuTnH7ZcNVbNCyG__waA",
                SpaceId = "heqkjv7oz4lj",
                Environment = environment
            };
            var client = new ContentfulManagementClient(httpClient, options);
            var qb = new Contentful.Core.Search.QueryBuilder<dynamic>
            {

            };

            qb.ContentTypeIs(modelid);
            var response = await client.GetEntriesCollection(qb);
            foreach (var data in response)
            {
                var value = new ContentModelTagsAndIds();
                var tags = data?.SelectToken("$metadata.tags")?.ToObject<dynamic>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                foreach (var tagvalue in tags)
                {
                    var s = JsonConvert.DeserializeObject<Tag>(tagvalue.ToString());
                    value.tags?.Add(s);
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
                value.Id = data?.SelectToken("sys.id")?.ToObject<string>();
#pragma warning restore CS8601 // Possible null reference assignment.
                returnValue.Add(value);
            }
        }
        catch (Exception)
        {
            //MessageBox.Show("Error while getting tags and entryid");
            return returnValue;
        }
        return returnValue;

    }
}

