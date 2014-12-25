using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionCenter
{
    public class UserManager
    {

        private static string sysUserName;
        private static string sysPassword;
        //用户
        public static string SysUserName
        {
            get { return sysUserName.Trim(); }
            set { sysUserName = value; }
        }
        public static string SysPassword
        {
            get { return sysPassword; }
            set { sysPassword = value; }
        }       
    }
}
