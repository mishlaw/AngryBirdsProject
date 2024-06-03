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

    public partial class MainWindow : Window  //Главное окно игры
    {
        public Bird ptichka;
        public Barrier beam;


        public MainWindow(Bird bird, Barrier barrier)
        {
            InitializeComponent();
            this.ptichka = bird;
            this.beam = barrier;
            // Создаем на экране фигуру, которая будет нашим барьером
            Rectangle rectangle = new Rectangle
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Red,
                Width = 30,  // желаемая ширина фигуры
                Height = beam.height  // желаемая высота фигуры
            };

            // Добавьте прямоугольник на canvas
            MainCanvas.Children.Add(rectangle);

            // Задайте расположение прямоугольника
            Canvas.SetLeft(rectangle, beam.distance + 36);
            Canvas.SetTop(rectangle, 600 - beam.height - 80);

        }

        //Анимация тряски экрана
        private async Task PerformTaskWithDelay()
        {
            // Действие 1
            // ... ваш код здесь ...
            Storyboard shakeAnimation = this.Resources["ShakeAnimation"] as Storyboard;

            // Установите элемент, к которому будет применяться анимация, как цель
            Storyboard.SetTarget(shakeAnimation, this);

            // Запустите анимацию
            shakeAnimation.Begin();

            // Ожидание задержки в 2 секунды
            await Task.Delay(1000);

            // Действие 2
            // ... ваш код здесь ...
            Finally gameover = new Finally();
            gameover.Show();
        }
        
    
        

        DispatcherTimer timer = new DispatcherTimer(); //Таймер для анимации
        int k = 0;
        private void Bird_MouseDown(object sender, MouseButtonEventArgs e) //Обработчик события нажатия на птичку
        {
            

            // создаем таймер
            
            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            timer.Tick += timer_tick;
            

            ptichka.Calculate(36, 172, beam); // Расчитываем координаты полета
            ptichka.Write("file.txt"); //Записываем коорлинаты в файл
            
            
            timer.Start();



        }
      
        private async void timer_tick(object sender, object e) //Анимация
        {
            int i = ptichka.Points.Count;
            if (ptichka.Points[k].x != -1)
            {
                Canvas.SetTop(red_bird, (600 - (ptichka.Points[k].y)));
                Canvas.SetLeft(red_bird, 36 + (ptichka.Points[k].x));
            } 
            else
            {
                timer.Stop();

                await PerformTaskWithDelay();

              


            }
            
            k++;
            if (k== i) {
                
                timer.Stop(); }

        }

        
           
        
    }
}


    

    
            


        
 

    

