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
using System.Windows.Shapes;

namespace AngryBirdsProject
{
    /// <summary>
    /// Логика взаимодействия для Finally.xaml
    /// </summary>
    public partial class Finally : Window
    {
        public Finally()
        {
            InitializeComponent();
        }
        private void RestartButton (object sender, RoutedEventArgs e)
        {
            // Запустить новый экземпляр приложения
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);

            // Выполнить выход из текущего приложения
            Application.Current.Shutdown();
        }

        private void ExitButton (object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
    }
}
