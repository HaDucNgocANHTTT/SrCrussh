using QuanLyRaVao.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using QuanLyRaVao;

namespace HoSoNhanSu.Security
{
    public class LstUser
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private static LstUser instance;
        private List<TaiKhoan> listAccountUser;

        public List<TaiKhoan> ListAccountUser { get => listAccountUser; set => listAccountUser = value; }
        public static LstUser Instance
        {
            get
            {
                if (instance == null)
                    instance = new LstUser();
                return instance;
            }
            set => instance = value;
        }

        private LstUser()
        {
            listAccountUser = new List<TaiKhoan>();
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "TaiKhoan";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                TaiKhoan a = new TaiKhoan(rd["TaiKhoan"].ToString(), rd["MatKhau"].ToString(), Convert.ToBoolean((rd["Quyen"])));
                listAccountUser.Add(a);
            }
        }
    }
}
