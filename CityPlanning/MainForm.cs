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

using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
//using DevExpress.Docs;          //Worksheet专用


//本项目解决方案
using ConnectionCenter;

namespace CityPlanning
{
    public partial class MainForm : RibbonForm
    {
        #region //变量声明
        
        
        //自定义类声明

        //模块定义
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
            frmStartConnectionConfig fscc = new frmStartConnectionConfig(this);
            fscc.ShowDialog();
        }

        //初始化连接,由初始化界面调用
        public void InitConnection()
        {
            
        }

        //初始化控件
        private void InitComponent()
        {
            ucNaviFiles.Dock = DockStyle.Fill;
            ucNaviRDB.Dock = DockStyle.Fill;

            this.ucNaviRDB.TreeList.DoubleClick += ucNaviRDB_TreeList_DoubleClick;

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
        private void bConnectConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //启动界面
            frmStartConnectionConfig fscc = new frmStartConnectionConfig(null);
            fscc.ShowDialog();
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

            DataTable dt = SQLServerConnection.GetDatabaseSchema();
            if (dt == null)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }
            this.ucNaviRDB.TreeList.KeyFieldName = "id";     //主要显示内容
            this.ucNaviRDB.TreeList.ParentFieldName = "TABLE_CATALOG";     //目录
            this.ucNaviRDB.TreeList.DataSource = dt;    //数据库
            DevExpress.XtraTreeList.Columns.TreeListColumnCollection col = this.ucNaviRDB.TreeList.Columns;
            this.ucNaviRDB.TreeList.Columns["TABLE_NAME"].SortOrder = SortOrder.Ascending;      //排序
            //显示内容
            for (int i = 0; i < ucNaviRDB.TreeList.Columns.Count; i++)
            {
                if (ucNaviRDB.TreeList.Columns[i].FieldName != "TABLE_NAME")
                {
                    ucNaviRDB.TreeList.Columns[i].Visible = false;
                }
            }



        }
        //文档
        private void bGalleryDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();            
            this.panelControl_Navigation.Controls.Add(ucNaviFiles);
            string path = FTPConnection.FtpIP;
            DataTable dt = ConnectionCenter.ConnLocalDisk.getDataTable(path);
            if (dt == null)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }
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

        #region //数据库相关
        private void ucNaviRDB_TreeList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeList tree = sender as TreeList;
                TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
                if (hi.Node != null)
                {
                    string nodeName = (string)hi.Node["TABLE_NAME"];
                    DataTable dt = SQLServerConnection.GetDataByTableName(nodeName);
                    if(dt == null)
                    {
                        MessageBox.Show("获取数据失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //表格控件
                    SpreadsheetControl ssc = new SpreadsheetControl();
                    IWorkbook workbook = ssc.Document;
                    workbook.BeginUpdate();
                    Worksheet worksheet = workbook.Worksheets[0];
                    worksheet.Name = nodeName;
                    worksheet.Import(dt,true, 0, 0);        //import方法需要添加DevExpress.Docs命名空间
                    workbook.EndUpdate();
                    //TabPage
                    XtraTabPage xtp = new XtraTabPage();
                    xtp.Text = nodeName;
                    xtp.Controls.Add(ssc);
                    ssc.Dock = DockStyle.Fill;
                    this.xtraTabControl_Main.TabPages.Add(xtp);
                    this.xtraTabControl_Main.SelectedTabPage = xtp;

                    ssc.Refresh();
                    xtp.Refresh();
                    this.xtraTabControl_Main.Refresh();
                    this.Refresh();

                }
            }
            catch
            {
            }
        }
        #endregion


    }
}