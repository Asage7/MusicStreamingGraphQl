using MusicStreaming.Data;
using MusicStreaming.Models;

namespace MusicStreaming.Mutation
{
    [ExtendObjectType(typeof(Mutation))]
    public class MutationMusic
    {
        [UseProjection]
        [UseFiltering]
        public async Task<Music> CreateMusic([Service] AppDBContext context, string name, string artist)
        {
            Music music = new Music
            {
                Name = name,
                Artist = artist             
            };
            context.Music.Add(music);
            context.SaveChanges();

            return music;
        }
        [UseProjection]
        [UseFiltering]
        public async Task<Music> AlterMusic([Service] AppDBContext context, Guid id, string name, string artist)
        {
            var musicdb = context.Music.FirstOrDefault(x => x.Id == id);
            if (musicdb == null)
                throw new Exception("Music not found");

            musicdb.Name = name;
            musicdb.Artist = artist;
            context.Update(musicdb);
            context.SaveChanges();
            return musicdb;

        }
        [UseProjection]
        [UseFiltering]
        public async Task<bool> DeleteMusic([Service] AppDBContext context, Guid id)
        {
            var musicdb = context.Music.FirstOrDefault(x => x.Id == id);
            if (musicdb == null)
                throw new Exception("Playlist not found");
            context.Music.Remove(musicdb);
            context.SaveChanges();
            return true;
        }
    }
}
