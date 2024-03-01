using DoAnSimple;
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
    public partial class frmDiscount : UserControl
    {
        // 1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        // 2. khai báo đối tượng DataTable để lưu dũ liệu bảng Category
        private DataTable dtCategory;
        // 3. khai báo biến kiểm tra đã chọn <thêm mới> hoặc <sửa>
        private bool modeNew;
        // 4. khai báo biến để kiểm tra trùng tên thuốc
        private string oldCategoryName;

        public frmDiscount()
        {
            InitializeComponent();
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Hiển thị dữ liệu lên lưới
            Display();
            // Thiết lập trạng thái các điều khiển
            dGVCategory.AutoResizeColumns();
            dGVCategory.Columns[1].HeaderText = "Tên";
            dGVCategory.Columns[2].HeaderText = "Giảm %";
            dGVCategory.Columns[3].HeaderText = "Mô tả thêm";
            SetControls(false);
        }
        private void dGVCategory_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị các textbox khác 
            txtId.Text = dGVCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiscount.Text = dGVCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dGVCategory.Rows[e.RowIndex].Cells[3].Value.ToString();
            // Lưu tên sản phẩm để check trùng tên hay không
            oldCategoryName = txtName.Text;
        }
        private void Display()
        {
            // Khai báo xâu truy vấn sql
            string sSql = "Select * From [Discount] Order by [Id]";
            dtCategory = myDataServices.RunQuery(sSql);
            // From now on, do not change the context of myDataService() - do not use it for other tables
            // Hiển thị lên grid
            dGVCategory.DataSource = dtCategory;
            foreach (DataGridViewColumn column in dGVCategory.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void SetControls(bool edit)
        {
            // Các check list combobox và textbox
            txtName.Enabled = edit;
            txtDescription.Enabled = edit;
            txtDiscount.Enabled = edit;
            // Các nút
            btnAdd.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnDelete.Enabled = !edit;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Nút thêm
            modeNew = true;
            SetControls(true);
            txtId.Clear();
            txtName.Clear();
            txtDiscount.Clear();
            txtDescription.Clear();
            txtName.Focus();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Nút sửa
            modeNew = false;
            SetControls(true);
            txtName.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Display();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Nút xóa
            // Thông báo người dùng có chắc chắn xóa dữ liệu
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            // Lấy mã của dòng được chọn trong dGVCategory
            int r = dGVCategory.CurrentRow.Index;
            // Lấy mã ProductId
            string ProductId = dGVCategory.Rows[r].Cells["Id"].Value.ToString();
            // Xóa dữ liệu khỏi bảng 
            string sSql = "DELETE FROM [Discount] WHERE Id = @CategoryId";
            myDataServices.ExecuteNonQuery(sSql, new SqlParameter("@CategoryId", ProductId));
            // Refresh the data display
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            string sSql;
            // 2. Kiểm tra có trùng tên sản phẩm hay không
            if (modeNew || (!modeNew && txtName.Text.Trim() != oldCategoryName.Trim()))
            {
                sSql = "Select * From [Discount] Where [Name] = @Name";
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
                // 1. Thêm dữ liệu vào bảng Category
                DataRow myDataRow = dtCategory.NewRow();
                myDataRow["Name"] = txtName.Text;
                myDataRow["Discount"] = txtDiscount.Text;
                myDataRow["Description"] = txtDescription.Text;
                dtCategory.Rows.Add(myDataRow);
                myDataServices.Update(dtCategory);
            }
            else
            {
                // Lấy dòng đang chọn
                int r = dGVCategory.CurrentRow.Index;
                DataRow myDataRow = dtCategory.Rows[r];
                myDataRow["Name"] = txtName.Text;
                myDataRow["Discount"] = txtDiscount.Text;
                myDataRow["Description"] = txtDescription.Text;
                myDataServices.Update(dtCategory);
            }
            Display();
            SetControls(false);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = "Select * from Discount WHERE Name LIKE '%' + @DrugName + '%'";
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
            dGVCategory.DataSource = myDataTable;
            //6. đóng kết nối và myDataReader
            myDataReader.Close();
            mySqlConnection.Close();
            foreach (DataGridViewColumn column in dGVCategory.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
