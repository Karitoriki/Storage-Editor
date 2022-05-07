using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Editor
{
    
    internal class Container
    {
        private int _id;
        private List<Item> _items = new List<Item>();
        private int _size;
        public Container(int pid, Item[] items, int size)
        {
            _id = pid;
            foreach (Item item in items) _items.Add(item);
            _size = size;
        }
        public int Id
            { get { return _id; } }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public void additem(Item item) { _items.Add(item); }
        public void removeitem(Item item) { _items.Remove(item); }
        public Item[] Items() { return _items.ToArray(); }
    }
}
