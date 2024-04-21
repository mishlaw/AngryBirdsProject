using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;



namespace AngryBirdsProject
{
    public partial class MainWindow : Window
    {
        public Bird ptichka;
        public Barrier beam;

        public MainWindow(Bird bird, Barrier barrier)
        {
            InitializeComponent();
            this.ptichka = bird;
            this.beam = barrier;
        }

        DispatcherTimer timer = new DispatcherTimer();
        int k = 0;
        private void Bird_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            // создаем таймер
            
            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            timer.Tick += timer_tick;
            

            ptichka.Calculate(36, 172, beam);
            ptichka.Write("file.txt");
            
            
            timer.Start();



        }

        private void timer_tick(object sender, object e)
        {
            int i = ptichka.Points.Count;
            Canvas.SetTop(red_bird,  ( 600 - (ptichka.Points[k].y)));
            Canvas.SetLeft(red_bird,   36 + (ptichka.Points[k].x));
            
            k++;
            if (k== i) {
                
                timer.Stop(); }

        }

        
           
        
    }
}


    

    
            


        
 

    

