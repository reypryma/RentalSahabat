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
    public partial class Login : Form
    {

        private readonly RentalEntities _db;
        public Login()
        {
            InitializeComponent();
            _db = new RentalEntities();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnMasuk_Click(object sender, EventArgs e)
        {
            var password = txtPass.Text;
            var user = txtUser.Text;

            var userLogin = _db.UserDatas.FirstOrDefault(q => q.username == user && q.password == password && q.isActive == true);
            if (userLogin != null && userLogin.isActive == true)
            {
                var userRole = userLogin.UserRoles.FirstOrDefault();
                //var nameRole = useRole.Role.name;
                RentalMainForm rentalMain = new RentalMainForm(this, userLogin);
                rentalMain.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Error Not Found");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }
    }
}
