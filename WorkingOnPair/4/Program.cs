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