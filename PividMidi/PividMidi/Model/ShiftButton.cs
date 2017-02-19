using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace PividMidi.Model
{
    public class ShiftButton : Button
    {
        public ShiftButton(string name, int channelID, APCMiniController apcMiniController) : base(name, channelID, apcMiniController)
        {
            Type = ControlType.ShiftButton;
            Value = 0;
        }
    }
}
