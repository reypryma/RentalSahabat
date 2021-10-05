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
    public partial class ListStuffsForm : Form
    {
        private readonly RentalEntities _db;
        public ListStuffsForm()
        {
            InitializeComponent();
            _db = new RentalEntities();

        }

        private void ListStuffsForm_Load(object sender, EventArgs e)
        {
            //Select id as IDBarang, NamaBarang as Namabarang from StuffTypes
            var stuffs = _db.StuffTypes
                .Select(q => new { NamaBarang = q.NamaBarang, DetailBarang = q.InfoBarang, id = q.id })
                .ToList();
            dgvListStuffs.DataSource = stuffs;

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var addEditBarang = new AddEditBarangForm();
            addEditBarang.MdiParent = this.MdiParent;
            addEditBarang.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvListStuffs.SelectedRows.Count > 0)
            {
                //MultiSelect = false; and SelectionMode = FullRowSelect;
                int idOftheSelected = (int)dgvListStuffs.SelectedRows[0].Cells["id"].Value;

                var stuff = _db.StuffTypes.FirstOrDefault(query => query.id == idOftheSelected);

                var addEditBarang = new AddEditBarangForm(stuff);
                addEditBarang.MdiParent = this.MdiParent;
                addEditBarang.Show();
                //MessageBox.Show(idOftheSelected.ToString());
            }


            //var stuff = _db.StuffTypes.FirstOrDefault(query => query.id == idOftheSelected);

            //var addEditBarang = new AddEditBarangForm(stuff);
            //addEditBarang.MdiParent = this.MdiParent;
            //addEditBarang.Show();                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvListStuffs.SelectedRows.Count > 0)
            {
                var idOftheSelected = (int)dgvListStuffs.SelectedRows[0].Cells["id"].Value;

                var stuff = _db.StuffTypes.FirstOrDefault(query => query.id == idOftheSelected);

                //var dropRecords = _db.RentRecords.Select(query => query.id == stuff.id);

                
                List<RentRecord> rentRecords = _db.RentRecords.Where(query => query.id == idOftheSelected).ToList();

                foreach(RentRecord rent in rentRecords)
                {
                    _db.RentRecords.Remove(rent);
                }

                _db.SaveChanges();

                _db.StuffTypes.Remove(stuff);
                _db.SaveChanges();

                MessageBox.Show("Berhasil Menghapus");
                dgvListStuffs.Refresh();
                
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var stuffs = _db.StuffTypes.Select(query => new {
                id = query.id,
                NamaBarang = query.NamaBarang,
                DetailBarang = query.InfoBarang

            }).ToList();

            dgvListStuffs.DataSource = stuffs;
            dgvListStuffs.Columns[0].HeaderText = "ID";
            dgvListStuffs.Columns[1].HeaderText = "Barang";
            dgvListStuffs.Columns[2].HeaderText = "Detail Barang";

        }

        private void dgvListStuffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Select id as IDBarang, NamaBarang as Namabarang from StuffTypes
            

            //MessageBox.Show(dgvListStuffs.SelectedRows.Cells["id"].Value.ToString());
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Maximized;
        //}
    }
}
