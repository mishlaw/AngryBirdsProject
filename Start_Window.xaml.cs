using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;


namespace AngryBirdsProject
{
    
    public partial class Start_Window
    {
       private void Button_Start_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            double velocity = Convert.ToDouble(start_velocity.Text);
            double corner = Convert.ToDouble(Corner.Text);
            double mass = 10;
            Bird bird = new Bird(velocity, corner, mass);
            bird.Calculate(1,1);
            bird.Write("C:\\Users\\Пользователь\\source\\repos\\AngryBirdsProject\\file.txt");
            MessageBox.Show("Начало движения", "Сообщение", MessageBoxButton.OKCancel);
         }
    }
}
