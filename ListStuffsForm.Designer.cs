
namespace RentalSahabat
{
    partial class ListStuffsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListStuffs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStuffs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListStuffs
            // 
            this.dgvListStuffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListStuffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListStuffs.Location = new System.Drawing.Point(36, 52);
            this.dgvListStuffs.Name = "dgvListStuffs";
            this.dgvListStuffs.RowHeadersWidth = 51;
            this.dgvListStuffs.RowTemplate.Height = 24;
            this.dgvListStuffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListStuffs.Size = new System.Drawing.Size(438, 357);
            this.dgvListStuffs.TabIndex = 0;
            this.dgvListStuffs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListStuffs_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Barang yang Tersedia untuk Disedekahkan";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(546, 116);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(95, 39);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Tambah";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(546, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(546, 266);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Hapus";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(675, 16);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(113, 42);
            this.refreshBtn.TabIndex = 5;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // ListStuffsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListStuffs);
            this.Name = "ListStuffsForm";
            this.Text = "ListStuffsForm";
            this.Load += new System.EventHandler(this.ListStuffsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStuffs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListStuffs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button refreshBtn;
    }
}