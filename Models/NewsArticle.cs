namespace BusinessNewsApp.Models
{
    // This matches the top-level JSON object
    public class NewsResponse
    {
        public List<Article> Articles { get; set; }
    }

    // This matches the individual article objects
    public class Article
    {
        public Source Source { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }

    // This matches the nested "source" object
    public class Source
    {
        public string Name { get; set; }
    }
}
