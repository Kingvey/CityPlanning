using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;

//本项目解决方案
using ConnectionCenter;

namespace EconomicZone
{
    public partial class MainForm : RibbonForm
    {
        #region //变量声明
        public Modules.ucNavigationRDB ucNaviRDB = new Modules.ucNavigationRDB();
        public Modules.ucNavigationFiles ucNaviFiles = new Modules.ucNavigationFiles();
        #endregion

        //
        public MainForm()
        {
            InitializeComponent();
            InitComponent();
            //InitSkinGallery();

        }
        //窗体初始化函数
        private void MainForm_Load(object sender, EventArgs e)
        {
            //启动界面
            //frmStartConnectionConfig fscc = new frmStartConnectionConfig(this);
            //fscc.ShowDialog();
        }

        //初始化控件
        private void InitComponent()
        {
            ucNaviFiles.Dock = DockStyle.Fill;
            ucNaviRDB.Dock = DockStyle.Fill;
        }
        void InitSkinGallery()
        {
            //SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        
        #region //关于
        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void iHelp_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region //主页Ribbon按钮事件
        //连接配置
        private void barBtn_ConnectConfig_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        
        //空间数据库
        private void bGalleryGeodatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
        //关系数据库
        private void bGalleryRelationalDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucNaviRDB);
        }
        //文档
        private void bGalleryDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();            
            this.panelControl_Navigation.Controls.Add(ucNaviFiles);
            string path = "D:\\dev - Design";
            DataTable dt = ConnectionCenter.ConnLocalDisk.getDataTable(path);            
            ucNaviFiles.TreeList.KeyFieldName = "id";
            ucNaviFiles.TreeList.ParentFieldName = "pid";
            ucNaviFiles.TreeList.DataSource = dt;

            //按名称排序
            ucNaviFiles.TreeList.BeginSort();
            ucNaviFiles.TreeList.Columns["type"].SortOrder = SortOrder.Descending;
            ucNaviFiles.TreeList.Columns["name"].SortOrder = SortOrder.Ascending;
            ucNaviFiles.TreeList.EndSort();

            //隐藏除"name"的列
            for (int i = 0; i < ucNaviFiles.TreeList.Columns.Count; i++)
            {
                if (ucNaviFiles.TreeList.Columns[i].FieldName != "name")
                {
                    ucNaviFiles.TreeList.Columns[i].Visible = false;
                }
            }


            
        }
        //三维地图
        private void bGallery3DMap_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion


    }
}