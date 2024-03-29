﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AntSim
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

        // TODO: Use currying
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

        // Overload that can be used without a comparison item
		public T PriorityItem (Func<T, double> sortMethod, Func<double, double, bool> comparison)
		{
			double score;
			double maxScore = double.MaxValue;
			T priorityItem = default (T);

			foreach (T item in _items) {
				score = sortMethod(item);

				if (comparison (score, maxScore)) {
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
            get
            {
                if (_items.Count != 0 || _items.First() != null)
                    return _items.First();
                else
                    throw new IndexOutOfRangeException("The collection has no first value.");
            }
        }
    }
}