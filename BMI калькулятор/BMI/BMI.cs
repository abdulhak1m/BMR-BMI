using BMI_калькулятор.BMR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_калькулятор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FromMocement();
            btn_minimize.Click += (s, e) => { WindowState = FormWindowState.Minimized; };
            btn_close.Click += (s, e) => { Close(); };
        }
        private void FromMocement()
        {
            int move = 0, x = 0, y = 0;
            topPanel.MouseDown += (s, e) => { move = 1; x = e.X; y = e.Y; };
            topPanel.MouseMove += (s, e) => { if (move == 1) SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y); };
            topPanel.MouseUp += (s, e) => { move = 0; };
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime marathonSkills = new DateTime(2020, 11, 25, 6, 0, 0);
            TimeSpan totalTime = marathonSkills - DateTime.Now;
            lblTimer.Text = totalTime.Days + " дней " + totalTime.Hours + " часов и " + totalTime.Minutes + " минут до старта Марафон";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void btn_BMI_This_Is_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(
                delegate ()
                {
                    MessageBox.Show("BMI обозначает индекс массы тела. " +
                "Он используется, чтобя дать понять Вам представление о том, " +
                "является ли Ваш вес избыточным или идеальным для Вашего роста." +
                "Это полезно знать, потому что если Ваш вес увеличивается или " +
                "уменьшается за пределами идеального диапазона, у Вас повышается риск заболеть.",
                "Справочный центр.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal bmi = 0;
            try
            {
                bmi = numericUpDown1.Value / (numericUpDown2.Value * numericUpDown2.Value) * 10000;
                bmi = Math.Round(bmi, 2);
                if((double)bmi < 18.5)
                {
                    panel5.Visible = true;
                    panel6.Visible = false;
                    panel7.Visible = false;
                    panel8.Visible = false;
                    label8.Text = bmi.ToString();
                    pic_BMI.Image = Properties.Resources.bmi_underweight_icon;
                }
                if((double)bmi >= 18.5 && (double)bmi <= 24.9)
                {
                    panel5.Visible = false;
                    panel6.Visible = true;
                    panel7.Visible = false;
                    panel8.Visible = false;
                    label9.Text = bmi.ToString();
                    pic_BMI.Image = Properties.Resources.bmi_healthy_icon;
                }
                if((double)bmi >= 25 && (double)bmi <= 29.9)
                {
                    panel5.Visible = false;
                    panel6.Visible = false;
                    panel7.Visible = true;
                    panel8.Visible = false;
                    label10.Text = bmi.ToString();
                    pic_BMI.Image = Properties.Resources.bmi_overweight_icon;
                }
                if((double)bmi > 30)
                {
                    panel5.Visible = false;
                    panel6.Visible = false;
                    panel7.Visible = false;
                    panel8.Visible = true;
                    label11.Text = bmi.ToString();
                    pic_BMI.Image = Properties.Resources.bmi_obese_icon;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pc_male_Click(object sender, EventArgs e)
        {
            pc_male.BorderStyle = BorderStyle.Fixed3D;
            pc_female.BorderStyle = BorderStyle.None;
        }

        private void pc_female_Click(object sender, EventArgs e)
        {
            pc_male.BorderStyle = BorderStyle.None;
            pc_female.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BMR_calculator bMR_Calculator = new BMR_calculator();
            bMR_Calculator.ShowDialog();
        }
    }
}
