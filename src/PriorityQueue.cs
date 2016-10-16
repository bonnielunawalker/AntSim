using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGame
{
    public class PriorityQueue<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T value)
        {
            _items.Add(value);
        }

        public void Remove(T value)
        {
            _items.Remove(value);
        }

        public bool Contains(T value)
        {
            return _items.Contains(value);
        }

		public T PriorityItem(Func<T, T, double> sortMethod, Func<double, double, bool> comparison, T comparisonItem)
        {
            double score;
            double maxScore = double.MaxValue;
            T priorityItem = default(T);

            foreach (T item in _items)
            {
                score = sortMethod(item, comparisonItem);

				if (comparison(score, maxScore))
                {
                    maxScore = score;
                    priorityItem = item;
                }
            }

            return priorityItem;
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public List<T> Items
        {
            get { return _items; }
        }

        public T First
        {
            get { return _items.First(); }
        }
    }
}