// Интерфейсы 
using System.Linq;  // для сортивровки 
var items = new Item[] // массив 
{
    new Item() { Name = "Меч", cost = 100},
    new Item() { Name = "Шлем", cost = 10},
    new Item() { Name = "Бриллиант", cost = 100500},
};

var sortedItems = items.Order(); // Функция сортировка 

foreach(var i in sortedItems)
    Console.WriteLine($"{i.Name} {i.Cost}");

// 06.12.24 Работа на паре

Console.WriteLine(s.ToUpper()); //все символы заглавные 
Console.WriteLine(s.ToLower()); //все символы строчные
Console.WriteLine(ToWave(s)); //ВсЕ сИмВоЛы ТаК
Console.WriteLine(s.ToUpperFirstLetter()); //
Console.WriteLine(s.ToWave().Decorate("xxx")); //