using System;

namespace List
{
    public class DoubleLinkedList
    {
        private L2Node _head;
        private L2Node _end;

        public DoubleLinkedList()
        {
            _head = null;
            _end = null;
        }
        public DoubleLinkedList(int a)
        {
            _head = new L2Node(a);
            _end = _head;
        }
        public DoubleLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _head = new L2Node(array[0]);
                L2Node tmp = _head;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new L2Node(array[i]);
                    tmp.Next.Previous = tmp;
                    tmp = tmp.Next;
                }
                _end = tmp;
            }
            else
            {
                _head = null;
                _end = null;
            }
        }
        public int GetLength()
        {

            L2Node current = _head;
            int length = 1;
            if (current == null)
            {
                return 0;
            }

                while (current.Next != null)
                {
                    current = current.Next;
                    length++;
                }
                return length;
        }
        public int[] ToArray()
        {
            int[] array = new int[GetLength()];
            L2Node current = _head;

            for (int i = 0; i <= array.Length - 1; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
        public DoubleLinkedList Clone()
        {
            DoubleLinkedList doublyLinkedList = new DoubleLinkedList();
            L2Node newCurrent = doublyLinkedList._head;
            int length = GetLength();
            L2Node current = _head;

            if (length != 0)
            {
                doublyLinkedList._head = new L2Node(current.Value);
                doublyLinkedList._end = doublyLinkedList._head;
                for (int i = 1; i < length; i++)
                {
                    current = current.Next;
                    doublyLinkedList._end.Next = new L2Node(current.Value);

                    doublyLinkedList._end = doublyLinkedList._end.Next;
                    doublyLinkedList._end.Previous = doublyLinkedList._head;
                }
            }
            else
            {
                doublyLinkedList._head = null;
                doublyLinkedList._end = null;
            }
            return doublyLinkedList;
        }
        public void AddFirst(int value)
        {
            int length = GetLength();
            if (length == 0)
            {
                _head = new L2Node(value);
                _end = _head;
            }
            else
            {
                _head.Previous = new L2Node(value);
                _head.Previous.Next = _head;
                _head = _head.Previous;
            }
        }
        public void AddFirst(DoubleLinkedList list)
        {
            DoubleLinkedList doublyLinkedList = list.Clone();
            L2Node current = doublyLinkedList._head;
            L2Node tmp;

            int length = doublyLinkedList.GetLength();
            if (length == 0)
            {

                return;
            }
            if (GetLength() == 0)
            {
                _head = current;
            }
            else
            {
                doublyLinkedList._end.Next = _head;
                tmp = current.Next;
                tmp.Previous = doublyLinkedList._head;
                _head = doublyLinkedList._head;
            }
        }
        public void AddAt(int index, int value)
        {
            int length = GetLength();

            if (index >= 0)
            {
                if (length == 0 || index >= length)
                {
                    AddLast(value);
                }
                else
                {
                    if (index == 0)
                    {
                        AddFirst(value);
                    }
                    else
                    {
                        if (index <= length / 2)
                        {
                            L2Node tmp = _head;
                            for (int i = 1; i < index; i++)
                            {
                                tmp = tmp.Next;
                            }
                            L2Node b = tmp.Next;
                            tmp.Next = new L2Node(value);
                            tmp.Next.Previous = tmp;
                            tmp = tmp.Next;
                            tmp.Next = b;
                            b.Previous = tmp;
                        }
                        else
                        {
                            L2Node tmp = _end;
                            for (int i = length - 1; i > index; i--)
                            {
                                tmp = tmp.Previous;
                            }
                            L2Node b = tmp.Previous;
                            tmp.Previous = new L2Node(value);
                            tmp.Previous.Next = tmp;
                            tmp = tmp.Previous;
                            tmp.Previous = b;
                            b.Next = tmp;
                        }
                    }
                }
            }
        }
        public void AddLast(int value)
        {
            if (GetLength() == 0)
            {
                _head = new L2Node(value);
                _end = _head;
            }
            else
            {
                _end.Next = new L2Node(value);
                _end.Next.Previous = _end;
                _end = _end.Next;
            }
        }

        public void AddLast(DoubleLinkedList list)
        {
            DoubleLinkedList cloneDoublyLinkedList = list.Clone();
            if (_head != null && cloneDoublyLinkedList._head != null)
            {
                _end.Next = cloneDoublyLinkedList._head;
                cloneDoublyLinkedList._head.Previous = _end;
                _end = cloneDoublyLinkedList._end;
            }
            else if (cloneDoublyLinkedList._head != null)
            {
                _head = cloneDoublyLinkedList._head;
            }
        }        
        
        public void RemoveFirst()
        {
            if (GetLength() != 0)
            {
                _head = _head.Next;
            }
            else
            {
                throw new Exception("Nothing to remove");
            }
        }
        public void RemoveLast()
        {
            int length = GetLength();
            if (length == 0)
            {
                throw new Exception("Nothing to remove");
            }
            if (length != 0)
            {
                if (length != 1)
                {
                    _end.Previous.Next = null;
                    _end = _end.Previous;
                }
                else
                {
                    _head = null;
                    _end = null;
                }
            }
        }
        public void RemoveLast(int n)
        {
            int length = GetLength();
            if (length == 0)
            {
                throw new Exception("Nothing to remove");
            }
            if (length != 0)
            {
                if (n < length)
                {
                    for (int i = 0; i < n; i++)
                    {
                        _end.Previous.Next = null;
                        _end = _end.Previous;
                    }
                }
                else
                {
                    _head = null;
                    _end = null;
                }
            }
        }
        public void RemoveAt(int index)
        {
            int length = GetLength();
            if (length != 0 && index >= 0 && length > index)
            {
                if (index == 0)
                {
                    RemoveFirst();
                }
                else if (index == length - 1)
                {
                    RemoveLast();
                }
                else
                {
                    if (index <= length / 2)
                    {
                        L2Node tmp = _head;
                        for (int i = 1; i < index; i++)
                        {
                            tmp = tmp.Next;
                        }
                        tmp.Next = tmp.Next.Next;
                        tmp.Next.Previous = tmp;
                        length--;
                    }
                    else
                    {
                        L2Node tmp = _end;
                        for (int i = length - 1; i > index; i--)
                        {
                            tmp = tmp.Previous;
                        }
                        tmp.Previous = tmp.Previous.Previous;
                        tmp.Previous.Next = tmp;
                    }
                }
            }
            else if (length == 0)
            {
                throw new Exception("Nothing to remove");
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public int IndexOf(int value)
        {
            int length = GetLength();
            L2Node tmp = _head;
            if (length == 0)
            {
                throw new Exception("List is empty");
            }

            for (int i = 0; i < length; i++)
            {
                if (tmp.Value == value)
                {
                    return i;
                }
                tmp = tmp.Next;
            }
            return -1;
        }
        public int Get(int index)
        {
            int length = GetLength();
            int value = 0;
            if (length == 0)
            {
                throw new Exception("List is empty");
            }

            L2Node tmp = _head;
            for (int i = 0; i < length; i++)
            {
                if (i == index)
                {
                    value = tmp.Value;
                    return value;
                }
                tmp = tmp.Next;
            }
            return -1;
        }
        public void Reverse()
        {
            int length = GetLength();
            if (length == 0)
            {
                throw new Exception("List is empty");
            }
            else
            {
                L2Node prev = null, current = _head, next;
                while (current != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    current.Previous = next;
                    prev = current;
                    current = next;
                }
                _head = prev;
            }
        }
       
        public int Min()
        {
            int min = 0;
            if (_head != null)
            {
                min = _head.Value;
                L2Node tmp = _head;
                while (tmp != null)
                {
                    if (min > tmp.Value)
                    {
                        min = tmp.Value;
                    }
                    tmp = tmp.Next;
                }
            }
            return min;
        }
        public int IndexMin()
        {
            int a = 0;
            if (_head != null)
            {
                int index = 0;
                int min = _head.Value;
                L2Node tmp = _head;
                while (tmp != null)
                {
                    if (min > tmp.Value)
                    {
                        min = tmp.Value;
                        a = index;
                    }
                    tmp = tmp.Next;
                    index++;
                }
            }
            else
            {
                a = -1;
            }
            return a;
        }
        public int Max()
        {
            int max = 0;
            L2Node tmp = _head;
            while (tmp != null)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return max;
        }
        public int IndexMax()
        {
            int a = 0;
            if (_head != null)
            {
                int index = 0;
                int max = 0;
                L2Node tmp = _head;
                while (tmp != null)
                {
                    if (max < tmp.Value)
                    {
                        max = tmp.Value;
                        a = index;
                    }
                    tmp = tmp.Next;
                    index++;
                }
            }
            else
            {
                a = -1;
            }
            return a;
        }
        public void RemoveFirstMultiple(int n)
        {
            if (_head == null)
            {
                throw new IndexOutOfRangeException();
            }

            L2Node current = _end;
            int length = GetLength();
            if (n > length)
            {
                throw new IndexOutOfRangeException();
            }
            if (length == n)
            {
                _head = null;
            }
            else
            {
                int i = 1;
                while (i != length - n)
                {

                    current = current.Previous;
                    i += 1;
                }
                _head = current;
            }
            current.Previous = null;
        }
        public void RemoveLastMultiply(int n)
        {
            L2Node current = _end;
            int length = GetLength();
            int i = 1;
            if (length == n)
            {
                _head = null;
            }
            else
            {
                while (i != n + 1)
                {
                    i += 1;
                    current = current.Previous;
                }
                current.Next = null;
                _end = current;
            }
        }
        public void RemoveAtMultiple(int idx, int n)
        {
            L2Node current = _end;
            int length = GetLength();
            if (idx == 0)
            {
                RemoveFirst(n);
            }
            else if (idx == length - 1)
            {
                RemoveLastMultiply(n);
            }
            else if (idx <= length / 2)
            {
                L2Node currentTmp = _head;
                for (int i = 0; i < idx - 1; i++)
                {
                    currentTmp = currentTmp.Next;
                }
                L2Node tmp1 = currentTmp;
                for (int i = 0; i < n + 1; i++)
                {
                    tmp1 = tmp1.Next;
                }
                currentTmp.Next = tmp1;
                tmp1.Previous = currentTmp;
            }
            else
            {
                for (int i = 0; i < length - idx - 1; i++)
                {
                    current = current.Previous;
                }
                L2Node tmp = current;
                for (int i = 0; i < n + 1; i++)
                {
                    tmp = tmp.Previous;
                }
                current.Previous = tmp;
                tmp.Next = current;
            }
        }

        public void RemoveFirst(int value)
        {
            int length = GetLength();
            if (length == 0)
            {
                throw new Exception("List is empty");
            }
            if (length != 0)
            {
                L2Node tmp = _head;
                while (tmp.Next.Value != value && tmp.Next != null)
                {
                    tmp = tmp.Next;
                    tmp.Next.Previous = tmp;
                }
                tmp.Next = tmp.Next.Next;
            }
        }
        public void RemoveAll(int value)
        {
            int length = GetLength();
            if (length == 0)
            {
                throw new Exception("List is empty");
            }
            if (length != 0)
            {
                while (_head.Value == value && length > 1)
                {
                    _head = _head.Next;
                    length--;
                }
                if (length == 1)
                {
                    if (_head.Value == value)
                    {
                        _head = null;
                        _end = null;
                        length = 0;
                    }
                    else
                    {
                        _end.Previous = _head;
                    }
                }
                else
                {
                    L2Node tmp = _head;
                    int b = length;
                    L2Node c;
                    for (int i = 1; i < b - 1; i++)
                    {
                        if (tmp.Next.Value == value)
                        {
                            c = tmp.Next.Next;
                            tmp.Next = c;
                            c.Previous = tmp;
                        }
                        else
                        {
                            tmp = tmp.Next;
                        }
                    }
                    if (tmp.Next.Value == value)
                    {
                        tmp.Next = null;
                        _end = tmp;
                    }
                    else
                    {
                        tmp = tmp.Next;
                        _end = tmp.Next;
                    }
                }
            }
        }
        public void Sort()
        {
            int length = GetLength();
            if (length != 0)
            {
                L2Node tmp = _head;
                int l = 0;
                while (tmp.Next != null)
                {
                    if (tmp.Value > tmp.Next.Value)
                    {
                        int a = tmp.Next.Value;
                        tmp.Next.Value = tmp.Value;
                        tmp.Value = a;
                        l = 1;
                    }
                    tmp = tmp.Next;
                }
                if (l != 0)
                {
                    Sort();
                }
            }
        }
        public void SortDesc()
        {
            int length = GetLength();
            if (length != 0)
            {
                L2Node tmp = _head;
                while (tmp.Next != null)
                {
                    if (tmp.Value < tmp.Next.Value)
                    {
                        int a = tmp.Next.Value;
                        tmp.Next.Value = tmp.Value;
                        tmp.Value = a;
                        SortDesc();
                    }
                    else
                    {
                        tmp = tmp.Next;
                    }
                }
            }
        }
        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;
            int length = GetLength();
            if (length != doubleLinkedList.GetLength())
            {
                return false;
            }

            L2Node tmp1 = _head;
            L2Node tmp2 = doubleLinkedList._head;

            for (int i = 0; i < length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";
            int length = GetLength();
            L2Node tmp = _head;
            for (int i = 0; i < length; i++)
            {
                s += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return s;
        }
        private L2Node EndOrHead(int index)
        {
            int length = GetLength();
            if (index > length / 2)
            {

                return _end;
            }
            else
            {

                return _head;
            }
        }
        public int this[int index]
        {
            get
            {
                int length = GetLength();
                if (index > length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                L2Node tmp = EndOrHead(index);
                if (tmp == _head)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    return tmp.Value;
                }
                else
                {
                    for (int i = 0; i < length - index - 1; i++)
                    {
                        tmp = tmp.Previous;
                    }
                    return tmp.Value;
                }
            }
            set
            {
                int length = GetLength();
                if (index > length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                L2Node tmp = EndOrHead(index);
                if (tmp == _head)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    tmp.Value = value;
                }
                else
                {
                    for (int i = 0; i < length - index - 1; i++)
                    {
                        tmp = tmp.Previous;
                    }
                    tmp.Value = value;
                }
            }
        }
    }
}

