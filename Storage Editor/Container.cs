using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Editor
{
    public class Container
    {
        private int _id = -1;
        private int[] items;
        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
