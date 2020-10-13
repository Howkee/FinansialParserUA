using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace MoneyParserUA.Core.Model
{
    class BankPriceParser : IParser<string[]>
    {
        List<string> list = new List<string>();
        public string[] Parse(IHtmlDocument document)
        {
            //var items = document.QuerySelectorAll("td")
            //       .Where(item => item.ClassName != null && 
            //       item.ClassName.Contains("mfm-text-nowrap"));

            var items = document.QuerySelectorAll("td[data-title='Готівковий ринок']");

            foreach (var item in items)
            {
                list.Add((string)item.TextContent);
            }
            return list.ToArray();                               
        }
    }
}
