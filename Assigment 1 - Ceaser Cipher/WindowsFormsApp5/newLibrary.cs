using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class newLibrary : Form
    {
        public bool Active = true;

        public newLibrary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Active = false;
                this.Close();
            }
        }

        public List<Char> getLowers()
        {
            List<Char> lowerLetters = new List<Char>();
            String library = textBox1.Text;

            for(int i=0; i<library.Length; i++)
            {
                Char letter = library[i];
                lowerLetters.Add(letter);
            }

            return lowerLetters;
        }


        public List<Char> getUppers()
        {
            List<Char> upperLetters = new List<Char>();
            String library = textBox2.Text;

            for (int i = 0; i < library.Length; i++)
            {
                Char letter = library[i];
                upperLetters.Add(letter);
            }

            return upperLetters;
        }

        public String getAlphabet()
        {
            return textBox3.Text;
        }

        /*private void button1_Click(object sender, EventArgs e)
        {

        }*/

        public bool getActive()
        {
            return Active;
        }
    }
}
