// Метод последовательных приближений  при 0.5 получаем 0.7

using System;

class Program {
    static void Main(string[] args) {
        double E = 0.0001;
        double x = 0;
        double iterations = 0;

        Console.Write("Введите значение коэффициента c (-1 < c < 1): ");

        if (double.TryParse(Console.ReadLine(), out double c)) {
            if (c > -1 && c < 1) {
                _check(ref x, ref iterations, E, c);

                Console.WriteLine($"\nТочка х имеет значение: x = {x:F4}, выполнено итераций: {iterations}");
            } else {
                Console.WriteLine("Вы ввели недопустимое значение для коэффициента c. Попробуйте снова.");
            }

            } else {
                Console.WriteLine("Ошибка: некорректный ввод.");
            }
        } 

    static void _check(ref double x, ref double iterations, double E, double c) {
        double newX = 0;

        do {
            x = newX;
            newX = Math.Cos(c * x);
            iterations++;
        } while (Math.Abs(newX - x) > E);

        x = newX;
    }
}