using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text= "Безымянный";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.InitialDirectory = "Текстовый файл|*.txt|Текст в формате ртф|*.rtf";
            openFileDialog.FilterIndex= 2;
            openFileDialog.RestoreDirectory = true;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStreamType streamType = openFileDialog.FileName.EndsWith("rtf") ?
                RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
                richTextBox.LoadFile(openFileDialog.FileName, streamType);
                this.Text = openFileDialog.FileName;
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = "c:\\";
            saveFile.Filter = "Текстовый файл|*.txt|Текст в формате ртф|*.rtf";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveFile.FileName);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           foreach(FontFamily var in FontFamily.Families)
           {
                toolStripComboBox.Items.Add(var.GetName(0));
           }
            toolStripComboBox.SelectedIndex = toolStripComboBox.Items.IndexOf(richTextBox.Font.Name);
            DateTime date = DateTime.Today;
            toolStripStatusLabel1.Text = date.ToString("D");
            toolStripStatusLabel2.Text = "Колличество символов: 0 ";
            toolStripStatusLabel3.Text = "Колличество символов без пробелов: 0 ";
        }

        private void цветToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = color.Color;
            }
        }

        private void шрифтToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = font.Font;
            }
        }

        private void toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox.Font = new Font(toolStripComboBox.SelectedItem.ToString(), richTextBox.Font.Size);
        }

        private void toolStripButton1_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = false;
            toolStripButton3.Checked = false;
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            int count = richTextBox.Text.Length;
            toolStripStatusLabel2.Text = "Колличество символов:" + count.ToString();
            int space = richTextBox.Text.Split(' ').Length-1;
            int count2 = count - space;
            toolStripStatusLabel3.Text = "Колличество символов без пробелов:" + count2.ToString();
            
        }
    }
}
