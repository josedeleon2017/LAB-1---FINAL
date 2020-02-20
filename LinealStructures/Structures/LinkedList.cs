using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinealStructures.Structures
{
    public class LinkedList<T> : Interfaces.ILinearDataStructure<T>, IEnumerable<T> where T : IComparable
    {
        static Node<T> Head { get; set; }
        static int Count;

        
        public void Insert(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
                Count++;
                return;
            }
            var node = new Node<T>(value);
            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
            Count++;
        }


        public T Get(int position)
        {
            var current = Head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public void Delete(T value)
        {
            var current = Head;
            if (Find(value))
            {
                if (current.Value.CompareTo(value)==0)
                {
                    Head = Head.Next;
                    current = null;
                    Count--;
                }
                else
                {
                    while (current.Value.CompareTo(value)!=0)
                    {
                        current = current.Next;
                    }
                    var aux = Head;
                    while (aux.Next != current)
                    {
                        aux = aux.Next;
                    }
                    aux.Next =current.Next;
                    Count--;
                }
            }
        }

        public bool Find(T value)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.CompareTo(value)==0)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      
    }
}
