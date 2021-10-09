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
    public partial class ListUserForm : Form
    {
        private readonly RentalEntities _db;
        public ListUserForm()
        {
            InitializeComponent();
            _db = new RentalEntities();
        }

        private void ListUserForm_Load(object sender, EventArgs e)
        {
            populateFields();
        }

        public void populateFields()
        {
            var rents = _db.UserDatas
            .Select(q => new
            {
                id = q.id,
                namaPelanggan = q.username,
                isActive = q.isActive == true ? "Aktif" : "Tidak Aktif",
                userRole = q.UserRoles.FirstOrDefault().Role.name
            })
                .ToList();
            dgvListUsers.DataSource = rents;
            dgvListUsers.Columns[1].HeaderText = "Nama User";
            dgvListUsers.Columns[2].HeaderText = "Status";
            dgvListUsers.Columns[2].HeaderText = "Role";
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvListUsers.SelectedRows.Count > 0)
            {
                try
                {
                    var idOftheSelected = (int)dgvListUsers.SelectedRows[0].Cells["id"].Value;

                    var user = _db.UserDatas.FirstOrDefault(query => query.id == idOftheSelected);

                    if(user.id == 1)
                    {
                        MessageBox.Show($"Dilarang menghapus user {user.username}");
                        return;
                    }

                    user.isActive = user.isActive == true ? false : true;

                    _db.SaveChanges();

                    MessageBox.Show($"Berhasil deaktifasi/aktifasi user {user.username}");
                    dgvListUsers.Refresh();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error: {ex}");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvListUsers.SelectedRows.Count > 0)
            {
                try
                {
                    var idOftheSelected = (int) dgvListUsers.SelectedRows[0].Cells["id"].Value;

                    var user = _db.UserDatas.FirstOrDefault(query => query.id == idOftheSelected);

                    UserAddEditForm userAddEditForm = new UserAddEditForm(user);
                    userAddEditForm.MdiParent = this.MdiParent;
                    userAddEditForm.Show();
                    dgvListUsers.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}");
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            populateFields();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            UserAddEditForm userAddEditForm = new UserAddEditForm();
            userAddEditForm.MdiParent = this.MdiParent;
            userAddEditForm.Show();
            dgvListUsers.Refresh();
        }
    }
}
