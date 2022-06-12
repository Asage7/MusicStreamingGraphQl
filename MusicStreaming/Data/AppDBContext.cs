using Microsoft.EntityFrameworkCore;
using MusicStreaming.Models;

namespace MusicStreaming.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            if (this.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory" &&
            this.Database.EnsureCreated())
            {
                this.Seed();
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Music> Music { get; set; }

        public void Seed()
        {

            Music music1 = new Music
            {
                Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"),
                Name = "Song1",
                Artist = "Artist1"
            };
            Music music2 = new Music
            {
                Id = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"),
                Name = "Song2",
                Artist = "Artist1"
            };
            Music music3 = new Music
            {
                Id = new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"),
                Name = "Song3",
                Artist = "Artist2"
            };
            Music music4 = new Music
            {
                Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777f2"),
                Name = "Song4",
                Artist = "Artist3"
            };
            Music music5 = new Music
            {
                Id = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f63"),
                Name = "Song5",
                Artist = "Artist3"
            };


            Playlist playlist1 = new Playlist
            {
                Id = new Guid("e97c32a6-5ca2-47c8-a02e-b3f7c7192dcc"),
                UserId = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f03"),
                Name = "Playlist1-User1",
                Musics = new List<Music>
                {
                    music1, music2, music3
                }
            };
            //music1.Playlists.Add(playlist1);
            //music2.Playlists.Add(playlist1);
            //music3.Playlists.Add(playlist1);
            this.Playlists.Add(playlist1);
            Playlist playlist2 = new Playlist
            {
                Id = new Guid("e97c32a6-5ca2-47c8-a02e-b3f7c7192daa"),
                Name = "Playlist2-User2",
                UserId = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f88"),
                Musics = new List<Music>
                {
                    music1, music2, music3
                }
            };
            //music1.Playlists.Add(playlist2);
            //music2.Playlists.Add(playlist2);
            //music3.Playlists.Add(playlist2);
            this.Playlists.Add(playlist2);
            Playlist playlist3 = new Playlist
            {
                Id = new Guid("9137dcaf-c3f4-4c02-a979-d4cf32ee9aec"),
                UserId = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f88"),
                Name = "Playlist3-User2",
                Musics = new List<Music>
                {
                    music4, music5, music3
                }
            };
            //music4.Playlists.Add(playlist3);
            //music5.Playlists.Add(playlist3);
            //music3.Playlists.Add(playlist3);
            this.Music.Add(music1);
            this.Music.Add(music2);
            this.Music.Add(music3);
            this.Music.Add(music4);
            this.Music.Add(music5);
            this.Playlists.Add(playlist3);
            User user = new User
            {
                Id = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f03"),
                Name = "User1",
                Idade = 16,
                Playlists = new List<Playlist> {
                    playlist1 
                }
            };
            this.Users.Add(user);
            user = new User
            {
                Id = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f88"),
                Name = "User2",
                Idade = 25,
                Playlists = new List<Playlist> { playlist2, playlist3}
            };

            this.Users.Add(user);
            this.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
            /*modelBuilder.Entity<User>().OwnsMany(p => p.Playlists).HasData(
                   
                        new Playlist
                        {
                            Id = new Guid("e97c32a6-5ca2-47c8-a02e-b3f7c7192dcc"),
                            UserId = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f03"),
                            Name = "Playlist1-User1",
                            Musics = new List<Music> {
                                new Music
                                {
                                    Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"),
                                    Name = "Song1",
                                    Artist = "Artist1"
                                },
                                new Music
                                {
                                    Id = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"),
                                    Name = "Song2",
                                    Artist = "Artist1"
                                },
                                new Music
                                {
                                    Id = new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"),
                                    Name = "Song3",
                                    Artist = "Artist2"
                                }
                            }
                        },
                        new Playlist
                        {
                            Id = new Guid("e97c32a6-5ca2-47c8-a02e-b3f7c7192daa"),
                            Name = "Playlist2-User2",
                            UserId = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f88"),
                            Musics = new List<Music> {
                                new Music
                                {
                                    Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"),
                                    Name = "Song1",
                                    Artist = "Artist1"
                                },
                                new Music
                                {
                                    Id = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"),
                                    Name = "Song2",
                                    Artist = "Artist1"
                                },
                                new Music
                                {
                                    Id = new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"),
                                    Name = "Song3",
                                    Artist = "Artist2"
                                }
                            }
                        },
                        new Playlist
                        {
                            Id = new Guid("9137dcaf-c3f4-4c02-a979-d4cf32ee9aec"),
                            UserId = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f88"),
                            Name = "Playlist3-User2",
                            Musics = new List<Music> {
                                new Music
                                {
                                    Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777f2"),
                                    Name = "Song4",
                                    Artist = "Artist3"
                                },
                                new Music
                                {
                                    Id = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f63"),
                                    Name = "Song5",
                                    Artist = "Artist3"
                                },
                                new Music
                                {
                                    Id = new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"),
                                    Name = "Song3",
                                    Artist = "Artist2"
                                }
                            }
                        }
                    
                    
                );*/

            /*modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f03"),
                    Name = "User1",
                    Idade = 16
                },
                new User
                {
                    Id = new Guid("70459d30-9d2b-48cf-b1a3-dfda48803f88"),
                    Name = "User2",
                    Idade = 25
                }}
            ); */
        }
    }
}
