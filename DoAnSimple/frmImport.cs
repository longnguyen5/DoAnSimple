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
            cmbProductFilter.Items.Add("Tìm theo mã sản phẩm");
            cmbProductFilter.SelectedIndex = 0;

            cmbSupplierFilter.Items.Add("Tìm theo tên");
            cmbSupplierFilter.Items.Add("Tìm theo mã nhà cung cấp");
            cmbSupplierFilter.SelectedIndex = 0;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

            dGVSupplier.AutoResizeColumns();
            dGVProduct.AutoResizeColumns();
            dGVImport.AutoResizeColumns();

            DisplayProduct();
            DisplaySupplier();
            DisplayImport();

            dGVSupplier.Columns[0].HeaderText = "Id NCC";
            dGVSupplier.Columns[1].HeaderText = "Tên NCC";
            dGVSupplier.Columns[2].HeaderText = "Số liên hệ";
            dGVSupplier.Columns[3].HeaderText = "Địa chỉ";

            dGVProduct.Columns[0].HeaderText = "Id SP";
            dGVProduct.Columns[1].HeaderText = "Tên SP";
            dGVProduct.Columns[2].HeaderText = "Loại SP";
            dGVProduct.Columns[3].HeaderText = "NCC";
            dGVProduct.Columns[4].HeaderText = "Giá SP";
            dGVProduct.Columns[5].HeaderText = "Mô tả SP";
            dGVProduct.Columns[6].HeaderText = "Đường dẫn hình ảnh";

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

            dGVImport.Columns[0].HeaderText = "Id SP";
            dGVImport.Columns[1].HeaderText = "Mã SX";
            dGVImport.Columns[2].HeaderText = "Tên SP";
            dGVImport.Columns[3].HeaderText = "SL Nhập";
            dGVImport.Columns[4].HeaderText = "Giá từng SP";
            dGVImport.Columns[5].HeaderText = "NSX";
            dGVImport.Columns[6].HeaderText = "HSD";

        }
        private void DisplaySupplier()
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
            //foreach (DataGridViewColumn column in dGVProduct.Columns)
            //{
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //}
        }

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            if (cmbSupplierFilter.SelectedIndex == 0)
            {
                string sSql = "Select * From Supplier Where [Name] = N'%" + txtSupplierSearch + "%'";
                DataTable dtSupplier = myDataServices.RunQuery(sSql);
                dGVSupplier.DataSource = dtSupplier;
            }
            else if (cmbSupplierFilter.SelectedIndex == 1)
            {
                string sSql = "Select * From Supplier Where [id] = '%" + txtSupplierSearch + "%'";
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
            button1.Enabled = edit;
            //btnProductSearch.Enabled = edit;
            txtPrice.Enabled = edit;
            textBox1.Enabled = edit;
            txtPrice.Enabled = edit;
            txtTotal.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            dateTimePicker2.Enabled = edit;
            //các nút
            btnAddImport.Enabled = !edit;
            btnNew.Enabled = edit;
            btnSave.Enabled = edit;

            dGVSupplier.Enabled = edit;
        }
        int importId = -1;
        private void btnAddImport_Click(object sender, EventArgs e)
        {
            SetControls(true);
            txtProductId.Clear();
            textBox1.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
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
                    int productId;
                    if (int.TryParse(row.Cells["Id"].Value?.ToString(), out productId))
                    {
                        //Console.WriteLine("Quantity: " + row.Cells["Quantity"].Value);
                        int quantity;
                        if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out quantity))
                        {
                            float price;
                            if (float.TryParse(row.Cells["Price"].Value?.ToString(), out price))
                            {
                                string prodid = row.Cells["ProdId"].Value?.ToString();

                                // Kiểm tra ngày sản xuất và ngày hết hạn
                                if (dateTimePicker1.Value > dateTimePicker2.Value || dateTimePicker1.Value > DateTime.Now)
                                {
                                    MessageBox.Show("Ngày sản xuất không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                sql = "UPDATE ProductDate SET ProDate = @date1, ExpDate = @date2, Quantity = @quan WHERE ProdId = @id";
                                myDataServices.ExecuteNonQuery(sql,
                                    new SqlParameter("@date1", dt1.ToString("yyyy-MM-dd")),
                                    new SqlParameter("@date2", dt2.ToString("yyyy-MM-dd")),
                                    new SqlParameter("@id", prodid),
                                    new SqlParameter("@quan", quantity));

                                // Lấy giá trị tổng tiền từ bảng Import
                                string totalSql = "SELECT Total FROM [Import] WHERE Id = @ImportId";
                                object totalObj = myDataServices.ExecuteScalar(totalSql, new SqlParameter("@ImportId", importId));
                                txtTotal.Text = totalObj.ToString();

                                // Kiểm tra giá trị tổng tiền có là null hay không
                                float total;
                                if (totalObj != null && float.TryParse(totalObj.ToString(), out total))
                                {
                                    // Hiển thị giá trị tổng tiền trong TextBox
                                    txtTotal.Text = total.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi khi lấy giá trị tổng tiền từ cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Giá tiền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("Id sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }

                MessageBox.Show("Đã lưu thành công vào cơ sở dữ liệu.");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để lưu.");
            }
            SetControls(false);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTotal.Text.Replace(",", ""), out decimal amount))
            {
                txtTotal.Text = string.Format("{0:#,0}", amount);
                txtTotal.SelectionStart = txtTotal.Text.Length;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal amount))
            {
                txtPrice.Text = string.Format("{0:#,0}", amount);
                txtPrice.SelectionStart = txtPrice.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void txtSupplierSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplierSearch.Text.Trim().Length == 0)
            {
                DisplaySupplier();
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
