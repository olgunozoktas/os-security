using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {

        private bool isActive = true;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public List<String> returnText()
        {
            //String upper = textBox1.Text;
            String lower = textBox1.Text;
            String frequencies = textBox2.Text;
            List<String> list = new List<String>();
            //list.Add(upper);
            list.Add(lower);
            list.Add(frequencies);
            return list;
        }

        public String libraryName()
        {
            return textBox3.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                isActive = false;
                MessageBox.Show("You Clicked Me");
                this.Close();
            }
            MessageBox.Show("You have to fill all the boxes");

        }

        public bool isActivated()
        {
            return isActive;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            isActive = false;
            MessageBox.Show("You Clicked Me");
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                isActive = false;
                MessageBox.Show("You Clicked Me");
                this.Close();
            }else
            MessageBox.Show("You have to fill all the boxes");
        }
    }
}
