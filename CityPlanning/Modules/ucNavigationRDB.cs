using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityPlanning.Modules
{
    public partial class ucNavigationRDB : UserControl
    {
        public ucNavigationRDB()
        {
            InitializeComponent();
        }

        public DevExpress.XtraTreeList.TreeList TreeList
        {
            get { return this.TreeListTables; }
            //set { this.treeList1 = value; }
        }

    }
}
