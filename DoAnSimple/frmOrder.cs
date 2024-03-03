using DoAnSimple;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnSimple
{
    public partial class frmOrder : UserControl
    {
        //1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        //2. khai báo datatable để lưu bảng Order_details
        private DataTable dtOrder;
        // 3. khai báo biến kiểm tra đã chọn <thêm mới>
        private bool modeNew;
        public frmOrder()
        {
            InitializeComponent();
        }
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            // lấy sản phẩm ra khỏi datagridview
            if (dGVOrder.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dGVOrder.SelectedRows[0];

                // Check if the selected row is not a new row
                if (!selectedRow.IsNewRow)
                {
                    // Get the "ProductName" cell
                    DataGridViewCell productNameCell = selectedRow.Cells["Name"];

                    // Check if the cell value is not null
                    if (productNameCell.Value != null)
                    {
                        // Get the value of the "DrugName" cell
                        string productName = productNameCell.Value.ToString();

                        // Remove the row from the DataGridView
                        dGVOrder.Rows.Remove(selectedRow);

                        // Refresh the DataGridView
                        dGVOrder.Refresh();

                        // Update the textbox by removing the drug name
                        txtProductName.Text = txtProductName.Text.Replace(productName, string.Empty);
                    }
                }
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // đưa sản phẩm vào datagridview
            // Check if dGVOrder is already bound to a data source
            if (dGVOrder.DataSource == null)
            {
                DataTable dtOrder = new DataTable();
                dtOrder.Columns.Add("ID", typeof(string));
                dtOrder.Columns.Add("Name", typeof(string));
                dtOrder.Columns.Add("ProdID", typeof(string));
                dtOrder.Columns.Add("Price", typeof(string));
                dtOrder.Columns.Add("Quantity", typeof(string));
                dGVOrder.DataSource = dtOrder;
            }

            // Get the currently selected row in dGVProduct
            DataGridViewRow selectedRow = dGVProduct.CurrentRow;

            // Check if a row is selected
            if (selectedRow != null)
            {
                // Retrieve the values from the selected row
                string ID = selectedRow.Cells["ID"].Value?.ToString();
                string Name = selectedRow.Cells["Name"].Value?.ToString();
                string Price = selectedRow.Cells["Price"].Value?.ToString();

                // Get the data source from dGVOrder
                DataTable dtOrder = (DataTable)dGVOrder.DataSource;
                bool productExists = false;
                foreach (DataRow row in dtOrder.Rows)
                {
                    if (row["Name"].ToString().Equals(Name))
                    {
                        productExists = true;
                        break;
                    }
                }

                if (productExists)
                {
                    MessageBox.Show("Đã tồn tại sản phẩm trong danh sách!");
                }
                else
                {
                    // Add the values to a new row in dtOrder
                    DataRow newRow = dtOrder.NewRow();
                    newRow["ID"] = ID;
                    newRow["Name"] = Name;
                    newRow["Price"] = Price;
                    dtOrder.Rows.Add(newRow);
                }

                // Refresh the data source binding
                dGVOrder.DataSource = dtOrder;
            }
        }
        private int orderId = -1;
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // Tạo hóa đơn
            modeNew = true;
            SetControls(true);
            /*            txtCustomerName.Clear();
                        txtPhone.Clear();*/
            txtCustomerName.Focus();
            txtProductName.Clear();
            txtQuantity.Clear();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetControls(true);

            // Kiểm tra xem có giá trị trong txtProductId không
            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                // Kiểm tra xem dtOrder đã được khởi tạo hay chưa
                if (dtOrder == null)
                {
                    // Nếu chưa, tạo một DataTable mới
                    dtOrder = new DataTable();

                    // Thêm các cột vào DataTable
                    dtOrder.Columns.Add("Id");
                    dtOrder.Columns.Add("Name");
                    dtOrder.Columns.Add("ProdId");
                    dtOrder.Columns.Add("Quantity");
                    dtOrder.Columns.Add("Discount");
                }

                // Lấy giá trị của Id từ TextBox
                int productId = Convert.ToInt32(txtProductId.Text);

                // Tạo một dòng mới trong DataTable và thêm vào dữ liệu
                DataRow dataRow = dtOrder.NewRow();
                dataRow["Id"] = productId;
                dataRow["Name"] = txtProductName.Text; // Đã thêm .Text để lấy giá trị từ TextBox
                dataRow["ProdId"] = ((DataRowView)cmbProdId.SelectedItem)["prodid"].ToString();
                dataRow["Quantity"] = txtQuantity.Text; // Đã thêm .Text để lấy giá trị từ TextBox
                dataRow["Discount"] = cmbDiscount.SelectedValue?.ToString(); // Kiểm tra null để tránh lỗi
                dtOrder.Rows.Add(dataRow);

                // Cập nhật nguồn dữ liệu cho DataGridView của hóa đơn
                dGVOrder.DataSource = dtOrder;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu để lưu không
            if (dGVOrder.Rows.Count > 0)
            {
                int r = dGVCustomer.CurrentRow.Index;
                string CustomerId = dGVCustomer.Rows[r].Cells["Id"].Value.ToString();
                string OrderDate = DateTime.Now.ToString();

                string sSql = "INSERT INTO [Order] (CustomerId, Date) VALUES (@CustomerId, @OrderDate); SELECT SCOPE_IDENTITY();";
                orderId = (int)myDataServices.ExecuteScalar(sSql, new SqlParameter("@CustomerId", CustomerId), new SqlParameter("@OrderDate", OrderDate));
                // Duyệt qua từng dòng trong dGVOrder
                foreach (DataGridViewRow row in dGVOrder.Rows)
                {
                    // Lấy thông tin từ mỗi dòng
                    int productId = Convert.ToInt32(row.Cells["Id"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    string discount = row.Cells["Discount"].Value.ToString();
                    string prodid = row.Cells["ProdId"].Value.ToString();
                    // Thực hiện lệnh SQL để cập nhật cơ sở dữ liệu
                    string sql = "INSERT INTO Order_details (Id, ProductId, ProdId, Quantity, DiscountId) VALUES (@OrderId, @ProductId, @ProdId, @Quantity, @Discount)";

                    // Thực hiện ExecuteNonQuery để thực hiện lệnh SQL
                    myDataServices.ExecuteNonQuery(sql,
                        new SqlParameter("@OrderId", orderId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@ProdId", prodid),
                        new SqlParameter("@Quantity", quantity),
                        new SqlParameter("@Discount", discount)
                    );

                    // Lấy giá trị tổng tiền từ bảng Order
                    string totalSql = "SELECT Total FROM [Order] WHERE Id = @OrderId";
                    float total = Convert.ToSingle(myDataServices.ExecuteScalar(totalSql, new SqlParameter("@OrderId", orderId)));

                    // Hiển thị giá trị tổng tiền trong TextBox
                    txtTotal.Text = total.ToString();
                }

                MessageBox.Show("Đã lưu thành công vào cơ sở dữ liệu.");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để lưu.");
            }
            SetControls(false);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Tạo nội dung hóa đơn
            if (orderId != -1)
            {
                string invoiceContent = GenerateInvoiceContent(orderId);

                // Hiển thị hộp thoại để chọn vị trí lưu tệp
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Chọn vị trí để lưu hóa đơn";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu hóa đơn vào tệp tin văn bản
                    File.WriteAllText(saveFileDialog.FileName, invoiceContent);
                    MessageBox.Show("Hóa đơn đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                orderId = -1;
            }
        }
        private DataTable GetInvoiceDetails(int orderId)
        {
            // Thực hiện truy vấn SQL để lấy chi tiết hóa đơn (sản phẩm) cho một hóa đơn cụ thể
            string sSql = "SELECT p.Name AS ProductName, od.ProdId, od.Quantity, od.Cost " +
                          "FROM Order_details od " +
                          "INNER JOIN Product p ON od.ProductId = p.Id " +
                          "WHERE od.Id = @OrderId";

            // Thực hiện truy vấn và trả về DataTable chứa chi tiết hóa đơn
            DataTable dtInvoiceDetails = myDataServices.RunQuery(sSql, new SqlParameter("@OrderId", orderId));

            return dtInvoiceDetails;
        }
        // Xuat hoa don o dang txt
        private string GenerateInvoiceContent(int orderId)
        {
            // Lấy ngày hôm nay
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            // Tạo nội dung hóa đơn
            string invoiceContent = $"HÓA ĐƠN\nNgày: {currentDate}\n";

            // Lấy thông tin khách hàng
            invoiceContent += $"Khách hàng: {txtCustomerName.Text}\n";
            invoiceContent += $"Số điện thoại: {txtPhone.Text}\n\n";

            // Thêm tiêu đề danh sách mua hàng
            invoiceContent += "Danh sách mua hàng:\n";
            invoiceContent += "---------------------------------------------------\n";
            invoiceContent += "Tên SP\t\t\t||SL\t||Mã SX\t\t||Giá tiền\n";
            invoiceContent += "---------------------------------------------------\n";

            // Lấy chi tiết hóa đơn (sản phẩm)
            DataTable dtInvoiceDetails = GetInvoiceDetails(orderId);
            // Thêm thông tin sản phẩm vào nội dung hóa đơn
            foreach (DataRow row in dtInvoiceDetails.Rows)
            {
                string productName = row["ProductName"].ToString();
                string prodid = row["ProdId"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal cost = Convert.ToDecimal(row["Cost"]);

                // Kiểm tra độ dài của Tên SP
                if (productName.Length > 25)
                {
                    // Xuống dòng khi Tên SP có độ dài lớn hơn 25
                    invoiceContent += $"{productName}\n\t\t\t\t||{quantity}\t||{prodid}\t||{cost:F2}VNĐ\n";
                }
                else
                {
                    // Tính toán số lượng khoảng trắng cần thêm để cân chỉnh cột
                    int paddingLength = 25 - productName.Length;
                    string padding = new string(' ', paddingLength);

                    // Thêm dòng cho từng sản phẩm
                    invoiceContent += $"{productName}{padding}||{quantity}\t||{prodid}\t||{cost:F2}VNĐ\n";
                }
            }


            // Thêm đường kẻ cuối cùng của danh sách mua hàng
            invoiceContent += "---------------------------------------------------\n";

            // Tính tổng cộng
            decimal total = dtInvoiceDetails.AsEnumerable().Sum(row => Convert.ToDecimal(row["Cost"]));
            invoiceContent += $"Tổng cộng: {total:F2}VNĐ";

            return invoiceContent;
        }


        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            if (cmbProductFilter.SelectedIndex == 0)
            {
                string sSql = "Select * From Product Where [Name] = N'%" + txtCustomerSearch + "%'";
                DataTable dtCustomer = myDataServices.RunQuery(sSql);
                dGVCustomer.DataSource = dtCustomer;
            }
            else if (cmbProductFilter.SelectedIndex == 1)
            {
                string sSql = "Select * From Product Where [id] = '%" + txtCustomerSearch + "%'";
                DataTable dtCustomer = myDataServices.RunQuery(sSql);
                dGVCustomer.DataSource = dtCustomer;
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (cmbCustomerFilter.SelectedIndex == 0)
            {
                string sSql = "Select * From Customer Where [Name] = N'%" + txtCustomerSearch + "%'";
                DataTable dtCustomer = myDataServices.RunQuery(sSql);
                dGVCustomer.DataSource = dtCustomer;
            }
            else if (cmbCustomerFilter.SelectedIndex == 1)
            {
                string sSql = "Select * From Customer Where [id] = '%" + txtCustomerSearch + "%'";
                DataTable dtCustomer = myDataServices.RunQuery(sSql);
                dGVCustomer.DataSource = dtCustomer;
            }
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Chuyển dữ liệu vào cmbDiscount
            string sSql = "Select * From [Discount] Order By [Name];";
            DataTable dtDiscount = myDataServices.RunQuery(sSql);
            cmbDiscount.ValueMember = "Id";
            cmbDiscount.DisplayMember = "Name";
            cmbDiscount.DataSource = dtDiscount;
            // cmbCustomerFilter
            cmbCustomerFilter.Items.Add("Tìm theo tên");
            cmbCustomerFilter.Items.Add("Tìm theo mã");
            cmbCustomerFilter.SelectedIndex = 0;
            // cmbProductFilter
            cmbProductFilter.Items.Add("Tìm theo tên");
            cmbProductFilter.Items.Add("Tìm theo mã");
            cmbProductFilter.SelectedIndex = 0;
            //
            rbOption1.Checked = true;
            //hiển thị dữ liệu lên lưới
            DisplayCustomer();
            DisplayProduct();
            DisplayOrder();
            DisplayAll();
            /*rbDrugName.Checked = true;
            rbCusName.Checked = true;*/
            dGVCustomer.AutoResizeColumns();
            dGVProduct.AutoResizeColumns();
            dGVOrder.AutoResizeColumns();
            int columnIndex = 6; // Thay thế bằng chỉ số cột thực tế
            int newWidth = 100; // Thay thế bằng chiều rộng mới bạn muốn đặt
            dGVProduct.Columns[columnIndex].Width = newWidth;

            dGVCustomer.Columns[0].HeaderText = "Id";
            dGVCustomer.Columns[1].HeaderText = "Tên";
            dGVCustomer.Columns[2].HeaderText = "Ngày sinh";
            dGVCustomer.Columns[3].HeaderText = "Địa chỉ";
            dGVCustomer.Columns[4].HeaderText = "Số điện thoại";
            dGVCustomer.Columns[5].HeaderText = "Giới tính";

            dGVProduct.Columns[0].HeaderText = "Id";
            dGVProduct.Columns[1].HeaderText = "Tên";
            dGVProduct.Columns[2].HeaderText = "Id loại SP";
            dGVProduct.Columns[3].HeaderText = "Id NCC";
            dGVProduct.Columns[4].HeaderText = "Giá";

            dGVOrderHistory.Columns[0].HeaderText = "Mã đơn hàng";
            dGVOrderHistory.Columns[1].HeaderText = "Mã khách hàng";
            dGVOrderHistory.Columns[2].HeaderText = "Ngày đặt";
            dGVOrderHistory.Columns[3].HeaderText = "Tổng tiền";

            //thiết lập trạng thái các điều khiển
            SetControls(false);
        }
        private void DisplayCustomer()
        {
            string sSql = "Select * from [Customer]";
            DataTable dtOrder = myDataServices.RunQuery(sSql);
            dGVCustomer.DataSource = dtOrder;
            foreach (DataGridViewColumn column in dGVCustomer.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void DisplayProduct()
        {
            string sSql = "Select * from [Product]";
            DataTable dtOrder = myDataServices.RunQuery(sSql);
            dGVProduct.DataSource = dtOrder;
            //foreach (DataGridViewColumn column in dGVProduct.Columns)
            //{
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //}
        }
        private void DisplayOrder()
        {
            // Thiết lập cấu trúc DataTable cho dữ liệu đặt hàng
            DataTable dtOrder = new DataTable();
            dtOrder.Columns.Add("Id");
            dtOrder.Columns.Add("Name");
            dtOrder.Columns.Add("Quantity");
            dtOrder.Columns.Add("Discount");

            // Gán DataTable cho DataGridView dGVOrder
            dGVOrder.DataSource = dtOrder;
        }
        private void SetControls(bool edit)
        {
            // các textbox và combobox
            txtCustomerName.Enabled = edit;
            txtPhone.Enabled = edit;
            txtQuantity.Enabled = edit;
            txtProductName.Enabled = edit;
            txtTotal.Enabled = edit;
            dGVCustomer.Enabled = !edit;
            cmbDiscount.Enabled = edit;
            cmbProdId.Enabled = edit;
            //các nút
            btnAddOrder.Enabled = !edit;
            btnSave.Enabled = edit;
            btnNew.Enabled = edit;
            /*            btnExport.Enabled = edit;*/

            btnRemoveProduct.Enabled = edit;
        }

        private void dGVCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Đưa thông tin khách hàng sang các textbox
            txtCustomerName.Text = dGVCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = dGVCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void dGVProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // đưa tên sản phẩm sang textbox
            if (dGVProduct.Rows[e.RowIndex].Cells[1].Value != null)
            {
                txtProductName.Text = dGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

            txtProductId.Text = dGVProduct.Rows[e.RowIndex].Cells[0].Value.ToString();

            string sql = "select prodid from productdate where productId = @id and expDate >= getdate();";
            DataTable dtProdId = myDataServices.RunQuery(sql, new SqlParameter("@id", txtProductId.Text));
            if (dtProdId.Rows.Count > 0)
            {
                cmbProdId.DataSource = dtProdId;
                cmbProdId.DisplayMember = "prodid";
            }
            else
            {
                MessageBox.Show("Sản phẩm bạn chọn không còn hàng nữa!", "Thông báo", MessageBoxButtons.OK);
                cmbProdId.DataSource = null;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOption2.Checked == true)
            {
                cboTime.Enabled = true;
                label14.Enabled = false;
                label15.Enabled = false;
                dTPStart.Enabled = false;
                dTPEnd.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOption3.Checked == true)
            {
                cboTime.Enabled = false;
                label14.Enabled = true;
                label15.Enabled = true;
                dTPStart.Enabled = true;
                dTPEnd.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOption1.Checked == true)
            {
                cboTime.Enabled = false;
                label14.Enabled = false;
                label15.Enabled = false;
                dTPStart.Enabled = false;
                dTPEnd.Enabled = false;
            }
        }

        private void dGVOrderHistory_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Lay Id cua Order
            string id = dGVOrderHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
            string sql = "Select * from [Order_details] where [id] = @id";
            DataTable dt = myDataServices.RunQuery(sql, new SqlParameter("@id", id));
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridView1.Columns[0].HeaderText = "Mã đơn hàng";
            dataGridView1.Columns[1].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Mã sản xuất";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Mã giảm giá";
            dataGridView1.Columns[5].HeaderText = "Giá ban đầu";
            dataGridView1.Columns[6].HeaderText = "Thành tiền";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rbOption1.Checked == true)
            {
                DisplayAll();
            }
            else
            {
                DisplayByTime();
            }
        }

        // dgvOrderHistory
        private void DisplayAll()
        {
            string sql = "Select * from [Order] Order By [Date] desc";
            DataTable dt = myDataServices.RunQuery(sql);
            dGVOrderHistory.DataSource = dt;
            foreach (DataGridViewColumn column in dGVOrderHistory.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void DisplayByTime()
        {
            String sql;
            DataTable dt = new DataTable();
            if (rbOption2.Checked == true)
            {
                // Nam
                if (cboTime.SelectedIndex == 0)
                {
                    sql = "Select * from [Order] where [Date] >= DATEADD(YEAR, -1, GETDATE());";
                    dt = myDataServices.RunQuery(sql);
                    dGVOrderHistory.DataSource = dt;
                }
                // Thang
                if (cboTime.SelectedIndex == 1)
                {
                    sql = "Select * from [Order] where [Date] >= DATEADD(MM, DATEDIFF(MM, 0, GETDATE()), 0) " +
                        "and [Date]< DATEADD(MM, DATEDIFF(MM, 0, GETDATE()) + 1, 0)";
                    dt = myDataServices.RunQuery(sql);
                    dGVOrderHistory.DataSource = dt;
                }
                // Tuan
                if (cboTime.SelectedIndex == 2)
                {
                    sql = "Select * from [Order] where [Date] >= DATEADD(WK, DATEDIFF(WK, 0, GETDATE()), 0)\r\n  " +
                        "AND [Date] < DATEADD(WK, DATEDIFF(WK, 0, GETDATE()) + 1, 0);";
                    dt = myDataServices.RunQuery(sql);
                    dGVOrderHistory.DataSource = dt;
                }
                // Ngay
                if (cboTime.SelectedIndex == 3)
                {
                    sql = "Select * from [Order] WHERE [Date] >= CAST(GETDATE() AS DATE)\r\n  " +
                        "AND [Date] < DATEADD(DAY, 1, CAST(GETDATE() AS DATE));";
                    dt = myDataServices.RunQuery(sql);
                    dGVOrderHistory.DataSource = dt;
                }
            }
            // Start + End
            if (rbOption3.Checked == true)
            {
                DateTime start = dTPStart.Value;
                DateTime end = dTPEnd.Value;
                sql = "Select * from [Order] WHERE [Date] Between @start and @end;";
                dt = myDataServices.RunQuery(sql, new SqlParameter("@start", start.ToString()), new SqlParameter("@end", end.ToString()));
                dGVOrderHistory.DataSource = dt;
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTotal.Text.Replace(",", ""), out decimal amount))
            {
                txtTotal.Text = string.Format("{0:#,0}", amount);
                txtTotal.SelectionStart = txtTotal.Text.Length;
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Trim().Length == 0)
            {
                DisplayCustomer();
            }
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtProductSearch.Text.Trim().Length == 0)
            {
                DisplayProduct();
            }
        }
    }
}
