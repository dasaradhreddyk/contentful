
//using System.Globalization;
//using ContentFulComparisionTool.Models;
//using ContentFulComparisionTool.ContentFul.Core.Report;
using System.Net.Http.Headers;

namespace ContentFulComparisionTool.ContentFul.Core.ReportGenerator.PostToTeams;
internal static class PostReportForContentChangesToTeams
{
    public static async Task<bool> PostReportForContentChangesToTeamsAsync()//string reportData)
    {
        var adaptiveCardJson = @"{
            ""@type"": ""MessageCard"",
            ""@context"": ""http://schema.org/extensions"",
            ""themeColor"": ""0076D7"",
            ""summary"": ""Dasaradha generated a new Contentful comparison report with 10 changes"",
            ""sections"": [{
                ""activityTitle"": ""Dasaradha generated a new Contentful comparison report"",
                ""activitySubtitle"": ""Contentful Review Report"",
                ""activityImage"": ""https://yt3.ggpht.com/a/AATXAJzgT-Phx1D5RY0sBAg15bvXocHAIWT1oOAogw=s900-c-k-c0xffffffff-no-rj-mo"",
                ""facts"": [{
                    ""name"": ""Assigned to"",
                    ""value"": ""Kevin Purnama""
                }, {
                    ""name"": ""Due date"",
                    ""value"": ""Mon Oct 02 2023 17:07:18 (AEST)""
                }, {
                    ""name"": ""Status"",
                    ""value"": ""Not started""
                }],
                ""markdown"": true
            }],
            ""potentialAction"": [{
                ""@type"": ""ActionCard"",
                ""name"": ""Approve"",
                ""inputs"": [{
                    ""@type"": ""TextInput"",
                    ""id"": ""comment"",
                    ""isMultiline"": true,
                    ""title"": ""Add an approval comment here""
                }],
                ""actions"": [{
                    ""@type"": ""HttpPOST"",
                    ""name"": ""Add comment"",
                    ""target"": ""https://learn.microsoft.com/outlook/actionable-messages""
                }]
            }, {
                ""@type"": ""OpenUri"",
                ""name"": ""View Report"",
                ""targets"": [{
                    ""os"": ""default"",
                    ""uri"": ""https://sep2023hackathon.blob.core.windows.net/reports/Result.pdf?sp=r&st=2023-09-21T00:09:08Z&se=2023-09-30T08:09:08Z&spr=https&sv=2022-11-02&sr=b&sig=t%2BdaBldbJXec%2B21%2Fy9rf9Ad6jU%2FCZMKkuwnIMU8QDW4%3D""
                }]
            }, {
                ""@type"": ""ActionCard"",
                ""name"": ""Change status"",
                ""inputs"": [{
                    ""@type"": ""MultichoiceInput"",
                    ""id"": ""list"",
                    ""title"": ""Select a status"",
                    ""isMultiSelect"": ""false"",
                    ""choices"": [{
                        ""display"": ""Approved"",
                        ""value"": ""1""
                    }, {
                        ""display"": ""Rejected"",
                        ""value"": ""2""
                    }, {
                        ""display"": ""Cancelled"",
                        ""value"": ""3""
                    }]
                }],
                ""actions"": [{
                    ""@type"": ""HttpPOST"",
                    ""name"": ""SaveStatus"",
                    ""target"": ""https://learn.microsoft.com/outlook/actionable-messages""
                }]
            }]
        }";

        var webhookUrl = "https://talhackiverse.webhook.office.com/webhookb2/07ab4e09-e0fd-4f89-a4a7-9719f30bccfa@530211ad-1dcf-42db-b0cc-f0ae94dbf11a/IncomingWebhook/50a3db4a0b0949afbf75d02b9d9950db/e9962fae-9960-4317-adaf-9ff60f0fec8f";

        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(adaptiveCardJson, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(webhookUrl, content);
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            return false;
        }

        return true;
    }
}
