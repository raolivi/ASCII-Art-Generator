using System.Xml.Schema;

namespace ASCIIFY_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                }
                catch (Exception error)  
                {
                    MessageBox.Show("Error: Select an image file!");
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Calls BitmapAscii
            BitmapASCII asciiObj = new BitmapASCII();

            //Adds the string generated in Asciitize to another string and adds that to rich text box
            string ascii = asciiObj.Asciitize((Bitmap)pictureBox1.Image, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            richTextBox1.Text = ascii;

            if (numericUpDown1.Value == 0 || numericUpDown2.Value == 0)
            {
                MessageBox.Show("Error: kernal cannot equal 0!");
            }
        }
    }
}