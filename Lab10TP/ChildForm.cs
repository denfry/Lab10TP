using System;
using System.Drawing;
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

            richTextBox = new RichTextBox();
            richTextBox.ReadOnly = false;
            richTextBox.Multiline = true;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.Controls.Add(richTextBox);

            this.StatusStrip = new StatusStrip();
            this.Controls.Add(StatusStrip);

            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
            statusLabel.Text = "No file opened";
            StatusStrip.Items.Add(statusLabel);
        }
        public string richTextBoxText
        {
            set { richTextBox.Text = value; }
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
