using System;
using System.Collections.Generic;
using System.Linq;
using Sanford.Multimedia.Midi;

namespace PividMidi.Model
{
    public class APCMiniController
    {
        private InputDevice _inputDevice;
        private ChannelStopper _channelStopper;
        private OutputDevice _outputDevice;

        public List<Control> Controls = new List<Control>();

        public APCMiniController(InputDevice inputDevice, OutputDevice outputDevice)
        {
            _inputDevice = inputDevice;
            _outputDevice = outputDevice;
            _channelStopper = new ChannelStopper();

            _inputDevice.ChannelMessageReceived += InputDeviceOnChannelMessageReceived;

            Controls.Add(new Fader("Fader 1", 48));
            Controls.Add(new Fader("Fader 2", 49));
            Controls.Add(new Fader("Fader 3", 50));
            Controls.Add(new Fader("Fader 4", 51));
            Controls.Add(new Fader("Fader 5", 52));
            Controls.Add(new Fader("Fader 6", 53));
            Controls.Add(new Fader("Fader 7", 54));
            Controls.Add(new Fader("Fader 8", 55));
            Controls.Add(new Fader("Fader 9", 56));


            _inputDevice.StartRecording();

        }

        private void InputDeviceOnChannelMessageReceived(object sender, ChannelMessageEventArgs channelMessageEventArgs)
        {
            switch (channelMessageEventArgs.Message.Command)
            {
                case ChannelCommand.NoteOff:
                    break;
                case ChannelCommand.NoteOn:
                    break;
                case ChannelCommand.PolyPressure:
                    break;
                case ChannelCommand.Controller:
                    Fader concernedFader =
                        Controls.First(
                                x => x.ChannelID == channelMessageEventArgs.Message.Data1 && x.Type == ControlType.Fader) as
                            Fader;
                    concernedFader.Value = channelMessageEventArgs.Message.Data2;
                    break;
                case ChannelCommand.ProgramChange:
                    break;
                case ChannelCommand.ChannelPressure:
                    break;
                case ChannelCommand.PitchWheel:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
