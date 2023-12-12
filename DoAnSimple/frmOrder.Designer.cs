﻿namespace DoAnSimple
{
    partial class frmOrder
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCustomerFilter = new System.Windows.Forms.ComboBox();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dGVOrder = new System.Windows.Forms.DataGridView();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.dGVCustomer = new System.Windows.Forms.DataGridView();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGVProduct = new System.Windows.Forms.DataGridView();
            this.btnProductSearch = new System.Windows.Forms.Button();
            this.cmbProductFilter = new System.Windows.Forms.ComboBox();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCustomer)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProduct)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCustomerFilter
            // 
            this.cmbCustomerFilter.FormattingEnabled = true;
            this.cmbCustomerFilter.Location = new System.Drawing.Point(194, 49);
            this.cmbCustomerFilter.Name = "cmbCustomerFilter";
            this.cmbCustomerFilter.Size = new System.Drawing.Size(165, 24);
            this.cmbCustomerFilter.TabIndex = 1;
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(10, 21);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(255, 22);
            this.txtCustomerSearch.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtProductId);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dGVOrder);
            this.groupBox4.Controls.Add(this.cmbDiscount);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtQuantity);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtProductName);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(390, 185);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(393, 294);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chi tiết hóa đơn";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(138, 23);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(92, 22);
            this.txtProductId.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Mã sản phẩm:";
            // 
            // dGVOrder
            // 
            this.dGVOrder.AllowUserToAddRows = false;
            this.dGVOrder.AllowUserToDeleteRows = false;
            this.dGVOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVOrder.Location = new System.Drawing.Point(2, 146);
            this.dGVOrder.MultiSelect = false;
            this.dGVOrder.Name = "dGVOrder";
            this.dGVOrder.ReadOnly = true;
            this.dGVOrder.RowHeadersWidth = 51;
            this.dGVOrder.RowTemplate.Height = 24;
            this.dGVOrder.Size = new System.Drawing.Size(381, 142);
            this.dGVOrder.TabIndex = 23;
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Location = new System.Drawing.Point(138, 107);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(241, 24);
            this.cmbDiscount.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Giảm giá:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(138, 79);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(92, 22);
            this.txtQuantity.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Số lượng (*):";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(138, 51);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(245, 22);
            this.txtProductName.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tên sản phẩm (*):";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(15, 89);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 24);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Xuất hóa đơn";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "đồng";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(213, 90);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotal.Size = new System.Drawing.Size(116, 22);
            this.txtTotal.TabIndex = 21;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Tổng tiền:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddOrder);
            this.groupBox1.Controls.Add(this.dGVCustomer);
            this.groupBox1.Controls.Add(this.btnCustomerSearch);
            this.groupBox1.Controls.Add(this.cmbCustomerFilter);
            this.groupBox1.Controls.Add(this.txtCustomerSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(17, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 228);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khách hàng";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(10, 48);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(77, 24);
            this.btnAddOrder.TabIndex = 19;
            this.btnAddOrder.Text = "HĐ mới";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // dGVCustomer
            // 
            this.dGVCustomer.AllowUserToAddRows = false;
            this.dGVCustomer.AllowUserToDeleteRows = false;
            this.dGVCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dGVCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCustomer.Location = new System.Drawing.Point(9, 79);
            this.dGVCustomer.MultiSelect = false;
            this.dGVCustomer.Name = "dGVCustomer";
            this.dGVCustomer.ReadOnly = true;
            this.dGVCustomer.RowHeadersWidth = 51;
            this.dGVCustomer.RowTemplate.Height = 24;
            this.dGVCustomer.Size = new System.Drawing.Size(350, 143);
            this.dGVCustomer.TabIndex = 1;
            this.dGVCustomer.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVCustomer_RowEnter);
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Location = new System.Drawing.Point(270, 20);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(89, 24);
            this.btnCustomerSearch.TabIndex = 13;
            this.btnCustomerSearch.Text = "Tìm";
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tìm kiếm theo:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(309, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quản lý hóa đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dGVProduct);
            this.groupBox2.Controls.Add(this.btnProductSearch);
            this.groupBox2.Controls.Add(this.cmbProductFilter);
            this.groupBox2.Controls.Add(this.txtProductSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(17, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 240);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sản phẩm";
            // 
            // dGVProduct
            // 
            this.dGVProduct.AllowUserToAddRows = false;
            this.dGVProduct.AllowUserToDeleteRows = false;
            this.dGVProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProduct.Location = new System.Drawing.Point(9, 79);
            this.dGVProduct.MultiSelect = false;
            this.dGVProduct.Name = "dGVProduct";
            this.dGVProduct.ReadOnly = true;
            this.dGVProduct.RowHeadersWidth = 51;
            this.dGVProduct.RowTemplate.Height = 24;
            this.dGVProduct.Size = new System.Drawing.Size(350, 155);
            this.dGVProduct.TabIndex = 1;
            this.dGVProduct.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVProduct_RowEnter);
            // 
            // btnProductSearch
            // 
            this.btnProductSearch.Location = new System.Drawing.Point(270, 20);
            this.btnProductSearch.Name = "btnProductSearch";
            this.btnProductSearch.Size = new System.Drawing.Size(89, 24);
            this.btnProductSearch.TabIndex = 13;
            this.btnProductSearch.Text = "Tìm";
            this.btnProductSearch.UseVisualStyleBackColor = true;
            this.btnProductSearch.Click += new System.EventHandler(this.btnProductSearch_Click);
            // 
            // cmbProductFilter
            // 
            this.cmbProductFilter.FormattingEnabled = true;
            this.cmbProductFilter.Location = new System.Drawing.Point(194, 49);
            this.cmbProductFilter.Name = "cmbProductFilter";
            this.cmbProductFilter.Size = new System.Drawing.Size(165, 24);
            this.cmbProductFilter.TabIndex = 1;
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Location = new System.Drawing.Point(10, 21);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(255, 22);
            this.txtProductSearch.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm kiếm theo:";
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(5, 17);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(54, 24);
            this.btnRemoveProduct.TabIndex = 14;
            this.btnRemoveProduct.Text = "<";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(65, 17);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(54, 24);
            this.btnAddProduct.TabIndex = 15;
            this.btnAddProduct.Text = ">";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnNew);
            this.groupBox3.Controls.Add(this.btnAddProduct);
            this.groupBox3.Controls.Add(this.btnRemoveProduct);
            this.groupBox3.Location = new System.Drawing.Point(390, 484);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 47);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(310, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 24);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Lưu HĐ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(227, 17);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(77, 24);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "Thêm SP";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnExport);
            this.groupBox6.Controls.Add(this.txtPhone);
            this.groupBox6.Controls.Add(this.txtTotal);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.txtCustomerName);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Location = new System.Drawing.Point(390, 57);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(393, 122);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hóa đơn";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(127, 58);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(245, 22);
            this.txtPhone.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Số điện thoại:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(127, 30);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(245, 22);
            this.txtCustomerName.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Tên khách hàng:";
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmOrder";
            this.Size = new System.Drawing.Size(800, 545);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCustomer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProduct)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbCustomerFilter;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVCustomer;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dGVProduct;
        private System.Windows.Forms.Button btnProductSearch;
        private System.Windows.Forms.ComboBox cmbProductFilter;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private System.Windows.Forms.DataGridView dGVOrder;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label7;
    }
}
