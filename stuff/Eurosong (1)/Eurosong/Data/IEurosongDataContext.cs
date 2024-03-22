using Eurosong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eurosong.Data
{
    public interface IEurosongDataContext
    {         
        //songs
        void AddSong(Song song);
        void DeleteSong(int id);
        void UpdateSong(int id, Song song);
        IEnumerable<Song> GetSongs();
        IEnumerable<Song> GetSongs(int artistID);
        Song GetSong(int id);

        //artists
        void AddArtist(Artist artist);
        void DeleteArtist(int id);
        void UpdateArtist(int id, Artist artist);
        IEnumerable<Artist> GetArtists();
        Artist GetArtist(int id);

        //votes
        void AddVote(Vote vote);
        void DeleteVote(int id);
        void UpdateVote(int id, Vote vote);

        IEnumerable<Vote> GetVotes();
        IEnumerable<Vote> GetVotes(int songId);
        Vote GetVote(int id);
        int GetPoints(int songId);

    }
}
