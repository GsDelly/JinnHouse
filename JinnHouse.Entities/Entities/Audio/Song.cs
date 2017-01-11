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
    public class Song : ISong
    {
        public int SongId { get; set; }

        public int MusicalSystemId { get; set; }

        /*[NotMapped]
        public virtual MusicalSystem MusicalSystem { get; set; }*/

        public Song(int number, string name, string singer)
        {
            this.Number = number;
            this.Name = name;
            this.Singer = singer;
        }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Singer { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Singer, Name);
        }
    }
}
