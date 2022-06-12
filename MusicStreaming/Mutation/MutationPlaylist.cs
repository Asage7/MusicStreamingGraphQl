using MusicStreaming.Data;
using MusicStreaming.Models;

namespace MusicStreaming.Mutation
{
    [ExtendObjectType(typeof(Mutation))]
    public class MutationPlaylist
    {
        public async Task<Playlist> CreatePlaylist([Service] AppDBContext context, Guid user_id, string name, List<Guid> musicIds)
        {
            Playlist playlist = new Playlist
            {
                UserId = user_id,
                Name = name,
                Musics = new List<Music>()
            };
            foreach (var musicId in musicIds)
            {
                playlist.Musics.Add(context.Music.FirstOrDefault(m => m.Id == musicId));
            }

            context.Playlists.Add(playlist);
            context.SaveChanges();

            return playlist;
        }
        public async Task<Playlist> AlterPlaylist([Service] AppDBContext context, Guid id, Guid user_id, string name, List<Guid> musicIds)
        {
            var playlistdb = context.Playlists.FirstOrDefault(x => x.Id == id);
            if (playlistdb == null)
                throw new Exception("Playlist not found");

            playlistdb.Name = name;
            playlistdb.UserId = user_id;
            foreach (var musicId in musicIds)
            {
                playlistdb.Musics.Add(context.Music.FirstOrDefault(m => m.Id == musicId));
            }
            context.Update(playlistdb);
            context.SaveChanges();
            return playlistdb;

        }
        public async Task<bool> DeletePlaylist([Service] AppDBContext context, Guid id)
        {
            var playlistdb = context.Playlists.FirstOrDefault(x => x.Id == id);
            if (playlistdb == null)
                throw new Exception("Playlist not found");
            context.Playlists.Remove(playlistdb);
            context.SaveChanges();
            return true;
        }
    }
}
