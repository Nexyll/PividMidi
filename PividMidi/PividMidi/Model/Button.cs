using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PividMidi.Model
{
    public abstract class Button : Control
    {
        public Button(string name, int channelID)
        {
            Name = name;
            ChannelID = channelID;
        }
    }

    public enum ledMode
    {
        Off,
        Green,
        BlinkGreen,
        Red,
        BlinkRed,
        Yellow,
        BlinkYellow
    }
}
