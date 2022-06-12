using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.Models
{
    public class Music
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
