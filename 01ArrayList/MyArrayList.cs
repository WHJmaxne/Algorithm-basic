using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayList
{
    public class MyArrayList
    {
        /// <summary>
        /// 容量
        /// </summary>
        private const int _defaultCapacity = 4;
        /// <summary>
        /// 存放数组元素
        /// </summary>
        private object[] _items;
        /// <summary>
        /// 数组大小
        /// </summary>
        private int _size;
        /// <summary>
        /// 元素个数为0的数组状态
        /// </summary>
        private static readonly object[] emptyArray = new object[0];

        public MyArrayList()
        {
            this._items = emptyArray;
        }

        public MyArrayList(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("capacity", "ArrayList容量不可为负数!");

            this._items = new object[capacity];
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual object this[int index]
        {
            get
            {
                if (index < 0 || index >= this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围!");
                }

                return this._items[index];
            }
            set
            {
                if (index < 0 || index >= this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围!");
                }

                this._items[index] = value;
            }
        }

        /// <summary>
        /// 当前数组元素个数
        /// </summary>
        public virtual int Count
        {
            get
            {
                return this._size;
            }
        }

        public virtual int Capacity
        {
            get
            {
                return this._items.Length;
            }
            set
            {
                if (value != this._items.Length)
                {
                    if (value < this._size)
                    {
                        throw new ArgumentOutOfRangeException("value", "容量太小!");
                    }
                    else
                    {
                        if (value == 0)
                        {
                            this._items = new object[_defaultCapacity];
                        }
                        else
                        {
                            object[] _temp = new object[value];
                            if (this._size > 0)
                            {
                                _items.CopyTo(_temp, this._size);
                            }
                            this._items = _temp;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="value"></param>
        public virtual void Add(object value)
        {
            if (this._size == this.Capacity)
            {
                this.EnsureCapacity(this._size + 1);
            }
            this._items[this._size] = value;
            this._size++;
        }

        /// <summary>
        /// 指定位置插入元素
        /// </summary>
        /// <param name="value"></param>
        public virtual void Insert(int index, object value)
        {
            if (index < 0 || index > this._size)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围!");
            }
            if (this._size == this.Capacity)
            {
                this.EnsureCapacity(this._size + 1);
            }
            if (index == this._size)
            {
                this.Add(value);
            }
            else
            {
                Array.Copy(this._items, index, this._items, index + 1, this._size - index);
                this._items[index] = value;
                this._size++;
            }
        }

        /// <summary>
        /// 移除指定索引元素
        /// </summary>
        /// <param name="index"></param>
        public virtual void Remove(int index)
        {
            if (index < 0 || index >= this._size)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围!");
            }
            this._size--;
            Array.Copy(this._items, index + 1, this._items, index, this._size - index);
            this._items[this._size] = null;
        }

        /// <summary>
        /// 扩容
        /// </summary>
        /// <param name="v"></param>
        private void EnsureCapacity(int v)
        {
            if (this.Capacity < v)
            {
                int num = this.Capacity == 0 ? _defaultCapacity : this.Capacity * 2;
                if (num < v)
                {
                    num = v;
                }
                this.Capacity = num;
            }
        }
    }
}
