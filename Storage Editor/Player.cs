using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Editor
{
    internal class Player
    {
        private int[] _position=new int[3];
        private int[] _rotation = new int[3];
        private string[] _unlockedGroups;
        public Player(int[] pos, int[] rot, string[] groups)
        {
            _position = pos;
            _rotation = rot;
            _unlockedGroups = groups;
        }
        public int Position(int i)
        {
            return _position[i];
        }
    }
}
