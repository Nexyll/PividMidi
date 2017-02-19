using Sanford.Multimedia.Midi;

namespace PividMidi.Model
{
    public class Fader : Control
    {
        public Fader(string name, int channelID, APCMiniController apcMiniController)
        {
            Name = name;
            ChannelID = channelID;
            Type = ControlType.Fader;
            ApcMiniController = apcMiniController;
        }
    }
}
