// для класса, реализующего очередь (в прошлый раз делали) добавить интерфейс IEnumerable, чтобы можно было вывести на экран содержимое очереди через foreach
using System;
using System.Linq;
public class Program {
    public static void Main() {
        var items = new Item[] {
            new Item() { Name = " Блузка ", cost = 400, WeightGram = 80 },
            new Item() { Name = " Брюки ", cost = 1000, WeightGram = 170 },
            new Item() { Name = " Свитер ", cost = 1200, WeightGram = 300 },
            new Item() { Name = " Куртка ", cost = 2000, WeightGram = 500},  
        };

        var wardrobe = new Wardrobe {
            cost = 10000, 
            weightGram = 30000,
            Items = items.ToList(),
        };

        var totalCost = items.Sum(item => item.GetCost());
        var totalCostWardrobe = items.Sum(item => item.GetCost()) + wardrobe.cost;
        var totalWeight = items.Sum(item => item.GetWeight()); 
        var totalWeightWardrobe = items.Sum(item => item.GetWeight()) + wardrobe.weightGram;
        var totalName = string.Join(",", items.Select( item => item.GetName()));

        Console.WriteLine("Общая стоимость одежды: " + totalCost + " рублей");
        Console.WriteLine("Общая стоимость одежды со шкафом: " + totalCostWardrobe + " рублей");
        Console.WriteLine();
        Console.WriteLine("Общий вес одежды: " + totalWeight + " кг");
        Console.WriteLine("Общий вес одежды со шкафом: " + totalWeightWardrobe + " кг");
        Console.WriteLine();
        Console.WriteLine("В шкафу лежат вещи: " + totalName);
    }
}