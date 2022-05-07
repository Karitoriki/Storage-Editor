using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Editor
{
    internal class Item
    {
        private int _id;//item id
        private string _gId;//item name
        private int _liId;//container refferal
        private string _liGrps;
        private Container _container;
        private int[] _pos = new int[3];//Obvious
        private int[] _rot = new int[3];//Obvious
        private int _wear;
        private int[] _pnls;//Panels on the side of buildings
        private string _color;
        private string _text;//containers
        private int _grwth;//seed spreaders
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Item(int id, string gId, int liId, string liGrps, int[] pos, int[] rot, int wear, int[] pnls, string color, string text, int grwth)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
        public Container Container
        { 
            get { return _container; } 
            set { _container = value; }
        }
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
