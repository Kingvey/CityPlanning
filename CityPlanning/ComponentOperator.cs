﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using DevExpress.XtraRichEdit;

namespace CityPlanning
{
    public class ComponentOperator
    {
        /// <summary>
        /// 主显示区是否包含指定名称的TabPage，本系统TabPage不可重名
        /// </summary>
        /// <param name="_tabName">TabPage名称</param>
        /// <param name="_xtraTabControl">主显示区tabControl</param>
        /// <returns>如果包含，则返回TabPage；若不包含，则返回空</returns>
        public static XtraTabPage IfHasTabPage(string _tabName, XtraTabControl _xtraTabControl)
        {
            XtraTabPage tabPage = null;
            if (_xtraTabControl == null)
            {
                return null;
            }
            int tabCount = _xtraTabControl.TabPages.Count;
            for (int i = 0; i < tabCount; i++)
            {
                string tabName = _xtraTabControl.TabPages[i].Text;
                if (tabName == _tabName)
                {
                    tabPage = _xtraTabControl.TabPages[i];
                    break;
                }
            }
            return tabPage;
        }
        public static string GetFileTypeByExtension(string _extension)
        {
            string fileType = "";
            switch(_extension.ToLower())
            {
                case ".doc":
                case ".docx":
                case ".txt":
                case ".rtf":
                case ".html":
                case ".htm":
                case ".mht":
                case ".mhtml":
                case ".xml":
                case ".epub":
                case ".odt":
                    fileType = "RichTextEdit";
                    break;
                case ".xls":
                case ".xlsx":
                case ".xlsm":
                case ".cvs":
                    fileType = "SpreadSheet";
                    break;
                case ".pdf":
                    fileType = "PdfViewer";
                    break;
                case ".mxd":
                    fileType = "MapControl";
                    break;
                default:
                    fileType = "";
                    break;
            }
            return fileType;
        }
    }
}
