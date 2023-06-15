using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;





// RelayCommand tworzy polecenia do przypisania interfejsu - przyciski, menu


namespace Kurier.Utilities
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;           // parametr od wykonania akcji 
        private readonly Func<object, bool> _canExecute; // sprawdzenie czy dane polecenie może być wykonane w danym momencie

        public event EventHandler CanExecuteChanged             // zdarzenie CanExecuteChanged jest wywoływane przy zmianie możliwości wykonania polecenia
        {
            add                                                 // odświeżanie stanu możliwości poleceń w odpowiedzi na ruchy użytkownika 
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)       // konstruktor
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);         // sprawdzenie czy polecenie może być wywołane w danym momencie 
        public void Execute(object parameter) => _execute(parameter);                    // metoda z interfejsu ICommand wywołuje akcję przekazaną do
                                                                                         // konstruktora, przekazując parametr do metody execute
    }
}
