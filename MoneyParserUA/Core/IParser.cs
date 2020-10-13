using AngleSharp.Html.Dom;

namespace MoneyParserUA.Core
{
    interface IParser<T> where T: class
    {
        T Parse(IHtmlDocument document);
    }
}
