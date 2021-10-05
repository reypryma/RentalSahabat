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
    
    public partial class RentalInputForm : Form
    {
        private readonly RentalEntities rentalEntities;


        public RentalInputForm()
        {
            InitializeComponent();
            rentalEntities = new RentalEntities();
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
                    var rentalRecord = new RentRecord();
                    rentalRecord.CustomerName = customerName;
                    rentalRecord.DateRented = tanggalPinjam;
                    rentalRecord.DateReturned = tanggalKembali;

                    rentalRecord.Cost = (decimal) hargaBarang;
                    rentalRecord.TypeOfStuffBorrowed = (int)cbTypeRented.SelectedValue;

                    //Save Record of submited to db
                    rentalEntities.RentRecords.Add(rentalRecord);
                    rentalEntities.SaveChanges();

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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Select * From StuffTypes
            var stuffRents = rentalEntities.StuffTypes.Select(q => new { id = q.id, NamaBarang = q.NamaBarang + ", " + q.InfoBarang }).ToList(); ;
            cbTypeRented.DisplayMember = "NamaBarang";
            cbTypeRented.ValueMember = "id";
            cbTypeRented.DataSource = stuffRents;
        }

        protected override void OnResize(EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void cbTypeRented_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}

