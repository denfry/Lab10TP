using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab10TP
{
    public partial class ChildForm3 : Form
    {
        private string fileName;

        public event EventHandler<List<(Point center, int radius)>> CirclesUpdated;

        public List<(Point center, int radius)> circles = new List<(Point, int)>();
        public ToolStripMenuItem OpenMenuItem { get; private set; }
        public ToolStripMenuItem SaveMenuItem { get; private set; }
        public ToolStripMenuItem SetEditableItem { get; private set; }
        public ToolStripMenuItem ClearCirclesItem { get; private set; }

        public ChildForm3()
        {
            InitializeComponent();
            InitializeComponents();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(528, 0);
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
            SetEditableItem = new ToolStripMenuItem("Редактировать");
            ClearCirclesItem = new ToolStripMenuItem("Очистить");
            ClearCirclesItem.Click += (sender, e) => ClearCircles();

            ToolStripStatusLabel editStatusLabel = new ToolStripStatusLabel();
            editStatusLabel.Text = "Редактирование: Выключено";
            statusStrip1.Items.Add(editStatusLabel);

            fileMenuItem.DropDownItems.Add(OpenMenuItem);
            fileMenuItem.DropDownItems.Add(SaveMenuItem);
            fileMenuItem.DropDownItems.Add(SetEditableItem);
            fileMenuItem.DropDownItems.Add(ClearCirclesItem);

            menuStrip3.Items.Add(fileMenuItem);
        }
        public void ClearCircles()
        {
            circles.Clear();
            pictureBox1.Invalidate();
        }

        public void SetEditableItem_Click()
        {
            if (((ToolStripStatusLabel)this.statusStrip1.Items[0]).Text != "Редактирование: Включено")
            {
                pictureBox1.MouseDown += PictureBox_MouseDown;
                ((ToolStripStatusLabel)this.statusStrip1.Items[0]).Text = "Редактирование: Включено";

            }
            else
            {
                pictureBox1.MouseDown -= PictureBox_MouseDown;
                ((ToolStripStatusLabel)this.statusStrip1.Items[0]).Text = "Редактирование: Выключено";
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
            // Создаем Graphics для рисования на PictureBox
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                // Определяем параметры круга
                int radius = 50;
                int diameter = radius * 2;

                // Вычисляем координаты верхнего левого угла описанного прямоугольника для круга
                int x = e.X - radius;
                int y = e.Y - radius;

                // Рисуем круг
                g.DrawEllipse(Pens.Red, x, y, diameter, diameter);

                // Добавляем круг в список
                circles.Add((new Point(x + radius, y + radius), radius));

                // Генерируем событие обновления кругов
                CirclesUpdated?.Invoke(this, circles);
            }
        }


        public void SetStatus(string fileName)
        {
            this.fileName = fileName;
            ((ToolStripStatusLabel)this.StatusStrip3.Items[0]).Text = fileName;
        }



        public void SaveImageWithCircles(string imagePath)
        {
            try
            {
                if (circles.Any())
                {
                    // Создаем новое изображение и графический контекст для рисования на нем
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Graphics g = Graphics.FromImage(bmp);

                    // Нарисуйте изображение на графическом контексте
                    g.DrawImage(pictureBox1.Image, Point.Empty);

                    // Добавьте рисование кружков
                    foreach (var circle in circles)
                    {
                        g.DrawEllipse(Pens.Red, circle.center.X - circle.radius, circle.center.Y - circle.radius, circle.radius * 2, circle.radius * 2);
                    }

                    // Сохраняем изображение в указанный путь
                    bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bmp.Dispose();
                    SetStatus("Файл сохранен: " + imagePath);
                }
                else
                {
                    // Если не было нарисовано кружков, сохраняем изображение в обычном формате
                    pictureBox1.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    SetStatus("Файл сохранен: " + imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
            }
        }
    }
}
