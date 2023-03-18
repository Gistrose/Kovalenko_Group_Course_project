using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kovalenko_Group_Course_projec
{
    public partial class Form1 : Form
    {
        private bool Mode;
        private MajorWork MajorObject;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            About A = new About();
            A.tAbout.Start ();
            A.ShowDialog();

            MajorObject = new MajorWork();
            this.Mode = true;
        }

        private void tClock_Tick(object sender, EventArgs e)
        {
            tClock.Stop();
            MessageBox.Show("Минуло 25 секунд", "Увага");
            tClock.Start();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                tbInput.Enabled = true;
                tClock.Start();
                bStart.Text = "Стоп";
                this.Mode = false;

            }
            else
            {
                tbInput.Enabled = false;
                tClock.Stop();
                bStart.Text = "Пуск";
                this.Mode = true;
                MajorObject.Write(tbInput.Text);
                MajorObject.Task ();
                label1.Text = MajorObject.Read();
            }
        }



        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') & (e.KeyChar <= '9') | (e.KeyChar == (char)8))
            {
                return;
            }
            else {
                tClock.Stop();
                MessageBox.Show("неправильний символ", "помилка");
                tClock.Start();
                e.KeyChar = (char)0;
            }
        }
    }
}
