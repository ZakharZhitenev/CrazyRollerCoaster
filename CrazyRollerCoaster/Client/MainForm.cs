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
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        Account account = new Account();
        DataTable data = new DataTable();
        sql sql = new sql();    
        public MainForm(string login)
        {
            InitializeComponent();
            data = sql.GetClient(login);
            account.Id = data.Rows[0][0].ToString();
            account.Login = data.Rows[0][1].ToString();
            account.Name = data.Rows[0][3].ToString();
            account.Surname = data.Rows[0][4].ToString();

        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelForms.Controls.Add(childForm);
            this.panelForms.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.Gray;
                    currentButton.ForeColor = Color.Black;
                    currentButton.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelButtons.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.White;
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                }
            }
        }




        private void buttonProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Profile(account), sender);
        }

        private void buttonAttract_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Attract(account), sender);
        }

        private void buttonShop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Shop(account), sender);
        }

        private void buttonTicket_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ticket(account), sender);
        }
    }
}
