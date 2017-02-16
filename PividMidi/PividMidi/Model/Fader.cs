namespace PividMidi.Model
{
    public class Fader : Control
    {
        public Fader(string name, int channelID)
        {
            Name = name;
            ChannelID = channelID;
            Type = ControlType.Fader;
        }
    }
}
