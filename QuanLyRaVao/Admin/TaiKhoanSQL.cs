using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.Data
{
    public class TaiKhoanSQL
    {
        private string tendangnhap;
        private string matkhau;

        public string Tendangnhap { get => tendangnhap; set => tendangnhap = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string connectStr(TaiKhoanSQL hientai)
        {
            return @"Server=DESKTOP-79I4RNR\MSSQLSERVER01;Database=QuanLyRaVao;User Id=ducngoc_vp;Password=1";
        }

    }
    public class Globals
    {
        public static TaiKhoanSQL hientai;
    }
}
