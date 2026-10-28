using System;
using System.Drawing;
using System.Windows.Forms;

namespace LR12_Variant7
{
    public class MainForm : Form
    {
        private TextBox txtH;
        private TextBox txtD;
        private TextBox txtO1;
        private TextBox txtF;
        private TextBox txtB;
        private Label lblStatus;

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Лабораторная работа №12 (Вариант 7)";
            this.Size = new Size(520, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 243, 246);

            // Заголовок формы
            Label lblHeader = new Label();
            lblHeader.Text = "Формула: Q = sin(h + d / e^0.1) - o1 + sin(f) + sqrt(|sin(b)|)";
            lblHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(30, 60, 100);
            lblHeader.Location = new Point(15, 15);
            lblHeader.Size = new Size(480, 25);
            this.Controls.Add(lblHeader);

            // Подсказка
            Label lblHint = new Label();
            lblHint.Text = "Двигайте курсор мыши по форме для динамического пересчета Q";
            lblHint.Font = new Font("Segoe UI", 8.5f, FontStyle.Italic);
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(15, 42);
            lblHint.Size = new Size(480, 20);
            this.Controls.Add(lblHint);

            // Группа переменных мыши
            GroupBox grpMouse = new GroupBox();
            grpMouse.Text = " Переменные мыши (ReadOnly) ";
            grpMouse.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            grpMouse.Location = new Point(15, 70);
            grpMouse.Size = new Size(475, 100);
            this.Controls.Add(grpMouse);

            Label lblH = new Label { Text = "Координата h (X):", Location = new Point(20, 30), Size = new Size(130, 22), Font = new Font("Segoe UI", 9) };
            txtH = new TextBox { Location = new Point(160, 28), Size = new Size(100, 22), ReadOnly = true, BackColor = Color.WhiteSmoke, Font = new Font("Segoe UI", 9) };
            Label lblD = new Label { Text = "Координата d (Y):", Location = new Point(20, 60), Size = new Size(130, 22), Font = new Font("Segoe UI", 9) };
            txtD = new TextBox { Location = new Point(160, 58), Size = new Size(100, 22), ReadOnly = true, BackColor = Color.WhiteSmoke, Font = new Font("Segoe UI", 9) };

            grpMouse.Controls.Add(lblH);
            grpMouse.Controls.Add(txtH);
            grpMouse.Controls.Add(lblD);
            grpMouse.Controls.Add(txtD);

            // Группа пользовательских переменных
            GroupBox grpUser = new GroupBox();
            grpUser.Text = " Пользовательские переменные ";
            grpUser.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            grpUser.Location = new Point(15, 180);
            grpUser.Size = new Size(475, 140);
            this.Controls.Add(grpUser);

            Label lblO1 = new Label { Text = "Параметр o1:", Location = new Point(20, 30), Size = new Size(130, 22), Font = new Font("Segoe UI", 9) };
            txtO1 = new TextBox { Text = "1.0", Location = new Point(160, 28), Size = new Size(100, 22), Font = new Font("Segoe UI", 9) };
            Label lblF = new Label { Text = "Параметр f:", Location = new Point(20, 65), Size = new Size(130, 22), Font = new Font("Segoe UI", 9) };
            txtF = new TextBox { Text = "0.5", Location = new Point(160, 63), Size = new Size(100, 22), Font = new Font("Segoe UI", 9) };
            Label lblB = new Label { Text = "Параметр b:", Location = new Point(20, 100), Size = new Size(130, 22), Font = new Font("Segoe UI", 9) };
            txtB = new TextBox { Text = "2.0", Location = new Point(160, 98), Size = new Size(100, 22), Font = new Font("Segoe UI", 9) };

            grpUser.Controls.Add(lblO1);
            grpUser.Controls.Add(txtO1);
            grpUser.Controls.Add(lblF);
            grpUser.Controls.Add(txtF);
            grpUser.Controls.Add(lblB);
            grpUser.Controls.Add(txtB);

            // Статус
            lblStatus = new Label();
            lblStatus.Text = "Текущий результат выводится в заголовок окна";
            lblStatus.Font = new Font("Segoe UI", 9);
            lblStatus.ForeColor = Color.DarkSlateBlue;
            lblStatus.Location = new Point(15, 335);
            lblStatus.Size = new Size(475, 25);
            this.Controls.Add(lblStatus);

            // Привязка событий мыши
            this.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            grpMouse.MouseMove += new MouseEventHandler(SubControl_MouseMove);
            grpUser.MouseMove += new MouseEventHandler(SubControl_MouseMove);

            txtO1.TextChanged += (s, e) => Recalculate();
            txtF.TextChanged += (s, e) => Recalculate();
            txtB.TextChanged += (s, e) => Recalculate();

            // Первичный расчет
            UpdateCoordinates(120, 85);
        }

        private void SubControl_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            Point p = this.PointToClient(c.PointToScreen(e.Location));
            UpdateCoordinates(p.X, p.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateCoordinates(e.X, e.Y);
        }

        public void UpdateCoordinates(int x, int y)
        {
            txtH.Text = x.ToString();
            txtD.Text = y.ToString();
            Recalculate();
        }

        private void Recalculate()
        {
            try
            {
                double h = Convert.ToDouble(txtH.Text);
                double d = Convert.ToDouble(txtD.Text);
                double o1 = Convert.ToDouble(txtO1.Text.Replace('.', ','));
                double f = Convert.ToDouble(txtF.Text.Replace('.', ','));
                double b = Convert.ToDouble(txtB.Text.Replace('.', ','));

                // Q = sin(h + d / e^0.1) - o1 + sin(f) + sqrt(|sin(b)|)
                double expFactor = Math.Exp(0.1);
                double inner = h + (d / expFactor);
                double term1 = Math.Sin(inner);
                double term2 = o1;
                double term3 = Math.Sin(f);
                double term4 = Math.Sqrt(Math.Abs(Math.Sin(b)));

                double Q = term1 - term2 + term3 + term4;

                if (double.IsNaN(Q) || double.IsInfinity(Q))
                {
                    this.Text = "Результат Q = ERROR";
                    lblStatus.Text = "Статус: Выражение не определено (ERROR)";
                }
                else
                {
                    this.Text = string.Format("Результат Q = {0:0.0000} (X={1}, Y={2})", Q, h, d);
                    lblStatus.Text = string.Format("Q = {0:0.0000} | sin({1:0.0}) - {2:0.0} + sin({3:0.0}) + sqrt(|sin({4:0.0})|)",
                        Q, inner, o1, f, b);
                }
            }
            catch
            {
                this.Text = "Результат Q = ERROR";
                lblStatus.Text = "Статус: Ошибка ввода параметров (ERROR)";
            }
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();

            if (args.Length > 0 && args[0] == "--screenshot")
            {
                string outPath = args.Length > 1 ? args[1] : "lr12_variant7_gui.png";
                form.Show();
                form.UpdateCoordinates(185, 142);
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
