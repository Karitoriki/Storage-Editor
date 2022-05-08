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
        private List<Item> items = new List<Item>();
        private List<Container> containers = new List<Container>();

        private List<string> names = new List<string>();

        private DataTable table = new DataTable();
        private DataSet dataSet = new DataSet();
        private DataRow dr;

        private List<Item> selectedItems = new List<Item>();
        private int selectedItemIndex = new int();

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
                    if (_item.id == _dummy[i])
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

        private void updateSelectedItem()
        {
            Item _item = selectedItems[selectedItemIndex];
            if (selectedItemIndex + 1 < selectedItems.Count && selectedItems.Count != 1)
                b_selectItemNext.Enabled = true;
            else b_selectItemNext.Enabled = false;

            if (selectedItemIndex > 0)
                b_selectItemPrevioaus.Enabled = true;
            else b_selectItemPrevioaus.Enabled = false;


            l_selectedItemNumber.Text = "Selected Item No.: " + selectedItemIndex.ToString();
            string contains = "";
            string info =
                "Id: " + _item.id + "\r\n"+
                "Name: " + _item.gId + "\r\n";
            if (_item.liId != 0)
            {
                contains = "Id: " + _item.Container.id + "\r\n";
                Item[] containedItems = _item.Container.Items();
                List<string> namelist = new List<string>();
                foreach (Item citem in containedItems)
                    if(!namelist.Contains(citem.gId))
                        namelist.Add(citem.gId);
                
                foreach(string name in namelist)
                {
                    int count = 0;
                    foreach (Item citem in containedItems)
                        if (name==citem.gId)count++;
                    contains += count.ToString() + "x " + name + "\r\n";
                }
            }
            if (_item.pos[0] != 0 && _item.pos[1] != 0 && _item.pos[2] != 0)
                info += "Position: " + _item.pos[0].ToString() + ", " + _item.pos[1].ToString() + ", " + _item.pos[2].ToString();

            tB_selectedItemInfos.Text = info;
            tB_contains.Text = contains;
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
                        if (!names.Contains(_dummyItem.gId)) names.Add(_dummyItem.gId);
                    }
                    names.Sort();
                    foreach (string name in names) cB_Items.Items.Add(name);
                    l_itemsInWorld.Enabled = true;
                    cB_Items.Enabled = true;


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
                        if (item.liId != 0) 
                            foreach(Container container in containers)
                                if(container.id==item.liId)
                                    item.Container=container;
                }
            }
            else MessageBox.Show("ERROR:\r\nWrong clipboard format!");
        }
        

        private void cB_Items_DropDownClosed(object sender, EventArgs e)
        {
            selectedItems.Clear();
            foreach (Item item in items)
            {
                if (item.gId == cB_Items.SelectedItem.ToString())selectedItems.Add(item);
            }
            l_itemsInWorld.Text = "Amount of Items in World: "+ selectedItems.Count.ToString();
            selectedItemIndex = 0;
            updateSelectedItem();
            l_selectedItemNumber.Enabled = true;
        }

        private void b_selectItemPrevioaus_Click(object sender, EventArgs e)
        {
            if (selectedItemIndex > 0) selectedItemIndex--;
            updateSelectedItem();
        }

        private void b_selectItemNext_Click(object sender, EventArgs e)
        {
            if (selectedItemIndex+1 < selectedItems.Count) selectedItemIndex++;
            updateSelectedItem();
        }
    }
}
// openFileDialog1.Filter = "Planet Crafter Savefile(*.json)|*.json";