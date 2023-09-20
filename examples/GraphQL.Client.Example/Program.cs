
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;


namespace GraphQL.Client.Example;

public static class Program
{
    public static async Task Main()
    {
        using var graphQLClient = new GraphQLHttpClient("https://graphql.contentful.com/content/v1/spaces/peh2zm75gpxk/environments/DEV/", new NewtonsoftJsonSerializer());

        graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer aMWxUPEAYZiACYK1ILFADZ0zeOIIsUxgrEnTSVXsHnc");
        var request = new GraphQLRequest
        {
            Query = @" query             {                transferTooltipModelCollection    {      items {                       coverCurrentBenefitStatementToolTip                    }                } }     "
        };

        var graphQLResponse = await graphQLClient.SendHttpRequestAsyncNew<GraphqlResponseModel>(request, "", "", "CBus", "CBU");

    }
}
