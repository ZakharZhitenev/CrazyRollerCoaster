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
    public partial class MainAdminForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        public MainAdminForm()
        {
            InitializeComponent();
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
            OpenChildForm(new Clients(), sender);
        }

        private void buttonAttract_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Attracrions(), sender);
        }

        private void buttonTicket_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HistroryShop(), sender);
        }

        private void buttonShop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Simulations(), sender);
        }
    }
}
