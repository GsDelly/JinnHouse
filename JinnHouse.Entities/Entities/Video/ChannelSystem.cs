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
    public class ChannelSystem : IChannelSystem
    {
        public ChannelSystem()
        {
            //this.Channels = new List<Channel>();
            //this.Channels = this.GetDefaultChannels();
            //this.CurrentChannel = this.GetDefaultChannels().First();
            this.Channels = new List<Channel>();
            this.Channels = this.GetDefaultChannels();
            this.CurrentChannel = this.Channels.ElementAt(0).Name;
            this.ChannelIndex = 0;
        }
        public ChannelSystem(int channel)
        {
            this.Channels = new List<Channel>();
            this.Channels = this.GetDefaultChannels();
            if ((channel > 0) && (channel <= this.Channels.Count()))
            {
                this.CurrentChannel = this.Channels.ElementAt(channel - 1).Name;
                this.ChannelIndex = channel;
            }  
        }

        public int ChannelSystemId { get; set; }
        /*[Key]
        public int Id { get; set; }*/
        //public Channel CurrentChannel { get; set; }

        public string CurrentChannel { get; set; }

        public int ChannelIndex { get; set; }

        [NotMapped]
        public IList<Channel> Channels { get; set; }

        /*[NotMapped]
        IChannel IChannelSystem.CurrentChannel
        {
            get
            {
                return this.CurrentChannel;
            }

            set
            {
                if (!(value is IChannel))
                    throw new InvalidCastException("must implement IChannel");

                this.CurrentChannel = (Channel)value;
            }
        }*/

        IList<IChannel> IChannelSystem.Channels
        {
            get
            {
                return (IList<IChannel>)this.Channels;
            }

            set
            {
                if (!(value is IList<IChannel>))
                    throw new InvalidCastException("must implement IVolumeSystem");

                this.Channels = (IList<Channel>)value;
            }
        }

        public void SwitchForward()
        {
                if (this.ChannelIndex >= 0 && this.ChannelIndex < this.Channels.Count() - 1)
                {
                    this.CurrentChannel = this.Channels.ElementAt(++this.ChannelIndex).Name;
                }
                else if (this.ChannelIndex == this.Channels.Count() - 1)
                {
                    this.CurrentChannel = this.Channels.ElementAt(0).Name;
                }
        }

        public void SwitchBackward()
        {
            if (this.ChannelIndex > 0 && this.ChannelIndex <= this.Channels.Count() - 1)
                {
                    this.CurrentChannel = this.Channels.ElementAt(--this.ChannelIndex).Name;
                }
                else if (this.ChannelIndex == 0)
                {
                    this.CurrentChannel = this.Channels.Last().Name;
                }
        }

        public string GetChannelList()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (IChannel channel in this.Channels)
            {
                stringBuilder.Append(channel.Name + " : " + channel.Number);
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }

        public IList<Channel> GetDefaultChannels()
        {
            return new List<Channel>
            {
                new Channel(1, "1+1"),
                new Channel(2, "Inter"),
                new Channel(3, "CNN"),
                new Channel(4, "Discovery"),
                new Channel(5, "BBC"),
                new Channel(6, "Animal Planet"),
                new Channel(7, "TNT"),
                new Channel(8, "NTV")
            };
        }

        IList<IChannel> IChannelSystem.GetDefaultChannels()
        {
            throw new NotImplementedException();
        }
    }
}
