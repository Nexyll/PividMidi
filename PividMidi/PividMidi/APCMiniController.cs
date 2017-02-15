using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace PividMidi
{
    class APCMiniController
    {
        private InputDevice _inputDevice;
        private OutputDevice _outputDevice;

        public List<Control> Controls = new List<Control>();

        public APCMiniController(InputDevice inputDevice, OutputDevice outputDevice)
        {
            _inputDevice = inputDevice;
            _outputDevice = outputDevice;

        }

    }
}
