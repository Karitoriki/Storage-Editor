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

        int[] stringA2intA(string[] _dummy)
        {
            int[] _i = new int[0];
            if (string.IsNullOrEmpty(_dummy[0])) return _i;

            int[] _playerpos = new int[_dummy.Length];
            for (int i = 0; i < _dummy.Length; i++) _playerpos[i] = Convert.ToInt32(Convert.ToDouble(_dummy[i], new CultureInfo("en-US")));
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
                    string[] Statunits = new string[5] { "ppq,ppt,ppb,ppm,pcm", "ppq,ppt,nK,ppm,K", "ppq,ppt,ppb,ppm,pcm", "ppq,ppt,ppb,ppm,pcm", "ppq,ppt,ppb,ppm,pcm" };
                    Terrainformation[4] = new Terrastat(nameof(Stats.Terraformation), 0, Statunits[4].Split(","));
                    for (int i = 0; i < 4; i++)
                    {
                        Terrainformation[i] = new Terrastat(Enum.GetName(typeof(Stats), i), Convert.ToInt64(getSaveGameValue("unit" + (Stats)i + "Level\":", sections[0], ".")), Statunits[i].Split(","));
                        Terrainformation[4].Stat += Terrainformation[i].Stat;
                        changeTableValue(Enum.GetName(typeof(Stats), i), "ActualValue", Terrainformation[i].Stat.ToString());
                    }
                    changeTableValue(Enum.GetName(typeof(Stats), 4), "ActualValue", Terrainformation[4].Stat.ToString());


                    player = new Player(stringA2intA(getSaveGameValue("playerPosition\":\"", sections[1], "\"").Split(",")), stringA2intA(getSaveGameValue("playerRotation\":\"", sections[1], "\"").Split(",")), getSaveGameValue("unlockedGroups\":\"", sections[1], "\"").Split(","));
                    l_player_pos.Text += " " + Math.Round(Convert.ToDecimal(player.Position(0)), 0).ToString() + ", " + Math.Round(Convert.ToDecimal(player.Position(1)), 0).ToString() + ", " + Math.Round(Convert.ToDecimal(player.Position(2)), 0).ToString();

                    string[] itemstrings = sections[2].TrimStart('\r').TrimStart('\n').Split("\n");
                    Item[] items = new Item[itemstrings.Length];
                    for (int i = 0; i < itemstrings.Length; i++)
                    {
                        items[i] = new Item
                        (
                            Convert.ToInt32(getSaveGameValue("\"id\":", itemstrings[i], ",")),
                            getSaveGameValue("\"gId\":\"", itemstrings[i], "\","),
                            Convert.ToInt32(getSaveGameValue("\"liId\":", itemstrings[i], ",")),
                            getSaveGameValue("\"liGrps\":\"", itemstrings[i], "\","),
                            stringA2intA(getSaveGameValue("\"pos\":\"", itemstrings[i], "\",").Split(",")),
                            stringA2intA(getSaveGameValue("\"rot\":\"", itemstrings[i], "\",").Split(",")),
                            Convert.ToInt32(getSaveGameValue("\"wear\":", itemstrings[i], ",")),
                            stringA2intA(getSaveGameValue("\"pnls\":\"", itemstrings[i], "\",").Split(",")),
                            getSaveGameValue("\"color\":\"", itemstrings[i], "\","),
                            getSaveGameValue("\"text\":\"", itemstrings[i], "\","),
                            Convert.ToInt32(getSaveGameValue("\"grwth\":", itemstrings[i], "}"))
                        );
                    }
                    itemstrings = sections[3].TrimStart('\r').TrimStart('\n').Split("\n");
                    Container[] containers = new Container[itemstrings.Length];
                    for (int i = 0; i < itemstrings.Length; i++)
                    {
                        containers[i] = new Container
                        (
                            Convert.ToInt32(getSaveGameValue("\"id\":", itemstrings[i], ",")),
                            stringA2intA(getSaveGameValue("\"woIds\":\"", itemstrings[i], "\",").Split(",")),
                            Convert.ToInt32(getSaveGameValue("\"liId\":", itemstrings[i], "}"))
                            
                        );
                    }
                }
            }
        }
        
    }
}