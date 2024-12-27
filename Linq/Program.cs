// 5 практика дз
// ДЗ: поэксперементировать с линк запросами. Создать массив содерж
// строки и остав строки, которые только длиннее трех символов. Привести к верхнему регистру и отсорт по алфавиту 
//where будет передано проверка на длину strign to upper
//почитать про Linq 

using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] data = { "мышь", "компьютер", "телефон", "принтер", "камера", "монитор" };

        Console.WriteLine("Исходный массив:");
        Console.WriteLine(string.Join(", ", data));

        var result = data
            .Where(s => s.Length > 3)
            .Select(s => s.ToUpper())
            .OrderBy(s => s);

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(string.Join(", ", result));
    }
}