using System;
using System.ComponentModel;
using Engine;

namespace GUI
{
    public class GameSession: INotifyPropertyChanged
    {
        public Character CurrentCharacter { get; set; }

        public GameSession()
        {
            CurrentCharacter = new Character();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}