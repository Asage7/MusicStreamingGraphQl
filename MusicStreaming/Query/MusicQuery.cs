using Microsoft.EntityFrameworkCore;
using MusicStreaming.Data;
using MusicStreaming.Models;

namespace MusicStreaming.Query
{
    [ExtendObjectType(typeof(Query))]
    public class MusicQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Music>> GetMusics([Service] AppDBContext context) => context.Music;
        [UseProjection]
        [UseFiltering]
        public async Task<Music> GetMusic([Service] AppDBContext context, Guid id) => context.Music.Include(p => p.Playlists).FirstOrDefault(x => x.Id == id);
    }
}
