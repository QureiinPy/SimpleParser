using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserWPF.Core.Habra
{
    /// <summary>
    /// Parser for Habr
    /// </summary>
    internal class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var parent = document.QuerySelectorAll("a").Where(x => x.ClassName != null && x.ClassName.Contains("tm-title__link"));
            var items = parent.Children("span");
            foreach ( var item in items )
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
