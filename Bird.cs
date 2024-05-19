using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AngryBirdsProject
{
    public class Description_of_point
    {

        public double x;
        public double y;
        public double Vx;
        public double Vy;

        public Description_of_point(double x, double y, double Vx, double Vy)
        {
            this.x = x;
            this.y = y;
            this.Vx = Vx;
            this.Vy = Vy;
        }
    }
    public class Barrier
    {
        public double distance, height;
        public Barrier(double distance, double height)
        {
            this.distance = distance;
            this.height = height;
        }
        public bool Collision(double x, double y)
        {
            double dist_l = distance - 35-36;
            double dist_r = distance + 5 ;
            if (((x >= dist_l) && (x <= dist_r)))
            {
                if (y <= height)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
             return false;
            
        }
    }
    public class Bird
    {
        readonly double V0;
        readonly double alpha;
        readonly double m;
        readonly double g = 9.8;
        public List<Description_of_point> Points = new List<Description_of_point> { };
        double partition = 50;
        double k = 1 / 10;

        public Bird(double V0, double alpha, double m)
        {
            this.V0 = V0;
            this.alpha = alpha;
            this.m = m;
        }

        public Description_of_point Position(List<Description_of_point> Points, Int32 i, double dt, double m, double k, Barrier barrier)
        {

            
                double x = Points[i - 1].x + dt * Points[i - 1].Vx;
                double y = Points[i - 1].y + dt * Points[i - 1].Vy;

                double Vx = Points[i - 1].Vx - k * dt * Points[i - 1].Vx / m;
                double Vy = Points[i - 1].Vy - dt * (g + k * Points[i - 1].Vy / m);
                if (barrier.Collision(x, y))
                {
                return new Description_of_point(-1, -1, 0, 0);

                }
                return new Description_of_point(x, y, Vx, Vy);
            


        }

        public void Calculate(double x0, double y0, Barrier barrier)
        {
            double t = 0;
            double T = 2 * V0 * Math.Sin(alpha * Math.PI / 180) / g;
            double dt = Math.Abs(T / partition);


            Description_of_point point = new Description_of_point(x0, y0, V0 * Math.Cos(alpha * Math.PI / 180), V0 * Math.Sin(alpha * Math.PI / 180));
            Points.Add(point);
            t += dt;
            Int32 i = 1;
            double k = 1 / 10;

            while (t <= T)
            {
                Description_of_point position = Position(Points, i, dt, m, k, barrier);
                if (position.x != -1)
                {
                    Points.Add(position);
                }
                else
                {
                    //MessageBox.Show("Произошло столкновение", "Конец", MessageBoxButton.OK);
                    Points.Add(position);
                    break;
                }
                t += dt;
                i += 1;
            }
            if (t > T)
            {
                MessageBox.Show($"Птичка упала в {Points.Last().x}", "Полет завершен", MessageBoxButton.OK);
            }
        }
        public void Read(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string s;

                while (((s = sr.ReadLine()) != null))
                {
                    string[] subs = s.Split();

                    if (!double.TryParse(subs[0], out double X))
                    {
                        return;
                    }

                    if (!double.TryParse(subs[1], out double Y))
                    {
                        return;
                    }

                    Description_of_point p = new Description_of_point(X, Y, 0, 0);
                    Points.Add(p);
                }
            }
        }
        public async void Write(string path)
        {
            using (StreamWriter outputFile = new StreamWriter(path, false))
            {
                foreach (Description_of_point p in Points)
                {
                    await outputFile.WriteLineAsync($"{p.x}, {p.y}");
                }
            }

        }


    }
}
