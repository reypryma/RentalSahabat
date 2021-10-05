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
    public partial class AddEditBarangForm : Form
    {
        private readonly RentalEntities _db;
        bool isUpdateMode;
        public AddEditBarangForm()
        {
            InitializeComponent();
            _db = new RentalEntities();
            isUpdateMode = false;
        }

        public AddEditBarangForm(StuffType stuffToEdit)
        {
            InitializeComponent();
            _db = new RentalEntities();
            lblTitle.Text = "Update Barang";
            PopulateFields(stuffToEdit);
            isUpdateMode = true;
        }

        private void PopulateFields(StuffType stuffToEdit)
        {
            labelID.Text = stuffToEdit.id.ToString();
            txtIinfoBarang.Text = stuffToEdit.InfoBarang;
            txtJenisBarang.Text = stuffToEdit.NamaBarang;
        }

        private void AddEditBarangForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (isUpdateMode)
            {
                var id = int.Parse(labelID.Text);
                var stuff = _db.StuffTypes.FirstOrDefault(q => q.id == id);
                stuff.NamaBarang = txtJenisBarang.Text;
                stuff.InfoBarang = txtIinfoBarang.Text;

                _db.SaveChanges();
            }
            else
            {
                var stuff = new StuffType
                {
                    NamaBarang = txtJenisBarang.Text,
                    InfoBarang = txtIinfoBarang.Text
                };
                _db.StuffTypes.Add(stuff);
                _db.SaveChanges();
            }
        }
    }
}
