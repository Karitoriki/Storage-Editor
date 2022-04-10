using System.Globalization;
using System.Data;
using System.IO;

namespace Storage_Editor
{
    public partial class SafefileAnalyzer : Form
    {
        public SafefileAnalyzer()
        {
            InitializeComponent();
        }
        private string[] sections=new string[9];
        private long[] Terraindex = new long[5] { 0, 0, 0, 0, 0 };
        private int[] PlayerPosition = new int[3];
        Player player;
        Terrastat[] Terrainformation = new Terrastat[5];

        DataTable table = new DataTable();
        DataSet dataSet = new DataSet();
        DataRow dr;

        enum Stats 
        { 
            Oxygen, 
            Heat, 
            Pressure, 
            Biomass, 
            Terraformation
        }
        enum column
        {
            Stat,
            ActualValue,
            Value,
            RelativePercent,
            Multipier
        }

        string getSaveGameValue(string searchText, string text, string terminator)
        {
            int pos = text.IndexOf(searchText);
            if (pos == -1)return "";

            pos += searchText.Length;
            text = text.Substring(pos);
            pos = text.IndexOf(terminator);
            if (pos == -1) return "";

            text = text.Substring(0, pos);
            return text;
        }

        int[] getPlayerPosition(string section,string PosRot)
        {
            string[] _dummy = getSaveGameValue("player"+PosRot+"\":\"", section, "\"").Split(",");
            int[] _playerpos = new int[_dummy.Length];
            for (int i = 0; i < _dummy.Length; i++) _playerpos[i] = Convert.ToInt32(Convert.ToDouble(dummy[i], new CultureInfo("en-US")));
            return _playerpos;
        }
       
        private void SafefileAnalyzer_Load(object sender, EventArgs e)
        {
            foreach (string col in Enum.GetNames(typeof(column)))
                table.Columns.Add(col, typeof(string));

            dGV_Terraformation.DataSource = table;//connect Table to Datagrid
            dataSet.Tables.Add(table);//connect table to dataSet

            foreach (string Stat in Enum.GetNames(typeof(Stats)))
            {
                dr = table.NewRow();
                dr[0] = Stat;
                table.Rows.Add(dr);
            }
        }

        void changeTableValue(string Stat,string valuetype, string value){
            foreach(DataRow dr in table.Rows) // search whole table
            {
                if(dr["Stat"] == Stat) // if Row = Input
                {
                    dr[valuetype] = value; //change the name
                    break;
                }
            }
        }

        private void b_clipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                sections = Clipboard.GetText().Split("@");
                if (sections != null)
                {
                    string[] Statunits = new string[5] { "ppq,ppt,ppb,ppm,pcm", "ppq,ppt,ppb,ppm,pcm", "ppq,ppt,ppb,ppm,pcm", "ppq,ppt,ppb,ppm,pcm", "ppq,ppt,ppb,ppm,pcm" };
                    Terrainformation[4] = new Terrastat(Enum.GetName(typeof(Stats), 4), 0, Statunits[4].Split(","));
                    for (int i = 0; i < 4; i++)
                    {
                        Terrainformation[i] = new Terrastat(Enum.GetName(typeof(Stats), i), Convert.ToInt64(getSaveGameValue("unit" + (Stats)i + "Level\":", sections[0], ".")), Statunits[i].Split(","));
                        Terraindex[4] += Terraindex[i];
                        changeTableValue(Enum.GetName(typeof(Stats), i), "ActualValue", Terraindex[i].ToString());
                        changeTableValue(Enum.GetName(typeof(Stats), 4), "ActualValue", Terraindex[4].ToString());
                    }
                    Statunits = null;
                    player = new Player(getPlayerPosition(sections[1], "Position"), getPlayerPosition(sections[1], "Rotation"), getSaveGameValue("unlockedGroups\":\"",sections[1],"\"").Split(","));
                    l_player_pos.Text += getSaveGameValue("playerPosition\":\"", sections[1], "\"");
                    
                }
            }
        }
        
    }
}