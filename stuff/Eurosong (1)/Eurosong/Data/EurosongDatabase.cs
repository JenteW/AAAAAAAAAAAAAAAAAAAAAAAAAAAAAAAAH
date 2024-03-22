using Eurosong.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eurosong.Data
{
    public class EurosongDatabase : IEurosongDataContext
    {
        LiteDatabase db = new LiteDatabase(@"data.db");

       

        /* ******************************************************
         ******************** SONG-METHODS **********************
         ******************************************************** */

        public void AddSong(Song song)
        {
            db.GetCollection<Song>("Songs").Insert(song);
        }
        public void DeleteSong(int id)
        {
            db.GetCollection<Song>("Songs").Delete(id);
            db.GetCollection<Vote>("Votes").DeleteMany(v => v.SongID == id);
        }

        public void UpdateSong(int id, Song song)
        {
            db.GetCollection<Song>("Songs").Update(id, song);
        }

        public Song GetSong(int id)
        {
            return db.GetCollection<Song>("Songs").FindById(id);
        }

        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>("Songs").FindAll();
        }

        public IEnumerable<Song> GetSongs(int artistId)
        {
            return db.GetCollection<Song>("Songs").Find(s => s.Artist == artistId);
        }

        /* ******************************************************
         ****************** ARTIST-METHODS **********************
         ******************************************************** */

        public void AddArtist(Artist artist)
        {
            db.GetCollection<Artist>("Artists").Insert(artist);
        }

        public void DeleteArtist(int id)
        {
            db.GetCollection<Artist>("Artists").Delete(id);
            List<Song> songs = this.GetSongs(id).ToList();
            foreach (var item in songs)
            {
                this.DeleteSong(item.ID);
            }
        }
        public void UpdateArtist(int id, Artist artist)
        {
            db.GetCollection<Artist>("Artists").Update(id, artist);
        }
        public Artist GetArtist(int id)
        {
            return db.GetCollection<Artist>("Artists").FindById(id);
        }

        public IEnumerable<Artist> GetArtists()
        {
            return db.GetCollection<Artist>("Artists").FindAll();
        }

        /* ******************************************************
         ******************* VOTE-METHODS ***********************
         ******************************************************** */

        public Vote GetVote(int id)
        {
            return db.GetCollection<Vote>("Votes").FindById(id);
        }
        public void DeleteVote(int id)
        {
            db.GetCollection<Vote>("Votes").Delete(id);
        }

        public void UpdateVote(int id, Vote vote)
        {
            db.GetCollection<Vote>("Votes").Update(id, vote);
        }
        public void AddVote(Vote vote)
        {
            db.GetCollection<Vote>("Votes").Insert(vote);
        }

        public IEnumerable<Vote> GetVotes()
        {
            return db.GetCollection<Vote>("Votes").FindAll();
        }
        public IEnumerable<Vote> GetVotes(int songId)
        {
            return db.GetCollection<Vote>("Votes").Find(v => v.SongID == songId);
        }

        public int GetPoints(int songId)
        {
            return db.GetCollection<Vote>("Votes").Find(v => v.SongID == songId).Sum(v => v.Points);
        }

       
    }
}
