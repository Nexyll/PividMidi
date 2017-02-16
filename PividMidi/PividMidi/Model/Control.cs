using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PividMidi.Model
{
    public abstract class Control : INotifyPropertyChanged
    {
        private int _value;

        /// <summary>
        /// Nom du contrôle
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Numéro de voie MIDI
        /// </summary>
        public int ChannelID { get; set; }
        /// <summary>
        /// Type de contrôle
        /// </summary>
        public ControlType Type { get; set; }

        /// <summary>
        /// valeur courante du contrôle
        /// </summary>
        public int Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Représente en les note ON et OFF des messages midi
        /// </summary>
        public bool State { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ControlType
    {
        Fader,
        Button
    }
}

