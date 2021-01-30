using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set.Model
{
    public class SimpleSet<T> : IEnumerable
    {
        private List<T> items = new List<T>();
        public int Count => items.Count();
        public SimpleSet()
        {

        }
        public SimpleSet(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public SimpleSet(T data)
        {
            this.Add(data);
        }
        public void Add(T data)
        {
            if(items.Contains(data))
            {
                return;
            }

            items.Add(data);
        }

        public void Remove(T data)
        {
            items.Remove(data);
        }

        public SimpleSet<T> Union(SimpleSet<T> secondSet)
        {
            SimpleSet<T> simpleSet = new SimpleSet<T>();

            foreach (var items in items)
            {
                simpleSet.Add(items);
            }

            foreach (var items in secondSet.items)
            {
                simpleSet.Add(items);
            }

            return simpleSet;
        }

        public SimpleSet<T> Intersection(SimpleSet<T> secondSet)
        {
            SimpleSet<T> newSet = new SimpleSet<T>();
            List<T> bigger;
            List<T> smaller;

            if(this.Count >= secondSet.Count)
            {
                bigger = this.items;
                smaller = secondSet.items;
            }
            else
            {
                bigger = secondSet.items;
                smaller = this.items;
            }

            foreach (var item1 in smaller)
            {
                foreach (var item2 in bigger)
                {
                    if(item1.Equals(item2))
                    {
                        newSet.Add(item1);
                        break;
                    }
                }
            }

            return newSet;
        }

        public SimpleSet<T> Difference(SimpleSet<T> secondSet)
        {
            SimpleSet<T> newSet = new SimpleSet<T>(items);

            foreach (var item in secondSet.items)
            {
                newSet.Remove(item);
            }

            return newSet;
        }

        public bool Subset(SimpleSet<T> secondSet)
        {
            foreach (var item1 in items)
            {
                bool Equalse = false;
                
                foreach (var item2 in secondSet.items)
                {
                    if(item1.Equals(item2))
                    {
                        Equalse = true;
                        break;
                    }
                }

                if(Equalse == false)
                {
                    return false;
                }
            }

            return true;
        }

        public SimpleSet<T> SymmetricDifference(SimpleSet<T> secondSet)
        {
            SimpleSet<T> newSet = new SimpleSet<T>();

            foreach (var item1 in this.items)
            {
                var Equals = false;
                
                foreach (var item2 in secondSet.items)
                {
                    if(item1.Equals(item2))
                    {
                        Equals = true;
                        break;
                    }
                }

                if(Equals == false)
                {
                    newSet.Add(item1);
                }
            }

            foreach (var item1 in secondSet.items)
            {
                bool Equals = false;

                foreach (var item2 in this.items)
                {
                    if (item1.Equals(item2))
                    {
                        Equals = true;
                        break;
                    }
                }

                if (Equals == false)
                {
                    newSet.Add(item1);
                }
            }

            return newSet;
        }
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
