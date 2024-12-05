// ДЗ: реализ пару интферфейсов, которые возвращают свойство предметов, например стоимость, вес. 
// Интерфейс, который позв узнать стоимость и вес + реализ несколько эл самых разных, меч - вес, цена; бутылка - вес, цена 
// Задания со * сундук, внутри которого лежат предметы и его вес будет склад из веса сундука и пред, которые в нем лежат
// Класс персонаж с предметами в инвентаре, экипировка, который тоже реализ интерфейс -> узнать стоимость предметов и вес 
// + есть коллекция со всеми предметами, пробежаться по ней и посчитать суммарную стоимость в конце 
// Пусть у интерфейса будет 1 метод, который возвр вес 

public class Wardrobe {
    public static void Main() {
        var items = new Item[] {
            new Item() { Name = "Блузка", cost = 400, WeightGram = 80 },
            new Item() { Name = "Брюки", cost = 1000, WeightGram = 170 },
            new Item() { Name = "Свитер", cost = 1200, WeightGram = 300 },
            new Item() { Name = "Куртка", cost = 2000, WeightGram = 500},  
        };

        var wardrobe = new Wardrobe[] {
            cost = 10000, 
            weightGram = 30000},
            Items = items.ToList();
        };

        var totalCost = items.Sum(item => item.GetCost()); 
        var totalWeight = items.Sum(item => item.GetWeight());
        var totalName = string.Join(",", items.Select( item => item.GetName()));

        Console.WriteLine("Общая стоимость одежды: " + totalCost + " рублей");
        Console.WriteLine("Общий вес одежды: " + totalWeight + " кг");
        Console.WriteLine("В шкафу есть одежда: " + totalName);
    }
}

