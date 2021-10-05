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
    public partial class RentalUpdateForm : Form
    {
        private readonly RentalEntities _db;
        public RentalUpdateForm()
        {
            InitializeComponent();
        }

        public RentalUpdateForm(RentRecord rentRecord)
        {
            InitializeComponent();
            _db = new RentalEntities();
           
            populateFields(rentRecord);
        }

        private void populateFields(RentRecord rentRecord)
        {
            labelID.Text = rentRecord.id.ToString();
            txtNamaPelanggan.Text = rentRecord.CustomerName;
            txtCost.Text = rentRecord.Cost.ToString();
            dtRented.Value = (DateTime)rentRecord.DateRented;
            dtReturned.Value = (DateTime)rentRecord.DateReturned;
            

            var stuffRents = _db.StuffTypes.Select(q => new { id = q.id, NamaBarang = q.NamaBarang + ", " + q.InfoBarang }).ToList(); ;
            cbTypeRented.DisplayMember = "NamaBarang";
            cbTypeRented.ValueMember = "id";
            cbTypeRented.DataSource = stuffRents;

            cbTypeRented.SelectedIndex = (int)rentRecord.TypeOfStuffBorrowed;
        }

        private void RentalUpdateForm_Load(object sender, EventArgs e)
        {
            //Select * From StuffTypes
            //RentalEntities _db = new RentalEntities();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string customerName = txtNamaPelanggan.Text;
                var tanggalPinjam = dtRented.Value;
                var tanggalKembali = dtReturned.Value;

                var jenisBarang = cbTypeRented.SelectedItem.ToString();
                double hargaBarang = Convert.ToDouble(txtCost.Text);

                bool isValid = true;
                var pesanError = "";

                if (String.IsNullOrWhiteSpace(customerName) || String.IsNullOrWhiteSpace(txtCost.Text))
                {
                    isValid = false;
                    pesanError += "Nama pelanggan dan harga tidak boleh kosong \n";
                }

                if (tanggalPinjam > tanggalKembali)
                {
                    isValid = false;
                    pesanError += "Opsi tanggal pinjam harus lebih awal dari tanggal kembali";
                    MessageBox.Show(pesanError);
                }

                if (isValid)
                {
                    var id = int.Parse(labelID.Text);
                    var rentalRecord = _db.RentRecords.FirstOrDefault(q => q.id == id);
                    rentalRecord.CustomerName = customerName;
                    rentalRecord.DateRented = tanggalPinjam;
                    rentalRecord.DateReturned = tanggalKembali;

                    rentalRecord.Cost = (decimal)hargaBarang;
                    rentalRecord.TypeOfStuffBorrowed = (int)cbTypeRented.SelectedValue;

                    //Update Records
                    _db.SaveChanges();

                    MessageBox.Show($"Terima kasih sudah menyewa, {txtNamaPelanggan.Text}\n"
                    + $"Tanggal Pinjam {tanggalPinjam} " + $"Kembali tanggal {tanggalKembali}\n" +
                    $"Terima Kasih sudah meminjam di NakoBraly"
                );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
    }
}
