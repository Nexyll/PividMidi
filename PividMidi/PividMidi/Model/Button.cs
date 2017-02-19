using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace PividMidi.Model
{
    public abstract class Button : Control
    {
        public Button(string name, int channelID, APCMiniController apcMiniController)
        {
            Name = name;
            ChannelID = channelID;
            ApcMiniController = apcMiniController;
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
