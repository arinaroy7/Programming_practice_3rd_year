class Item: IComparable {
    public string Name;

    public int Cost;

    public int CompareTo(object? obj) {
        var secondItem = (Item) obj;
        // ...
    }
}