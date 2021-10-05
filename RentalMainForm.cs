using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalSahabat
{
    public partial class RentalMainForm : Form
    {
        public RentalMainForm()
        {
            InitializeComponent();
        }

        private void rentalSahabatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tambahkanPeminjamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tambahRentalForm = new RentalInputForm();
            tambahRentalForm.MdiParent = this;
            
            tambahRentalForm.Show();
            //tambahRentalForm.WindowState = FormWindowState.Maximized;
        }

        private void lihatListBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listBarang = new ListStuffsForm();
            listBarang.MdiParent = this;
            listBarang.Show();
        }

        private void lihatListPeminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manajemenRental = new ManajemenRentalForm();
            manajemenRental.MdiParent = this;
            manajemenRental.Show();
        }

        private void RentalMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
