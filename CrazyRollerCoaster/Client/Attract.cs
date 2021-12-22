using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRollerCoaster.Client
{
    public partial class Attract : Form
    {
        Account account = new Account();
        DataTable dataTick = new DataTable();
        DataTable dataAttract = new DataTable();
        sql sql = new sql();
        public Attract(Account acc)
        {
            InitializeComponent();
            account = acc;
            dataTick = sql.GetTicket(account.Id);
            
            for (int i = 0; i < dataTick.Rows.Count; i++)
            {
                comboBox1.Items.Add(dataTick.Rows[i][3]);
            }
        }

        private void addButton(int i, FlowLayoutPanel flw)
        {
            Button but = new Button();
            but.Name = "txtForm" + i;
            but.Tag = dataAttract.Rows[i][0];
            but.Size = new Size(150, 40);
            but.Text = dataAttract.Rows[i][1].ToString();
            but.Click += but_click;
            flw.Controls.Add(but);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataAttract = sql.GetAttract(comboBox1.SelectedItem.ToString());
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < dataAttract.Rows.Count; i++)
            {
                //flowLayoutPanel1.Controls.Add(flw);
                addButton(i, flowLayoutPanel1);
            }
        }

        private void but_click(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var iduser = account.Id;
            var idticket = dataTick.Rows[comboBox1.SelectedIndex][0].ToString();
            var idAttract = but.Tag.ToString();
            if(sql.CreateVisit(iduser, idticket, idAttract))
            {
                MessageBox.Show("Вы посетили аттракцион "+ but.Text);
            }
        }
    }
}
