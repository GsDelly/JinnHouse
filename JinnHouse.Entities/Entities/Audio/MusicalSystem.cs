using JinnHouse.Entities.Interfaces.Interfaces.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities.Audio
{
    public class MusicalSystem : IMusicSystem
    {
        /*public ISong CurrentSong { get; set; }

        public IList<ISong> Songs { get; set; }*/

        public MusicalSystem()
        {
            this.Songs = new List<Song>();
            this.Songs = this.GetDefaultSongs();
            this.CurrentSong = this.Songs.ElementAt(0).ToString();
            this.SongIndex = 0;
        }

        public int MusicalSystemId { get; set; }

        //public virtual AudioSystem AudioSystem { get; set; }

        /*[NotMapped]
        public Song CurrentSong { get; set; }*/

        [NotMapped]
        public IList<Song> Songs { get; set; }

        /*ISong IMusicSystem.CurrentSong
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }*/
        IList<ISong> IMusicSystem.Songs
        {
            get
            {
                return (IList<ISong>) this.Songs;
            }

            set
            {
                if (!(value is IList<ISong>))
                    throw new InvalidCastException("must implement IChannel");

                this.Songs = (IList<Song>)value;
            }
        }

        public string CurrentSong { get; set; }

        public int SongIndex { get; set; }

        public void SwitchForward()
        {
            if (this.SongIndex >= 0 && this.SongIndex < this.Songs.Count() - 1)
            {
                this.CurrentSong = this.Songs.ElementAt(++this.SongIndex).ToString();
            }
            else if (this.SongIndex == this.Songs.Count() - 1)
            {
                this.CurrentSong = this.Songs.ElementAt(0).ToString();
            }
        }

        public void SwitchBackward()
        {
            if (this.SongIndex > 0 && this.SongIndex <= this.Songs.Count() - 1)
            {
                this.CurrentSong = this.Songs.ElementAt(--this.SongIndex).Name;
            }
            else if (this.SongIndex == 0)
            {
                this.CurrentSong = this.Songs.Last().Name;
            }
        }

        public IList<Song> GetDefaultSongs()
        {
            return new List<Song>
            {
                new Song(1, "Questa nostra stagione", "Eros ramazzotti"),
                new Song(2, "Lifelines", "A-ha"),
                new Song(3, "Can't take my hands off you", "Soultans"),
                new Song(4, "Love will keep us alive", "Scorpions"),
                new Song(5, "My friend", "Groove armada"),
                new Song(6, "I`d like you for christmas", "Julie London"),
                new Song(7, "Heartbreaker", "Will.i.am"),
                new Song(8, "Come along now", "Despina Vandi")
            };
        }

        IList<ISong> IMusicSystem.GetDefaultSongs()
        {
            throw new NotImplementedException();
        }

        public string GetSongsList()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (ISong song in this.Songs)
            {
                stringBuilder.Append(song.Singer+ " - " + song.Name);
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}
