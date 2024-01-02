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
