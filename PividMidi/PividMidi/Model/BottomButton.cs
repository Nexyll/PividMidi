using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace PividMidi.Model
{
    public class BottomButton : Button
    {
        public BottomButton(string name, int channelID, APCMiniController apcMiniController) : base(name, channelID, apcMiniController)
        {
            Type = ControlType.BottomButton;
            Value = 0;
        }
    }
}
