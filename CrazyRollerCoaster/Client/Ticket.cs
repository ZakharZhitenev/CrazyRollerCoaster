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
    public partial class Ticket : Form
    {
        Account account = new Account();
        DataTable data = new DataTable();
        sql sql = new sql();
        public Ticket(Account acc)
        {
            InitializeComponent();
            account = acc;
            data = sql.GetTicket(account.Id);
            //MessageBox.Show(data.Rows[0][1].ToString());
        }

        private void addLabelTicket(int i, FlowLayoutPanel flow)
        {
            var datenow = DateTime.Now;
            var diff = Convert.ToDateTime(data.Rows[i][6]) - datenow;

            Label lbl = new Label();
            lbl.Name = "lbl" + data.Rows[i][0];
            lbl.Font = new Font(lbl.Font.Name, 14);
            lbl.Text = "Ваш билет " + data.Rows[i][0].ToString() + " закончится через " + diff.Hours + " часов";

            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.AutoSize = true;
            //lbl.Dock = DockStyle.Fill;
            //lbl.Dock = DockStyle.Top;
            flow.Controls.Add(lbl);
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                //flowLayoutPanel1.Controls.Add(flw);
                addLabelTicket(i, flowLayoutPanel1);
            }
        }
    }
}
