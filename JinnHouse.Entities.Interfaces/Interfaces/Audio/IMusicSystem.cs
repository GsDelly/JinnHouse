using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Audio
{
    public interface IMusicSystem : IMusicControlable
    {
        string CurrentSong { get; set; }

        int SongIndex { get; set; }

        IList<ISong> Songs { get; set; }

        IList<ISong> GetDefaultSongs();
    }
}
