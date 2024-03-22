namespace Calling_Elvis
{
    public class Song
    {
        public int id { get; set; }
        public  string title { get; set; }
        public int artist { get; set; }
        public string spotify { get; set; }


        public override string ToString()
        {
            return $"{id} - {title} - ({artist})\n Spotify: {spotify}";
        }
    }
}
