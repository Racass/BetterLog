using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger.Front
{
    public partial class ShowLogTable : Form
    {
        DataTable VisualData = new DataTable("myLog");
        public ShowLogTable()
        {
            InitializeComponent();

        }
        internal void SyncDataTxt(DataTable myData)
        {
            try
            {
                VisualData.Merge(myData);
                VisualData.Columns.Remove("ID");
                BindingSource SBind = new BindingSource();
                SBind.DataSource = VisualData;
                dataView.DataSource = VisualData;
                dataView.DataSource = SBind;
                dataView.Refresh();
            }
            catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
