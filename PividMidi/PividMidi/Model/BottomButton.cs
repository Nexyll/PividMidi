using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PividMidi.Model
{
    public class BottomButton : Button
    {
        public BottomButton(string name, int channelID) : base(name, channelID)
        {
            Type = ControlType.BottomButton;
            Value = 0;
        }
    }
}
