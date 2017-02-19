using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace PividMidi.Model
{
    public class RightButton : Button
    {
        public RightButton(string name, int channelID, APCMiniController apcMiniController) : base(name, channelID, apcMiniController)
        {
            Type = ControlType.RightButton;
            Value = 0;
        }
    }
}
