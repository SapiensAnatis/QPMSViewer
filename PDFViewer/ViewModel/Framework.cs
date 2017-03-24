using System;
using System.ComponentModel;

namespace PDFViewer.ViewModel
{
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string PropertyName)
        {
            if (this.GetType().GetMethod(PropertyName) != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
            else
            {
                throw new NotImplementedException($"ObservableObject '{this.GetType()}' does not have/implement the property '{PropertyName}'.");
            }
        }
    }
}
