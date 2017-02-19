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
        private OutputDevice _outputDevice2;

        public List<Control> Controls = new List<Control>();

        public APCMiniController(InputDevice inputDevice, OutputDevice outputDevice, OutputDevice outputDevice2)
        {
            _inputDevice = inputDevice;
            _outputDevice = outputDevice;
            _outputDevice2 = outputDevice2;
            _channelStopper = new ChannelStopper();

            _inputDevice.ChannelMessageReceived += InputDeviceOnChannelMessageReceived;

            for (int i = 1; i < 10; i++)
            {
             Controls.Add(new Fader("Fader " + i, i+47, this));   
            }

            for (int i = 1; i < 65; i++)
            {
                Controls.Add(new MatrixButton("Bouton " + i, i-1, this));
            }

            for (int i = 1; i < 9; i++)
            {
                Controls.Add(new BottomButton("Bottom " + i, i+63, this));
            }

            for (int i = 1; i < 9; i++)
            {
                Controls.Add(new RightButton("Right " + i, i+81, this));
            }

            Controls.Add(new ShiftButton("Shift", 98, this));

            _inputDevice.StartRecording();

        }

        private void InputDeviceOnChannelMessageReceived(object sender, ChannelMessageEventArgs channelMessageEventArgs)
        {
            switch (channelMessageEventArgs.Message.Command)
            {
                case ChannelCommand.NoteOff:
                    Button concernedButtonOff = 
                        Controls.First(
                            x => x.ChannelID == channelMessageEventArgs.Message.Data1 && (x.Type == ControlType.BottomButton || x.Type == ControlType.MatrixButton || x.Type == ControlType.RightButton || x.Type == ControlType.ShiftButton)) as Button;
                    concernedButtonOff.Value = 0;
                    break;
                case ChannelCommand.NoteOn:
                    Button concernedButtonOn =
                        Controls.First(
                            x => x.ChannelID == channelMessageEventArgs.Message.Data1 && (x.Type == ControlType.BottomButton || x.Type == ControlType.MatrixButton || x.Type == ControlType.RightButton || x.Type == ControlType.ShiftButton)) as Button;
                    concernedButtonOn.Value = 127;
                    break;
                case ChannelCommand.PolyPressure:
                    break;
                case ChannelCommand.Controller:
                    Fader concernedFader =
                        Controls.First(
                                x => x.ChannelID == channelMessageEventArgs.Message.Data1 && x.Type == ControlType.Fader) as
                            Fader;
                    concernedFader.Value = channelMessageEventArgs.Message.Data2;

                    //ChannelMessage channelMessage = new ChannelMessage(channelMessageEventArgs.Message.Command, channelMessageEventArgs.Message.MidiChannel, channelMessageEventArgs.Message.Data1, channelMessageEventArgs.Message.Data2);
                    //_outputDevice.Send(channelMessage);

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

        public void setLed(int channel, int Data)
        {
            Console.WriteLine("Channel : " + channel + " Data : " + Data);
            ChannelMessage channelMessage = new ChannelMessage(ChannelCommand.NoteOn, 1, channel, Data);
            _outputDevice.Send(channelMessage);
        }

        public void setLed(ChannelCommand command, int channel, ledMode ledMode)
        {
            ChannelMessage channelMessage = null;
            switch (ledMode)
            {
                case ledMode.Off:
                    channelMessage = new ChannelMessage(command, 1, channel, 0);
                    break;
                case ledMode.Green:
                    channelMessage = new ChannelMessage(command, 1, channel, 1);
                    break;
                case ledMode.BlinkGreen:
                    channelMessage = new ChannelMessage(command, 1, channel, 2);
                    break;
                case ledMode.Red:
                    channelMessage = new ChannelMessage(command, 1, channel, 3);
                    break;
                case ledMode.BlinkRed:
                    channelMessage = new ChannelMessage(command, 1, channel, 4);
                    break;
                case ledMode.Yellow:
                    channelMessage = new ChannelMessage(command, 1, channel, 5);
                    break;
                case ledMode.BlinkYellow:
                    channelMessage = new ChannelMessage(command, 1, channel, 6);
                    break;
                default:
                    channelMessage = new ChannelMessage(command, 1, channel, 127);
                    break;
            }
            _outputDevice.Send(channelMessage);
        }

        public void sendMidi(Control control)
        {
            ChannelMessage channelMessage = null;
            if (control.Type == ControlType.BottomButton || control.Type == ControlType.MatrixButton || control.Type == ControlType.RightButton || control.Type == ControlType.ShiftButton)
            {
                if (control.Value == 127)
                {
                    channelMessage = new ChannelMessage(ChannelCommand.NoteOn, 0, control.ChannelID, control.Value);
                }
                else
                {
                    channelMessage = new ChannelMessage(ChannelCommand.NoteOff, 0, control.ChannelID, control.Value);
                }
            }
            else
            {
                channelMessage = new ChannelMessage(ChannelCommand.Controller, 0, control.ChannelID, control.Value);
            }
            _outputDevice2.Send(channelMessage);
        }
    }
}
