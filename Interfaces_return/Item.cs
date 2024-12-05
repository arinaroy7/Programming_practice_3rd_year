using System;
using System.Linq; 
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
    public double cost { get; set; }
    public double WeightGram { get; set; }
    public string Name { get; set;}
    public List<Item> Items { get; set;} = new List<Item>(); // коллекция предметов к шкафу
    
    public decimal GetCost() {
        decimal itemsCost = Items.Sum(item => item.GetCost());
        return itemsCost + (decimal)cost;
    }
    public double GetWeight() {
        double itemsWeight = Items.Sum(item => item.GetWeight());
        return itemsWeight + WeightGram;
    }

    public string GetName() {
        return Name; 
    }
}