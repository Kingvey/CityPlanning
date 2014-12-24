using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EconomicZone
{
    public partial class frmStartConnectionConfig : DevExpress.XtraEditors.XtraForm
    {
        //渐变步长
        private double OPACITY_STEP1 = 0.02;
        private double OPACITY_STEP2 = 0.06;
        private double OPACITY_STEP3 = 0.1;
        //渐变等级，先慢，后快
        private double OPACITY_LEVEL1 = 0.3;
        private double OPACITY_LEVEL2 = 0.6;
        private MainForm mainFrm;

        public frmStartConnectionConfig(MainForm _MainForm)
        {
            InitializeComponent();
            mainFrm = _MainForm;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Opacity >= OPACITY_LEVEL1)
                {
                    this.Opacity -= OPACITY_STEP1;
                }
                else if (this.Opacity < OPACITY_LEVEL2 && this.Opacity >= OPACITY_LEVEL1 && this.Opacity >= OPACITY_STEP2)
                {
                    this.Opacity -= OPACITY_STEP2;
                }
                else if (this.Opacity < OPACITY_LEVEL1 && this.Opacity >= OPACITY_STEP3)
                {
                    this.Opacity -= OPACITY_STEP3;
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void frmStartConnectionConfig_Load(object sender, EventArgs e)
        {
            this.Refresh();
            mainFrm.Opacity = 0;
            
        }

        private void frmStartConnectionConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();
            //如果点击取消按钮，则mainFrm已经被释放
            if(!mainFrm.IsDisposed)
            {
                mainFrm.Opacity = 1;
            }            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 100;
            this.timer1.Start(); 
        }

        private void btn_ConfigConnections_Click(object sender, EventArgs e)
        {
            this.panelControl1.Visible = !this.panelControl1.Visible;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            mainFrm.Close();
        }
    }
}