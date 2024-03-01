using DoAnSimple;
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
    public partial class frmStatic : UserControl
    {
        //1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        DataTable dtSale = new DataTable();
        DataTable dtImport = new DataTable();

        public frmStatic()
        {
            InitializeComponent();
        }

        private void btnStaticSearch_Click(object sender, EventArgs e)
        {
            int TotalSales = 0;
            int TotalImport = 0;
            int TotalRevenue = 0;
            int TotalCost = 0;
            if (cmbStaticFilter.SelectedIndex == 0)
            {
                string sSql = "select * from YearlyProductSalesView";
                dtSale = myDataServices.RunQuery(sSql);
                dGVProductOut.DataSource = dtSale;

                sSql = "select * from YearlyProductQuantityView";
                dtImport = myDataServices.RunQuery(sSql);
                dGVProductIn.DataSource = dtImport;
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalSales), 0) AS TotalSales, ISNULL(SUM(TotalRevenue), 0) AS TotalRevenue FROM YearlyProductSalesView";
                    DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                    if (result.Rows.Count > 0)
                    {
                        TotalSales = Convert.ToInt32(result.Rows[0]["TotalSales"]);
                        TotalRevenue = Convert.ToInt32(result.Rows[0]["TotalRevenue"]);

                        txtTotalNumberOut.Text = TotalSales.ToString();
                        txtTotalOut.Text = TotalRevenue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng doanh số bán ra và tổng doanh thu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalImport), 0) AS TotalImport, ISNULL(SUM(TotalCost), 0) AS TotalCost FROM YearlyProductQuantityView";
                    DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                    if (result.Rows.Count > 0)
                    {
                        TotalImport = Convert.ToInt32(result.Rows[0]["TotalImport"]);
                        TotalCost = Convert.ToInt32(result.Rows[0]["TotalCost"]);

                        txtTotalNumberIn.Text = TotalImport.ToString();
                        txtTotalIn.Text = TotalCost.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng số nhập vào và tổng chi phí: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (cmbStaticFilter.SelectedIndex == 1)
            {
                string sSql = "select * from MonthlyProductSalesView";
                dtSale = myDataServices.RunQuery(sSql);
                dGVProductOut.DataSource = dtSale;
                sSql = "select * from MonthlyProductQuantityView";
                dtImport = myDataServices.RunQuery(sSql);
                dGVProductIn.DataSource = dtImport;
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalSales), 0) AS TotalSales, ISNULL(SUM(TotalRevenue), 0) AS TotalRevenue FROM MonthlyProductSalesView";
                    DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                    if (result.Rows.Count > 0)
                    {
                        TotalSales = Convert.ToInt32(result.Rows[0]["TotalSales"]);
                        TotalRevenue = Convert.ToInt32(result.Rows[0]["TotalRevenue"]);

                        txtTotalNumberOut.Text = TotalSales.ToString();
                        txtTotalOut.Text = TotalRevenue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng doanh số bán ra và tổng doanh thu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalImport), 0) AS TotalImport, ISNULL(SUM(TotalCost), 0) AS TotalCost FROM MonthlyProductQuantityView";
                    DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                    if (result.Rows.Count > 0)
                    {
                        TotalImport = Convert.ToInt32(result.Rows[0]["TotalImport"]);
                        TotalCost = Convert.ToInt32(result.Rows[0]["TotalCost"]);

                        txtTotalNumberIn.Text = TotalImport.ToString();
                        txtTotalIn.Text = TotalCost.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng số nhập vào và tổng chi phí: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (cmbStaticFilter.SelectedIndex == 2)
            {
                string sSql = "select * from WeeklyProductSalesView";
                dtSale = myDataServices.RunQuery(sSql);
                dGVProductOut.DataSource = dtSale;
                sSql = "select * from WeeklyProductQuantityView";
                dtImport = myDataServices.RunQuery(sSql);
                dGVProductIn.DataSource = dtImport;
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalSales), 0) AS TotalSales, ISNULL(SUM(TotalRevenue), 0) AS TotalRevenue FROM WeeklyProductSalesView";
                    DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                    if (result.Rows.Count > 0)
                    {
                        TotalSales = Convert.ToInt32(result.Rows[0]["TotalSales"]);
                        TotalRevenue = Convert.ToInt32(result.Rows[0]["TotalRevenue"]);

                        txtTotalNumberOut.Text = TotalSales.ToString();
                        txtTotalOut.Text = TotalRevenue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng doanh số bán ra và tổng doanh thu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalImport), 0) AS TotalImport, ISNULL(SUM(TotalCost), 0) AS TotalCost FROM WeeklyProductQuantityView";
                    DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                    if (result.Rows.Count > 0)
                    {
                        TotalImport = Convert.ToInt32(result.Rows[0]["TotalImport"]);
                        TotalCost = Convert.ToInt32(result.Rows[0]["TotalCost"]);

                        txtTotalNumberIn.Text = TotalImport.ToString();
                        txtTotalIn.Text = TotalCost.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng số nhập vào và tổng chi phí: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (cmbStaticFilter.SelectedIndex == 3)
            {
                string sSql = "select * from DailyProductSalesView";
                dtSale = myDataServices.RunQuery(sSql);
                dGVProductOut.DataSource = dtSale;
                sSql = "select * from DailyProductQuantityView";
                dtImport = myDataServices.RunQuery(sSql);
                dGVProductIn.DataSource = dtImport;
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalSales), 0) AS TotalSales, ISNULL(SUM(TotalRevenue), 0) AS TotalRevenue FROM DailyProductSalesView";
                    DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                    if (result.Rows.Count > 0)
                    {
                        TotalSales = Convert.ToInt32(result.Rows[0]["TotalSales"]);
                        TotalRevenue = Convert.ToInt32(result.Rows[0]["TotalRevenue"]);

                        txtTotalNumberOut.Text = TotalSales.ToString();
                        txtTotalOut.Text = TotalRevenue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng doanh số bán ra và tổng doanh thu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    sSql = "SELECT ISNULL(SUM(TotalImport), 0) AS TotalImport, ISNULL(SUM(TotalCost), 0) AS TotalCost FROM DailyProductQuantityView";
                    DataTable result = myDataServices.RunQuery(sSql);

                    if (result.Rows.Count > 0)
                    {
                        TotalImport = Convert.ToInt32(result.Rows[0]["TotalImport"]);
                        TotalCost = Convert.ToInt32(result.Rows[0]["TotalCost"]);

                        txtTotalNumberIn.Text = TotalImport.ToString();
                        txtTotalIn.Text = TotalCost.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tổng số nhập vào và tổng chi phí: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            foreach (DataGridViewColumn column in dGVProductOut.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn column in dGVProductIn.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void frmStatic_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Display();
            int TotalSales = 0;
            int TotalImport = 0;
            int TotalRevenue = 0;
            int TotalCost = 0;
            cmbStaticFilter.Items.Add("Trong năm");
            cmbStaticFilter.Items.Add("Trong tháng");
            cmbStaticFilter.Items.Add("Trong tuần");
            cmbStaticFilter.Items.Add("Trong ngày");
            try
            {
                string sSql = "SELECT ISNULL(SUM(TotalSales), 0) AS TotalSales, ISNULL(SUM(TotalRevenue), 0) AS TotalRevenue FROM ProductSalesView";
                DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                if (result.Rows.Count > 0)
                {
                    TotalSales = Convert.ToInt32(result.Rows[0]["TotalSales"]);
                    TotalRevenue = Convert.ToInt32(result.Rows[0]["TotalRevenue"]);

                    txtTotalNumberOut.Text = TotalSales.ToString();
                    txtTotalOut.Text = TotalRevenue.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tổng doanh số bán ra và tổng doanh thu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string sSql = "SELECT ISNULL(SUM(TotalImport), 0) AS TotalImport, ISNULL(SUM(TotalCost), 0) AS TotalCost FROM ProductImportView";
                DataTable result = myDataServices.RunQuery(sSql); // Giả sử bạn đã có hàm RunQuery trả về DataTable trong lớp DataServices

                if (result.Rows.Count > 0)
                {
                    TotalImport = Convert.ToInt32(result.Rows[0]["TotalImport"]);
                    TotalCost = Convert.ToInt32(result.Rows[0]["TotalCost"]);

                    txtTotalNumberIn.Text = TotalImport.ToString();
                    txtTotalIn.Text = TotalCost.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tổng số nhập vào và tổng chi phí: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Lấy sản phẩm có ngày hết hạn sau ngày hiện tại
            string sql1 = "SELECT p.id, p.name, SUM(pd.quantity) AS total_quantity " +
                           "FROM product p " +
                           "JOIN productdate pd ON p.id = pd.productid " +
                           "WHERE pd.expDate > GETDATE() " +
                           "GROUP BY p.id, p.name " +
                           "ORDER BY p.id DESC";

            DataTable dt1 = myDataServices.RunQuery(sql1);
            dataGridView1.DataSource = dt1;

            // Lấy sản phẩm có ngày hết hạn trong vòng 1 tháng kể từ ngày hiện tại
            string sql2 = "SELECT p.id, p.name, pd.ExpDate, SUM(pd.quantity) AS total_quantity " +
                           "FROM product p " +
                           "JOIN productdate pd ON p.id = pd.productid " +
                           "WHERE pd.expDate BETWEEN GETDATE() AND DATEADD(MONTH, 1, GETDATE()) " +
                           "GROUP BY p.id, p.name, pd.ExpDate " +
                           "ORDER BY p.id DESC";

            DataTable dt2 = myDataServices.RunQuery(sql2);
            dataGridView2.DataSource = dt2;

            // Lấy tất cả sản phẩm (không có điều kiện về ngày hết hạn)
            string sql3 = "SELECT p.id, p.name, SUM(pd.quantity) AS total_quantity " +
                           "FROM product p " +
                           "JOIN productdate pd ON p.id = pd.productid " +
                           "GROUP BY p.id, p.name " +
                           "ORDER BY p.id DESC";

            DataTable dt3 = myDataServices.RunQuery(sql3);
            dataGridView3.DataSource = dt3;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dGVProductIn.Columns[0].HeaderText = "Mã SP";
            dGVProductIn.Columns[1].HeaderText = "Tên SP";
            dGVProductIn.Columns[2].HeaderText = "SL nhập";
            dGVProductIn.Columns[3].HeaderText = "Thành tiền";

            dGVProductOut.Columns[0].HeaderText = "Mã SP";
            dGVProductOut.Columns[1].HeaderText = "Tên SP";
            dGVProductOut.Columns[2].HeaderText = "SL bán";
            dGVProductOut.Columns[3].HeaderText = "Thành tiền";

            dataGridView1.Columns[0].HeaderText = "Mã SP";
            dataGridView1.Columns[1].HeaderText = "Tên SP";
            dataGridView1.Columns[2].HeaderText = "Số lượng";

            dataGridView2.Columns[0].HeaderText = "Mã SP";
            dataGridView2.Columns[1].HeaderText = "Tên SP";
            dataGridView2.Columns[2].HeaderText = "HSD";
            dataGridView2.Columns[3].HeaderText = "Số lượng";

            dataGridView3.Columns[0].HeaderText = "Mã SP";
            dataGridView3.Columns[1].HeaderText = "Tên SP";
            dataGridView3.Columns[2].HeaderText = "Số lượng";

        }
        private void Display()
        {
            // Khai báo xâu truy vấn sql
            string sSql = "select * from ProductSalesView";
            dtSale = myDataServices.RunQuery(sSql);
            dGVProductOut.DataSource = dtSale;

            sSql = "select * from ProductImportView";
            dtImport = myDataServices.RunQuery(sSql);
            dGVProductIn.DataSource = dtImport;

            foreach (DataGridViewColumn column in dGVProductOut.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn column in dGVProductIn.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
