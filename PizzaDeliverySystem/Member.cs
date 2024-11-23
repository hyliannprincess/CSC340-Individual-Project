using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;

namespace PizzaDeliverySystem
{
    internal class Member
    {
        string Fname;
        string Lname;
        string address;
        string email;
        string phone;
        string password;
        int cID;

        public Member(string Fname, string Lname, string address, string email, string phone, string password)
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.address = address;
            this.email = email;
            this.phone = phone;
            this.password = password;
        }
        public string getEmail()
        {
            return email;
        }
        public string getFname()
        {
            return Fname;
        }
        public string getLname()
        {
            return Lname;
        }
        public string getAddress()
        {
            return address;
        }
        public int getID()
        {
            return cID;
        }
        public string getPhone()
        {
            return phone;
        }

        public string getPassword()
        {
            return password;
        }

        public string toString()
        {
            return email+" "+Fname+" "+Lname+" "+address+" "+phone+" "+password+" ";
        }

        public void createMember(Member newMember)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO adams_member (Fname, Lname, address, email, phone, password) VALUES (@ufname, @ulname, @uaddress, @uemail, @uphone, @upassword)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ufname", newMember.getFname());
                cmd.Parameters.AddWithValue("@ulname", newMember.getLname());
                cmd.Parameters.AddWithValue("@uaddress", newMember.getAddress());
                cmd.Parameters.AddWithValue("@uemail", newMember.getEmail());
                cmd.Parameters.AddWithValue("@uphone", newMember.getPhone());
                cmd.Parameters.AddWithValue("@upassword", newMember.getPassword());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
        public void updateMember(string email, Member newMember)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE adams_member SET Fname=@ufname, Lname=@ulname, address=@uaddress, email=@uemail, phone=@uphone, password=@upassword WHERE email=@uemail";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ufname", newMember.getFname());
                cmd.Parameters.AddWithValue("@ulname", newMember.getLname());
                cmd.Parameters.AddWithValue("@uaddress", newMember.getAddress());
                cmd.Parameters.AddWithValue("@uphone", newMember.getPhone());
                cmd.Parameters.AddWithValue("@upassword", newMember.getPassword());
                cmd.Parameters.AddWithValue("@uemail", email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        public static bool checkUser(String userData)
        {
            string s = userData;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM adams_member WHERE email=@uemail";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@uemail", s);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    myReader.Close();
                    return false;
                }
                else
                {
                    myReader.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return false;
        }

        public static bool checkEmail(String emailData)
        {
            string s = emailData;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM adams_member WHERE email=@emailname";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@emailname", s);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    myReader.Close();
                    return true;
                }
                else
                {
                    myReader.Close();
                    return false;
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return false;

        }

        public static string ReturnInfo(string username)
        {
            string userInfo = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM adams_member WHERE email = @email";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@email", username);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string email = reader["email"].ToString();
                        string fname = reader["fname"].ToString();
                        string lname = reader["lname"].ToString();
                        string phone = reader["phone"].ToString();
                        string id = reader["ID"].ToString();
                        string Address = reader["Address"].ToString();

                        userInfo = $"Username: {username}\nEmail: {email}\nPhone: {phone}\nFirst Name: {fname}\nLast Name: {lname}\nID: {id}";
                        //MessageBox.Show(userInfo);
                        return userInfo;
                    }
                    else
                    {

                    }

                }
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return userInfo;

        }

        

    }

}
