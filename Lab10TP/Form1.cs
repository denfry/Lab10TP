using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Lab10TP
{
    public partial class MainForm : Form
    {
        ChildForm1 childForm1 = new ChildForm1();
        ChildForm2 childForm2 = new ChildForm2();
        ChildForm3 childForm3 = new ChildForm3();
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int formWidth = (this.ClientSize.Width - 10) / 2;
            int formHeight = (this.ClientSize.Height - 10) / 2;
            int formHeightPicture = this.ClientSize.Height - 10;
            int form1LocationX = 0;
            int form1LocationY = 0;
            int form2LocationX = 0;
            int form2LocationY = 200;

            
            childForm1.MdiParent = this;
            childForm1.Text = "Форма 1";
            childForm1.Size = new Size(formWidth, formHeight);
            childForm1.Location = new Point(form1LocationX, form1LocationY);
            childForm1.Show();

            
            childForm2.MdiParent = this;
            childForm2.Text = "Форма 2";
            childForm2.Size = new Size(formWidth, formHeight);
            childForm2.Location = new Point(form2LocationX, form2LocationY);
            childForm2.Show();

            
            childForm3.MdiParent = this;
            childForm3.Text = "Форма 3";
            childForm3.SetEditable(true);
            childForm3.Size = new Size(formWidth, formHeightPicture);
            childForm3.Location = new Point(formWidth, 0);
            childForm3.Show();

            childForm1.OpenMenuItem.Click += ChildForm1_OpenMenuItem_Click;
            childForm1.SaveMenuItem.Click += ChildForm1_SaveMenuItem_Click;
            childForm1.richTextBox1.Refresh();

            childForm2.OpenMenuItem.Click += ChildForm2_OpenMenuItem_Click;
            childForm2.SaveMenuItem.Click += ChildForm2_SaveMenuItem_Click;
            childForm2.richTextBox2.Refresh();

            childForm3.OpenMenuItem.Click += ChildForm3_OpenMenuItem_Click;
            childForm3.SaveMenuItem.Click += ChildForm3_SaveMenuItem_Click;
            
        }
        private void ChildForm1_OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                childForm1.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                childForm1.SetStatus(openFileDialog.FileName);
                childForm1.richTextBox1.Refresh();
            }
        }

        private void ChildForm1_SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, childForm1.richTextBox1.Text);
                childForm1.SetStatus("Файл сохранен: " + saveFileDialog.FileName);
                childForm1.richTextBox1.Clear();
            }
        }
        private void ChildForm2_OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                childForm2.richTextBox2.Text = File.ReadAllText(openFileDialog.FileName);
                childForm2.SetStatus(openFileDialog.FileName);
                childForm2.richTextBox2.Refresh();
            }
        }

        private void ChildForm2_SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, childForm2.richTextBox2.Text);
                childForm2.SetStatus("Файл сохранен: " + saveFileDialog.FileName);
                childForm2.richTextBox2.Clear();
            }
        }
        private void ChildForm3_OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                childForm3.pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                childForm3.SetStatus(openFileDialog.FileName);
                childForm3.pictureBox1.Refresh();
            }
        }
        
        private void ChildForm3_SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Изображения (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                childForm3.SetStatus("Файл сохранен: " + saveFileDialog.FileName);
                childForm3.ClearPicture();
            }
        }
    }
}
