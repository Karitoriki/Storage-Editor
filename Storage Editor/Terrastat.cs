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
        public string Value()
        {
            if (_stat > 1000)
            {
                if (_stat>1000000)
                {
                    if (_stat > 1000000000)
                    {
                        if (_stat > 1000000000000)
                        {
                            return _stat.ToString() + _units[4];
                        }
                        else
                        {
                            return _stat.ToString() + _units[3];
                        }
                    }
                    else
                    {
                        return _stat.ToString() + _units[2];
                    }
                }
                else
                {
                    double stat = Convert.ToDouble(_stat/1000);
                    return stat.ToString() + _units[1];
                }
            }
            else
            {
                return _stat.ToString() + _units[0];
            }
        }
        public string Percentage(long Terraindex)
        {
            double percent = Math.Round(Convert.ToDouble(_stat) / Convert.ToDouble(Terraindex), 2);
            return percent.ToString()+"%";
        }
    }
}
