using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MirthApp.Models;
using SQLite;

namespace MirthApp.Data
{
    public class ReleaseDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ReleaseDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Release>().Wait();
            _database.CreateTableAsync<Genre>().Wait();
            _database.CreateTableAsync<ReleaseGenre>().Wait();
            _database.CreateTableAsync<Artist>().Wait();
        }

        // ARTIST METHODS
        public Task<List<Artist>> GetArtistsAsync()
        {
            return _database.Table<Artist>().ToListAsync();
        }

        public Task<Artist> GetArtistAsync(int id)
        {
            return _database.Table<Artist>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        public Task<int> SaveArtistAsync(Artist artist)
        {
            if (artist.ID != 0)
            {
                return _database.UpdateAsync(artist);
            }
            else
            {
                return _database.InsertAsync(artist);
            }
        }

        public Task<int> DeleteArtistAsync(Artist artist)
        {
            return _database.DeleteAsync(artist);
        }

        public Task<List<Release>> GetReleasesForArtistAsync(int artistId)
        {
            return _database.Table<Release>()
                            .Where(r => r.ArtistId == artistId)
                            .ToListAsync();
        }


        // GENRE METHODS
        public Task<int> SaveGenreAsync(Genre genre)
        {
            if (genre.ID != 0)
            {
                return _database.UpdateAsync(genre);
            }
            else
            {
                return _database.InsertAsync(genre);
            }
        }

        public Task<int> DeleteGenreAsync(Genre genre)
        {
            return _database.DeleteAsync(genre);
        }

        public Task<List<Genre>> GetGenresAsync()
        {
            return _database.Table<Genre>().ToListAsync();
        }



        // RELEASEGENRES METHODS
        public Task<int> SaveReleaseGenreAsync(ReleaseGenre releaseG)
        {
            if (releaseG.ID != 0)
            {
                return _database.UpdateAsync(releaseG);
            }
            else
            {
                return _database.InsertAsync(releaseG);
            }
        }
        public Task<List<Genre>> GetReleaseGenresAsync(int releaseID)
        {
            return _database.QueryAsync<Genre>(
            "select G.ID, G.Name from Genre G"
            + " inner join ReleaseGenre RG"
            + " on G.ID = RG.GenreID where RG.ReleaseID = ?",
            releaseID);
        }

        public Task<int> DeleteGenreFromReleaseAsync(int genreId, int releaseId)
        {
            return _database.Table<ReleaseGenre>()
                .Where(rg => rg.GenreID == genreId && rg.ReleaseID == releaseId)
                .DeleteAsync();
        }



        // RELEASE METHODS
        public Task<List<Release>> GetReleasesAsync()
        {
            return _database.Table<Release>().ToListAsync();
        }
        public Task<Release> GetReleaseAsync(int id)
        {
            return _database.Table<Release>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public async Task<int> SaveReleaseAsync(Release release)
        {
            if (release.SelectedArtist != null)
            {
                // Save the associated Artist if it exists
                await SaveArtistAsync(release.SelectedArtist);
                release.ArtistId = release.SelectedArtist.ID;
            }

            if (release.ID != 0)
            {
                return await _database.UpdateAsync(release);
            }
            else
            {
                return await _database.InsertAsync(release);
            }
        }
        public Task<int> DeleteReleaseAsync(Release release)
        {
            return _database.DeleteAsync(release);
        }
    }
}
