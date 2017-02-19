using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace PividMidi.Model
{
    public class MatrixButton : Button
    {
        public MatrixButton(string name, int channelID, APCMiniController apcMiniController) : base(name, channelID, apcMiniController)
        {
            Type = ControlType.MatrixButton;
            Value = 0;
        }
    }
}
