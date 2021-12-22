using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRollerCoaster.Admin
{
    public partial class HistroryShop : Form
    {
        sql sql = new sql();
        public HistroryShop()
        {
            InitializeComponent();
        }

        private void HistroryShop_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.AllShop();
        }
    }
}
