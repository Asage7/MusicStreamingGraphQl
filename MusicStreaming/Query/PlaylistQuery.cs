using Microsoft.EntityFrameworkCore;
using MusicStreaming.Data;
using MusicStreaming.Models;

namespace MusicStreaming.Query
{
    [ExtendObjectType(typeof(Query))]
    public class PlaylistQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Playlist>> GetPlaylists([Service] AppDBContext context) => context.Playlists;
        [UseProjection]
        [UseFiltering]
        public async Task<Playlist> GetPlaylist([Service] AppDBContext context, Guid id) => context.Playlists.Include(p => p.Musics).FirstOrDefault(x => x.Id == id);
    }
}
