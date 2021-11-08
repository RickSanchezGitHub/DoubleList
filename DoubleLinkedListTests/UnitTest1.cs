using List;
using NUnit.Framework;

namespace DoubleLinkedListTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { }, new int[] { 4 }, 4)]
        [TestCase(new int[] { 3 }, new int[] { 3, 4 }, 4)]

        public void AddLastTests(int[] array, int[] expectedArray, int value)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddLast(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 }, 4)]
        [TestCase(new int[] { }, new int[] { 4 }, 4)]
        [TestCase(new int[] { 3 }, new int[] { 4, 3 }, 4)]
        [TestCase(new int[] { 2 }, new int[] { 4, 2 }, 4)]
        public void AddFirstTests(int[] array, int[] expectedArray, int value)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, int.MaxValue, new int[] { int.MaxValue, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -9, new int[] { 1, 2, 3, 4, -9, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -100, new int[] { -1, -2, -3, -4, -100, -5 })]
        [TestCase(new int[] { 1 }, 0, 0, new int[] { 0, 1 })]
        [TestCase(new int[] { }, 0, 0, new int[] { 0 })]
        public void AddAtTests(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddAt(index, value);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2, -3, -4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveLastTests(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 }, 2)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2 }, 3)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { }, 5)]

        public void RemoveLastTests(int[] array, int[] expArray, int n)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveLastMultiply(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -2, -3, -4, -5 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveFirstTests(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);

        }
       
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 }, 2)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -4, -5 }, 3)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { }, 5)]

        public void RemoveFirstMultipleTests(int[] array, int[] expArray, int quantity)            
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFirst(quantity);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2, -3, -4 }, 4)]
        [TestCase(new int[] { 1 }, new int[] { }, 0)]
        public void RemoveAtTests(int[] array, int[] expArray, int index)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveAt(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 }, 0, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { }, 0, 5)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2, -3, -4 }, 4, 1)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, new int[] { -1, -2 }, 2, 3)]
        [TestCase(new int[] { 1 }, new int[] { }, 0, 1)]
        public void RemoveAtTests(int[] array, int[] expArray, int index, int quantity)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveAtMultiple(index, quantity);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 4)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, -1, 0)]
        [TestCase(new int[] { 1 }, 1, 0)]
        public void IndexValueTest(int[] array, int value, int expected)
        {

            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.IndexOf(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 0, -1)]
        [TestCase(new int[] { 1 }, 0, 1)]
        public void GetTest(int[] array, int index, int expected)
        {

            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.Get(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void ReverseTests(int[] array, int[] expectedArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, int.MaxValue, new int[] { int.MaxValue, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 12, new int[] { 1, 2, 12, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, -19, new int[] { 1, 2, 3, -19, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -100, new int[] { -1, -2, -3, -4, -100 })]
        [TestCase(new int[] { 1 }, 0, 0, new int[] { 0 })]
        public void SetTest(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual[index] = value;
            Assert.AreEqual(expected, actual);
        }
       
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }, 17)]
        [TestCase(new int[] { 1, 111, 12, 13, 14, 15, 16, 17 }, 111)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }, 17)]
        [TestCase(new int[] { 1, 2, 32, 13, 14, 15, 16, 17 }, 32)]
        [TestCase(new int[] { 11, 12, 13, 1401, 15, 16, 17 }, 1401)]
        public void MaxTest(int[] array, int expected)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.Max();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, -8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }, -8)]
        [TestCase(new int[] { 1, 111, 12, -13, 14, 15, 16, 17 }, -13)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 11, 12, 13, 14, 15, 16, 17 }, 0)]
        [TestCase(new int[] { 1, 2, -32, 13, 14, 15, 16, 17 }, -32)]
        [TestCase(new int[] { 11, 12, 13, 1401, 15, 16, 17 }, 11)]


        public void MinTest(int[] array, int expected)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.Min();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }, 16)]
        [TestCase(new int[] { 1, 111, 12, 13, 14, 15, 16, 17 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 160, 17 }, 15)]
        [TestCase(new int[] { 1, 2, 32, 13, 14, 15, 16, 17 }, 2)]
        [TestCase(new int[] { 11, 12, 13, 1401, 15, 16, 17 }, 3)]


        public void IndexOfMaxTest(int[] array, int expected)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.IndexMax();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, -8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }, 7)]
        [TestCase(new int[] { 1, 111, 12, -13, 14, 15, 16, 17 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 11, 12, 13, 14, 15, 16, 17 }, 9)]
        [TestCase(new int[] { 1, 2, -32, 13, 14, 15, 16, 17 }, 2)]
        [TestCase(new int[] { 11, 12, 13, 1401, 15, 16, 17 }, 0)]

        public void IndexOfMinTest(int[] array, int expected)
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);
            int actual = doubleLinkedList.IndexMin();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 4, 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 9, 7, 6, 4, 3, 1, 8, 5, 2 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { -2, -4, -6, -8, -1, -3, -7, -9, -5 }, new int[] { -9, -8, -7, -6, -5, -4, -3, -2, -1 })]
        [TestCase(new int[] { int.MaxValue, 2, 3, int.MinValue }, new int[] { int.MinValue, 2, 3, int.MaxValue })]

        public void SortTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Sort();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 4, 1, 2, 3 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 9, 7, 6, 4, 3, 1, 8, 5, 2 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { -2, -4, -6, -8, -1, -3, -7, -9, -5 }, new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9 })]
        [TestCase(new int[] { int.MaxValue, 2, 3, int.MinValue }, new int[] { int.MaxValue, 3, 2, int.MinValue })]

        public void SortDescTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.SortDesc();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 4, 4, 2, 3, 1 }, new int[] { 4, 2, 3, 1 }, 4)]
        [TestCase(new int[] { 5, 8, 7, 9, 4, 6, 1, 4, 4, 4, 7, 8, 0 }, new int[] { 5, 8, 7, 9, 6, 1, 4, 4, 4, 7, 8, 0 }, 4)]
        [TestCase(new int[] { -2, -4, -6, -8, -1, -3, -8, -7, -9, -5 }, new int[] { -2, -4, -6, -1, -3, -8, -7, -9, -5 }, -8)]
        [TestCase(new int[] { 10, 25, int.MaxValue, 12, int.MaxValue, 2, 3, int.MinValue }, new int[] { 10, 25, 12, int.MaxValue, 2, 3, int.MinValue }, int.MaxValue)]

        public void RemoveFirstValTest(int[] array, int[] expectedArray, int value)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 4, 4, 2, 3, 1 }, new int[] { 2, 3, 1 }, 4)]
        [TestCase(new int[] { 5, 8, 7, 9, 4, 6, 1, 4, 4, 4, 7, 8, 0 }, new int[] { 5, 8, 7, 9, 6, 1, 7, 8, 0 }, 4)]
        [TestCase(new int[] { -2, 2, 1, 4, 5, 6, 6, 6, 8, 7, 8, 9, 6, 6, 6, 0 }, new int[] { -2, 2, 1, 4, 5, 8, 7, 8, 9, 0 }, 6)]
        [TestCase(new int[] { 10, 25, int.MaxValue, 12, int.MaxValue, 2, 3, int.MinValue }, new int[] { 10, 25, 12, 2, 3, int.MinValue }, int.MaxValue)]
        public void RemoveAllTest(int[] array, int[] expectedArray, int value)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveAll(value);
            Assert.AreEqual(expected, actual);
        }
    }
}