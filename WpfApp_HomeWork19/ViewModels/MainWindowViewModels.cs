using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp_HomeWork19.Models;
using WpfApp_HomeWork19.Models.WpfApp_Les19.Models;

namespace WpfApp_HomeWork19.ViewModels
{
    internal class MainWindowViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)// [CallerMemberName] - позволяет не передавать в качестве аргумента строку имени свойства, и подставит, в этом случае, имя вызвавшего свойства
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int number1;
        public int Number1
        {
            get { return number1; }
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }

        private int number2;
        public int Number2
        {
            get { return number2; }
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

        private double number3;
        public double Number3
        {
            get { return number3; }
            set
            {
                number3 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAdCommandExecute(object p)
        {
            Number3 = Ariph.LRound(Number1);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (number1 != 0) return true;
            else return false;
        }
        public MainWindowViewModels()
        {
            AddCommand = new RelayCommand(OnAdCommandExecute, CanAddCommandExecuted);
        }

    }
}
