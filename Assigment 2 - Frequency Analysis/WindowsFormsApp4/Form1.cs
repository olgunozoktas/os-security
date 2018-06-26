using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public List<LibraryKey> cipherText = new List<LibraryKey>();
        public List<String> usedKey = new List<String>();
        public List<LibraryKey> keys = new List<LibraryKey>();
        public List<String> sentencesBeforeChanged = new List<String>();
        public List<String> messageRecovered = new List<String>();
        public bool f;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            keys.Add(new LibraryKey("a", "8.12"));
            keys.Add(new LibraryKey("b", "1.49"));
            keys.Add(new LibraryKey("c", "2.71"));
            keys.Add(new LibraryKey("d", "4.32"));
            keys.Add(new LibraryKey("e", "12.02"));
            keys.Add(new LibraryKey("f", "2.30"));
            keys.Add(new LibraryKey("g", "2.03"));
            keys.Add(new LibraryKey("h", "5.92"));
            keys.Add(new LibraryKey("i", "7.31"));
            keys.Add(new LibraryKey("j", "0.10"));
            keys.Add(new LibraryKey("k", "0.69"));
            keys.Add(new LibraryKey("l", "3.98"));
            keys.Add(new LibraryKey("m", "2.61"));
            keys.Add(new LibraryKey("n", "6.95"));
            keys.Add(new LibraryKey("o", "7.68"));
            keys.Add(new LibraryKey("p", "1.82"));
            keys.Add(new LibraryKey("q", "0.11"));
            keys.Add(new LibraryKey("r", "6.02"));
            keys.Add(new LibraryKey("s", "6.28"));
            keys.Add(new LibraryKey("t", "9.10"));
            keys.Add(new LibraryKey("u", "2.88"));
            keys.Add(new LibraryKey("v", "1.11"));
            keys.Add(new LibraryKey("w", "2.09"));
            keys.Add(new LibraryKey("x", "0.17"));
            keys.Add(new LibraryKey("y", "2.11"));
            keys.Add(new LibraryKey("z", "0.07"));

            libraryNameToolStripMenuItem.Text = "Library Name: Default(English)";

            //MessageBox.Show("Size of list is: " + keys.Count.ToString());
            //Bubble Sort to arrange the list
            for (int i = 0; i < keys.Count; i++)
            {
                for (int j = 0; j < keys.Count; j++)
                {
                    if (float.Parse(keys[j].frequency) < float.Parse(keys[i].frequency))
                    {
                        LibraryKey temp = keys[j];
                        keys[j] = keys[i];
                        keys[i] = temp;
                    }
                }
            }

            for (int i = 0; i < keys.Count; i++)
            {
                /*this.chart1.Series["Letter"].Points.AddXY(keys[i].keyword, float.Parse(keys[i].frequency));*/
                dataGridView1.Columns.Add(keys[i].keyword, keys[i].keyword);
                dataGridView1.Rows[0].Cells[i].Value = keys[i].frequency;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //dataGridView2.Columns.Clear();
            //dataGridView2.Rows.Clear();

            if (f)
            {
                MessageBox.Show("You already gave cipherText before");
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("You have to enter chiper text to continue!!!");
                return;
            }

            String value = textBox1.Text;
            bool exist = false;
            int count;
            for (int i = 0; i < value.Length; i++)
            {
                count = 0;
                for (int j = 0; j < value.Length; j++)
                {

                    if (value[i].Equals("'") || value[i].Equals(",") || value[i].Equals(".") || value[i].Equals('"') ||
                        value[i].Equals(";") || value[i].Equals("  ") || value[i].Equals(' ') || value[i].Equals("|") ||
                        value[i].Equals(',') || value[i].Equals(" '"))
                    {
                        exist = true; //to make sure that statement is true
                        break;
                    }

                    exist = checkIfKeyExists(value[i].ToString());
                    //MessageBox.Show("Exist: " + exist);
                    if (exist == true)
                    {
                        //MessageBox.Show(value[i].ToString() + " is exist in the library");
                        break;
                    }
                    else
                    {
                        if (value[i].ToString() == value[j].ToString())
                        {
                            count++;
                        }
                    }
                }
                if (!exist)
                {
                    usedKey.Add(value[i].ToString());
                    cipherText.Add(new LibraryKey(value[i].ToString(), count.ToString()));
                }
                exist = false;
                //MessageBox.Show(value[i].ToString() + " is counted as " + count);
                //break;
            }

            //To Add unadded items like z is 0 and etc...
            /*bool existInCipherText;
            for (int i = 0; i < keys.Count; i++)
            {
                existInCipherText = false;
                for (int j = 0; j < cipherText.Count; j++)
                {

                    if (cipherText[j].keyword == keys[i].keyword.ToUpper() || cipherText[j].keyword == keys[i].keyword.ToLower())
                    {
                        existInCipherText = true;
                        break;
                    }
                }

                if (!existInCipherText)
                {
                    cipherText.Add(new LibraryKey(keys[i].keyword.ToUpper(), "0"));
                }
            }*/


            //Bubble Sort to order them desc order
            for (int i = 0; i < cipherText.Count; i++)
            {
                for (int j = 0; j < cipherText.Count; j++)
                {
                    if (float.Parse(cipherText[j].frequency) < float.Parse(cipherText[i].frequency))
                    {
                        LibraryKey temp = cipherText[j];
                        cipherText[j] = cipherText[i];
                        cipherText[i] = temp;
                    }
                }
            }

            for (int i = 0; i < cipherText.Count; i++)
            {
                dataGridView2.Columns.Add(cipherText[i].keyword, cipherText[i].keyword);
                dataGridView2.Rows[0].Cells[i].Value = cipherText[i].frequency;
            }

            f = true;
            fillComboBoxes();
            richTextBox1.Text = textBox1.Text;
            showCipherText();
        }

        public void showCipherText()
        {
            String cipher = "";
            for (int i = 0; i < cipherText.Count; i++)
            {
                cipher += cipherText[i].keyword;
            }
            //MessageBox.Show("Cipher Text is:\n" + cipher);
        }


        public bool checkIfKeyExists(String value)
        {
            for (int i = 0; i < usedKey.Count; i++)
            {
                if (usedKey[i] == value.ToUpper() || usedKey[i] == value.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public void fillComboBoxes()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                comboBox2.Items.Add(keys[i].keyword);
            }

            for(int i= 0; i<cipherText.Count; i++)
            {
                comboBox1.Items.Add(cipherText[i].keyword);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            List<Char> characterInCipher = new List<char>();

            String replaceWith = comboBox2.SelectedItem.ToString();
            String value = comboBox1.SelectedItem.ToString();
            String cipher = richTextBox1.Text;
            String newCipher = "";

            /* To check if the key is used before or no */
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].keyword.Equals(replaceWith) && keys[i].used == true)
                {
                    MessageBox.Show("You cannot select this letter again!");
                    return;
                }
            }

            /* To check if the key is used before or no */
            for (int i = 0; i < cipherText.Count; i++)
            {
                if (cipherText[i].keyword.Equals(value) && cipherText[i].used == true)
                {
                    MessageBox.Show("You cannot select this letter again!");
                    return;
                }
            }

            sentencesBeforeChanged.Add(cipher);

            for (int i = 0; i < cipher.Length; i++)
            {
                characterInCipher.Add(cipher[i]);
            }

            for (int i = 0; i < characterInCipher.Count; i++)
            {
                if (characterInCipher[i].Equals(value[0]))
                {
                    characterInCipher[i] = replaceWith[0];
                }
                newCipher += characterInCipher[i];
            }

            //MessageBox.Show("New Cipher is: \n" + newCipher);
            richTextBox1.Text = null;
            richTextBox1.Text = newCipher;

            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].keyword.Equals(replaceWith))
                {
                    keys[i].used = true;
                }
            }

            for (int i = 0; i < cipherText.Count; i++)
            {
                if (cipherText[i].keyword.Equals(value))
                {
                    //MessageBox.Show("Value found at " + i);
                    cipherText[i].used = true;
                }
            }

            String added = value + " - " + replaceWith;
            listBox1.Items.Add(added);

        }
        //Not used
        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Not Used

        private void button3_Click(object sender, EventArgs e)
        {
            Char from = ' ';
            Char to = ' ';
            String valueOfRichText = richTextBox1.Text.ToString();
            List<Char> valueOfRichTextChars = new List<char>();
            int indexSelectedSentence = 0;

            if (this.listBox1.SelectedIndex >= 0)
            {
                String selectedItem = this.listBox1.Items[this.listBox1.SelectedIndex].ToString();
                to = selectedItem[0];//S
                from = selectedItem[4]; //e
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);


                //MessageBox.Show("The selected item is: " + from + " " + to);
            }

            for (int i = 0; i < valueOfRichText.Length; i++)
            {
                Char getCurrentvValue = valueOfRichText[i];
                if (getCurrentvValue.Equals(from))
                {
                    getCurrentvValue = to;
                }
                valueOfRichTextChars.Add(getCurrentvValue);
            }

            String replace = "";

            for (int i = 0; i < valueOfRichTextChars.Count; i++)
            {
                replace += valueOfRichTextChars[i];
            }

            richTextBox1.Text = null;
            richTextBox1.Text = replace;

            //Reset item in keys
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].keyword.Equals(from.ToString()))
                {
                    keys[i].used = false;
                }
            }

            //Reset item in chipherText
            for (int i = 0; i < cipherText.Count; i++)
            {

                if (cipherText[i].keyword.Equals(to.ToString()))
                {
                    cipherText[i].used = false;
                }
            }

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void newLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 libraryForm = new Form2();
            List<String> message = new List<string>();
            List<String> frequency = new List<string>();

            bool isActivated = true;
            libraryForm.ShowDialog(this);
            String libraryName = "";
            while (isActivated)
            {
                isActivated = libraryForm.isActivated();
                //MessageBox.Show("Is Activated: " + isActivated);
                if (!isActivated)
                {
                    message = libraryForm.returnText();
                    libraryName = libraryForm.libraryName();
                    libraryForm.Close();
                    libraryForm.Dispose();
                }
            }

            resetForLibrary();

            String frequencyAdded = "";
            for (int i = 0; i < message[1].Length; i++)
            {
                if (message[1][i].Equals(','))
                {
                    frequency.Add(frequencyAdded);
                    frequencyAdded = "";
                }
                else if (i == message[1].Length - 1)
                {
                    frequencyAdded += message[1][i];
                    frequency.Add(frequencyAdded);
                }
                else
                {
                    frequencyAdded += message[1][i];
                }
            }

            for (int i = 0; i < message[0].Length; i++)
            {
                keys.Add(new LibraryKey(message[0][i].ToString(), frequency[i]));
            }

            fillDataGrid();
            libraryNameToolStripMenuItem.Text = "Library Name: " + libraryName;

            //TODO: Others..............
        }

        public void ResetAll()
        {
            usedKey.Clear();
            cipherText.Clear();
            textBox1.Text = "";
            richTextBox1.Text = "";
            listBox1.Items.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 0; i < keys.Count; i++)
            {
                keys[i].used = false;
            }
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            f = false;
        }

        public void resetForLibrary()
        {
            ResetAll();
            keys.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        public void fillDataGrid()
        {
            //Bubble Sort to arrange the list
            for (int i = 0; i < keys.Count; i++)
            {
                for (int j = 0; j < keys.Count; j++)
                {
                    if (float.Parse(keys[j].frequency) < float.Parse(keys[i].frequency))
                    {
                        LibraryKey temp = keys[j];
                        keys[j] = keys[i];
                        keys[i] = temp;
                    }
                }
            }

            for (int i = 0; i < keys.Count; i++)
            {
                //MessageBox.Show("Letter is: " + keys[i].keyword + "\n Frequency is: " + keys[i].frequency);
                /*this.chart1.Series["Letter"].Points.AddXY(keys[i].keyword, float.Parse(keys[i].frequency));*/
                dataGridView1.Columns.Add(keys[i].keyword, keys[i].keyword);
                dataGridView1.Rows[0].Cells[i].Value = keys[i].frequency;
            }
        }

        /*private void button3_Click(object sender, EventArgs e)
        {

        }

        /*private void button2_Click(object sender, EventArgs e)
        {

        }*/
    }

    public class LibraryKey
    {
        public bool used { get; set; }
        public String keyword { get; set; }
        public String frequency { get; set; }

        public LibraryKey(String keyword, String frequency)
        {
            this.keyword = keyword;
            this.frequency = frequency;
            this.used = false;
        }
    }
}


