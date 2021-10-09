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
    public partial class UserAddEditForm : Form
    {
        private bool isEdit;
        private readonly RentalEntities _db;
        private UserData userData;

        public UserAddEditForm()
        {
            InitializeComponent();
            _db = new RentalEntities();
            isEdit = false;
        }

        public UserAddEditForm(UserData userData)
        {
            InitializeComponent();
            this.userData = userData;
            _db = new RentalEntities();
            isEdit = true;
            populateFields(userData);
        }

        private void UserAddEditForm_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                populateFields(userData);
            }
            else
            {
                var roleOptions = _db.Roles.Select(q => new { Role = q.name + ", " + q.description }).ToList();
                cbRoleType.DisplayMember = "Role";
                cbRoleType.ValueMember = "id";
                cbRoleType.DataSource = roleOptions;

                btnSubmit.Text = "Buat User";
            }
            
        }

        private void populateFields(UserData userData)
        {

            lblID.Text = "Nomor User: " + userData.id.ToString();
            txtNamaUser.Text = userData.username;

            var roleOptions = _db.Roles.Select(q => new { Role = q.name + ", " + q.description }).ToList(); 
            cbRoleType.DisplayMember = "Role";
            cbRoleType.ValueMember = "id";
            cbRoleType.DataSource = roleOptions;

            cbRoleType.SelectedIndex = (int)_db.UserRoles.SingleOrDefault(q => q.userid == userData.id).roleid;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (isEdit)
                {
                    var id = int.Parse(lblID.Text.Replace("Nomor User: ", ""));
                    var updateUser = _db.UserDatas.FirstOrDefault(q => q.id == id);
                    updateUser.username = txtNamaUser.Text;

                    if (!String.IsNullOrEmpty(txtPassword.Text))
                    {
                        updateUser.password = txtPassword.Text;
                    }

                    //db.SaveChanges();

                    var roleID = (int)cbRoleType.SelectedIndex;

                    //UserRole userRole = _db.UserRoles.FirstOrDefault(q => q.userid == id);
                    //userRole.roleid = roleID;

                    var updateRole = _db.UserRoles.SingleOrDefault(q => q.userid == userData.id);
                    

                    MessageBox.Show($"Role {updateRole.roleid}, User {updateRole.userid}");

                    updateRole.roleid = roleID;
                    updateRole.userid = updateUser.id;
                    _db.SaveChanges();

                }
                else
                {
                    var newUser = new UserData();
                    newUser.username = txtNamaUser.Text;
                    newUser.isActive = true;

                    if (!String.IsNullOrEmpty(txtPassword.Text) && cbRoleType.SelectedIndex.ToString() != null)
                    {
                        newUser.password = txtPassword.Text;
                    }
                    else
                    {
                        MessageBox.Show("Wajib Isi Password");
                        return;
                    }

                    _db.UserDatas.Add(newUser);
                    _db.SaveChanges();

                    var newRoleID = (int)cbRoleType.SelectedIndex;

                    UserRole userRole = new UserRole
                    {
                        roleid = newRoleID,
                        userid = newUser.id
                    };

                    _db.UserRoles.Add(userRole);
                    _db.SaveChanges();
                }
                //this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex);

            }
            
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
