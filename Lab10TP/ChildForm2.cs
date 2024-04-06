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
    public partial class ChildForm2 : Form
    {
        private string fileName;
        public ToolStripMenuItem OpenMenuItem { get; private set; }
        public ToolStripMenuItem SaveMenuItem { get; private set; }
        public ChildForm2()
        {
            InitializeComponent();
            InitializeComponents();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 359);
        }

        public void InitializeComponents()
        {

            richTextBox2.ReadOnly = false;
            richTextBox2.Multiline = true;
            richTextBox2.Dock = DockStyle.Fill;
            richTextBox2.ScrollBars = RichTextBoxScrollBars.Vertical;


            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
            statusLabel.Text = "Файл не выбран";
            StatusStrip2.Items.Add(statusLabel);

            ToolStripMenuItem fileMenuItem = new ToolStripMenuItem("Файл");
            OpenMenuItem = new ToolStripMenuItem("Открыть");
            SaveMenuItem = new ToolStripMenuItem("Сохранить");

            fileMenuItem.DropDownItems.Add(OpenMenuItem);
            fileMenuItem.DropDownItems.Add(SaveMenuItem);

            menuStrip2.Items.Add(fileMenuItem);


        }



        public void SetStatus(string fileName)
        {
            this.fileName = fileName;
            ((ToolStripStatusLabel)this.StatusStrip2.Items[0]).Text = fileName;
        }

    }
}
