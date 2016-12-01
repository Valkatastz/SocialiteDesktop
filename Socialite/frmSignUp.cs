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
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmLogin signed = new frmLogin();
            SqlConnection account = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\TeamDev\Socialite\Socialite\Socialite\SocialiteDB.mdf;Integrated Security=True;Connect Timeout=30");
            account.Open();

            if (lblCheck.ForeColor == System.Drawing.Color.Green && lblEmailCheck.ForeColor == System.Drawing.Color.Green)
            {
                SqlCommand add = new SqlCommand("Insert into Accounts(Username, Password, First_Name, Last_Name, Email) Values('" + txtUsername.Text + "', '" + txtPassword.Text + "' ,  '" + txtEmail.Text + "' , '" + txtFirstName.Text + "' , '" + txtLastName.Text + "')", account);
                add.ExecuteNonQuery();
                account.Close();
                this.Hide();
                signed.Show();
            }
            else
            {
                MessageBox.Show("Please, choose different Username or Email");
            }

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            SqlConnection account = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\TeamDev\Socialite\Socialite\Socialite\SocialiteDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter acadp = new SqlDataAdapter("Select Count (*) From Accounts where Username='" + txtUsername.Text + "'", account);
            DataTable adt = new DataTable();
            acadp.Fill(adt);
            if (int.Parse(adt.Rows[0][0].ToString()) == 0)
            {
                lblCheck.Text = txtUsername.Text + " is Available";
                this.lblCheck.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblCheck.Text = txtUsername.Text + " is not available";
                this.lblCheck.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            SqlConnection account = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\TeamDev\Socialite\Socialite\Socialite\SocialiteDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter acadp = new SqlDataAdapter("Select Count (*) From Accounts where Email='" + txtEmail.Text + "'", account);
            DataTable adt = new DataTable();
            acadp.Fill(adt);
            if (int.Parse(adt.Rows[0][0].ToString()) == 0)
            {
                lblEmailCheck.Text = txtEmail.Text + " is Available";
                this.lblEmailCheck.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblEmailCheck.Text = txtEmail.Text + " is not available";
                this.lblEmailCheck.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }
    }
}
