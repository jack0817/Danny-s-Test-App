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
        public Func<bool> CanExecutionFunction { get; set; }

        public ButtonCommand(Action executeAction, Func<bool> canExecuteFunction = null)
        {
            this.ExecuteAction = executeAction;
            this.CanExecutionFunction = canExecuteFunction;
        }

        public bool CanExecute(object parameter)
        {
            if(this.CanExecutionFunction == null)
                return true;

            return this.CanExecutionFunction();
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
                return;

            this.ExecuteAction();
        }

        public void FireCanExecuteChanged()
        {
            if (this.CanExecuteChanged == null)
                return;

            this.CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
