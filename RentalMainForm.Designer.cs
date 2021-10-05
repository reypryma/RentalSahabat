
namespace RentalSahabat
{
    partial class RentalMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rentalSahabatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tambahkanPeminjamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lihatListPeminjamanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barangYangTersediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lihatListBarangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rentalSahabatToolStripMenuItem,
            this.barangYangTersediaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rentalSahabatToolStripMenuItem
            // 
            this.rentalSahabatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tambahkanPeminjamToolStripMenuItem,
            this.lihatListPeminjamanToolStripMenuItem});
            this.rentalSahabatToolStripMenuItem.Name = "rentalSahabatToolStripMenuItem";
            this.rentalSahabatToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.rentalSahabatToolStripMenuItem.Text = "RentalSahabat";
            this.rentalSahabatToolStripMenuItem.Click += new System.EventHandler(this.rentalSahabatToolStripMenuItem_Click);
            // 
            // tambahkanPeminjamToolStripMenuItem
            // 
            this.tambahkanPeminjamToolStripMenuItem.Name = "tambahkanPeminjamToolStripMenuItem";
            this.tambahkanPeminjamToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.tambahkanPeminjamToolStripMenuItem.Text = "Tambahkan Peminjam";
            this.tambahkanPeminjamToolStripMenuItem.Click += new System.EventHandler(this.tambahkanPeminjamToolStripMenuItem_Click);
            // 
            // lihatListPeminjamanToolStripMenuItem
            // 
            this.lihatListPeminjamanToolStripMenuItem.Name = "lihatListPeminjamanToolStripMenuItem";
            this.lihatListPeminjamanToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.lihatListPeminjamanToolStripMenuItem.Text = "Lihat  List Peminjaman";
            this.lihatListPeminjamanToolStripMenuItem.Click += new System.EventHandler(this.lihatListPeminjamanToolStripMenuItem_Click);
            // 
            // barangYangTersediaToolStripMenuItem
            // 
            this.barangYangTersediaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lihatListBarangToolStripMenuItem});
            this.barangYangTersediaToolStripMenuItem.Name = "barangYangTersediaToolStripMenuItem";
            this.barangYangTersediaToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.barangYangTersediaToolStripMenuItem.Text = "Barang yang Tersedia";
            // 
            // lihatListBarangToolStripMenuItem
            // 
            this.lihatListBarangToolStripMenuItem.Name = "lihatListBarangToolStripMenuItem";
            this.lihatListBarangToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lihatListBarangToolStripMenuItem.Text = "Lihat list barang";
            this.lihatListBarangToolStripMenuItem.Click += new System.EventHandler(this.lihatListBarangToolStripMenuItem_Click);
            // 
            // RentalMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 504);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RentalMainForm";
            this.Text = "RentalMainForm";
            this.Load += new System.EventHandler(this.RentalMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rentalSahabatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tambahkanPeminjamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lihatListPeminjamanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barangYangTersediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lihatListBarangToolStripMenuItem;
    }
}