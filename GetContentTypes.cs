using System;

public class ContentTypes
{
	public ContentTypes()
	{
	}
    public GetContentTypes()
    {
        var httpClient = new HttpClient();
        var options = new ContentfulOptions
        {
            ManagementApiKey = Properties.Settings.Default.ManagementApiKey,
            SpaceId = Properties.Settings.Default.SpaceId,
            Environment = "Development"
        };
        var client = new ContentfulManagementClient(httpClient, options);

        var contentTypes = await client.GetContentTypes();
        // would get all the content types from the "staging" environment

       
        // Will delete the webhook from the master environment!
    }
}
