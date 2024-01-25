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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
                MessageBox.Show("Không kết nối được với cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int acctype;
            if (txtUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tài khoản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            // truy vấn bảng User
            // trạng thái status 1 nghỉ việc , 0 k nghỉ
            string sSql = "Select * from [User] Where Username = @uname AND Password = @pword AND status = 0";
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
            string name = dt.Rows[0]["Name"].ToString();
            ;
            if (acctype == 0) // Nhân viên
            {
                Main frm = new Main(name);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else // Quản lý
            {
                ManagerMain frm = new ManagerMain(name);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnLogin.KeyPress += new KeyPressEventHandler(Login_KeyPress);
            txtUsername.KeyPress += new KeyPressEventHandler(Login_KeyPress);
            txtPassword.KeyPress += new KeyPressEventHandler(Login_KeyPress);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Gọi phương thức hoặc thực hiện hành động bạn muốn ở đây
                btnLogin.PerformClick();

                // Ngăn chặn sự kiện Enter tiếp tục được xử lý
                e.Handled = true;
            }
        }
    }
}
