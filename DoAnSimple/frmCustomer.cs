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


            //DisplayHistory();
        }
        string id;
        void DisplayHistory()
        {
            /*
            // Hiện lịch sử mua hàng của khách hàng lên dgvBuyHistory
            string sql = "Select o.id, o.[date], p.[name], od.prodid, od.quantity, od.price, od.discountId, od.cost \r\n" +
                "from vw_customer_clone c \r\n" +
                "join [Order] o on c.Id = o.CustomerId" +
                "\r\njoin Order_details od on od.Id = o.Id " +
                "\r\njoin product p on od.productId = p.id" +
                "\r\nwhere o.customerid = @customerID" +
                "\r\norder by o.[date] desc";
            DataTable dtHis = myDataServices.RunQuery(sql, new SqlParameter("@customerID", txtId.Text));
            */
            string sql = "select id, date, name, prodid, quantity, price, discountid, cost from vw_customer_clone_2 " +
                "\r\nwhere customerid = @customerID" +
                "\r\norder by [date] desc";
            DataTable dtHis = myDataServices.RunQuery(sql, new SqlParameter("@customerID", id));
            dGVHistory.DataSource = dtHis;
            dGVHistory.Columns[0].HeaderText = "Mã đơn hàng";
            dGVHistory.Columns[1].HeaderText = "Ngày đặt";
            dGVHistory.Columns[2].HeaderText = "Tên sản phẩm";
            dGVHistory.Columns[3].HeaderText = "Mã sản xuất";
            dGVHistory.Columns[4].HeaderText = "Số lượng";
            dGVHistory.Columns[5].HeaderText = "Giá SP";
            dGVHistory.Columns[6].HeaderText = "Giảm giá";
            dGVHistory.Columns[7].HeaderText = "Thành tiền";
            foreach (DataGridViewColumn column in dGVHistory.Columns)
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

                string checkQuery = "SELECT COUNT(*) FROM customer WHERE phone = @phone";
                int count = myDataServices.ExecuteScalar(checkQuery, new SqlParameter("@phone", txtContact.Text));

                if (count > 0)
                {
                    // Số điện thoại đã tồn tại, thông báo bằng MessageBox
                    MessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Số điện thoại không trùng, tiếp tục thêm vào cơ sở dữ liệu
                    string insertQuery = "INSERT INTO customer VALUES (@name, @dob, @address, @phone, @gender)";
                    myDataServices.ExecuteNonQuery(insertQuery,
                        new SqlParameter("@name", txtName.Text),
                        new SqlParameter("@dob", dateDOB.Value.ToString("yyyy-MM-dd")),
                        new SqlParameter("@address", txtAddress.Text),
                        new SqlParameter("@phone", txtContact.Text),
                        new SqlParameter("@gender", cmbGender.SelectedIndex));

                    // Thông báo thành công
                    MessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 1. Thêm dữ liệu vào bảng Product
                //DataRow myDataRow = dtCustomer.NewRow();
                //myDataRow["Name"] = txtName.Text;
                //myDataRow["DOB"] = dateDOB.Value;
                //myDataRow["Address"] = txtAddress.Text;
                //myDataRow["Phone"] = txtContact.Text;
                //myDataRow["Gender"] = cmbGender.SelectedIndex;
                //dtCustomer.Rows.Add(myDataRow);
                //myDataServices.Update(dtCustomer);

                // Test 1
                //Console.WriteLine(dateDOB.Value.ToString("yyyy-MM-dd"));

                //string test = "INSERT INTO customer VALUES (@name, @dob, @address, @phone, @gender)";

                //myDataServices.ExecuteNonQuery(test,
                //    new SqlParameter("@name", txtName.Text),
                //    new SqlParameter("@dob", dateDOB.Value.ToString("yyyy-MM-dd")),
                //    new SqlParameter("@address", txtAddress.Text),
                //    new SqlParameter("@phone", txtContact.Text),
                //    new SqlParameter("@gender", cmbGender.SelectedIndex));


            }
            else
            {
                // Edit data in the Drugs table
                // Lấy dòng đang chọn
                //int r = dGVCustomer.CurrentRow.Index;
                //DataRow myDataRow = dtCustomer.Rows[r];
                //myDataRow["Name"] = txtName.Text;
                //myDataRow["DOB"] = dateDOB.Value;
                //myDataRow["Address"] = txtAddress.Text;
                //myDataRow["Phone"] = txtContact.Text;
                //myDataRow["Gender"] = cmbGender.SelectedIndex;
                //myDataServices.Update(dtCustomer);

                string test = "update customer \r\n" +
                    "set [name] = @name, dob = @dob, " +
                    "[address] = @address, phone = @phone, " +
                    "gender = @gender\r\n" +
                    "where id = @id";

                myDataServices.ExecuteNonQuery(test, new SqlParameter("@name", txtName.Text), new SqlParameter("@dob", dateDOB.Value), new SqlParameter("@address", txtAddress.Text), new SqlParameter("@phone", txtContact.Text), new SqlParameter("@gender", cmbGender.SelectedIndex), new SqlParameter("@id", txtId.Text));
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
            string cId = dGVCustomer.Rows[r].Cells["Id"].Value.ToString();
            // Xóa dữ liệu khỏi bảng Product
            string sSql = "DELETE FROM [Customer] WHERE Id = @cId";
            myDataServices.ExecuteNonQuery(sSql, new SqlParameter("@cId", cId));
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

        void dgvCustomerDisplay()
        {
            // Khai báo xâu truy vấn sql
            string sSql = "Select * From [Customer] Order by [Id]";
            DataTable dtCustomer2 = myDataServices.RunQuery(sSql);
            // From now on, do not change the context of myDataService() - do not use it for other tables
            // Hiển thị lên grid
            dGVCustomer2.DataSource = dtCustomer;
            foreach (DataGridViewColumn column in dGVCustomer2.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dGVCustomer2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerId.Text = dGVCustomer2.Rows[e.RowIndex].Cells[0].Value.ToString();
            id = txtCustomerId.Text;
            txtCustomerName.Text = dGVCustomer2.Rows[e.RowIndex].Cells[1].Value.ToString();

            // Thực hiện truy vấn để lấy tổng quantity và cost
            string sql = "SELECT SUM(od.quantity) AS TotalQuantity, SUM(od.cost) AS TotalCost " +
                         "FROM customer c " +
                         "JOIN [order] o ON c.id = o.customerid " +
                         "JOIN order_details od ON od.id = o.id " +
                         "WHERE c.id = @cusid";

            DataTable dtCustomer2 = myDataServices.RunQuery(sql, new SqlParameter("@cusid", txtCustomerId.Text));

            // Kiểm tra xem có dữ liệu trả về từ truy vấn hay không
            if (dtCustomer2.Rows.Count > 0)
            {
                // Lấy giá trị tổng quantity và cost từ DataTable
                object totalQuantityObj = dtCustomer2.Rows[0]["TotalQuantity"];
                object totalCostObj = dtCustomer2.Rows[0]["TotalCost"];

                // Kiểm tra xem giá trị có phải là DBNull không trước khi chuyển đổi
                int totalQuantity = totalQuantityObj != DBNull.Value ? Convert.ToInt32(totalQuantityObj) : 0;
                decimal totalCost = totalCostObj != DBNull.Value ? Convert.ToDecimal(totalCostObj) : 0;

                // Hiển thị giá trị trong các TextBox
                txtTotalAmount.Text = totalQuantity.ToString();
                txtTotalRevenue.Text = totalCost.ToString();
            }
            else
            {
                // Nếu không có dữ liệu trả về, đặt giá trị trong các TextBox thành rỗng hoặc giá trị mặc định
                txtTotalAmount.Text = "";
                txtTotalRevenue.Text = "";
            }
            DisplayHistory();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = "Select * from customer WHERE [Name] LIKE '%' + @Name + '%'";
            DisplaySearch(sSql, new SqlParameter("@Name", txtSearch.Text.Trim()));
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
            dGVCustomer.DataSource = myDataTable;
            //6. đóng kết nối và myDataReader
            myDataReader.Close();
            mySqlConnection.Close();
            foreach (DataGridViewColumn column in dGVCustomer.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dgvCustomerDisplay();
        }

        private void txtTotalRevenue_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTotalRevenue.Text.Replace(",", ""), out decimal amount))
            {
                txtTotalRevenue.Text = string.Format("{0:#,0}", amount);
                txtTotalRevenue.SelectionStart = txtTotalRevenue.Text.Length;
            }
        }
    }
}
