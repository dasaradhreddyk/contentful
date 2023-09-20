using Newtonsoft.Json;

namespace GraphQL.Client.Http;

public class m
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
        [JsonProperty("hoursWorkedLabelToolTip")]
        public string HoursWorkedLabelToolTip { get; set; }
    }
}
