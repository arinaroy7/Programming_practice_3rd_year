// для класса, реализующего очередь добавить интерфейс IEnumerable, чтобы можно было вывести на экран содержимое очереди через foreach
class Queue {
    static void Main() {
        var stringQueue = new GenericQueue<string>();
        stringQueue.Enqueue("Circle");
        stringQueue.Enqueue("Triangle");
        stringQueue.Enqueue("Square");

        Console.WriteLine("Все элементы очереди: ");
        Console.WriteLine();
        foreach (var shape in stringQueue) {
            Console.WriteLine(shape);
        }

        Console.WriteLine();
        Console.WriteLine("Первая фигура: " + stringQueue.Peek());
        Console.WriteLine();
        Console.WriteLine("Удаление  и извлечение первого эл из очереди: " + stringQueue.Dequeue());
        Console.WriteLine("Удаление и извлечение первого эл из оставшейся очереди: " + stringQueue.Dequeue());

        var intQueue = new GenericQueue<int>();
        intQueue.Enqueue(1);
        intQueue.Enqueue(20);
        intQueue.Enqueue(300);

        Console.WriteLine();
        Console.WriteLine("Все элементы очереди: ");
        Console.WriteLine();
        foreach (var number in intQueue)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();
        Console.WriteLine("Первый элемент: " + intQueue.Peek());
        Console.WriteLine();
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