using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using K4os.Compression.LZ4.Internal;

namespace PizzaDeliverySystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel2.Hide();
            panel3.Hide();  
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel7.Hide();
            panel5.Hide();
            panel6.Hide();
            panel8.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool notExist = Member.checkEmail(textBox3.Text);
            if (Member.IsValidEmail(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                string email = textBox3.Text;


                Member mem = new Member(textBox1.Text, textBox6.Text, textBox8.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                mem.updateMember(email, mem);
                string message = "Member profile has been updated!";
                string title = "Success";
                MessageBox.Show(message, title);
            }
            else
            {
                string message = "Invalid input. Please enter valid data";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel8.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel7.Show();
            panel8.Hide();
            panel5.Hide();
            panel6.Hide();
            panel3.Hide();
            panel2.Hide();
        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Show();
            panel5.Hide();
            panel7.Hide();
            panel3.Hide();
            panel2.Hide();
            panel8.Hide();
            

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string id = textBox12.Text;
            int stat = Order.checkOrderStatus(id);

            if (stat == 1)
            {
                label15.Text = "In Progress";
            }
            else if (stat == 2)
            {
                label15.Text = "Out for Delivery";
            }
            else if (stat == 3)
            {
                label15.Text = "Delivered";
            }
            else
            {
                label15.Text = "Status Unavailable";
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel7.Hide();
            panel8.Show();
            panel5.Hide();
            panel6.Hide();
            panel3.Hide();
            panel2.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            double total;
            if (checkBox1.Checked)
            {
                total = 10.99;
            }
            else if (checkBox3.Checked)
            {
                total = 12.99;
            }
            else if (checkBox2.Checked)
            {
                total = 16.99;
            }
            else
            {
                total = 0;
            }
            panel2.Show();
            label29.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            panel5.Show();
            panel2.Hide();
            panel3.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();

            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Member.IsValidEmail(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox13.Text))
            {
                string mFName = textBox17.Text;
                string mLName = textBox7.Text;
                string maddress = textBox13.Text;
                string memail = textBox15.Text;
                string mphone = textBox16.Text;
                string mpassword = textBox14.Text;

                Member mem = new Member(mFName, mLName, maddress, memail, mphone, mpassword);
                


                mem.createMember(mem);
                string message = "You are now a Member! Thank you for joining!";
                string title = "Success";
                MessageBox.Show(message, title);
            }
            else
            {
                string message = "Invalid input. Please enter valid data";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel7.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox20.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrWhiteSpace(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox18.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                DateTime date = DateTime.Now;
                string email = textBox11.Text;
                double total;
                if (checkBox1.Checked)
                {
                    total = 10.99;
                }
                else if (checkBox3.Checked)
                {
                    total = 12.99;
                }
                else if (checkBox2.Checked)
                {
                    total = 16.99;
                }
                else
                {
                    total = 0;
                }
                Order order = new Order(1,date,total,email);
                Order.createOrder(order);
                string message = "Order Placed!";
                string title = "Success";
                MessageBox.Show(message, title);
            }
            else
            {
                string message = "Error. Please Try Again.";
                string title = "Success";
                MessageBox.Show(message, title);
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox21.Text = "";
            textBox21.AppendText(Order.checkOrderEmail(textBox5.Text));
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
