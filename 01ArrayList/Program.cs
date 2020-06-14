using System;

namespace _01ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopArrayList l = new LoopArrayList();
            for (int i = 1; i < 11; i++)
            {
                l.Add(i);
            }
            Console.WriteLine(l.ToString());
            Console.WriteLine(l.CurrentValue);
            l.RemoveCurrNode();
            Console.WriteLine(l.CurrentValue);
            Console.WriteLine(l.ToString());
            l.Move(4);
            Console.WriteLine(l.CurrentValue);
            Console.WriteLine(l.ToString());
        }
    }
    public class LoopArrayList
    {
        /// <summary>
        /// 元素个数
        /// </summary>
        private int _count;

        /// <summary>
        /// 尾指针
        /// </summary>
        private LoopNode tail;
        /// <summary>
        /// 上一个节点
        /// </summary>
        private LoopNode prev;


        /// <summary>
        /// 增加元素
        /// </summary>
        /// <param name="value"></param>
        public void Add(object value)
        {
            LoopNode node = new LoopNode(value);
            if (tail == null)
            {
                tail = node;
                tail.next = node;
                prev = node;
            }
            else
            {
                node.next = tail.next;
                tail.next = node;
                if (prev == tail)
                {
                    prev = node;
                }
                tail = node;
            }
            this._count++;
        }

        /// <summary>
        /// 删除当前元素
        /// </summary>
        public void RemoveCurrNode()
        {
            //为空
            if (tail == null)
            {
                throw new NullReferenceException("集合中元素为空!");
            }
            else if (_count == 1)
            {
                tail = null;
                prev = null;
            }
            else
            {
                if (prev.next == tail)
                {
                    tail = prev;
                }
                prev.next = prev.next.next;
            }
            _count--;
        }

        public void Move(int step)
        {
            if (step < 0)
            {
                throw new ArgumentOutOfRangeException("step", "setp < 0");
            }
            if (tail == null)
            {
                throw new NullReferenceException("集合中元素为空!");
            }
            for (int i = 0; i < step; i++)
            {
                prev = prev.next;
            }
        }

        public object CurrentValue
        {
            get
            {
                return prev.next.item;
            }
        }

        public override string ToString()
        {
            if (tail == null)
            {
                return string.Empty;
            }
            string s = string.Empty;
            LoopNode temp = tail.next;
            for (int i = 0; i < _count; i++)
            {
                s += temp.ToString() + "  ";
                temp = temp.next;
            }
            return s;
        }

        public int Count
        {
            get
            {
                return this._count;
            }
        }
        class LoopNode
        {
            public LoopNode(object value)
            {
                item = value;
            }
            /// <summary>
            /// 放置数据
            /// </summary>
            public object item;
            public LoopNode next;
            public override string ToString()
            {
                return item.ToString();
            }
        }
    }

}
