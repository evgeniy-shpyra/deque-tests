using System;
using System.Collections;
using System.Collections.Generic;


namespace Lib
{
    internal class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }



    public class CustomDeque<T> : IEnumerable<T>
    {

        public event Action<T> ElementAdded;
        public event Action<T> ElementRemoved;
        public event Action Cleared;

        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;

        public CustomDeque()
        {
        }


        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;

            ElementAdded?.Invoke(data);
        }
        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;

            ElementAdded?.Invoke(data);
        }

        public T RemoveLast()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Неможливо видалити елемент. Дек порожній.");
            }

            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;

            ElementRemoved?.Invoke(output);

            return output;
        }
        public T RemoveFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Неможливо видалити елемент. Дек порожній.");
            }
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;

            ElementRemoved?.Invoke(output);

            return output;
        }

        public int Count { get { return count; } }
        public T First { get { return head.Data; } }
        public T Last { get { return tail.Data; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;

            Cleared?.Invoke();
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public bool IsEmpty { get { return count == 0; } }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}
