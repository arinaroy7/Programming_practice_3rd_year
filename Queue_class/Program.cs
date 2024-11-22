using System;  //очередь должна добавлять и извлекать любые типы данных
using System.Collections.Generic; //тип Т может заменяться любым указанным типом данных

public class GenericQueue<T> {
    private LinkedList<T> items = new LinkedList<T>();

    public void Enqueue(T item) { //доб эл T items в конец очереди
        items.AddLast(item); 
    }

    public T Dequeue() { // удал и возвр эл в конец очереди
        if (IsEmpty()) {
            throw new InvalidOperationException("В очереди ничего нет");
        }
        T value = items.First.Value;
        items.RemoveFirst();
        return value;
    }

    public T Peek() {
        if (IsEmpty()) {
            throw new InvalidOperationException("Очередь пуста");
        }
        return items.First.Value;
    }

    public bool IsEmpty() {
        return items.Count == 0;
    }

    public int Count {
        get { return items.Count;} // получ колич эл в очереди 
    }
}
class Queue {
    static void Main() {
        var stringQueue = new GenericQueue<string>();
        stringQueue.Enqueue("Circle");
        stringQueue.Enqueue("Triangle");
        stringQueue.Enqueue("Square");

        Console.WriteLine("Первая фигура: " + stringQueue.Peek());
        Console.WriteLine("Удаление  и извлечение первого эл из очереди: " + stringQueue.Dequeue());
        Console.WriteLine("Удаление и извлечение первого эл из оставшейся очереди: " + stringQueue.Dequeue());

        var intQueue = new GenericQueue<int>();
        intQueue.Enqueue(1);
        intQueue.Enqueue(10);
        intQueue.Enqueue(100);

        Console.WriteLine("Первый элемент: " + intQueue.Peek());
        Console.WriteLine("Удаление и извлечение первого эл из очереди: " + intQueue.Dequeue());
        Console.WriteLine("Удаление и извлечение первого эл из оставшейся очереди: " + intQueue.Dequeue());

        try {
            intQueue.Dequeue();
        }
        catch (Exception ex) {
            Console.WriteLine("Очередь пуста " + ex.Message);
        }
    }
}
