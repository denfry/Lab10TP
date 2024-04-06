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
    public partial class ChildForm3 : Form
    {
        private string fileName;
        public event EventHandler<List<(Point center, int radius)>> CirclesUpdated;

        public List<(Point center, int radius)> circles = new List<(Point, int)>();
        public ToolStripMenuItem OpenMenuItem { get; private set; }
        public ToolStripMenuItem SaveMenuItem { get; private set; }

        public ChildForm3()
        {
            InitializeComponent();
            InitializeComponents();
        }

        public void InitializeComponents()
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.MouseHover += PictureBox_MouseHover;

            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
            statusLabel.Text = "No file opened";
            StatusStrip3.Items.Add(statusLabel);

            ToolStripMenuItem fileMenuItem = new ToolStripMenuItem("Файл");
            OpenMenuItem = new ToolStripMenuItem("Открыть");
            SaveMenuItem = new ToolStripMenuItem("Сохранить");

            fileMenuItem.DropDownItems.Add(OpenMenuItem);
            fileMenuItem.DropDownItems.Add(SaveMenuItem);

            menuStrip3.Items.Add(fileMenuItem);
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
            toolTip.SetToolTip(pictureBox1, "Изменяемый рисунок");
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Добавляем новые координаты к списку кружков
            circles.Add((e.Location, 50)); // Просто добавим круги радиусом 50
            pictureBox1.Invalidate(); // Перерисовываем pictureBox, чтобы отобразить новые кружки

            // Вызываем событие, передающее информацию о кружках обратно на главную форму
            CirclesUpdated?.Invoke(this, circles);
        }

        public void SetStatus(string fileName)
        {
            this.fileName = fileName;
            ((ToolStripStatusLabel)this.StatusStrip3.Items[0]).Text = fileName;
        }
    }
}
