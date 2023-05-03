using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMvvm.ViewModels;
using WpfMvvm.Views;

namespace WpfMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            ((MainWindowVM)DataContext).ShowWindowEvent += MainWindow_ShowWindowEvent;
            ((MainWindowVM)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }

        private void MainWindow_ShowMessageEvent(string message)
        {
            MessageBox.Show(message);
        }

        private void MainWindow_ShowWindowEvent()
        {
            (new AdditionalWindow()).ShowDialog();
        }
    }
}
