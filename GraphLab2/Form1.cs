using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void intoShadesOfGray()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // фильтр форматов файлов
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // загружаем изображение
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Bitmap temp = new Bitmap(pictureBox1.Image);
            Bitmap result = new Bitmap(temp.Width, temp.Height);
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    Color pixel = temp.GetPixel(i, j);
                    var newPixel1 = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                    var newPixel =(int)(newPixel1 <= 255 ? newPixel1 : 255);
                    result.SetPixel(i,j, Color.FromArgb(pixel.A,newPixel,newPixel,newPixel));
                }
            }

            pictureBox2.Image = result;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile("C:\\Users\\катя\\Pictures\\VKjrjTk6tgk.jpg");
            intoShadesOfGray();
        }
    }
}