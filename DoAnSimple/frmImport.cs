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
using System.Xml.Linq;

namespace DoAnSimple
{
    public partial class frmImport : UserControl
    {
        //1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        //2. khai báo datatable để lưu bảng Import_details
        private DataTable dtImport;
        public frmImport()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }
        private void frmImport_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Các comboBox
            cmbProductFilter.Items.Add("Tìm theo tên");
            cmbProductFilter.Items.Add("Tìm theo mã");
            cmbProductFilter.SelectedIndex = 0;

            cmbSupplierFilter.Items.Add("Tìm theo tên");
            cmbSupplierFilter.Items.Add("Tìm theo mã");
            cmbSupplierFilter.SelectedIndex = 0;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

            dGVSupplier.AutoResizeColumns();
            dGVProduct.AutoResizeColumns();
            dGVImport.AutoResizeColumns();

            DisplayProduct();
            DisplayCustomer();
            DisplayImport();
            SetControls(false);
        }
        private void DisplayImport()
        {
            // Thiết lập cấu trúc DataTable cho dữ liệu đặt hàng
            DataTable dtImport = new DataTable();
            dtImport.Columns.Add("ProductId");
            dtImport.Columns.Add("ProdId");
            dtImport.Columns.Add("Name");
            dtImport.Columns.Add("Quantity");
            dtImport.Columns.Add("Price");
            dtImport.Columns.Add("ProductDate");
            dtImport.Columns.Add("ExpireDate");

            // Gán DataTable cho DataGridView dGVOrder
            dGVImport.DataSource = dtImport;
            dGVImport.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dGVImport.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
        private void DisplayCustomer()
        {
            string sSql = "Select * from [Supplier]";
            DataTable dtSupplier = myDataServices.RunQuery(sSql);
            dGVSupplier.DataSource = dtSupplier;
            foreach (DataGridViewColumn column in dGVSupplier.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void DisplayProduct()
        {
            string sSql = "Select * from [Product]";
            DataTable dtProduct = myDataServices.RunQuery(sSql);
            dGVProduct.DataSource = dtProduct;
            foreach (DataGridViewColumn column in dGVProduct.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            if (cmbSupplierFilter.SelectedIndex == 0)
            {
                string sSql = "Select * From Customer Where [Name] = N'%" + txtSupplierSearch + "%'";
                DataTable dtSupplier = myDataServices.RunQuery(sSql);
                dGVSupplier.DataSource = dtSupplier;
            }
            else if (cmbSupplierFilter.SelectedIndex == 1)
            {
                string sSql = "Select * From Customer Where [id] = '%" + txtSupplierSearch + "%'";
                DataTable dtSupplier = myDataServices.RunQuery(sSql);
                dGVSupplier.DataSource = dtSupplier;
            }
        }

        private void dGVSupplier_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Supplier (Id, Name, Contact, Address)
            string supid = dGVSupplier.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            txtSupplierName.Text = dGVSupplier.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtContact.Text = dGVSupplier.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
            string sSql = "Select * From Product Where [SupplierId] = @supplierid";
            DataTable dtProduct = myDataServices.RunQuery(sSql, new SqlParameter("@supplierid", supid));
            dGVProduct.DataSource = dtProduct;
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            if (cmbProductFilter.SelectedIndex == 0)
            {
                string sSql = "Select * From Product Where [Name] = N'%" + txtProductSearch + "%'";
                DataTable dtProduct = myDataServices.RunQuery(sSql);
                dGVProduct.DataSource = dtProduct;
            }
            else if (cmbProductFilter.SelectedIndex == 1)
            {
                string sSql = "Select * From Product Where [id] = '%" + txtProductSearch + "%'";
                DataTable dtProduct = myDataServices.RunQuery(sSql);
                dGVProduct.DataSource = dtProduct;
            }
        }

        private void dGVProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = dGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductId.Text = dGVProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void SetControls(bool edit)
        {
            // các textbox và combobox
            txtSupplierName.Enabled = edit;
            txtContact.Enabled = edit;
            txtProductName.Enabled = edit;
            txtProductId.Enabled = edit;
            txtQuantity.Enabled = edit;
            textBox1.Enabled = edit;
            txtPrice.Enabled = edit;
            txtTotal.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            dateTimePicker2.Enabled = edit;
            //các nút
            btnAddImport.Enabled = !edit;
            btnNew.Enabled = edit;
            btnSave.Enabled = edit;

        }
        int importId = -1;
        private void btnAddImport_Click(object sender, EventArgs e)
        {
            SetControls(true);
            txtSupplierName.Clear();
            txtContact.Clear();
            txtProductId.Clear();
            textBox1.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            if (dtImport != null)
            {
                dtImport.Rows.Clear(); // Nếu cần
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetControls(true);
            textBox1.Clear();
            txtProductId.Clear();
            txtProductName.Clear();
            // Kiểm tra xem có giá trị trong txtProductId không
            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                // Kiểm tra xem dtOrder đã được khởi tạo hay chưa
                if (dtImport == null)
                {
                    // Nếu chưa, tạo một DataTable mới
                    dtImport = new DataTable();

                    // Thêm các cột vào DataTable
                    dtImport.Columns.Add("Id");
                    dtImport.Columns.Add("ProdId");
                    dtImport.Columns.Add("Name");
                    dtImport.Columns.Add("Quantity");
                    dtImport.Columns.Add("Price");
                    /*dtImport.Columns.Add("Cost");*/
                    dtImport.Columns.Add("ProductDate");
                    dtImport.Columns.Add("ExpireDate");
                }

                // Lấy giá trị của Id từ TextBox
                int productId = Convert.ToInt32(txtProductId.Text);

                // Tạo một dòng mới trong DataTable và thêm vào dữ liệu
                DataRow dataRow = dtImport.NewRow();
                dataRow["Id"] = productId;
                dataRow["ProdId"] = textBox1.Text;
                dataRow["Name"] = txtProductName.Text;
                dataRow["ProdId"] = textBox1.Text;
                dataRow["Quantity"] = txtQuantity.Text;
                dataRow["Price"] = txtPrice.Text;
                DateTime dt1 = dateTimePicker1.Value.Date;
                DateTime dt2 = dateTimePicker2.Value.Date;

                dataRow["ProductDate"] = dt1;
                dataRow["ExpireDate"] = dt2;

                dtImport.Rows.Add(dataRow);

                // Cập nhật nguồn dữ liệu cho DataGridView của hóa đơn
                dGVImport.DataSource = dtImport;
                dGVImport.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
                dGVImport.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu để lưu không
            if (dGVImport.Rows.Count > 0)
            {
                int r = dGVSupplier.CurrentRow.Index;
                string SupplierId = dGVSupplier.Rows[r].Cells["Id"].Value.ToString();
                string ImportDate = DateTime.Now.ToString();

                string sSql = "INSERT INTO [Import] (SupplierId, Date) VALUES (@CustomerId, @ImportDate); SELECT SCOPE_IDENTITY();";
                importId = (int)myDataServices.ExecuteScalar(sSql, new SqlParameter("@CustomerId", SupplierId), new SqlParameter("@ImportDate", ImportDate));
                // Duyệt qua từng dòng trong dGVOrder
                foreach (DataGridViewRow row in dGVImport.Rows)
                {
                    // Lấy thông tin từ mỗi dòng
                    int productId = Convert.ToInt32(row.Cells["Id"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    float price = float.Parse(row.Cells["Price"].Value.ToString());
                    string prodid = row.Cells["ProdId"].Value.ToString();
                    if (dateTimePicker1.Value > dateTimePicker2.Value)
                    {
                        MessageBox.Show("Ngày sản xuất không được vượt qua ngày hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dateTimePicker1.Focus();
                        return;
                    }
                    if (dateTimePicker1.Value > DateTime.Now)
                    {
                        MessageBox.Show("Ngày sản xuất không được đến từ tương lai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dateTimePicker1.Focus();
                        return;
                    }
                    // Thực hiện lệnh SQL để cập nhật cơ sở dữ liệu
                    string sql = "INSERT INTO Import_details (Id, ProductId, ProdId, Quantity, Price) VALUES (@ImportId, @ProductId, @prodid, @Quantity, @Price)";

                    // Thực hiện ExecuteNonQuery để thực hiện lệnh SQL
                    myDataServices.ExecuteNonQuery(sql,
                        new SqlParameter("@ImportId", importId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@prodid", prodid),
                        new SqlParameter("@Quantity", quantity),
                        new SqlParameter("@Price", price)
                    );

                    DateTime dt1 = dateTimePicker1.Value.Date;
                    DateTime dt2 = dateTimePicker2.Value.Date;
                    sql = "Update ProductDate set ProDate = @date1, ExpDate = @date2, Quantity = @quan where ProdId = @id";
                    myDataServices.ExecuteNonQuery(sql,
                        new SqlParameter("@date1", dt1.Date.ToString()),
                        new SqlParameter("@date2", dt2.Date.ToString()),
                        new SqlParameter("@id", prodid),
                        new SqlParameter("@quan", quantity));
                    // Lấy giá trị tổng tiền từ bảng Order
                    string totalSql = "SELECT Total FROM [Import] WHERE Id = @ImportId";
                    float total = Convert.ToSingle(myDataServices.ExecuteScalar(totalSql, new SqlParameter("@ImportId", importId)));

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
    }
}
