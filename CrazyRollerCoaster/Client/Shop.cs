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
    public partial class Shop : Form
    {
        Account account = new Account();
        sql sql = new sql();    
        public Shop(Account acc)
        {
            InitializeComponent();
            account = acc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hours = 0;
            switch (comboBoxStatus.Text)
            {
                case "Standard": hours = 5;
                    break;
                case "VIP":
                    hours = 10;
                    break;
                case "Platinum":
                    hours = 24;
                    break;

                default:
                    break;
            }

            sql.CreateTicket(account.Id,comboBoxAge.SelectedItem.ToString(),comboBoxType.SelectedItem.ToString(), comboBoxStatus.SelectedItem.ToString(), hours);
        }
    }
}
