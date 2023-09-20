

using Newtonsoft.Json;

namespace GraphQL.Client.Example;


public class GraphqlResponseModel
{
    [JsonProperty("data")]
    public Data data { get; set; }
    public partial class Data
    {
        [JsonProperty("transferTooltipModelCollection")]
        public TransferTooltipModelCollection TransferTooltipModelCollection { get; set; }
    }
    public partial class TransferTooltipModelCollection
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
    public partial class Item
    {
        [JsonProperty("coverCurrentBenefitStatementToolTip")]
        public string CoverCurrentBenefitStatementToolTip { get; set; }
    }
}


public class PersonAndFilmsResponse
{
    public PersonContent Person { get; set; }


    public class PersonContent
    {
        public string Name { get; set; }

        public FilmConnectionContent FilmConnection { get; set; }

        public class FilmConnectionContent
        {
            public List<FilmContent> Films { get; set; }

            public class FilmContent
            {
                public string Title { get; set; }
            }
        }
    }
}
