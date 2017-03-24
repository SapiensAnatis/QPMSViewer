using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDFViewer.ViewModel
{
    public class DelegateCommand : ICommand
    { 
        // For binding purposes
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action; // Define action
        }

        public void Execute(object parameter)
        {
            _action(); // Perform action
        }

        public bool CanExecute(object parameter)
        {
            return true; // Don't gray out buttons it's dumb
        }

        public event EventHandler CanExecuteChanged;
    }
}
