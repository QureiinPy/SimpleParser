

namespace ParserWPF.Core.Habra
{
    /// <summary>
    /// Settings for Habr
    /// </summary>
    internal class HabraSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://habr.com/ru/articles";
        //public string Preffix { get; set; } = "page{CurrentId}";
        public string Preffix { get; set; } = "page";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public HabraSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
    }
}
