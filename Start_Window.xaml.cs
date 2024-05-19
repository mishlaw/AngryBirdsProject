using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;


namespace AngryBirdsProject
{
    
    public partial class Start_Window
    {
       private void Button_Start_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        
            string def_velocity = start_velocity.Text;
            def_velocity=string.IsNullOrWhiteSpace(def_velocity) ? "80" : def_velocity;
            string def_corner = Corner.Text;
            def_corner = string.IsNullOrWhiteSpace(def_corner) ? "30" : def_corner;
            string def_mass = Mass.Text;
            def_mass = string.IsNullOrWhiteSpace(def_mass) ? "5" : def_mass;
            string def_x=Barrier_x.Text;
            def_x = string.IsNullOrEmpty(def_x) ? "250" : def_x;
            string def_y=Barrier_y.Text;
            def_y=string.IsNullOrEmpty(def_y) ? "300" : def_y;

            double velocity = Convert.ToDouble(def_velocity);
            double corner = Convert.ToDouble(def_corner);
            double mass = Convert.ToDouble(def_mass);
            double x = Convert.ToDouble(def_x);
            double y = Convert.ToDouble(def_y);
            Bird bird = new Bird(velocity, corner, mass);
            Barrier barrier = new Barrier(x, y);

           

            MainWindow mainWindow = new MainWindow(bird, barrier);
            mainWindow.Show();

        
           

         }
    }
}
