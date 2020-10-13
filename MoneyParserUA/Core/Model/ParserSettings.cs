namespace MoneyParserUA.Core.Model
{
    class ParserSettings : IParserSettings
    {
        public string Url { get; set; } = "https://minfin.com.ua";
        public string Postfix { get; set; } = "ua/currency";
    }
}
