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
        public Main()
        {
            InitializeComponent();
            openChildControl(new frmMain());
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
            openChildControl(new frmMain());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildControl(new frmCategory());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            openChildControl(new frmSupplier());
        }
    }
}
