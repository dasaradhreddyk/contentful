using Contentful.Core;
using Contentful.Core.Configuration;
using ContentfulComparisionWeb.Builder;
using ContentfulComparisionWeb.ContentFul.Core.Report;
using ContentfulComparisionWeb.Models;
using Newtonsoft.Json;
using ContentType = Contentful.Core.Models.ContentType;

namespace ContentfulComparisionWeb.Services.ContentfulServices;
internal static class ContentFulAPIServices
{
    public static string? actionedItemId = " ";

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //Update content: step 1: copy dev content to uat 2. use publish entry with new verison number.

    public static async Task<bool> UpdateContentUATAsync(string modelId, string entryIdDev, string entryIdUAT)
    {
        var client = GetUATClient();
        var clientDev = GetDevClient();

        var contentUAT = await client.GetEntry(entryIdUAT);
        var contentDev = await clientDev.GetEntry(entryIdDev);

        var prevContent = contentUAT.Fields;

        contentUAT.Fields = contentDev.Fields;
        contentUAT.Metadata = contentDev.Metadata;

        await client.CreateOrUpdateEntry(contentUAT, null, null, contentUAT.SystemProperties.Version);

        int? newVersion = contentUAT?.SystemProperties.Version + 1;
#pragma warning disable CS8629 // Nullable value type may be null.
        await client.PublishEntry(entryIdUAT, (int)newVersion);
#pragma warning restore CS8629 // Nullable value type may be null.


        //generate report.....
        var tags = contentUAT?.Metadata.Tags;
        string fundName = "";
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        foreach (var tagvalue in tags)
        {

            fundName += tagvalue.Sys.Id + " ";
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        GenerateReportForContentChanges.UpdateFieldsInReport(modelId, fundName, prevContent, contentUAT?.Fields,
            Models.ContentStatus.UPDATED, "Merge Content");
        return true;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //createContentUAT   

    public static void createContentUAT(ContentType selectedContent, string modelId)
    {
        var client = GetUATClient();
        if (modelId != null && selectedContent != null)
        {
            var response = client.CreateEntry(selectedContent, modelId);
        }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //createContentModelUAT

    public static async Task<bool> CreateOrUpdateContentModelUATAsync(ContentType selectedModel, string modelId)
    {

        if (modelId != null && selectedModel != null)
        {
            var client = GetUATClient();
            var currentModel = await client.GetContentType(modelId);
            var prevData = selectedModel;
            try
            {
                foreach (var fld in currentModel.Fields)
                {
                    if (!selectedModel.Fields.Select(x => x.Id).ToList().Contains(fld.Id))
                    {
                        fld.Omitted = true;
                        selectedModel.Fields.Add(fld);
                    }
                }
                var response = await client.CreateOrUpdateContentType(selectedModel, null, currentModel.SystemProperties.Version);
                actionedItemId = response.SystemProperties.Id;
                int? newVersion = response.SystemProperties.Version;
#pragma warning disable CS8629 // Nullable value type may be null.
                await client.ActivateContentType(modelId, (int)newVersion);
                var newModel = await client.GetContentType(modelId);
                var newModel1 = newModel.Fields.Where(x => x.Omitted == false).Select(x => x);

                //Generate report
                GenerateReportForModelChanges.UpdateFieldsInReport(modelId, "", newModel1, currentModel.Fields, Models.ContentStatus.UPDATED, "Merge Content Model to UAT");


            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
        }
        return true;

    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //  Create and update one STEP

    public static async Task<bool> CreateModelAndContentsOneStepAsync(string modelId, ContentType selectedModel)
    {
        var client = GetUATClient();

        var response = await client.CreateOrUpdateContentType(selectedModel);

        var contentIds = await GetAllContentsOneStepAsync(modelId, "Development");

        foreach (var content in contentIds.Items)
        {
            var clientDev = GetDevClient();
            var val = content?.SelectToken("sys.id")?.ToObject<dynamic>();
            var con = await clientDev.GetEntry(val);

            // TODO: Make sure it is not created twice.
            await client.CreateEntry(con, modelId);

            //Update report.~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            var tags = content?.SelectToken("$metadata.tags")?.ToObject<dynamic>();
            string fundName = "";
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var tagvalue in tags)
            {
                var s = JsonConvert.DeserializeObject<Tag>(tagvalue.ToString());
                fundName += s.sys.id + " ";
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            GenerateReportForContentChanges.UpdateFieldsInReport(modelId, fundName, null, con?.Fields, Models.ContentStatus.CREATED, "Merge Content to UAT");
        }

        PublishContentUATAsync(modelId);
        return true;

    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // private funtions..

    public static async Task<ContentType> GetContentModelByIdAsync(string modelId, string environment)
    {
        var httpClient = new HttpClient();
        var options = new ContentfulOptions
        {
            ManagementApiKey = "CFPAT-4shYBeUOdEvAcUfrYT6a7JtOuTnH7ZcNVbNCyG__waA",
            SpaceId = "heqkjv7oz4lj",
            Environment = environment
        };
        var client = new ContentfulManagementClient(httpClient, options);
        return await client.GetContentType(modelId);
    }

    public static void GetAllContentsOneStepAsync(string environment)
    {
        var httpClient = new HttpClient();
        var options = new ContentfulOptions
        {
            ManagementApiKey = "CFPAT-4shYBeUOdEvAcUfrYT6a7JtOuTnH7ZcNVbNCyG__waA",
            SpaceId = "heqkjv7oz4lj",
            Environment = environment
        };
        var client = new ContentfulManagementClient(httpClient, options);
    }

    public static async void PublishContentModelUATAsync()
    {
        var client = GetUATClient();
        var entry = await client.PublishEntry(actionedItemId, 1);
    }
    public static async Task<dynamic> GetAllContentsOneStepAsync(string modelId, string environment)
    {
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
        qb.ContentTypeIs(modelId);
        return await client.GetEntriesCollection(qb);

    }
    public static async void CreateContentOneStepAsync(string ModelId, ContentType selectedContent)
    {
        var client = GetUATClient();
        ContentType response = await client.CreateEntry(selectedContent, ModelId);
    }

    public static async void PublishContentUATAsync(string modelId)
    {

        var client = GetUATClient();

        var tagsAndIds = await GetContentModel.GetContentsAsync(modelId, "UAT");
        foreach (var tagsandids in tagsAndIds)
        {
            if (tagsandids != null)
            {
                await client.PublishEntry(tagsandids?.Id.ToString(), 1);
            }
        }
    }
    public static ContentfulManagementClient GetDevClient()
    {
        var httpClient = new HttpClient();
        var options = new ContentfulOptions
        {
            ManagementApiKey = "CFPAT-4shYBeUOdEvAcUfrYT6a7JtOuTnH7ZcNVbNCyG__waA",
            SpaceId = "heqkjv7oz4lj",
            Environment = "Development"
        };
        var client = new ContentfulManagementClient(httpClient, options);
        return client;

    }
    public static ContentfulManagementClient GetUATClient()
    {
        var httpClient = new HttpClient();
        var options = new ContentfulOptions
        {
            ManagementApiKey = "CFPAT-4shYBeUOdEvAcUfrYT6a7JtOuTnH7ZcNVbNCyG__waA",
            SpaceId = "heqkjv7oz4lj",
            Environment = "UAT"
        };
        var client = new ContentfulManagementClient(httpClient, options);
        return client;

    }
}





