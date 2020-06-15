using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayList
{
    public class TwoWayArrayList
    {
        private int _count;
        private TWNode head;
        private TWNode tail;
        private TWNode curr;

        public object CurrentValue
        {
            get
            {
                return curr.ToString();
            }
        }

        public void Add(object value)
        {
            TWNode node = new TWNode(value);
            if (_count == 0)
            {
                head = node;
                tail = node;
                curr = node;
                node.prev = node;
                node.next = node;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
                node.next = node;
                tail = node;
            }
            _count++;
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
                head = null;
                curr = null;
            }
            else
            {
                if (curr.prev == curr)
                {
                    head = curr.next;
                    head.prev = head;
                    curr = head;
                }
                else if (tail.next == tail)
                {
                    tail = tail.prev;
                    tail.next = tail;
                    curr = tail;
                }
                else
                {
                    curr.prev.next = curr.next;
                    curr.next.prev = curr.prev;
                    curr = curr.next;
                }
            }
            _count--;
        }

        public void AfterMove(int step)
        {
            if (step < 0)
            {
                throw new ArgumentOutOfRangeException("step", "setp < 0");
            }
            if (_count == 0)
            {
                throw new NullReferenceException("集合中元素为空!");
            }
            for (int i = 0; i < step; i++)
            {
                if (curr == curr.next)
                {
                    continue;
                }
                curr = curr.next;
            }
        }

        public void BeforeMove(int step)
        {
            if (step < 0)
            {
                throw new ArgumentOutOfRangeException("step", "setp < 0");
            }
            if (_count == 0)
            {
                throw new NullReferenceException("集合中元素为空!");
            }
            for (int i = 0; i < step; i++)
            {
                if (curr == curr.prev)
                {
                    continue;
                }
                curr = curr.prev;
            }
        }

        public override string ToString()
        {
            string s = string.Empty;
            if (tail == null)
            {
                return s;
            }
            TWNode temp = head;
            for (int i = 0; i < _count; i++)
            {
                s += temp.ToString() + "  ";
                temp = temp.next;
            }
            return s;
        }


        public class TWNode
        {
            public object item;
            public TWNode(object value)
            {
                item = value;
            }
            public TWNode prev;
            public TWNode next;

            public override string ToString()
            {
                return item.ToString();
            }
        }
    }
}
