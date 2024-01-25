using DrugStoreManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
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
            invoiceContent += "Tên SP\t\t||SL\t||Mã SX\t\t||Giá tiền\n";
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

                // Thêm dòng cho từng sản phẩm
                invoiceContent += $"{productName}\t||{quantity}\t||{prodid}\t||{cost:F2}VND\n";
            }

            // Thêm đường kẻ cuối cùng của danh sách mua hàng
            invoiceContent += "---------------------------------------------------\n";

            // Tính tổng cộng
            decimal total = dtInvoiceDetails.AsEnumerable().Sum(row => Convert.ToDecimal(row["Cost"]));
            invoiceContent += $"Tổng cộng: {total:F2}VND";

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

            //hiển thị dữ liệu lên lưới
            DisplayCustomer();
            DisplayProduct();
            DisplayOrder();

            /*rbDrugName.Checked = true;
            rbCusName.Checked = true;*/
            dGVCustomer.AutoResizeColumns();
            dGVProduct.AutoResizeColumns();
            dGVOrder.AutoResizeColumns();
            int columnIndex = 6; // Thay thế bằng chỉ số cột thực tế
            int newWidth = 100; // Thay thế bằng chiều rộng mới bạn muốn đặt

            dGVProduct.Columns[columnIndex].Width = newWidth;
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
            foreach (DataGridViewColumn column in dGVProduct.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
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
    }
}
