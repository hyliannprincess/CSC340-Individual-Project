using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PizzaDeliverySystem
{
    internal class Order
    {
        int status;
        string ID;
        DateTime date;
        double total;
        string email;

        public Order(int status, DateTime date, double total, string email)
        {
            this.status = status;
            this.date = date;
            this.total = total;
            this.email = email;
        }

        public string getEmail()
        {
            return email;
        }
        public int getStatus()
        {
            return status;
        }

        public string getID()
        {
            return ID;
        }

        public DateTime getDate()
        {
            return date;
        }

        public double getTotal()
        {
            return total;
        }
        public static void createOrder(Order newOrder)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO adams_order (total,dateplaced,email) VALUES (@utotal, @udate, @uemail)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@utotal", newOrder.getTotal());
                cmd.Parameters.AddWithValue("@udate", newOrder.getDate());
                cmd.Parameters.AddWithValue("@uemail", newOrder.getEmail());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
        //checks order status
        public static int checkOrderStatus(string ID)
        {
            int status = -1;
            
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT status FROM adams_order WHERE orderNum=@orderID";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@orderID", ID);

                MySqlDataReader myReader = cmd.ExecuteReader();
                if(myReader.Read()){
                    status = myReader.GetInt32("status");
                    
                    myReader.Close();
                    return status;
                }
                else
                {
                    myReader.Close();
                    return status;
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
            conn.Close();
            Console.WriteLine("Done.");
        }

        //check if order ID exists
        public static bool checkOrderID(string orderNum)
        {
            string s = orderNum;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM adams_member WHERE ID=@orderN";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@orderN", s);
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

        public static string checkOrderEmail(string email)
        {
            string info = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM adams_order WHERE email=@uemail";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@uemail", email);
                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {

                    if (myReader.Read())
                    {
                        string orderNum = myReader["orderNum"].ToString();
                        string orderDate = myReader["datePlaced"].ToString();
                        string orderTotal = myReader["total"].ToString();

                        info = $"Order #{orderNum} -  Total: {orderTotal} Date Placed: {orderDate}\n";
                        return info;
                    }
                    else
                    {
                        return info;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return info;

        }
    }


}
