using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_калькулятор.BMR
{
    public partial class BMR_calculator : Form
    {
        public BMR_calculator()
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

        private void BMR_Load(object sender, EventArgs e)
        {
            timer1.Start();
            panel_BMR.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (pc_male.BorderStyle == BorderStyle.None && pc_female.BorderStyle == BorderStyle.None)
                {
                    MessageBox.Show("Чел, выбери свой пол пожалуйста!", "Полт не выбран!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(pc_male.BorderStyle == BorderStyle.Fixed3D)
                    {
                        double bmr = 66 + (13.7 * Convert.ToDouble(numericUpDown1.Value)) + (5 * Convert.ToDouble(numericUpDown2.Value)) - (6.8 * Convert.ToDouble(numericUpDown3.Value));
                        bmr = bmr / 1000;
                        bmr = Math.Round(bmr, 3);
                        lbl_BMR.Text = bmr.ToString();

                        panel_BMR.Visible = true;

                        label15.Text = "  " + (Math.Round(bmr * 1.2, 2)).ToString();
                        label16.Text = "  " + (Math.Round(bmr * 1.375, 2)).ToString();
                        label17.Text = "  " + (Math.Round(bmr * 1.55, 2)).ToString();
                        label18.Text = "  " + (Math.Round(bmr * 1.725, 2)).ToString();
                        label19.Text = "  " + (Math.Round(bmr * 1.9, 2)).ToString();
                    }
                    if(pc_female.BorderStyle == BorderStyle.Fixed3D)
                    {
                        double bmr = 655 + (9.6 * Convert.ToDouble(numericUpDown1.Value)) + (1.8 * Convert.ToDouble(numericUpDown2.Value)) + (4.7 * Convert.ToDouble(numericUpDown3.Value));
                        bmr = bmr / 1000;
                        bmr = Math.Round(bmr, 3);
                        lbl_BMR.Text = bmr.ToString();

                        panel_BMR.Visible = true;
                        label15.Text = "  " + (Math.Round(bmr * 1.2, 2)).ToString();
                        label16.Text = "  " + (Math.Round(bmr * 1.375, 2)).ToString();
                        label17.Text = "  " + (Math.Round(bmr * 1.55, 2)).ToString();
                        label18.Text = "  " + (Math.Round(bmr * 1.725, 2)).ToString();
                        label19.Text = "  " + (Math.Round(bmr * 1.9, 2)).ToString();
                    }
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

        private void button2_Click(object sender, EventArgs e)
        {
            BMR_info info = new BMR_info();
            info.ShowDialog();
        }
    }
}
