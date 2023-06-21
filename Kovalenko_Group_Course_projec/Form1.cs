using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

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
            MajorObject = new MajorWork();
            MajorObject.SetTime();
            MajorObject.Modify = false;

            About A = new About(0);
            A.tAbout.Start();
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
                пускToolStripMenuItem.Text = "Стоп";

            }
            else
            {
                tbInput.Enabled = false;
                tClock.Stop();
                bStart.Text = "Пуск";
                this.Mode = true;
                MajorObject.Write(tbInput.Text);
                MajorObject.Task();
                label1.Text = MajorObject.Read();
                пускToolStripMenuItem.Text = "Старт";
            }
        }



        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') & (e.KeyChar <= '9') | (e.KeyChar == (char)8))
            {
                return;
            }
            else
            {
                tClock.Stop();
                MessageBox.Show("неправильний символ", "помилка");
                tClock.Start();
                e.KeyChar = (char)0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string s;
            s = (System.DateTime.Now - MajorObject.GetTime()).ToString();
            MessageBox.Show(s, "Час роботи програми");
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void проПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About A = new About(0);
            A.ShowDialog();
        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                MajorObject.WriteSaveFileName(sfdSave.FileName); 
                MajorObject.Generator();
                MajorObject.SaveToFile();
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog() == DialogResult.OK)
                {
                MessageBox.Show(ofdOpen.FileName);
                }
        }

        private void проНакопичувачіToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string[] disks = (System.IO.Directory.GetLogicalDrives()); 
            string disk = "";
            for (int i = 0; i < disks.Length; i++)
            {
                try
                {

                    System.IO.DriveInfo D = new System.IO.DriveInfo(disks[i]);
                    double totalbytes = D.TotalSize;
                    double freebytes = D.TotalFreeSpace;
                    double tGbytes = totalbytes / Math.Pow(2, 30);
                    double fGbytes = freebytes / Math.Pow(2, 30);
                    disk += (D.Name + tGbytes + "-" + fGbytes +"Gb"+ (char)13); ;
                    
                }
                catch
                {
                    disk += disks[i] + "- не готовий" + (char)13;
                }
            }
            
            MessageBox.Show(disk, "Накопичувачі");
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (MajorObject.SaveFileNameExists())
                    MajorObject.SaveToFile(); 
                else
                    зберегтиЯкToolStripMenuItem_Click(sender, e); 
            }
        }

        private void новийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MajorObject.NewRec();
            tbInput.Clear();// очистити вміст тексту
            label1.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MajorObject.Modify)
                if (MessageBox.Show("Дані не були збережені. Продовжити вихід?", "УВАГА",
                MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
        }
    }
}
