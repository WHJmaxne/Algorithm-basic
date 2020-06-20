using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace _01ArrayList
{
    public class MyStack
    {
        private object[] _items;

        private const int _defaultCapacity = 10;
        private int size = 0;

        public MyStack() : this(_defaultCapacity)
        {
        }

        public MyStack(int capacity)
        {
            capacity = capacity > _defaultCapacity ? capacity : _defaultCapacity;
            _items = new object[capacity];
            size = 0;
        }

        public void Push()
        {
        }

        //出栈
        public object Pop()
        {
            if (this.size <= 0)
            {
                throw new ArgumentOutOfRangeException("栈容量为0");
            }
            object obj = this._items[--this.size];
            this._items[this.size] = null;
            return obj;
        }

        //入栈
        public void Push(object value)
        {
            if (this.size == this._items.Length)
            {
                object[] dest = new object[2 * this.size];
                Array.Copy(this._items, 0, dest, 0, this.size);
                this._items = dest;
            }

            this._items[this.size++] = value;
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public object Peek()
        {
            if (this.size <= 0)
            {
                throw new ArgumentOutOfRangeException("栈容量为0");
            }
            return this._items[this.size - 1];
        }
    }
}