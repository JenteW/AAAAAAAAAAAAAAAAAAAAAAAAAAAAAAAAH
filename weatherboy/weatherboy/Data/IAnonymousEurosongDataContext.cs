using weatherboy.Models;

namespace weatherboy.Data
{
    public interface IAnonymousEurosongDataContext
    {
        void AddSong(Song song);
        IEnumerable<Song> GetSongs();
        Song GetSongById(int id);
        List<Vote> getVoteBySongID(int songid);
        
        //ARTIST
        void AddArtist(Artist artist);
        IEnumerable<Artist> GetArtist();
        Artist GetArtistById(int id);

        //get songs by artist id
        List<Song> getSongsByArtistID(int Artistid);

        //VOTE
        void AddVote(Vote vote);
        IEnumerable<Vote> GetVote();

        Vote GetVoteBySongId(int songid);



    }
}
