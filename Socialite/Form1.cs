using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Socialite
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            frmSignUp su = new frmSignUp();
            this.Hide();
            su.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmAccount social = new frmAccount();
            SqlConnection account = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\TeamDev\Socialite\Socialite\Socialite\SocialiteDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter acadp = new SqlDataAdapter("Select Count (*) From Accounts where Email='" + txtEmail.Text + "' and Password = '" + txtPassword.Text + "'", account);
            DataTable adt = new DataTable();
            acadp.Fill(adt);
            if (adt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                social.Show();
            }
            else
            {
                MessageBox.Show("Email or Password are wrong!");
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
