using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRollerCoaster.OtherForm
{
    public partial class Registration : Form
    {
        sql sql = new sql();
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string rndId = rnd.Next(1000,99999).ToString();
            if (textBoxLogin.Text.Length == 0 || textBoxPass.Text.Length == 0 || textBoxName.Text.Length == 0 || textBoxSurname.Text.Length == 0 )
            {
                MessageBox.Show("Поля не должны быть пустыми!");
            }
            else if (sql.RegUser(rndId,textBoxLogin.Text, textBoxPass.Text, textBoxName.Text, textBoxSurname.Text))
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }


        }
    }
}
