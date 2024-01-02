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
    public partial class frmEmployee : UserControl
    {
        // 1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        // 2. khai báo đối tượng DataTable để lưu dũ liệu bảng Product
        private DataTable dtUser;
        // 3. khai báo biến kiểm tra đã chọn <thêm mới> hoặc <sửa>
        private bool modeNew;
        // 4. khai báo biến để kiểm tra trùng tên thuốc
        private string oldName;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmbStatus.Items.Add("Đang làm việc");
            cmbStatus.Items.Add("Đã nghỉ việc");
            cmbStatus.SelectedIndex = 0;

            cmbUserType.Items.Add("Nhân viên");
            cmbUserType.Items.Add("Quản lý");
            cmbUserType.SelectedIndex = 0;
            SetControls(false);
            dGVProduct.AutoResizeColumns();
            Display();
        }
        private void Display()
        {
            // Khai báo xâu truy vấn sql
            string sSql = "Select * From [User] Order by [Id]";
            dtUser = myDataServices.RunQuery(sSql);
            // From now on, do not change the context of myDataService() - do not use it for other tables
            // Hiển thị lên grid
            dGVProduct.DataSource = dtUser;
        }
        private void dGVProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            string status = dGVProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (status == "0")
            {
                cmbStatus.SelectedIndex = 0;
            }
            else
            {
                cmbStatus.SelectedIndex = 1;
            }

            string type = dGVProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (type == "0")
            {
                cmbUserType.SelectedIndex = 0;
            }
            else
            {
                cmbUserType.SelectedIndex = 1;
            }
            // Hiển thị các textbox khác 
            txtId.Text = dGVProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = dGVProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtUserName.Text = dGVProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = dGVProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dGVProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDescription.Text = dGVProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
        private void SetControls(bool edit)
        {
            // Các check list combobox và textbox
            txtName.Enabled = edit;
            txtEmail.Enabled = edit;
            txtDescription.Enabled = edit;
            txtId.Enabled = edit;
            txtPassword.Enabled = edit;
            txtUserName.Enabled = edit;
            txtPhone.Enabled = edit;
            cmbStatus.Enabled = edit;
            cmbUserType.Enabled = edit;
            // Các nút
            btnAdd.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnDelete.Enabled = !edit;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            modeNew = true;
            SetControls(true);
            txtId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtDescription.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            modeNew = false;
            SetControls(true);
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Nút xóa
            // Thông báo người dùng có chắc chắn xóa dữ liệu
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            // Lấy mã của dòng được chọn trong dGVProduct
            int r = dGVProduct.CurrentRow.Index;
            // Lấy mã ProductId
            string ProductId = dGVProduct.Rows[r].Cells["Id"].Value.ToString();
            // Xóa dữ liệu khỏi bảng Product
            string sSql = "DELETE FROM [User] WHERE Id = @ProductId";
            myDataServices.ExecuteNonQuery(sSql, new SqlParameter("@ProductId", ProductId));
            // Refresh the data display
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập tên nguoi dung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            string sSql;
            // 2. Kiểm tra có trùng tên sản phẩm hay không
            if (modeNew || (!modeNew && txtName.Text.Trim() != oldName.Trim()))
            {
                sSql = "Select * From [User] Where [Name] = @Name";
                DataServices dsSearch = new DataServices();
                DataTable dtSearch = dsSearch.RunQuery(sSql, new SqlParameter("@Name", txtName.Text));
                if (dtSearch.Rows.Count > 0)
                {
                    MessageBox.Show("Đã nhập/sửa trùng tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }
            }
            // Thêm mới hoặc sửa
            if (modeNew)
            {
                // Thêm mới 
                // 1. Thêm dữ liệu vào bảng Product
                DataRow myDataRow = dtUser.NewRow();
                myDataRow["Name"] = txtName.Text;
                myDataRow["Username"] = txtUserName.Text;
                myDataRow["Password"] = txtPassword.Text;
                myDataRow["Phone"] = txtPhone.Text;
                myDataRow["Email"] = txtEmail.Text;
                myDataRow["Status"] = cmbStatus.SelectedIndex;
                myDataRow["Description"] = txtDescription.Text;
                myDataRow["Type"] = cmbUserType.SelectedIndex;

                dtUser.Rows.Add(myDataRow);
                myDataServices.Update(dtUser);
            }
            else
            {
                // Lấy dòng đang chọn
                int r = dGVProduct.CurrentRow.Index;
                DataRow myDataRow = dtUser.Rows[r];
                myDataRow["Name"] = txtName.Text;
                myDataRow["Username"] = txtUserName.Text;
                myDataRow["Password"] = txtPassword.Text;
                myDataRow["Phone"] = txtPhone.Text;
                myDataRow["Email"] = txtEmail.Text;
                myDataRow["Status"] = cmbStatus.SelectedIndex;
                myDataRow["Description"] = txtDescription.Text;
                myDataRow["Type"] = cmbUserType.SelectedIndex;
                myDataServices.Update(dtUser);
            }
            Display();
            SetControls(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = "Select * from User WHERE Name LIKE '%' + @DrugName + '%'";
            DisplaySearch(sSql, new SqlParameter("@DrugName", txtSearch.Text.Trim()));
        }
        private void DisplaySearch(string sSql, params SqlParameter[] parameters)
        {
            SqlConnection mySqlConnection = new SqlConnection();
            mySqlConnection.ConnectionString = "Data Source=LAPTOP-VHVPC4RM\\SQLEXPRESS;Initial Catalog=Mart;Integrated Security=True";
            //1. tạo đối tượng cmd
            SqlCommand cmd = new SqlCommand(sSql, mySqlConnection);
            cmd.Parameters.AddRange(parameters);
            //2. mở kết nối
            mySqlConnection.Open();
            //3. truy vấn dữ liệu vào đối tượng SqlDataReader
            SqlDataReader myDataReader = cmd.ExecuteReader();
            //hiển thị dữ liệu lên lưới
            //4. chuyển dữ liệu từ myDataReader sang đối tượng DataTable
            DataTable myDataTable = new DataTable();
            myDataTable.Load(myDataReader);
            //5. hiển thi dữ liệu trong myDataTable lên lưới
            dGVProduct.DataSource = myDataTable;
            //6. đóng kết nối và myDataReader
            myDataReader.Close();
            mySqlConnection.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
