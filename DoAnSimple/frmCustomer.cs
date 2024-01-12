using DrugStoreManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private string oldCustomerName;

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
            oldCustomerName = txtName.Text;
        }
    }
}
