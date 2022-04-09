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
            RelativePercent
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

        int[] getPlayerPosition(string section)
        {
            string[] dummy = getSaveGameValue("playerPosition\":\"", section, "\"").Split(",");
            int[] playerpos = new int[dummy.Length];
            for (int i = 0; i < dummy.Length; i++) playerpos[i] = Convert.ToInt32(Convert.ToDouble(dummy[i], new CultureInfo("en-US")));
            return playerpos;
        }
       
        private void SafefileAnalyzer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                var col = (column)i;
                table.Columns.Add(col.ToString(), typeof(string));
            }

            dGV_Terraformation.DataSource = table;//connect Table to Datagrid
            dataSet.Tables.Add(table);//connect table to dataSet

            for (int i = 0; i < Enum.GetNames(typeof(Stats)).Length; i++)
            {
                dr = table.NewRow();
                dr[0] = (Stats)i;
                table.Rows.Add(dr);
            }
            changeTableValue((Stats)0,);
        }
        void changeTableValue(string Stat,string valuetype, string value){
            foreach(DataRow dr in table.Rows) // search whole table
            {
                if(dr["Stat"] == Stat) // if id==2
                {
                    dr["Product_name"] = "cde"; //change the name
                    break;
                }
            }
        }

private void b_clipboard_Click(object sender, EventArgs e)
        {
           /* if (Clipboard.ContainsText())
            {
                sections = Clipboard.GetText().Split("@");
                if (sections != null)
                {
                    string[] searchValues = new string[4] { "unitOxygenLevel", "unitHeatLevel", "unitPressureLevel", "unitBiomassLevel" };
                    for (int i = 0; i < searchValues.Length; i++)
                    {
                        dGV_Terraformation.
                        Terraindex[i] = Convert.ToInt64(getSaveGameValue(searchValues[i]+"\":", sections[0], "."));
                        Terraindex[4] += Terraindex[i];
                        Terradata[i].Text += Terraindex[i].ToString();
                        Terradata[4].Text = "TI: "+Terraindex[4];
                    }
                    PlayerPosition = getPlayerPosition(sections[1]);
                    l_player_pos.Text += getSaveGameValue("playerPosition\":\"", sections[1], "\"");
                    
                }
            }*/
        }
        
    }
}