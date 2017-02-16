using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PividMidi
{
    public class Fader : Control
    {
        public Fader(string name, int channelID)
        {
            Name = name;
            ChannelID = channelID;
            Type = ControlType.Fader;
        }
    }
}
