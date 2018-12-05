using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SeaBattleship.BasicTypes;

namespace SeaBattleship
{
    //модель представления для главной формы сервера
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            StartButtonEnabled = true;
            StopButtonEnabled = false;
            model = new ServerModel();
        }
        public bool StartButtonEnabled { get; set; }
        public bool StopButtonEnabled { get; set; }
        public string LogText { get; set; }
        public ICommand StartCommand
        {
            get
            {

                StartButtonEnabled = false;
                StopButtonEnabled = true;
                return _startCommand ?? (_startCommand = new RelayCommand((@object) =>
                {
                    LogText += "Сервер запущен.\n";
                    model.StartServer();
                    OnPropertyChanged("LogText");
                }));
            }
        }
        public ICommand StopCommand
        {
            get
            {
                StartButtonEnabled = true;
                StopButtonEnabled = false;
                return _startCommand ?? (_stopCommand = new RelayCommand((@object) =>
                {
                    LogText += "Сервер остановлен.\n";
                    model.StopServer();
                    OnPropertyChanged("LogText");
                }));
            }
        }
        private ICommand _startCommand;
        private ICommand _stopCommand;
        private ServerModel model;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
