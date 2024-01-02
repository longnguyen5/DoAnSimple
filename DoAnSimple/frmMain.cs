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
    public partial class frmMain : UserControl
    {
        // 1. khai báo đối tượng DataServices
        private DataServices myDataServices;
        // 2. khai báo đối tượng DataTable để lưu dũ liệu bảng Product
        private DataTable dtSale;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng myDataServices
            myDataServices = new DataServices();
            // Kiểm tra xem thử có kết nối được với CSDL hay không
            if (!myDataServices.OpenDB())
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị dữ liệu lên lưới
            btnDaily_Click(sender, e);
            dGVTopProduct.AutoResizeColumns();

        }

        private void Display(string sSql)
        {
            // Khai báo xâu truy vấn sql
            dtSale = myDataServices.RunQuery(sSql);
            // From now on, do not change the context of myDataService() - do not use it for other tables
            // Hiển thị lên grid
            dGVTopProduct.DataSource = dtSale;
            foreach (DataGridViewColumn column in dGVTopProduct.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnDaily_Click(object sender, EventArgs e)
        {
            string sSql = "Select TOP 5 * From [vw_DoanhThu_Ngay] Order by [Make]";
            Display(sSql);
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            string sSql = "Select * From [vw_DoanhThu_Tuan] Order by [Make]";
            Display(sSql);
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            string sSql = "Select * From [vw_DoanhThu_Thang] Order by [Make]";
            Display(sSql);
        }
    }
}
