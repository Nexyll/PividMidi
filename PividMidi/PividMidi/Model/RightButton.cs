using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PividMidi.Model
{
    public class RightButton : Button
    {
        public RightButton(string name, int channelID) : base(name, channelID)
        {
            Type = ControlType.RightButton;
            Value = 0;
        }
    }
}
