using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

class Program {
    static void Main(string[] args) {
        _calcFunction();

        static void _calcFunction() {
            // Инициализация формы и графика
            var form = new Form();
            form.Text = "График x(t)";
            form.Width = 800;
            form.Height = 600;

            var plotModel = new PlotModel { Title = "Функция x(t)" };
            var series = new LineSeries();

            double maxValueX = double.MinValue;
            double maxValueT = 0;

            for (double t = -2; t <= 2; t += 0.1) {
                double x = (t > -1 && t < 1) ? Math.Exp(1 / (t * t - 1)) : 0;

                Console.WriteLine($" t = {t:F3}, x(t) = {x:F6}");

                if (x > maxValueX) {
                    maxValueX = x;
                    maxValueT = t;
                }

                // Добавляем точку на график
                series.Points.Add(new DataPoint(t, x));
            }

            Console.WriteLine($"Максимальное значение: х = {maxValueX:F6}, при t = {maxValueT:F6}");

            // Добавляем график в модель и отображаем
            plotModel.Series.Add(series);
            var plotView = new PlotView {
                Dock = DockStyle.Fill,
                Model = plotModel
            };
            form.Controls.Add(plotView);
            Application.Run(form); // Показываем форму
        }
    }
}
