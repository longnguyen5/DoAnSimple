using DrugStoreManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnSimple
{
    public partial class Login : Form
    {
        // khai báo một biến lớp 
        private DataServices myDataServices;
        private SqlCommand mySqlCommand;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            myDataServices = new DataServices();
            // kết nối đến CSDL
            if (myDataServices.OpenDB() == false)
            {
                return;
            }
            int acctype, id;
            // truy vấn bảng User
            string sSql = "Select * from [User] Where Username = @uname AND Password = @pword";
            DataTable dt = myDataServices.RunQuery(sSql, new SqlParameter("@uname", txtUsername.Text), new SqlParameter("@pword", txtPassword.Text));
            // kiem tra username va password
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không đúng tài khoản/mật khẩu đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            else
            {
                acctype = Convert.ToInt32(dt.Rows[0]["Type"]);
            }
            if (acctype == 0) // Nhân viên
            {
                Main frm = new Main();
                frm.ShowDialog();
            }
            else // Quản lý
            {
                ManagerMain frm = new ManagerMain();
                frm.ShowDialog();
            }
            this.Hide();
        }
    }
}
