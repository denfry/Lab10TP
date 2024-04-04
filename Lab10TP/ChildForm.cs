using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10TP
{
    public partial class ChildForm : Form
    {
        private string fileName;

        public ChildForm()
        {
            InitializeComponent();
            InitializeComponents();
        }

        public void InitializeComponents()
        {
            this.Size = new Size(400, 300);

            pictureBox1 = new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.MouseHover += PictureBox_MouseHover;
            this.Controls.Add(pictureBox1);

            textBox1 = new TextBox();
            textBox1.Multiline = true;
            textBox1.Dock = DockStyle.Fill;
            textBox1.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(textBox1);

            this.StatusStrip = new StatusStrip();
            this.Controls.Add(StatusStrip);

            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
            statusLabel.Text = "No file opened";
            StatusStrip.Items.Add(statusLabel);
        }

        public void SetEditable(bool editable)
        {
            if (editable)
            {
                pictureBox1.MouseDown += PictureBox_MouseDown;
            }
            else
            {
                pictureBox1.MouseDown -= PictureBox_MouseDown;
            }
        }

        public void ClearPicture()
        {
            pictureBox1.Image = null;
        }

        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox1, "Editable Picture");
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Реализация рисования на pictureBox
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawEllipse(new Pen(Color.Red, 2), e.X, e.Y, 50, 50);
            g.Dispose();
        }

        public void SetStatus(string fileName)
        {
            this.fileName = fileName;
            ((ToolStripStatusLabel)this.StatusStrip.Items[0]).Text = "File: " + fileName;
        }
    }
}
