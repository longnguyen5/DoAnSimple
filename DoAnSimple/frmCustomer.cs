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
    public partial class frmCustomer : UserControl
    {
        // 1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        // 2. khai báo đối tượng DataTable để lưu dũ liệu bảng Customer
        private DataTable dtCustomer;
        // 3. khai báo biến kiểm tra đã chọn <thêm mới> hoặc <sửa>
        private bool modeNew;
        // 4. khai báo biến để kiểm tra trùng tên thuốc
        private string oldPhone;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cmbGender.Items.Add("Nữ");
            cmbGender.Items.Add("Nam");
            cmbGender.SelectedIndex = 0;
            Display();
            // Thiết lập trạng thái các điều khiển
            dGVCustomer.AutoResizeColumns();
            dGVCustomer.Columns[0].HeaderText = "ID Khách hàng";
            dGVCustomer.Columns[1].HeaderText = "Họ và tên";
            dGVCustomer.Columns[2].HeaderText = "Ngày sinh";
            dGVCustomer.Columns[3].HeaderText = "Địa chỉ";
            dGVCustomer.Columns[4].HeaderText = "Số điện thoại";
            dGVCustomer.Columns[5].HeaderText = "Giới tính";
            SetControls(false);
        }

        private void Display()
        {
            // Khai báo xâu truy vấn sql
            string sSql = "Select * From [Customer] Order by [Id]";
            dtCustomer = myDataServices.RunQuery(sSql);
            // From now on, do not change the context of myDataService() - do not use it for other tables
            // Hiển thị lên grid
            dGVCustomer.DataSource = dtCustomer;
            foreach (DataGridViewColumn column in dGVCustomer.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetControls(bool edit)
        {
            // Các check list combobox và textbox
            txtId.Enabled = edit;
            txtName.Enabled = edit;
            txtContact.Enabled = edit;
            txtAddress.Enabled = edit;
            cmbGender.Enabled = edit;
            dateDOB.Enabled = edit;
            // Các nút
            btnAdd.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnDelete.Enabled = !edit;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;

            dGVCustomer.Enabled = !edit;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Nút thêm
            modeNew = true;
            SetControls(true);
            txtId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
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

        private void dGVCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị giới tính của khách hàng
            cmbGender.SelectedIndex = Convert.ToInt32(dGVCustomer.Rows[e.RowIndex].Cells[5].Value);
            // Hiển thị các textbox khác 
            txtId.Text = dGVCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateDOB.Value = Convert.ToDateTime(dGVCustomer.Rows[e.RowIndex].Cells[2].Value);
            txtAddress.Text = dGVCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtContact.Text = dGVCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
            // Lưu tên khách hàng để check trùng tên hay không
            oldPhone = txtContact.Text;

            // Hiện lịch sử mua hàng của khách hàng lên dgvBuyHistory
            string sql = "Select o.id, o.[date], p.[name], od.prodid, od.quantity, od.price, od.discountId, od.cost \r\n" +
                "from Customer c \r\n" +
                "join [Order] o on c.Id = o.CustomerId" +
                "\r\njoin Order_details od on od.Id = o.Id " +
                "\r\njoin product p on od.productId = p.id" +
                "\r\nwhere o.customerid = @customerID" +
                "\r\norder by o.[date] desc";
            DataTable dt = myDataServices.RunQuery(sql, new SqlParameter("@customerID", txtId.Text));
            dGVBuyHistory.DataSource = dt;
            dGVBuyHistory.Columns[0].HeaderText = "Mã đơn hàng";
            dGVBuyHistory.Columns[1].HeaderText = "Ngày đặt";
            dGVBuyHistory.Columns[2].HeaderText = "Tên sản phẩm";
            dGVBuyHistory.Columns[3].HeaderText = "Mã sản xuất";
            dGVBuyHistory.Columns[4].HeaderText = "Số lượng";
            dGVBuyHistory.Columns[5].HeaderText = "Giá SP";
            dGVBuyHistory.Columns[6].HeaderText = "Giảm giá";
            dGVBuyHistory.Columns[7].HeaderText = "Thành tiền";
            foreach (DataGridViewColumn column in dGVBuyHistory.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            if (txtContact.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContact.Focus();
                return;
            }
            // Thêm mới hoặc sửa
            if (modeNew)
            {
                // Thêm mới 
                // 1. Thêm dữ liệu vào bảng Product
                DataRow myDataRow = dtCustomer.NewRow();
                myDataRow["Name"] = txtName.Text;
                myDataRow["DOB"] = dateDOB.Value;
                myDataRow["Address"] = txtAddress.Text;
                myDataRow["Phone"] = txtContact.Text;
                myDataRow["Gender"] = cmbGender.SelectedIndex;
                dtCustomer.Rows.Add(myDataRow);
                myDataServices.Update(dtCustomer);
            }
            else
            {
                // Edit data in the Drugs table
                // Lấy dòng đang chọn
                int r = dGVCustomer.CurrentRow.Index;
                DataRow myDataRow = dtCustomer.Rows[r];
                myDataRow["Name"] = txtName.Text;
                myDataRow["DOB"] = dateDOB.Value;
                myDataRow["Address"] = txtAddress.Text;
                myDataRow["Phone"] = txtContact.Text;
                myDataRow["Gender"] = cmbGender.SelectedIndex;
                myDataServices.Update(dtCustomer);
            }
            Display();
            SetControls(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Nút xóa
            // Thông báo người dùng có chắc chắn xóa dữ liệu
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            // Lấy mã của dòng được chọn trong dGVProduct
            int r = dGVCustomer.CurrentRow.Index;
            // Lấy mã ProductId
            string ProductId = dGVCustomer.Rows[r].Cells["Id"].Value.ToString();
            // Xóa dữ liệu khỏi bảng Product
            string sSql = "DELETE FROM [Product] WHERE Id = @ProductId";
            myDataServices.ExecuteNonQuery(sSql, new SqlParameter("@ProductId", ProductId));
            // Refresh the data display
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length == 0)
            {
                Display();
            }
        }
    }
}
