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
using static Lab10TP.ChildForm;

namespace Lab10TP
{
    public partial class MainForm : Form
    {
        private ChildForm _editableChildForm;
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            InitializeMenu();
            this.Load += new EventHandler(MainForm_Load);
        }
        

        private void InitializeMenu()
        {
            MainMenu _mainMenu = new MainMenu();
            MenuItem _fileMenu = new MenuItem("File");
            MenuItem _editMenu = new MenuItem("Edit");
            MenuItem _clearMenu = new MenuItem("Clear");

            _fileMenu.MenuItems.Add(new MenuItem("Open", OpenFile_Click));
            _fileMenu.MenuItems.Add(new MenuItem("Save", SaveFile_Click));
            _editMenu.MenuItems.Add(new MenuItem("Edit Picture", EditPicture_Click));
            _clearMenu.MenuItems.Add(new MenuItem("Clear Picture", ClearPicture_Click));

            _mainMenu.MenuItems.Add(_fileMenu);
            _mainMenu.MenuItems.Add(_editMenu);
            _mainMenu.MenuItems.Add(_clearMenu);

            this.Menu = _mainMenu;

        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (ActiveMdiChild is ChildForm childForm)
                {
                    try
                    {
                        childForm.textBox1.Text = File.ReadAllText(openFileDialog.FileName);
                        childForm.SetStatus(openFileDialog.SafeFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ChildForm childForm)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем содержимое активной формы в текстовый файл
                    File.WriteAllText(saveFileDialog.FileName, childForm.textBox1.Text);
                    childForm.SetStatus(saveFileDialog.FileName);
                }
            }
        }

        private void EditPicture_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ChildForm childForm)
            {
                childForm.SetEditable(true);
            }
        }

        private void ClearPicture_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ChildForm childForm)
            {
                childForm.ClearPicture();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int formWidth = (this.ClientSize.Width - 10) / 2; // ширина формы будет половиной ширины главной формы с учетом разделителя
            int formHeight = (this.ClientSize.Height - 10) / 2; // высота формы будет равна высоте главной формы без горизонтального скролла
            int formHeightPicture = this.ClientSize.Height - 10;
            int form1LocationX = 0; // начальная координата X для первой формы
            int form1LocationY = 0; // начальная координата Y для первой формы
            int form2LocationX = 0; // начальная координата X для второй формы
            int form2LocationY = formHeight + 10; // начальная координата Y для второй формы

            // Создаем и настраиваем первую форму с текстом
            ChildForm childForm1 = new ChildForm();
            childForm1.MdiParent = this;
            childForm1.Text = "Text Form 1";
            childForm1.Size = new Size(formWidth, formHeight); // устанавливаем размер формы
            childForm1.Location = new Point(form1LocationX, form1LocationY); // устанавливаем расположение формы
            childForm1.Show();

            // Создаем и настраиваем вторую форму с текстом
            ChildForm childForm2 = new ChildForm();
            childForm2.MdiParent = this;
            childForm2.Text = "Text Form 2";
            childForm2.Size = new Size(formWidth, formHeight); // устанавливаем размер формы
            childForm2.Location = new Point(form2LocationX, form2LocationY); // устанавливаем расположение формы
            childForm2.Show();

            // Создаем и настраиваем форму с редактируемым рисунком
            ChildForm _editableChildForm = new ChildForm();
            _editableChildForm.MdiParent = this;
            _editableChildForm.Text = "Editable Picture Form";
            _editableChildForm.SetEditable(true);
            _editableChildForm.Size = new Size(formWidth, formHeightPicture); // устанавливаем размер формы
            _editableChildForm.Location = new Point(formWidth, 0); // устанавливаем расположение формы
            _editableChildForm.Show();

        }
    }
}
