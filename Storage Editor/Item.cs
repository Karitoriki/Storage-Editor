using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Editor
{
    internal class Item
    {
        private int _id;
        private string _gId;
        private int _liId;
        private string _liGrps;
        private int[] _pos = new int[3];
        private int[] _rot = new int[3];
        private int _wear;
        private int[] _pnls;
        private string _color;
        private string _text;
        private int _grwth;
        public Item(int id, string gId, int liId, string liGrps, int[] pos, int[] rot, int wear, int[] pnls, string color, string text, int grwth)
        {
            _id = id;
            _gId = gId;
            _liId = liId;
            _liGrps = liGrps;
            _pos = pos;
            _rot = rot;
            _wear = wear;
            _pnls = pnls;
            _color = color;
            _text = text;
            _grwth = grwth;
        }
        public int Id
            { get { return _id; } }
        public string GId
            { get { return _gId; } }
        public int LiId
            { get { return _liId; } }
        public int[] Pos
            { get { return _pos; } }
        public int[] Rot
            { get { return _rot; } }
        public int Wear
            { get { return _wear; } }
        public int[] Pnls
            { get { return _pnls; } }
        public string Text
            { get { return _text; } }
        public int Grwth
            { get { return _grwth; } }

    }
}
