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
    public partial class Attracrions : Form
    {
        sql sql = new sql();
        public Attracrions()
        {
            InitializeComponent();
        }

        private void Attracrions_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.AllAttractions();
        }
    }
}
