using AngleSharp.Html.Parser;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserWPF.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings settings;
        HtmlLoader loader;
        private bool isActive;
        public int PageId { get; set; }
        public int ordinalNumber { get; set; }
        public bool IsActive
        {
            get { return isActive; }
        }

        public event Action<object, T> OnNewData;
        public event Action<object> OnComplited;

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
                return settings;
            }
            set
            {
                settings = value;
                loader = new HtmlLoader(value);
            }
        }


        public ParserWorker(IParser<T> parser)
        { 
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.settings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }
        public void Abort()
        {
            isActive = false;
            
        }
        private async void Worker()
        {
            for (int i = settings.StartPoint; i <= settings.EndPoint; i++)
            {
                if (!isActive)
                {
                    OnComplited?.Invoke(this);
                    return;
                }
                PageId = i;
                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();
                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);

                OnNewData?.Invoke(this, result);
            }
            OnComplited?.Invoke(this);
            isActive = false;
        }
    }
}
