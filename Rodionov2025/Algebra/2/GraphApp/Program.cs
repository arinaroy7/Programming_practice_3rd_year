// Функция на Берлин!
using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

class Program {
    static void Main(string[] args) {
        _calcFunction();
        
        static void _calcFunction() {
         
            var form = new Form();
            form.Text = "График функции х(t)";
            form.Width = 800;
            form.Height = 600;

            var plotModel = new PlotModel { Title = "Функция x(t)" };
            var series = new LineSeries();

            double maxValueX = double.MinValue; //изначально очень маленькое значение
            double maxValueT = 0;
            
            for (double t = -2; t<=2; t+=0.1) {
                double e = Math.E;
                double x = 0;

                if (t < 1 && t > -1) {
                    x = Math.Exp(1/(t*t-1));
                }
                else {
                    x=0;
                }
                Console.WriteLine($" t = {t:F3}, x(t) = {x:F6}");

                if (x > maxValueX) {
                    maxValueX = x;
                    maxValueT = t;
                }
                series.Points.Add(new DataPoint(t, x)); 
            }
            Console.WriteLine($"Максимальное значение: х = {maxValueX:F6}, при t = {maxValueT:F6}");
            
            plotModel.Series.Add(series); //Добавляем график в модель и отображаем
            var plotView = new PlotView {
                Dock = DockStyle.Fill,
                Model = plotModel
            };
            form.Controls.Add(plotView);
            Application.Run(form); //Отображение графика
        }
    }
}
