using List;
using System;


namespace EntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList doubleList = new DoubleLinkedList(new int[] { 3, 2, 1, 4, 5, 6 });
            doubleList.AddFirst(2);
        }
    }
}
