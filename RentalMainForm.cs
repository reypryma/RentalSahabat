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
        private Login login;
        private UserRole userRole;
        private UserData userLogin;

        public RentalMainForm()
        {
            InitializeComponent();
        }

        public RentalMainForm(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        public RentalMainForm(Login login, UserRole userRole) : this(login)
        {
            this.userRole = userRole;
        }

        public RentalMainForm(Login login, UserData userLogin) : this(login)
        {
            this.userLogin = userLogin;
            userRole = userLogin.UserRoles.FirstOrDefault();
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
            txtInformasi.Text = $"Masuk sebagai : {userLogin.username} | {userRole.Role.name}";

            if(!userRole.Role.name.Contains("admin"))
            {
                userRentalSahabatToolStripMenuItem.Visible = false;
            }
        }

        private void userRentalSahabatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utills.FormIsOpen("ListUserForm"))
            {
                ListUserForm listUserForm = new ListUserForm();
                listUserForm.MdiParent = this;
                listUserForm.Show();
            }
        }
    }
}
