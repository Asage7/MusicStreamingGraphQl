using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
