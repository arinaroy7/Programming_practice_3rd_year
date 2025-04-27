// Метод Ньютона для приближенного вычисления квадратного корня из числа
using System;

class Program {
    static void Main(string[] args) {
        var a = double.Parse(Console.ReadLine());
        var iterations = double.Parse(Console.ReadLine());
        double x = 0;

        for (int i=0; i<a; i++) {
            if (Math.Abs(iterations - x) > 0.001) {
                x = 0.5*(iterations + a/iterations);
            }
            else {
                break;
            }
        }
        Console.WriteLine(Math.Round(x, 3));
    }
}