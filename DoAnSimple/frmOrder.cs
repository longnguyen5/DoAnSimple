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
    public partial class frmOrder : UserControl
    {
        //1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        //2. khai báo datatable để lưu bảng Import
        private DataTable dtImport;
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

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // Tạo hóa đơn
            modeNew = true;
            SetControls(true);
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtCustomerName.Focus();
            txtProductName.Clear();
            txtQuantity.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Thêm sản phẩm ở chi tiết hóa đơn
            SetControls(true);
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtCustomerName.Focus();
            txtProductName.Clear();
            txtQuantity.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Thêm mới
            // 1. Insert 
            string customerIDQuery = "SELECT [Id] FROM [Customer] WHERE [Name] LIKE N'%' + @CustomerName + '%'";
            string drugIDQuery = "SELECT [Id] FROM Drugs WHERE [Name] LIKE N'%' + @DrugName + '%'";
            // Insert vào bảng Order một đơn hàng và nhận lại ID của đơn đặt hàng vừa tạo
            string ordersSql = "INSERT INTO [Order] (OrderDate, TotalPrice) OUTPUT INSERTED.Id VALUES (@OrderDate, @TotalPrice);";
            // Lấy CustomerID
            string customerID = myDataServices.ExecuteScalar(customerIDQuery, new SqlParameter("@CustomerName", txtCustomerName.Text.Trim())).ToString();






        }

        private void btnExport_Click(object sender, EventArgs e)
        {

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
            // Chuyển dữ liệu vào cmbCategory
            string sSql = "Select * From [Discount] Order By [Name];";
            DataTable dtDiscount = myDataServices.RunQuery(sSql);
            cmbDiscount.DataSource = dtDiscount;
            cmbDiscount.DisplayMember = "Name";
            cmbDiscount.ValueMember = "Id";
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
            //thiết lập trạng thái các điều khiển
            SetControls(false);
        }
        private void DisplayCustomer()
        {
            string sSql = "Select * from [Customer]";
            DataTable dtOrder = myDataServices.RunQuery(sSql);
            dGVCustomer.DataSource = dtOrder;
        }
        private void DisplayProduct()
        {
            string sSql = "Select * from [Product]";
            DataTable dtOrder = myDataServices.RunQuery(sSql);
            dGVProduct.DataSource = dtOrder;
        }
        private void DisplayOrder()
        {
            //string sSql = "Select top 0 Drugs.DrugID, Drugs.DrugName, Drugs.Price, Quantity from Drugs, OrderDetails where Drugs.DrugID = OrderDetails.DrugID";
            string sSql = "Select TOP 0 p.Id, p.Name, p.Price, p.Quantity from [Product] p";
            DataTable dtOrder = myDataServices.RunQuery(sSql);
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
            dateOrderDate.Enabled = edit;
            cmbDiscount.Enabled = edit;
            //các nút
            btnAddOrder.Enabled = !edit;
            btnSave.Enabled = edit;
            btnNew.Enabled = edit;
            btnExport.Enabled = edit;
            btnAddProduct.Enabled = edit;
            btnRemoveProduct.Enabled = edit;
        }

        private void dGVCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerName.Text = dGVCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = dGVCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void dGVProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = dGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
