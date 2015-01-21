using System.ComponentModel;
using System.Runtime.CompilerServices;
using Pars.Annotations;

namespace Pars
{
    public class ErrorMessage : INotifyPropertyChanged
    {
        private string _message;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Message
        {
            get { return _message; }
            set
            {
                if(_message == value) return;
                _message = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
