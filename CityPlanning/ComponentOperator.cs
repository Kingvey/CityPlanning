using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevExpress.XtraTab;

namespace CityPlanning
{
    public class ComponentOperator
    {
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
    }
}
