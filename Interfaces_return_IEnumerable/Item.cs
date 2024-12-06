using System.Collections.Generic;

public interface IValuable {
    decimal GetCost();
}

public interface IWeighable {
    double GetWeight();
}

public interface INameable {
    string GetName();
}

public class Item: IValuable, IWeighable, INameable  { 
    public decimal cost { get; set; }
    public double WeightGram { get; set; }
    public string? Name { get; set;}
    public List<Item> Items { get; set;} = new List<Item>(); // коллекция предметов к шкафу
    
    public decimal GetCost() {
        decimal itemsCost = Items.Sum(item => item.GetCost());
        return itemsCost + cost;
    }
    public double GetWeight() {
        double itemsWeight = Items.Sum(item => item.GetWeight());
        return itemsWeight + WeightGram;
    }

    public string GetName() {
        return Name; 
    }
}

public class Wardrobe {
    public decimal cost { get; set; }
    public double weightGram { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
}