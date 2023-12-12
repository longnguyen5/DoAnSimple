namespace DoAnSimple
{
    partial class frmStatic
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sốLượngSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trongNămToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trongThángToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trongThángToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trongTuầnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trongNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStaticSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStaticFilter = new System.Windows.Forms.ComboBox();
            this.dGVProductOut = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtTotalNumberOut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalOut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGVProductIn = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalIn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalNumberIn = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductOut)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductIn)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sốLượngSảnPhẩmToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 52);
            // 
            // sốLượngSảnPhẩmToolStripMenuItem
            // 
            this.sốLượngSảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trongNămToolStripMenuItem,
            this.trongThángToolStripMenuItem,
            this.trongThángToolStripMenuItem1,
            this.trongTuầnToolStripMenuItem,
            this.trongNgàyToolStripMenuItem});
            this.sốLượngSảnPhẩmToolStripMenuItem.Name = "sốLượngSảnPhẩmToolStripMenuItem";
            this.sốLượngSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.sốLượngSảnPhẩmToolStripMenuItem.Text = "Số lượng sản phẩm";
            // 
            // trongNămToolStripMenuItem
            // 
            this.trongNămToolStripMenuItem.Name = "trongNămToolStripMenuItem";
            this.trongNămToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.trongNămToolStripMenuItem.Text = "Trong năm ";
            // 
            // trongThángToolStripMenuItem
            // 
            this.trongThángToolStripMenuItem.Name = "trongThángToolStripMenuItem";
            this.trongThángToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.trongThángToolStripMenuItem.Text = "Trong quý";
            // 
            // trongThángToolStripMenuItem1
            // 
            this.trongThángToolStripMenuItem1.Name = "trongThángToolStripMenuItem1";
            this.trongThángToolStripMenuItem1.Size = new System.Drawing.Size(172, 26);
            this.trongThángToolStripMenuItem1.Text = "Trong tháng";
            // 
            // trongTuầnToolStripMenuItem
            // 
            this.trongTuầnToolStripMenuItem.Name = "trongTuầnToolStripMenuItem";
            this.trongTuầnToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.trongTuầnToolStripMenuItem.Text = "Trong tuần";
            // 
            // trongNgàyToolStripMenuItem
            // 
            this.trongNgàyToolStripMenuItem.Name = "trongNgàyToolStripMenuItem";
            this.trongNgàyToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.trongNgàyToolStripMenuItem.Text = "Trong ngày";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // btnStaticSearch
            // 
            this.btnStaticSearch.Location = new System.Drawing.Point(498, 21);
            this.btnStaticSearch.Name = "btnStaticSearch";
            this.btnStaticSearch.Size = new System.Drawing.Size(89, 24);
            this.btnStaticSearch.TabIndex = 13;
            this.btnStaticSearch.Text = "Tìm";
            this.btnStaticSearch.UseVisualStyleBackColor = true;
            this.btnStaticSearch.Click += new System.EventHandler(this.btnStaticSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tìm kiếm theo:";
            // 
            // cmbStaticFilter
            // 
            this.cmbStaticFilter.FormattingEnabled = true;
            this.cmbStaticFilter.Location = new System.Drawing.Point(327, 21);
            this.cmbStaticFilter.Name = "cmbStaticFilter";
            this.cmbStaticFilter.Size = new System.Drawing.Size(165, 24);
            this.cmbStaticFilter.TabIndex = 1;
            // 
            // dGVProductOut
            // 
            this.dGVProductOut.AllowUserToAddRows = false;
            this.dGVProductOut.AllowUserToDeleteRows = false;
            this.dGVProductOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProductOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProductOut.Location = new System.Drawing.Point(8, 21);
            this.dGVProductOut.MultiSelect = false;
            this.dGVProductOut.Name = "dGVProductOut";
            this.dGVProductOut.ReadOnly = true;
            this.dGVProductOut.RowHeadersWidth = 51;
            this.dGVProductOut.RowTemplate.Height = 24;
            this.dGVProductOut.Size = new System.Drawing.Size(777, 145);
            this.dGVProductOut.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGVProductOut);
            this.groupBox1.Location = new System.Drawing.Point(3, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 172);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sản phẩm bán ra";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(309, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Thống kê";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtTotalNumberOut
            // 
            this.txtTotalNumberOut.Location = new System.Drawing.Point(267, 96);
            this.txtTotalNumberOut.Name = "txtTotalNumberOut";
            this.txtTotalNumberOut.Size = new System.Drawing.Size(100, 22);
            this.txtTotalNumberOut.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tổng số lượng sản phẩm bán:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tổng thu:";
            // 
            // txtTotalOut
            // 
            this.txtTotalOut.Location = new System.Drawing.Point(550, 96);
            this.txtTotalOut.Name = "txtTotalOut";
            this.txtTotalOut.Size = new System.Drawing.Size(100, 22);
            this.txtTotalOut.TabIndex = 16;
            this.txtTotalOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(649, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "VND";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGVProductIn);
            this.groupBox2.Location = new System.Drawing.Point(3, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 160);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sản phẩm nhập về";
            // 
            // dGVProductIn
            // 
            this.dGVProductIn.AllowUserToAddRows = false;
            this.dGVProductIn.AllowUserToDeleteRows = false;
            this.dGVProductIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProductIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProductIn.Location = new System.Drawing.Point(8, 21);
            this.dGVProductIn.MultiSelect = false;
            this.dGVProductIn.Name = "dGVProductIn";
            this.dGVProductIn.ReadOnly = true;
            this.dGVProductIn.RowHeadersWidth = 51;
            this.dGVProductIn.RowTemplate.Height = 24;
            this.dGVProductIn.Size = new System.Drawing.Size(777, 133);
            this.dGVProductIn.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(649, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "VND";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tổng chi:";
            // 
            // txtTotalIn
            // 
            this.txtTotalIn.Location = new System.Drawing.Point(550, 68);
            this.txtTotalIn.Name = "txtTotalIn";
            this.txtTotalIn.Size = new System.Drawing.Size(100, 22);
            this.txtTotalIn.TabIndex = 16;
            this.txtTotalIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tổng số lượng sản phẩm nhập:";
            // 
            // txtTotalNumberIn
            // 
            this.txtTotalNumberIn.Location = new System.Drawing.Point(267, 68);
            this.txtTotalNumberIn.Name = "txtTotalNumberIn";
            this.txtTotalNumberIn.Size = new System.Drawing.Size(100, 22);
            this.txtTotalNumberIn.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtTotalNumberIn);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbStaticFilter);
            this.groupBox3.Controls.Add(this.txtTotalOut);
            this.groupBox3.Controls.Add(this.btnStaticSearch);
            this.groupBox3.Controls.Add(this.txtTotalNumberOut);
            this.groupBox3.Controls.Add(this.txtTotalIn);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(3, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 130);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // frmStatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmStatic";
            this.Size = new System.Drawing.Size(800, 545);
            this.Load += new System.EventHandler(this.frmStatic_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductOut)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductIn)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sốLượngSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trongNămToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trongThángToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trongThángToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trongTuầnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trongNgàyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btnStaticSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStaticFilter;
        private System.Windows.Forms.DataGridView dGVProductOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalNumberOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalIn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalNumberIn;
        private System.Windows.Forms.DataGridView dGVProductIn;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
