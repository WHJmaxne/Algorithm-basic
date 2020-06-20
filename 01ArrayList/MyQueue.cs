using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayList
{
    public class MyQueue
    {
        private object[] _array;
        private const int _defaultCapacity = 0x20;
        private int _size;
        public MyQueue() : this(_defaultCapacity)
        {

        }
        public MyQueue(int capacity)
        {
            capacity = capacity > _defaultCapacity ? capacity : _defaultCapacity;
            this._array = new object[capacity];
            this._size = 0;
        }

        public object DeQueue()
        {
            if (this._size <= 0)
            {
                throw new ArgumentOutOfRangeException("队列为空");
            }
            object obj = this._array[0];

            return obj;
        }
    }
}
