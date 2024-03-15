using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ProjectStations.ViewModel
{
    public class ViewModelProjectEmissoras : INotifyPropertyChanged
    {
        public void ThreadUI(Action acao)
        {
            Application.Current.MainWindow.Dispatcher.Invoke(acao);
        }

        public void ThreadUIAsync(Action acao, DispatcherPriority prioridade)
        {
            Application.Current.MainWindow.Dispatcher.BeginInvoke(acao, prioridade);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public DelegateCommand(Action<T> execute)
            : this(execute, x => true)
        {
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (canExecute == null) throw new ArgumentNullException("canExecute");
            if (execute == null) throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
