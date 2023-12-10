﻿namespace DoAnSimple
{
    partial class frmProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dGVProduct = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(304, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sản phẩm(*):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nhà cung cấp(*):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 360);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(116, 169);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(166, 22);
            this.txtQuantity.TabIndex = 14;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(116, 106);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(165, 24);
            this.cmbCategory.TabIndex = 13;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(117, 74);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(165, 24);
            this.cmbSupplier.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(116, 15);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(166, 22);
            this.txtId.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Mã sản phẩm:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(9, 211);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(273, 76);
            this.txtDescription.TabIndex = 6;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(116, 137);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(166, 22);
            this.txtPrice.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(166, 22);
            this.txtName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giá(*):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Loại sản phẩm(*):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(12, 424);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 108);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(193, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 31);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 62);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 31);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(193, 27);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 31);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(101, 27);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(89, 31);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 31);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Location = new System.Drawing.Point(392, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 26);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.txtSearch);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Location = new System.Drawing.Point(309, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 74);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRefresh.Location = new System.Drawing.Point(392, 42);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 26);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(70, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(316, 22);
            this.txtSearch.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dGVProduct);
            this.groupBox4.Location = new System.Drawing.Point(309, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(469, 397);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dữ liệu";
            // 
            // dGVProduct
            // 
            this.dGVProduct.AllowUserToAddRows = false;
            this.dGVProduct.AllowUserToDeleteRows = false;
            this.dGVProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProduct.Location = new System.Drawing.Point(6, 21);
            this.dGVProduct.MultiSelect = false;
            this.dGVProduct.Name = "dGVProduct";
            this.dGVProduct.ReadOnly = true;
            this.dGVProduct.RowHeadersWidth = 51;
            this.dGVProduct.RowTemplate.Height = 24;
            this.dGVProduct.Size = new System.Drawing.Size(457, 358);
            this.dGVProduct.TabIndex = 0;
            this.dGVProduct.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVProduct_RowEnter);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmProduct";
            this.Size = new System.Drawing.Size(800, 545);
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dGVProduct;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtQuantity;
    }
}