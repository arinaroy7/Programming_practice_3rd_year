using System;
using System.Collections;
using System.Collections.Generic;

public class GenericQueue<T> : IEnumerable<T> {
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

    public IEnumerator<T> GetEnumerator() {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}