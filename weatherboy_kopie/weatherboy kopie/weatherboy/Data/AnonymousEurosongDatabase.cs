using LiteDB;
using weatherboy.Data;
using weatherboy.Models;

namespace weatherboy.Data
{
    public class AnonymousEurosongDatabase : IAnonymousEurosongDataContext
    {
        LiteDatabase db = new LiteDatabase(@"data.db");

        // SONG

        public void AddSong(Song song)
        {
            db.GetCollection<Song>("Songs").Insert(song);
        }

        public void DeleteSong(int songid)
        {
            db.GetCollection<Song>("Songs").Delete(songid);
        }

        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>("Songs").FindAll();
        }
        public Song GetSongById(int id)
        {
            return db.GetCollection<Song>("Songs").FindById(id);
        }

        public List<Vote> getVoteBySongID(int songid)
        {
            return db.GetCollection<Vote>("Votes").Find(x => x.Song_ID == songid).ToList();
        }

        // ARTIST

        public void AddArtist(Artist artist)
        {
            db.GetCollection<Artist>("Artists").Insert(artist);
        }

        public  IEnumerable<Artist> GetArtist()
        {
            return db.GetCollection<Artist>("Artists").FindAll();
        }
        public Artist GetArtistById(int id)
        {
            return db.GetCollection<Artist>("Artists").FindById(id);
        }
        public List<Song> getSongsByArtistID(int Artistid)
        {
            return db.GetCollection<Song>("Songs").Find(x => x.Artist_ID == Artistid).ToList();
        }

        // VOTE
        public void AddVote(Vote vote)
        {
            db.GetCollection<Vote>("Votes").Insert(vote);
        }

        public IEnumerable<Vote> GetVote()
        {
            return db.GetCollection<Vote>("Votes").FindAll();
        }
        public Vote GetVoteBySongId(int songid)
        {
            return db.GetCollection<Vote>("Votes").FindById(songid);
        }
    }
}
