using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PividMidi.Model
{
    public class MatrixButton : Button
    {
        public MatrixButton(string name, int channelID) : base(name, channelID)
        {
            Type = ControlType.MatrixButton;
            Value = 0;
        }
    }
}
