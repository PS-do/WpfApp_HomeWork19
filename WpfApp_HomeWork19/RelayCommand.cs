using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp_HomeWork19
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecut;
        public event EventHandler CanExecuteChanged // событие срабатывающее когда состояние команды могло быть изменено
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecut = null)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecut = CanExecut;
        }
        public bool CanExecute(object parameter) => canExecut?.Invoke(parameter) ?? true; // проверяет доступность комманды
        public void Execute(object parameter) => execute(parameter); // выполняемая команда

    }
}
