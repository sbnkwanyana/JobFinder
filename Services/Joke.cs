namespace JobFinder.Services
{
    public class Joke
    {
        public string[] Categories { get; set; }
        public string Created_at { get; set; }
        public string Icon_Url { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }

        public Joke(string[] categories, string created_at, string icon_url, string id, string url, string value)
        {
            Categories = categories;
            Created_at = created_at;
            Icon_Url = icon_url;
            Id = id;
            Url = url;
            Value = value;
        }
    }
}