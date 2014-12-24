using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraTreeList;
//using DevExpress.Data.Filtering;

namespace EconomicZone.Modules
{    
    public partial class ucNavigationFiles : UserControl
    {
        

        
        public ucNavigationFiles()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {            
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            treeList1.OptionsFilter.FilterMode = FilterMode.Smart;

        }

        public DevExpress.XtraTreeList.TreeList TreeList
        {
            get { return this.treeList1; }
            //set { this.treeList1 = value; }
        }

        //创建过滤器
        private void textEdit_Filter_EditValueChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraTreeList.Nodes.TreeListNode fNode = treeList1.FocusedNode;
            //DevExpress.XtraTreeList.Columns.TreeListColumn fColumn = treeList1.FocusedColumn;
            
                string filterText = this.textEdit_Filter.Text.Trim();
                FilterCondition fc = new FilterCondition(FilterConditionEnum.Equals, this.treeList1.Columns["name"], filterText);
                treeList1.FilterConditions.Add(fc);
                //BinaryOperator bo = new BinaryOperator("name", filterText, BinaryOperatorType.Like);
                //this.treeList1.Columns["name"].MRUFilters.Add(new TreeListFilterInfo(bo));
            
        }

        private void treeList1_ColumnFilterChanged(object sender, EventArgs e)
        {

        }
    }
}
