using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DannysTestApp.Commands
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action ExecuteAction { get; set; }

        public ButtonCommand(Action executeAction)
        {
            this.ExecuteAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
                return;

            this.ExecuteAction();
        }
    }
}
