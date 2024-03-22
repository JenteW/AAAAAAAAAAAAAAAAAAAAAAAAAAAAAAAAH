using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Calling_Elvis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("https://api.elvis.cloud");
            var request = new RestRequest("http://webservies.be/Eurosong/Songs", Method.Get);

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
       
            List<Song> songs = System.Text.Json.JsonSerializer.Deserialize<List<Song>>(response.Content);
            Console.WriteLine(String.Join("\n", songs));
            Console.Write("Song");
            int id = Convert.ToInt32(Console.ReadLine());
            Song song = songs.Find(s => s.id == id);
            Console.WriteLine(song);

            request = new RestRequest($"http://webservies.be/Eurosong/Artists/{song.artist}", Method.Get);
            response = client.Execute(request);
            Artist artist = System.Text.Json.JsonSerializer.Deserialize<Artist>(response.Content);
            Console.WriteLine("Artist");
            Console.WriteLine(artist);

            Console.WriteLine("song");
            Console.WriteLine(song);
        }
    }
}