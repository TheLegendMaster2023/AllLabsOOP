using System;
using System.Drawing;
using System.Windows.Forms;

namespace LR12_Demo
{
    public class Form1 : Form
    {
        private TextBox textBox1;

        public Form1()
        {
            this.Text = "Лабораторная работа №12 (Demo)";
            this.Size = new Size(420, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label { Text = "Сумма координат мыши:", Location = new Point(30, 40), Size = new Size(180, 20) };
            textBox1 = new TextBox { Location = new Point(30, 65), Size = new Size(150, 25) };

            this.Controls.Add(lbl);
            this.Controls.Add(textBox1);

            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        }

        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = string.Format("Координаты: {0}, {1}", e.X, e.Y);
            textBox1.Text = (e.X + e.Y).ToString();
        }

        public void SetCoords(int x, int y)
        {
            Text = string.Format("Координаты: {0}, {1}", x, y);
            textBox1.Text = (x + y).ToString();
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();

            if (args.Length > 0 && args[0] == "--screenshot")
            {
                string outPath = args.Length > 1 ? args[1] : "lr12_demo.png";
                form.Show();
                form.SetCoords(140, 95);
                Application.DoEvents();

                Bitmap bmp = new Bitmap(form.Width, form.Height);
                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
                bmp.Save(outPath, System.Drawing.Imaging.ImageFormat.Png);
                bmp.Dispose();
                form.Close();
                return;
            }

            Application.Run(form);
        }
    }
}
