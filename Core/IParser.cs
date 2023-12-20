using AngleSharp.Html.Dom;


namespace ParserWPF.Core
{
    internal interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
