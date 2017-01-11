using JinnHouse.Entities.Entities.Audio;
using JinnHouse.Entities.Interfaces.Interfaces.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities.Video
{

    public class Channel : IChannel
    {
        public int Id { get; set; }

        public Channel(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        public int Number { get; set; }

        public string Name { get; set; }
    }
}
