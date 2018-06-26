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
    public partial class Form1 : Form
    {


        public List<Char> library = new List<Char>();
        public List<Char> libraryUpper = new List<Char>();
        public List<Char> lowerCaseEncryptionLibrary = new List<Char>();
        public List<Char> upperCaseEncryptionLibrary = new List<Char>();
        public List<Char> encryptionLibrary = new List<Char>();

        public Form1()
        {
            InitializeComponent();

           for(char letter='a'; letter<='z'; letter++)
            {
                library.Add(letter);
            }

           for(char letter='A'; letter<='Z'; letter++)
            {
                libraryUpper.Add(letter);
            }

            alphabetToolStripMenuItem.Text = "Library: Default(English)";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            lowerCaseEncryptionLibrary.Clear();
            upperCaseEncryptionLibrary.Clear();

            if(textBox1.Text == "")
            {
                MessageBox.Show("You have to enter plain text to encrypt");
                return;
            }

            if(numericUpDown1.Value == (decimal)0)
            {
                MessageBox.Show("Shift cannot be 0");
                return;
            }

            decimal value = numericUpDown1.Value;
            int libraryLength = library.Count;

            List<Char> library2 = library;
            List<Char> library3 = libraryUpper;

            string key = textBox1.Text;
            string encrypted = "";

            int counter = 0;
            for(int i = 0; i<key.Length; i++)
            {
                counter = 0;
                Char character = key[i];

                if(character == ' ')
                {
                    encrypted += " ";
                    continue;
                }

                int index = library2.IndexOf(character);
                int tempIndex = index;

                while(counter != value)
                {
                    tempIndex++;
                    if(tempIndex >= libraryLength)
                    {
                        tempIndex = 0;
                    }

                    counter += 1;
                }

                Char getChar = library[tempIndex];
                encrypted += getChar;

            }

            numericUpDown2.Value = numericUpDown1.Value;
            textBox2.Text = encrypted;
            textBox1.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            lowerCaseEncryptionLibrary.Clear();
            upperCaseEncryptionLibrary.Clear();

            if(textBox2.Text == "")
            {
                MessageBox.Show("You have to enter plain text to encrypt");
                return;
            }

            if(numericUpDown2.Value == (decimal)0)
            {
                MessageBox.Show("Shift cannot be 0");
                return;
            }

            decimal value = numericUpDown1.Value;
            int libraryLength = library.Count;

            List<Char> library2 = library;
            List<Char> library3 = libraryUpper;

            string key = textBox2.Text;
            MessageBox.Show(key);
            string decrypted = "";

            int counter = 0;
            for (int i = 0; i < key.Length; i++)
            {
                counter = 0;
                Char character = key[i];
            
                if(character == ' ')
                {
                    decrypted += " ";
                    continue;
                }

                int index = library2.IndexOf(character);
                int tempIndex = index;

                while (counter != value)
                {
                
                    if (tempIndex == 0)
                    {
                        tempIndex = libraryLength;
                    }

                    tempIndex--;

                    counter++;
                }

                Char getChar = library[tempIndex];
                decrypted += getChar;

            }

            numericUpDown2.Value = numericUpDown1.Value;
            textBox1.Text = decrypted;
        }

        private void newLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newLibrary open = new newLibrary();
            open.ShowDialog();

            library.Clear();
            libraryUpper.Clear();
            bool active = true;
            String alphabet = "Library: ";
            while (active)
            {
                active = open.getActive();
                if (!active)
                {
                    library = open.getLowers();
                    libraryUpper = open.getUppers();
                    alphabet = alphabet + open.getAlphabet();

                }

                open.Dispose();

                String message = "";
                String message2 = "";
                for (int i = 0; i < library.Count; i++)
                {
                    message += library[i].ToString();
                    message2 += libraryUpper[i].ToString();
                }

                alphabetToolStripMenuItem.Text = alphabet.ToString();
                MessageBox.Show("Lower Case Library: " + message + "\n Upper Case Library: " + message2);
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            library.Clear();
            libraryUpper.Clear();
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                library.Add(letter);
            }

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                libraryUpper.Add(letter);
            }

            alphabetToolStripMenuItem.Text = "Library: Default(English)";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }
    }
}
