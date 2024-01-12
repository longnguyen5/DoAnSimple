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
    public partial class frmProduct : UserControl
    {
        // 1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        // 2. khai báo đối tượng DataTable để lưu dũ liệu bảng Product
        private DataTable dtProduct;
        // 3. khai báo biến kiểm tra đã chọn <thêm mới> hoặc <sửa>
        private bool modeNew;
        // 4. khai báo biến để kiểm tra trùng tên thuốc
        private string oldProductName;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Cập nhật số lượng sản phẩm (Loại bỏ các sản phẩm đã hết hạn sử dụng)
            string sSql = "UPDATE Product\r\n" +
                "SET Quantity = (SELECT SUM(SH.Quantity) \r\n               " +
                "FROM Product_Date AS SH\r\n               " +
                "WHERE SH.MaSP = Product.MaSP\r\n                 " +
                "AND CAST(SH.HSD AS DATE) >= CAST(GETDATE() AS DATE))\r\n";
            myDataServices.ExecuteNonQuery(sSql);
            // Chuyển dữ liệu vào cmbCategory
            sSql = "Select * From [Category] Order By [Name];";
            DataTable dtCategory = myDataServices.RunQuery(sSql);
            cmbCategory.DataSource = dtCategory;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
            // Chuyển dữ liệu vào cmbSupplier
            sSql = "Select * From [Supplier] Order By [Name];";
            DataTable dtSupplier = myDataServices.RunQuery(sSql);
            cmbSupplier.DataSource = dtSupplier;
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";
            // Hiển thị dữ liệu lên lưới
            Display();
            // Thiết lập trạng thái các điều khiển
            dGVProduct.AutoResizeColumns();
            SetControls(false);
        }
        private void dGVProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị tên loại sản phẩm ứng với CategoryId
            cmbCategory.SelectedValue = dGVProduct.Rows[e.RowIndex].Cells[2].Value.ToString(); ;
            // Hiển thị tên loại sản phẩm ứng với SupplierId
            cmbSupplier.SelectedValue = dGVProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            // Hiển thị các textbox khác 
            txtId.Text = dGVProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dGVProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtQuantity.Text = dGVProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDescription.Text = dGVProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
            // Lưu tên sản phẩm để check trùng tên hay không
            oldProductName = txtName.Text;
        }
        private void Display()
        {
            // Khai báo xâu truy vấn sql
            string sSql = "Select * From [Product] Order by [Id]";
            dtProduct = myDataServices.RunQuery(sSql);
            // From now on, do not change the context of myDataService() - do not use it for other tables
            // Hiển thị lên grid
            dGVProduct.DataSource = dtProduct;
            foreach (DataGridViewColumn column in dGVProduct.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void SetControls(bool edit)
        {
            // Các check list combobox và textbox
            txtName.Enabled = edit;
            cmbSupplier.Enabled = edit;
            cmbCategory.Enabled = edit;
            txtPrice.Enabled = edit;
            txtQuantity.Enabled = edit;
            txtDescription.Enabled = edit;
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
            txtPrice.Clear();
            txtDescription.Clear();
            txtQuantity.Clear();
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
            // Lấy mã của dòng được chọn trong dGVProduct
            int r = dGVProduct.CurrentRow.Index;
            // Lấy mã ProductId
            string ProductId = dGVProduct.Rows[r].Cells["Id"].Value.ToString();
            // Xóa dữ liệu khỏi bảng Product
            string sSql = "DELETE FROM [Product] WHERE Id = @ProductId";
            myDataServices.ExecuteNonQuery(sSql, new SqlParameter("@ProductId", ProductId));
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
            if (txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập giá sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out int quantityValue))
            {
                MessageBox.Show("Vui lòng nhập một giá trị số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return;
            }
            if (quantityValue < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return;
            }
            string sSql;
            // 2. Kiểm tra có trùng tên sản phẩm hay không
            if (modeNew || (!modeNew && txtName.Text.Trim() != oldProductName.Trim()))
            {
                sSql = "Select * From [Product] Where [Name] = @Name";
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
                DataRow myDataRow = dtProduct.NewRow();
                myDataRow["Name"] = txtName.Text;
                myDataRow["CategoryId"] = cmbCategory.SelectedValue;
                myDataRow["SupplierId"] = cmbSupplier.SelectedValue;
                myDataRow["Price"] = txtPrice.Text;
                myDataRow["Quantity"] = txtQuantity.Text;
                myDataRow["Description"] = txtDescription.Text;
                dtProduct.Rows.Add(myDataRow);
                myDataServices.Update(dtProduct);
            }
            else
            {
                // Edit data in the Drugs table
                // Lấy dòng đang chọn
                int r = dGVProduct.CurrentRow.Index;
                DataRow myDataRow = dtProduct.Rows[r];
                myDataRow["Name"] = txtName.Text;
                myDataRow["CategoryID"] = cmbCategory.SelectedValue;
                myDataRow["SupplierID"] = cmbSupplier.SelectedValue;
                myDataRow["Price"] = txtPrice.Text;
                myDataRow["Quantity"] = txtQuantity.Text;
                myDataRow["Description"] = txtDescription.Text;
                myDataServices.Update(dtProduct);
            }
            Display();
            SetControls(false);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = "Select * from Product WHERE Name LIKE '%' + @DrugName + '%'";
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


    }
}
