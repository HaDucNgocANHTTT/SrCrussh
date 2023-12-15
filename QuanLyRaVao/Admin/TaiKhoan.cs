using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao
{
    public class TaiKhoan
    {
        string userName;
        string password;
        private bool accountType;
        public string UserName { get { return userName; } set { userName = value; } }
        public string Password { get { return password; } set { password = value; } }

        public bool AccountType { get => accountType; set => accountType = value; }
        public TaiKhoan(string userName, string password, bool accountType)
        {
            this.userName = userName;
            this.Password = password;
            this.AccountType = accountType;
        }
    }
    public class Const
    {
        public static bool AccountType;
    }

}
