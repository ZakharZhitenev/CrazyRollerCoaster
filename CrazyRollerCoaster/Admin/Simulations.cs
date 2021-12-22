using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRollerCoaster.Admin
{
    public partial class Simulations : Form
    {
        sql sql = new sql();    
        public Simulations()
        {
            InitializeComponent();
        }


        private bool working = false;
        private int countUser = 0;


        public void SimpleGenerateUser()
        {
            string id,login, password, name, surname;

            string[] Arrlogin = { "Justia", "Jemmad", "Juniyan", "Onarche", "Velanial", "Letteryn", "Istassi", "Unaalie", "Deli", "Astin" };
            string[] Arrpassword = { "Idantaguad", "Shanhaaaaaaa", "Nevannyand", "Lehanasyaako", "Ukiordelian", "Aneyanethan", "Bruceanuelia", "Landraghere" };
            string[] Arrname = { "Максим", "Илья", "Ника", "Алиса", "Мия", "Кирилл", "Даниил", "Вадим", "Алексей", "Тимофей", "Мария", "Фёдор" };
            string[] Arrsurname = { "Михайлова", "Попов", "Алчевский", "Колесников", "Быков", "Марочко", "Житар", "Червоний", "Пономаренко", "Носков" };

            Random random = new Random();

            while (working)
            {
                id = random.Next(1000, 99999).ToString();
                login = Arrlogin[random.Next(0, Arrlogin.Length - 1)];
                password = Arrpassword[random.Next(0, Arrpassword.Length - 1)];
                name = Arrname[random.Next(0, Arrname.Length - 1)];
                surname = Arrsurname[random.Next(0, Arrsurname.Length - 1)];


                countUser++;

                
                label1.Invoke(new Action(() => label1.Text = countUser.ToString()));
                sql.RegUser(id,login,password,name,surname);

                Thread.Sleep(1000);

            }



        }




        private void Start()
        {
            working = true;
            Task.Run(() => SimpleGenerateUser());
        }

        private void Stop()
        {
            working = false;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {

            Start();

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop();

        }

    }
}
