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

            Controls.Add(new MatrixButton("Bouton 1", 0));
            Controls.Add(new MatrixButton("Bouton 2", 1));
            Controls.Add(new MatrixButton("Bouton 3", 2));
            Controls.Add(new MatrixButton("Bouton 4", 3));
            Controls.Add(new MatrixButton("Bouton 5", 4));
            Controls.Add(new MatrixButton("Bouton 6", 5));
            Controls.Add(new MatrixButton("Bouton 7", 6));
            Controls.Add(new MatrixButton("Bouton 8", 7));
            Controls.Add(new MatrixButton("Bouton 9", 8));
            Controls.Add(new MatrixButton("Bouton 10", 9));
            Controls.Add(new MatrixButton("Bouton 11", 10));
            Controls.Add(new MatrixButton("Bouton 12", 11));
            Controls.Add(new MatrixButton("Bouton 13", 12));
            Controls.Add(new MatrixButton("Bouton 14", 13));
            Controls.Add(new MatrixButton("Bouton 15", 14));
            Controls.Add(new MatrixButton("Bouton 16", 15));
            Controls.Add(new MatrixButton("Bouton 17", 16));
            Controls.Add(new MatrixButton("Bouton 18", 17));
            Controls.Add(new MatrixButton("Bouton 19", 18));
            Controls.Add(new MatrixButton("Bouton 20", 19));
            Controls.Add(new MatrixButton("Bouton 21", 20));
            Controls.Add(new MatrixButton("Bouton 22", 21));
            Controls.Add(new MatrixButton("Bouton 23", 22));
            Controls.Add(new MatrixButton("Bouton 24", 23));
            Controls.Add(new MatrixButton("Bouton 25", 24));
            Controls.Add(new MatrixButton("Bouton 26", 25));
            Controls.Add(new MatrixButton("Bouton 27", 26));
            Controls.Add(new MatrixButton("Bouton 28", 27));
            Controls.Add(new MatrixButton("Bouton 29", 28));
            Controls.Add(new MatrixButton("Bouton 30", 29));
            Controls.Add(new MatrixButton("Bouton 31", 30));
            Controls.Add(new MatrixButton("Bouton 32", 31));
            Controls.Add(new MatrixButton("Bouton 33", 32));
            Controls.Add(new MatrixButton("Bouton 34", 33));
            Controls.Add(new MatrixButton("Bouton 35", 34));
            Controls.Add(new MatrixButton("Bouton 36", 35));
            Controls.Add(new MatrixButton("Bouton 37", 36));
            Controls.Add(new MatrixButton("Bouton 38", 37));
            Controls.Add(new MatrixButton("Bouton 39", 38));
            Controls.Add(new MatrixButton("Bouton 40", 39));
            Controls.Add(new MatrixButton("Bouton 41", 40));
            Controls.Add(new MatrixButton("Bouton 42", 41));
            Controls.Add(new MatrixButton("Bouton 43", 42));
            Controls.Add(new MatrixButton("Bouton 44", 43));
            Controls.Add(new MatrixButton("Bouton 45", 44));
            Controls.Add(new MatrixButton("Bouton 46", 45));
            Controls.Add(new MatrixButton("Bouton 47", 46));
            Controls.Add(new MatrixButton("Bouton 48", 47));
            Controls.Add(new MatrixButton("Bouton 49", 48));
            Controls.Add(new MatrixButton("Bouton 50", 49));
            Controls.Add(new MatrixButton("Bouton 51", 50));
            Controls.Add(new MatrixButton("Bouton 52", 51));
            Controls.Add(new MatrixButton("Bouton 53", 52));
            Controls.Add(new MatrixButton("Bouton 54", 53));
            Controls.Add(new MatrixButton("Bouton 55", 54));
            Controls.Add(new MatrixButton("Bouton 56", 55));
            Controls.Add(new MatrixButton("Bouton 57", 56));
            Controls.Add(new MatrixButton("Bouton 58", 57));
            Controls.Add(new MatrixButton("Bouton 59", 58));
            Controls.Add(new MatrixButton("Bouton 60", 59));
            Controls.Add(new MatrixButton("Bouton 61", 60));
            Controls.Add(new MatrixButton("Bouton 62", 61));
            Controls.Add(new MatrixButton("Bouton 63", 62));
            Controls.Add(new MatrixButton("Bouton 64", 63));

            Controls.Add(new BottomButton("Bottom 1", 64));
            Controls.Add(new BottomButton("Bottom 2", 65));
            Controls.Add(new BottomButton("Bottom 3", 66));
            Controls.Add(new BottomButton("Bottom 4", 67));
            Controls.Add(new BottomButton("Bottom 5", 68));
            Controls.Add(new BottomButton("Bottom 6", 69));
            Controls.Add(new BottomButton("Bottom 7", 70));
            Controls.Add(new BottomButton("Bottom 8", 71));

            Controls.Add(new RightButton("Right 1", 82));
            Controls.Add(new RightButton("Right 2", 83));
            Controls.Add(new RightButton("Right 3", 84));
            Controls.Add(new RightButton("Right 4", 85));
            Controls.Add(new RightButton("Right 5", 86));
            Controls.Add(new RightButton("Right 6", 87));
            Controls.Add(new RightButton("Right 7", 88));
            Controls.Add(new RightButton("Right 8", 89));

            Controls.Add(new ShiftButton("Shift", 98));

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
    }
}
