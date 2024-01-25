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
    public partial class Main : Form
    {
        private string sName;
        public Main(string name)
        {
            InitializeComponent();
            sName = name;
            openChildControl(new frmMain(sName));
        }

        private UserControl activeControl = null;
        private void openChildControl(UserControl childControl)
        {
            if (activeControl != null)
            {
                // Remove the current User Control
                panelChildForm.Controls.Remove(activeControl);
            }

            activeControl = childControl;
            childControl.Dock = DockStyle.Fill;

            // Add the User Control to the panel
            panelChildForm.Controls.Add(childControl);
            panelChildForm.Tag = childControl;
            childControl.BringToFront();
            childControl.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildControl(new frmProduct());
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            openChildControl(new frmMain(sName));
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildControl(new frmCategory());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            openChildControl(new frmSupplier());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openChildControl(new frmImport());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildControl(new frmOrder());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildControl(new frmCustomer());
        }

        private void btnStatic_Click(object sender, EventArgs e)
        {
            openChildControl(new frmStatic());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
