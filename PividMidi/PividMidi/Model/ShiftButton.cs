using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PividMidi.Model
{
    public class ShiftButton : Button
    {
        public ShiftButton(string name, int channelID) : base(name, channelID)
        {
            Type = ControlType.ShiftButton;
            Value = 0;
        }
    }
}
