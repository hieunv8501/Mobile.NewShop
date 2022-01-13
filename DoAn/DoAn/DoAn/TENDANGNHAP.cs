using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn
{
    public class TENDANGNHAP
    {
        public static string TenDangNhap = null;
        public static bool IsAdmin;

        public void Set_TenDangNhap(string TENDANGNHAP)
        {
            TenDangNhap = TENDANGNHAP;
        }
        public string Get_TenDangNhap()
        {
            return TenDangNhap;
        }
        public void SetNull_TenDangNhap()
        {
            TenDangNhap = null;
        }
        public void Set_IsAdmin(bool IsAdmins)
        {
            IsAdmin = IsAdmins;
        }
        public bool Get_IsAdmin()
        {
            return IsAdmin;
        }

    }
}
