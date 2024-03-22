namespace Calling_Elvis
{
    public class Artist
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{id} - {name}";
        }
    }
}
