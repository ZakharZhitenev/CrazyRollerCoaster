using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRollerCoaster
{
    class sql
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static MySqlConnection GetDBConnection()
        {
            string host = "c9113991.beget.tech";
            int port = 3306;
            string database = "c9113991_attract";
            string username = "c9113991_attract";
            string password = "Zaxar228";

            return GetDBConnection(host, port, database, username, password);
        }



        MySqlConnection conn = GetDBConnection();



        public bool LoginUser(string login, string password)
        {
            bool flag = false;

            string sql = String.Format("SELECT * FROM visitors WHERE login = @uL AND password = @uP;");
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
            conn.Open();
            MySqlDataReader sqldr = command.ExecuteReader();

            if (sqldr.HasRows)
                flag = true;

            conn.Close();

            return flag;
        }


        public bool RegUser(string id, string login, string password, string name, string surname)
        {

            bool flag = false;


            string sql = String.Format("INSERT INTO visitors(id,name,surname,login,password) VALUES (@uId,@uName, @uSurname, @uLogin,@uPass)");

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uId", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@uLogin", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uPass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@uName", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@uSurname", MySqlDbType.VarChar).Value = surname;

            conn.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                flag = true;
                conn.Close();
            }
            return flag;

        }

        public DataTable GetClient(string login)
        {
            DataTable data = new DataTable();
            data.Clear();
            string sql = String.Format("SELECT * FROM visitors WHERE login = @uLogin ");
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uLogin", MySqlDbType.VarChar).Value = login;
            conn.Open();
            MySqlDataReader sqldr = command.ExecuteReader();
            data.Load(sqldr);

            conn.Close();
            return data;
        }

        public bool CreateTicket(string id_user, string type_age, string type_ticket, string type_attract, int hours)
        {
            Random rnd = new Random();
            bool flag = false;
            var dateStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var dateEnd = DateTime.Now.AddHours(hours).ToString("yyyy-MM-dd HH:mm:ss");
            var id = "tick-" + rnd.Next(1000,9999);



            string sql = String.Format("INSERT INTO ticket_history(id,id_user,type_age,type_ticket,type_attract,dateStart,dateEnd) VALUES (@uId,@id_user,@type_age, @type_ticket, @type_attract,@dateStart,@dateEnd)");

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uId", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = id_user;
            command.Parameters.Add("@type_age", MySqlDbType.VarChar).Value = type_age;
            command.Parameters.Add("@type_ticket", MySqlDbType.VarChar).Value = type_ticket;
            command.Parameters.Add("@type_attract", MySqlDbType.VarChar).Value = type_attract;
            command.Parameters.Add("@dateStart", MySqlDbType.VarChar).Value = dateStart;
            command.Parameters.Add("@dateEnd", MySqlDbType.VarChar).Value = dateEnd;

            conn.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                flag = true;
                conn.Close();
            }
            return flag;

        }


        public DataTable GetTicket(string id)
        {
            var datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable data = new DataTable();
            data.Clear();
            string sql = String.Format("SELECT * FROM ticket_history WHERE id_user = @uId AND dateEnd >@datenow");
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uId", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@datenow", MySqlDbType.VarChar).Value = datenow;
            conn.Open();
            MySqlDataReader sqldr = command.ExecuteReader();
            data.Load(sqldr);

            conn.Close();
            return data;
        }

        public DataTable GetAttract(string type_ticket)
        {
            DataTable data = new DataTable();
            data.Clear();
            string sql = String.Format("SELECT * FROM attractions WHERE type = @utype");
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@utype", MySqlDbType.VarChar).Value = type_ticket;
            conn.Open();
            MySqlDataReader sqldr = command.ExecuteReader();
            data.Load(sqldr);

            conn.Close();
            return data;
        }

        public bool CreateVisit(string idUser, string idTicket,string idAttract)
        {
            Random rnd = new Random();
            bool flag = false;
            var id = rnd.Next(10000,99999);
            var datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            string sql = String.Format("INSERT INTO visits(id,id_user,id_ticket,id_attraction,date_shop) VALUES (@uId,@id_user,@id_ticket, @id_attraction, @date_shop)");

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uId", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = idUser;
            command.Parameters.Add("@id_ticket", MySqlDbType.VarChar).Value = idTicket;
            command.Parameters.Add("@id_attraction", MySqlDbType.VarChar).Value = idAttract;
            command.Parameters.Add("@date_shop", MySqlDbType.VarChar).Value = datenow;


            conn.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                flag = true;
                conn.Close();
            }
            return flag;


        }

        public ArrayList AllClients()
        {
            ArrayList allclients = new ArrayList();
            conn.Open();

            string sql = String.Format("SELECT id,login,name,surname FROM visitors order by name");
            MySqlCommand command = new MySqlCommand(sql, conn);
          
            MySqlDataReader sqldr = command.ExecuteReader();

            if (sqldr.HasRows)
            {
                foreach (DbDataRecord result in sqldr)
                    allclients.Add(result);
                conn.Close();
            }
            


            return allclients;
        }
        public ArrayList AllAttractions()
        {
            ArrayList allclients = new ArrayList();
            conn.Open();

            string sql = String.Format("SELECT * FROM attractions");
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader sqldr = command.ExecuteReader();

            if (sqldr.HasRows)
            {
                foreach (DbDataRecord result in sqldr)
                    allclients.Add(result);
                conn.Close();
            }



            return allclients;
        }


        public ArrayList AllShop()
        {
            ArrayList allclients = new ArrayList();
            conn.Open();

            string sql = String.Format("SELECT * FROM visits");
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader sqldr = command.ExecuteReader();

            if (sqldr.HasRows)
            {
                foreach (DbDataRecord result in sqldr)
                    allclients.Add(result);
                conn.Close();
            }



            return allclients;
        }

    }
}
