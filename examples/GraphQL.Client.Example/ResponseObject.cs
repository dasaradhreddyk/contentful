
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GraphQL.Client.Example
{


    public partial class Welcome
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

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

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, GraphQL.Client.Example.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, GraphQL.Client.Example.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
