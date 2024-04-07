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
            double mass = Convert.ToDouble(Mass.Text);
            double x = Convert.ToDouble(Barrier_x.Text);
            double y = Convert.ToDouble(Barrier_y.Text);
            Bird bird = new Bird(velocity, corner, mass);
            Barrier barrier = new Barrier(x, y);
            bird.Calculate(1,1, barrier);
            bird.Write("C:\\Users\\Пользователь\\source\\repos\\test_angrybirds\\file.txt");
        

         }
    }
}
