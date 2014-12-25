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

using ConnectionCenter;

namespace CityPlanning
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
        //窗体打开
        private void frmStartConnectionConfig_Load(object sender, EventArgs e)
        {
            this.Refresh();
            if (mainFrm != null)
            {
                mainFrm.Opacity = 0;
            }
            else
            {
                this.panelControl1.Visible = !this.panelControl1.Visible;
            }
        }
        //窗体关闭
        private void frmStartConnectionConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FTP
            FTPConnection.FtpIP = this.txt_ftpIP.Text.Trim();
            FTPConnection.FtpPort = this.txt_ftpPort.Text.Trim();
            FTPConnection.FtpUserName = this.txt_ftpUserName.Text.Trim();
            FTPConnection.FtpPassword = this.txt_ftpPassword.Text.Trim();
            //数据库            
            SQLServerConnection.DBServerName = this.txt_DBServerName.Text.Trim();
            SQLServerConnection.DbCatalogName = this.txt_DBCatalogName.Text.Trim();
            SQLServerConnection.DBUserName = this.txt_DBUserName.Text.Trim();
            SQLServerConnection.DBPassword = this.txt_DBPassword.Text.Trim();
            //用户
            UserManager.SysUserName = this.txt_SysUserName.Text.Trim();
            UserManager.SysPassword = this.txt_SysPassword.Text.Trim();
                        
            this.timer1.Stop();
            //如果点击取消按钮，则mainFrm已经被释放
            if (mainFrm != null)
            {
                if (!mainFrm.IsDisposed)
                {
                    mainFrm.Opacity = 1;
                }
            }
        }

        //登录按钮
        private void btn_Login_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 100;
            this.timer1.Start(); 
        }

        //取消按钮
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (mainFrm != null)
            {
                mainFrm.Close();
            }            
        }
        //配置连接
        private void btn_ConfigConnections_Click(object sender, EventArgs e)
        {
            this.panelControl1.Visible = !this.panelControl1.Visible;
        }
        //渐变的timer
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
    }
}