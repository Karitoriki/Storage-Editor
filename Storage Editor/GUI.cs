using System.Globalization;
using System.Data;
using System.IO;

namespace Storage_Editor
{
    public partial class SafefileAnalyzer : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SafefileAnalyzer()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
        }
        private string[] sections=new string[9];
        private Player player;
        private Terrastat[] Terrainformation = new Terrastat[5];
        List<Item> items = new List<Item>();
        List<Container> containers = new List<Container>();

        List<Item> selectedItems = new List<Item>();
        List<string> names = new List<string>();

        private DataTable table = new DataTable();
        private DataSet dataSet = new DataSet();
        private DataRow dr;

        enum Stats 
        {
            Oxygen = 0,
            Heat = 1,
            Pressure = 2,
            Biomass = 3,
            Terraformation = 4
        }
        enum column
        {
            Stat,
            ActualValue,
            Value,
            RelativePercent,
            Multipier
        }

        private string getSaveGameValue(string searchText, string text, string terminator)
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

        private int[] stringA2intA(string[] _dummy)
        {
            int[] _i = new int[0];
            if (string.IsNullOrEmpty(_dummy[0])) return _i;

            int[] _playerpos = new int[_dummy.Length];
            for (int i = 0; i < _dummy.Length; i++) _playerpos[i] = Convert.ToInt32(Convert.ToDouble(_dummy[i], new CultureInfo("en-US")));
            return _playerpos;
        }
        private Item[] intA2ItemA(int[] _dummy)
        {
            Item[] _i = new Item[0];
            if (_dummy==null) return _i;
            Item[] _items = new Item[_dummy.Length];

            for (int i = 0; i < _dummy.Length; i++)
            {
                foreach (Item _item in items)
                {
                    if (_item.Id == _dummy[i])
                    {
                        _items[i] = _item;
                        break;
                    }
                }
            }
            return _items;
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

        private void changeTableValue(string Stat,string valuetype, string value){
            foreach(DataRow dr in table.Rows) // search whole table
            {
                if(dr["Stat"].ToString() == Stat) // if Row = Input
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
                    string[] Statunits = new string[5] { "ppq,ppt,ppb,ppm,pcm", "pK,nK,µK,mK,K", "nPa,µPa,mPa,Pa,pcm", "g,kg,t,kt,mt", "Ti,kTi,MTi,GTi,TTi" };
                    Terrainformation[4] = new Terrastat(nameof(Stats.Terraformation), 0, Statunits[4].Split(","));
                    for (int i = 0; i < 4; i++)
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        Terrainformation[i] = new Terrastat(Enum.GetName(typeof(Stats), i), Convert.ToInt64(getSaveGameValue("unit" + (Stats)i + "Level\":", sections[0], ".")), Statunits[i].Split(","));
                        Terrainformation[4].Stat += Terrainformation[i].Stat;

                        changeTableValue(Enum.GetName(typeof(Stats), i), Enum.GetName(column.ActualValue), Terrainformation[i].Stat.ToString());
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        changeTableValue(Enum.GetName(typeof(Stats), i), Enum.GetName(column.RelativePercent), Terrainformation[i].Percentage(Terrainformation[4].Stat));
                    }
                    changeTableValue(Enum.GetName(typeof(Stats), 4), "ActualValue", Terrainformation[4].Stat.ToString());
#pragma warning restore CS8604 // Possible null reference argument.


                    player = new Player(stringA2intA(getSaveGameValue("playerPosition\":\"", sections[1], "\"").Split(",")), stringA2intA(getSaveGameValue("playerRotation\":\"", sections[1], "\"").Split(",")), getSaveGameValue("unlockedGroups\":\"", sections[1], "\"").Split(","));
                    l_player_pos.Text += " " + Math.Round(Convert.ToDecimal(player.Position(0)), 0).ToString() + ", " + Math.Round(Convert.ToDecimal(player.Position(1)), 0).ToString() + ", " + Math.Round(Convert.ToDecimal(player.Position(2)), 0).ToString();

                    string[] itemstrings = sections[2].TrimStart('\r','\n').Split("\n");
                    foreach (string item in itemstrings)
                    {
                        Item _dummyItem = new Item
                        (
                            Convert.ToInt32(getSaveGameValue("\"id\":", item, ",")),
                            getSaveGameValue("\"gId\":\"", item, "\","),
                            Convert.ToInt32(getSaveGameValue("\"liId\":", item, ",")),
                            getSaveGameValue("\"liGrps\":\"", item, "\","),
                            stringA2intA(getSaveGameValue("\"pos\":\"", item, "\",").Split(",")),
                            stringA2intA(getSaveGameValue("\"rot\":\"", item, "\",").Split(",")),
                            Convert.ToInt32(getSaveGameValue("\"wear\":", item, ",")),
                            stringA2intA(getSaveGameValue("\"pnls\":\"", item, "\",").Split(",")),
                            getSaveGameValue("\"color\":\"", item, "\","),
                            getSaveGameValue("\"text\":\"", item, "\","),
                            Convert.ToInt32(getSaveGameValue("\"grwth\":", item, "}"))
                        );
                        items.Add(_dummyItem);
                        if (!names.Contains(_dummyItem.GId)) names.Add(_dummyItem.GId);
                    }
                    foreach (string name in names) cB_Items.Items.Add(name);


                    itemstrings = sections[3].TrimStart('\r','\n').Split("\n");
                    foreach(string container in itemstrings)
                        containers.Add
                        (
                            new Container
                            (
                                Convert.ToInt32(getSaveGameValue("\"id\":", container, ",")),
                                intA2ItemA(stringA2intA(getSaveGameValue("\"woIds\":\"", container, "\",").Split(","))),
                                Convert.ToInt32(getSaveGameValue("\"size\":", container, "}"))
                            )
                        );
                    foreach(Item item in items)
                        if (item.LiId != 0) 
                            foreach(Container container in containers)
                                if(container.Id==item.LiId)
                                    item.Container=container;
                }
            }
            else MessageBox.Show("ERROR:\r\nWrong clipboard format!");
        }
        

        private void cB_Items_DropDownClosed(object sender, EventArgs e)
        {
            selectedItems.Clear();
            int count = 0;
            foreach (Item item in items)
            {
                if (item.GId == cB_Items.SelectedItem.ToString())
                {
                    selectedItems.Add(item);
                    count++;
                }
            }
            l_itemsInWorld.Text = "Amount of Items in World: "+count.ToString();
        }
    }
}