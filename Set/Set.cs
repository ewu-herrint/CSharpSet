/* 
     Name: Tyler Herrin
     Class Description: An implementation of a set, a set being: an unordered collection of values, where each value occurs 
                        at most once. A group of elements with three properties: (1) all elements belong to a universe, 
                        (2) either each element is a member of the set or it is not, and (3) the elements are unordered.
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment1
{
    public class Set : ICollection, IEnumerable
    {
        private ArrayList list;
        private int count;

        //Constructor
        public Set()
        {
            this.list = new ArrayList();
            this.count = 0;
        }

        // Implement IEnumerable and ICollection Interface
        object ICollection.SyncRoot { get { return list.SyncRoot; } }

        bool ICollection.IsSynchronized { get { return list.IsSynchronized; } }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            try
            {
                foreach(object o in this)
                {
                    array.SetValue(o, index);
                    index++;
                }
            }
            catch(IndexOutOfRangeException)
            {
                throw new ArgumentException("Number of objects in set is greater than available space in the array.");
            }
        }
        

        // Set Methods
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public bool Empty
        {
            get
            {
                if (this.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public object this[int index]
        {
            get
            {
                if(index < 0)
                    throw new IndexOutOfRangeException();
                if(index >= this.Count)
                    throw new IndexOutOfRangeException();
                return list[index];
            }
        }

        public bool Contains(object o)
        {
            return list.Contains(o);
        }

        public bool Add(object o)
        {
            // If list contains the object, don't add and return false
            if (this.list.Contains(o))
                return false;
            // If list doesn't contain object, add and return true
            else
            {
                this.list.Add(o);
                this.count++;
                return true;
            }
        }

        public bool Remove(object o)
        {
            // If list contains object remove and return true
            if (this.list.Contains(o))
            {
                list.Remove(o);
                count--;
                return true;
            }
            // if list doesn't contain object return false
            else
                return false;
        }

        public override bool Equals(object o)
        {
            Set that = (Set)o;

            // If the sizes don't match there must be at least one element that doesn't match
            if (this.Count != that.Count)
                return false;

            // For each object t in that
            foreach(object t in that)
            {
                // If the object t is not contained in this
                if (!this.Contains(t))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int sum = 0;
            foreach(object o in this)
            {
                sum += o.GetHashCode();
            }

            return sum;
        }

        public override string ToString()
        {
            string s = "[";
            for(int i = 0; i < this.Count - 2; i++)
            {
                s += this[i].ToString() + ", ";
            }
            s += this[this.Count - 1].ToString() + "]";

            return s;
        }
    }
}