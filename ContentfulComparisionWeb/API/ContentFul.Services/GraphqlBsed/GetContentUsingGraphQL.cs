using ContentfulComparisionWeb.ContentFulQuery;
using GraphQL;
using GraphQL.Client.Http;
using ContentfulComparisionWeb.Models;
using GraphQL.Client.Serializer.Newtonsoft;

namespace ContentfulComparisionWeb.Services.ContentFulFactory;
public static class GetContentUsingGraphQL
{
    public static async Task<GraphQL.Client.Http.CFContentViewModel> ExecuteQueryAsync(string environment, string collectionName, string tpid, string fundName)
    {
        var returnValue = new GraphQL.Client.Http.CFContentViewModel();
        string url = "https://graphql.contentful.com/content/v1/spaces/heqkjv7oz4lj/environments/";

        string[] envrionments = { EnvironmentEnum.Development.ToString(), EnvironmentEnum.UAT.ToString() };

        foreach (string env in envrionments)
        {
            if (!environment.ToLower().Contains("all"))
            {
                if (!environment.Equals(env))
                    continue;
            }
            url = "https://graphql.contentful.com/content/v1/spaces/heqkjv7oz4lj/environments/";
            if (env.Equals(EnvironmentEnum.Development.ToString()))
                url += "Development";
            if (env.Equals("UAT") || environment.Equals("Demo"))
                url += "UAT";

            using var graphQLClient = new GraphQLHttpClient(url, new NewtonsoftJsonSerializer());

            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 8LqJoQqpf9-uLsxyQSy0h7OB5ESgOd5R-XOqIG5ehXI");
            var request = new GraphQLRequest
            {
                Query = BuildGraphQLQuery.BuildQueryBasedOnCollection(collectionName, env, tpid)
            };
            var graphQLResponse = await graphQLClient.SendHttpRequestAsyncNew<dynamic>(request, env, collectionName, tpid, fundName);
            returnValue.Error = graphQLResponse.Error;
            returnValue.Status = graphQLResponse.Status;
            returnValue.Environment = graphQLResponse.Environment;
            returnValue.ViewModelData.AddRange(graphQLResponse.ViewModelData);
        }

        var data = returnValue.ViewModelData.OrderBy(x => x.FieldName).Select(x => x).ToList();

        returnValue.ViewModelData.Clear();

        returnValue.ViewModelData.AddRange(data.Select(x => x));

        return returnValue;
    }

}
