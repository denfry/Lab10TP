using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab10TP
{
    public partial class ChildForm1 : Form
    {
        private string fileName;
        public ToolStripMenuItem OpenMenuItem { get; private set; }
        public ToolStripMenuItem SaveMenuItem { get; private set; }
        public ChildForm1()
        {
            InitializeComponent();
            InitializeComponents();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
        }

        public void InitializeComponents()
        {
            richTextBox1.ReadOnly = false;
            richTextBox1.Multiline = true;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            

            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
            statusLabel.Text = "Файл не выбран";
            StatusStrip1.Items.Add(statusLabel);

            ToolStripMenuItem fileMenuItem = new ToolStripMenuItem("Файл");
            OpenMenuItem = new ToolStripMenuItem("Открыть");
            SaveMenuItem = new ToolStripMenuItem("Сохранить");

            fileMenuItem.DropDownItems.Add(OpenMenuItem);
            fileMenuItem.DropDownItems.Add(SaveMenuItem);

            menuStrip1.Items.Add(fileMenuItem);

            
        }

        public void SetStatus(string fileName)
        {
            this.fileName = fileName;
            ((ToolStripStatusLabel)this.StatusStrip1.Items[0]).Text = fileName;
        }

    }
}
