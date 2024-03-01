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
    public partial class frmEmployee : UserControl
    {
        // 1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        // 2. khai báo đối tượng DataTable để lưu dũ liệu bảng User
        private DataTable dtUser;
        // 3. khai báo biến kiểm tra đã chọn <thêm mới> hoặc <sửa>
        private bool modeNew;
        // 4. khai báo biến để kiểm tra trùng tên 
        private string oldName;
        // 5. khai báo biến imagePath
        private string imagePath;
        public frmEmployee()
        {
            InitializeComponent();
            this.AutoScroll = true;
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

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            SetControls(false);
            dGVProduct.AutoResizeColumns();
            Display();
            dGVProduct.CellFormatting += new DataGridViewCellFormattingEventHandler(dGVProduct_CellFormatting);
            dGVProduct.Columns[1].HeaderText = "Tên nhân viên";
            dGVProduct.Columns[2].HeaderText = "Tài khoản";
            dGVProduct.Columns[3].HeaderText = "Mật khẩu";
            dGVProduct.Columns[4].HeaderText = "Số điện thoại";
            dGVProduct.Columns[5].HeaderText = "Email";
            dGVProduct.Columns[6].HeaderText = "Trạng thái";
            dGVProduct.Columns[7].HeaderText = "Mô tả";
            dGVProduct.Columns[8].HeaderText = "Loại";
            dGVProduct.Columns[9].HeaderText = "Hình ảnh";
            dGVProduct.Columns[10].HeaderText = "Ngày vào";
        }
        private void dGVProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem đang định dạng cột mật khẩu hay không (đổi 'Password' thành tên thực tế của cột)
            if (e.ColumnIndex >= 0 && dGVProduct.Columns[e.ColumnIndex].Name == "Password")
            {
                // Kiểm tra giá trị không phải null để tránh lỗi
                if (e.Value != null)
                {
                    // Đổi giá trị thành số dấu * tương ứng với độ dài của mật khẩu
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
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

            string type = dGVProduct.Rows[e.RowIndex].Cells[8].Value.ToString();
            if (type == "0")
            {
                cmbUserType.SelectedIndex = 0;
            }
            else
            {
                cmbUserType.SelectedIndex = 1;
            }
            // Hiển thị các textbox khác 
            oldName = txtName.Text;
            txtId.Text = dGVProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = dGVProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtUserName.Text = dGVProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = dGVProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dGVProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDescription.Text = dGVProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
            dateTimePicker.Value = Convert.ToDateTime(dGVProduct.Rows[e.RowIndex].Cells[10].Value);
            string duLieuHinhAnh = dGVProduct.Rows[e.RowIndex].Cells[9].Value.ToString();

            if (string.IsNullOrEmpty(duLieuHinhAnh))
            {
                // Nếu đường dẫn hình ảnh rỗng, sử dụng ảnh mặc định
                pictureBox.Image = Properties.Resources.user;
            }
            else
            {
                // Ngược lại, sử dụng đường dẫn hình ảnh từ cơ sở dữ liệu
                pictureBox.ImageLocation = duLieuHinhAnh;
                imagePath = duLieuHinhAnh;
            }
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
            checkBox.Enabled = edit;
            dGVProduct.Enabled = !edit;

            // Các nút

            btnAdd.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnDelete.Enabled = !edit;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;
            btnImage.Enabled = edit;
            button1.Enabled = edit;
            dateTimePicker.Enabled = edit;
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
            pictureBox.Image = Properties.Resources.user;
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
                myDataRow["ImagePath"] = imagePath;
                myDataRow["DateIn"] = dateTimePicker.Value.ToString();
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
                myDataRow["ImagePath"] = imagePath;
                myDataRow["DateIn"] = dateTimePicker.Value.ToString();
                myDataServices.Update(dtUser);
            }
            imagePath = "";
            Display();
            SetControls(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = "SELECT * FROM [User] WHERE [Name] LIKE '%' + @UserName + '%'";
            DisplaySearch(sSql, new SqlParameter("@UserName", txtSearch.Text.Trim()));
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

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(dlg.FileName);
                imagePath = dlg.FileName;
            }
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Khi trạng thái của CheckBox thay đổi, thay đổi kiểu hiển thị của TextBox mật khẩu
            txtPassword.UseSystemPasswordChar = !checkBox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imagePath = null;
            pictureBox.Image = Properties.Resources.user;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                Display();
            }
        }
    }
}
