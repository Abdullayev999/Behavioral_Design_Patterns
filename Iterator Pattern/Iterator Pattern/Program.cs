using System;
using System.Collections;

namespace Iterator_Pattern
{
    class MyIntCollection : IEnumerable
    {
        private int[] array;

        public MyIntCollection(params int[] numbers)
        {
            array = numbers;
        }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyIntCollectionReverseEnumerator(this.array);
        }
    }

    class MyIntCollectionEnumerator : IEnumerator
    {
        public object Current { get; set; }
        private int position = -1;
        private readonly int[] array;

        public MyIntCollectionEnumerator(int[] array)
        {
            this.array = array;
        }

        public bool MoveNext()
        {
            position++;
            if (position < array.Length)
            {
                Current = array[position];
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }

    class MyIntCollectionReverseEnumerator : IEnumerator
    {
        public object Current { get; set; }
        private int position;
        private readonly int[] array;

        public MyIntCollectionReverseEnumerator(int[] array)
        {
            this.array = array;
            position = array.Length;
        }

        public bool MoveNext()
        {
            position--;
            if (position >= 0)
            {
                Current = array[position];
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = array.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var coll = new MyIntCollection(11, 22, 33, 44, 55);
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }

            //var coll = new MyIntCollection(11, 22, 33, 44, 55);
            //var enumerator = coll.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    var item = enumerator.Current;
            //    Console.WriteLine(item);
            //}
            //enumerator.Reset();
        }
    }
}
