using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    internal class MainWindowVM
    {
        public delegate void ShowWindow();
        public event ShowWindow? ShowWindowEvent;
        public delegate void ShowMessage(string message);
        public event ShowMessage? ShowMessageEvent;

        public ICommand ShowMessageCommand { get; }
        public ICommand ShowWindowCommand { get; }

        public MainWindowVM()
        {
            ShowMessageCommand = new ShowMessageCommandRealisation(this);
            ShowWindowCommand = new ShowWindowCommandRealisation(this);
        }

        private class ShowMessageCommandRealisation : ICommand
        {
            private MainWindowVM mainWindowVM;
            public ShowMessageCommandRealisation(MainWindowVM mainWindowVM)
            {
                this.mainWindowVM = mainWindowVM;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => true;

            public void Execute(object? parameter) => mainWindowVM.ShowMessageEvent?.Invoke("test");
        }

        private class ShowWindowCommandRealisation : ICommand
        {
            private MainWindowVM mainWindowVM;
            public ShowWindowCommandRealisation(MainWindowVM mainWindowVM)
            {
                this.mainWindowVM = mainWindowVM;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => true;
            public void Execute(object? parameter) => mainWindowVM.ShowWindowEvent?.Invoke();
            
        }
    }
}
