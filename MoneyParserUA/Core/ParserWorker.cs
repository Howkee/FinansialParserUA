using AngleSharp.Html.Parser;
using System;

namespace MoneyParserUA.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HTMLLoader loader;

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }
        public IParserSettings ParserSettings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HTMLLoader(value);
            }
        }

       public event Action<object, T> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings):this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new HTMLLoader(parserSettings);
        }

        public async void Work()
        {
            var source = await loader.GetSourse();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source.ToString());
            var result = parser.Parse(document);

            OnCompleted?.Invoke(this, result);
        }

    }
}
