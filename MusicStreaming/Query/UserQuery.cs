using MusicStreaming.Data;
using MusicStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicStreaming.Query
{
    [ExtendObjectType(typeof(Query))]
    public class UserQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<User>> GetUsers ([Service] AppDBContext context) => context.Users;
        [UseProjection]
        [UseFiltering]
        public async Task<User> GetUser([Service] AppDBContext context, Guid id) => context.Users.Include(p => p.Playlists).FirstOrDefault(x => x.Id == id);
    }
}
