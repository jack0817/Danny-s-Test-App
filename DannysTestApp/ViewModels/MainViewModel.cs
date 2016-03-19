using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name; 
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.NotifyProperyChanged();
            }
        }

        public MainViewModel()
        {
            this.Name = "Main View";
        }
        protected void NotifyProperyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged == null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
