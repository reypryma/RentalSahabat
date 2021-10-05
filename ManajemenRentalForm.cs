using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentalSahabat
{
    public partial class ManajemenRentalForm : Form
    {
        private readonly RentalEntities _db;
        public ManajemenRentalForm()
        {
            InitializeComponent();
            _db = new RentalEntities();
        }

        private void ManajemenRentalForm_Load(object sender, EventArgs e)
        {
            var rents = _db.RentRecords
            .Select(q => new {id = q.id, namaPelanggan = q.CustomerName, Pinjam = q.DateRented,
               Deadline = q.DateReturned, Biaya = q.Cost, Barang = q.StuffType.NamaBarang + ", " + q.StuffType.InfoBarang 
            })
                .ToList();
            dgvListStuffs.DataSource = rents;
            dgvListStuffs.Columns[1].HeaderText = "Nama Pelanggan";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var rentalInputForm = new RentalInputForm();
            rentalInputForm.MdiParent = this.MdiParent;
            rentalInputForm.Show();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var rents = _db.RentRecords.Select(q => new {
                id = q.id,
                namaPelanggan = q.CustomerName,
                Pinjam = q.DateRented,
                Deadline = q.DateReturned,
                Biaya = q.Cost,
                Barang = q.StuffType.NamaBarang + ", " + q.StuffType.InfoBarang
            }).ToList();

            dgvListStuffs.DataSource = rents;
            dgvListStuffs.Columns[1].HeaderText = "Nama Pelanggan";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvListStuffs.SelectedRows.Count > 0)
            {

                try
                {
                    var idOftheSelected = (int)dgvListStuffs.SelectedRows[0].Cells["id"].Value;

                    var rent = _db.RentRecords.FirstOrDefault(query => query.id == idOftheSelected);
                    _db.RentRecords.Remove(rent);
                    _db.SaveChanges();

                    MessageBox.Show("Berhasil Menghapus");
                    dgvListStuffs.Refresh();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error: {ex}");
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvListStuffs.SelectedRows.Count > 0)
            {
                //MultiSelect = false; and SelectionMode = FullRowSelect;
                int idOftheSelected = (int)dgvListStuffs.SelectedRows[0].Cells["id"].Value;

                var updateRent = _db.RentRecords.FirstOrDefault(query => query.id == idOftheSelected);

                var rentalInputForm = new RentalUpdateForm(updateRent);
                rentalInputForm.MdiParent = this.MdiParent;
                rentalInputForm.Show();
            }

            
        }
    }
}
