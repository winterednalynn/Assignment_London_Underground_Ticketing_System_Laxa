using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;

namespace Assignment_London_Underground_Ticketing_System
{
    public class EdnalynnList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;
        private const int InitialCapacity = 10; // initially 100 but the assignment said 10 ? changed to 10 . Uncertain if correct. 

        public EdnalynnList()
        {
            _items = new T[InitialCapacity];
            _count = 0;
        }

        public void Add(T item) // Provided Code by professor 
        {
            _items[_count] = item;
            _count++;
        }

        public IEnumerator<T> GetEnumerator() // Provided code by professor 
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() // Code provided by professor 
        {
            return this.GetEnumerator();
        }
        private void CheckIntegrity()
        {
            //private void CheckIntegrity(): when run, checks to see if the current count of elements is over 80% of the capacity of the current internal array.
            //If it is then expand the capacity by 2. Ensure none of the items are lost and that they maintain their location integrity.

            //80 / 100 = 0.8  

            if (_count >= _items.Length * 0.8)
            {
                T[] newItem = new T[_items.Length * 2 ];
                Array.Copy(_items, newItem, _items.Length);
                _items = newItem; 
            }
        }
     
        public void AddAtIndex (T value, int index)
        {
            //Shifting Elements:

            //It uses Array.Copy to efficiently shift existing elements at and after the index by one position to make room for the new element.

            //Throw new exception power is to trigger an exception & grasp the literal index of the presenting parameter. 


            //Add an item at the selected index. Make sure to maintain object location integrity

            // Using if conditional statement to check if the index is less than zero OR greather than or equal to the count ; Same pattern presented 
            if (index<0 || index >= _count)
            {
                throw new Exception(nameof(index));
            }
            Array.Copy(_items, index + 1, _items, index, _count - index - 1);
            _count--; 
        }
        public void RemoveAtIndex(int index)
        {
            //Remove the item at the selected index. Validate to make sure the index is within range. Make sure item location integrity is maintained. 
            //Throw new exception power is to trigger an exception & grasp the literal index of the presenting parameter. 
            // Using if conditional statement to check if the index is less than zero OR greather than or equal to the count ; Same pattern presented
            if (index<0 || index >= _count)
            {
                throw new Exception(nameof(index));

            }
            Array.Copy(_items,index +1, _items, index, _count - index - 1);
            _count--; 
        }
        public T GetItem(int index)
        {
            //Throw new exception power is to trigger an exception & grasp the literal index of the presenting parameter. 
            // Using if conditional statement to check if the index is less than zero OR greather than or equal to the count ; Same pattern presented
            if (index<0 || index >= _count)
            {
                throw new Exception(nameof(index));
            }
            return _items[index];
        }
       


    }
}
