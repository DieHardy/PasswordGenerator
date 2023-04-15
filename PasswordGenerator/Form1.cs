using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string numbers = "0123456789";
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string symbols = @"`~!@#$%^&*()–_=+[{}]\|;:‘“,./<>?";
        private void button1_Click(object sender, EventArgs e)
        {
            string parameters = "";
            int counterParameters = 0;
            int lengthPassword = 0;
            try
            {
                lengthPassword = Int32.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("You need to type a number!");
                textBox1.Text = "";
            }
            if (checkBox1.Checked == true)
            {
                parameters += lowercase;
                counterParameters += lowercase.Length;
            }
            if (checkBox2.Checked == true)
            {
                parameters += uppercase;
                counterParameters += uppercase.Length;
            }
            if (checkBox3.Checked == true)
            {
                parameters += numbers;
                counterParameters += numbers.Length;
            }
            if (checkBox4.Checked == true)
            {
                parameters += symbols;
                counterParameters += symbols.Length;
            }
            Random rnd = new Random();
            if (lengthPassword == 0)
            {
                MessageBox.Show("You can`t create a password with 0 symbols!");
                textBox2.Text = "";
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
            {
                MessageBox.Show("Choose at least one of the parameter!");
                textBox2.Text = "";
            }
            else
            {
                textBox2.Text = "";

                for (int i = 0; i < lengthPassword; i++)
                {
                    textBox2.Text += parameters[rnd.Next(0, counterParameters)]; ;
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (Object)textBox2.Text);
        }
    }
}
