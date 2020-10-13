using AngleSharp.Html.Dom;
using System.Collections.Generic;


namespace MoneyParserUA.Core.Model
{
    class BlackMarketParser : IParser<string[]>
    {
        List<string> list = new List<string>();
        public string[] Parse(IHtmlDocument document)
        {
            var items = document.QuerySelectorAll("td[data-title='Чорний ринок']");

            foreach (var item in items)
            {
                list.Add((string)item.TextContent);
            }
            return list.ToArray();

        }
    }
}
