using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Editor
{
    internal class Terrastat
    {
        private string _name;
        private long _stat;
        private string[] _units = new string[5];//{ "ppq", "ppt", "ppb", "ppm","pcm" }
        public Terrastat(string name, long stat, string[] units)
        {
            _name = name;
            _stat = stat;
            _units = units;
        }
        public string Name
        {
            get { return _name; }
        }
        public long Stat
        {
            get { return _stat; }
            set { _stat = value; }
        }
        public string Units(int i)
        {
            return _units[i];
        }
    }
}
