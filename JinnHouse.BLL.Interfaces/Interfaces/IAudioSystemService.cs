using JinnHouse.Entities.Entities.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces
{
    public interface IAudioSystemService
    {
        AudioSystem GetAudioSystemById(int id);

        IEnumerable<AudioSystem> GetAllAudioSystems();

        void Switch(int id);

        void RemoveAudioSystem(int id);

        void AddAudioSystem(string name);

        bool IsExists(string name);
    }
}
