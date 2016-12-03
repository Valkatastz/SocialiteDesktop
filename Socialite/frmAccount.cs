using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socialite
{
    public partial class frmAccount : MetroForm
    {
        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {

        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void lnkLogOut_Click(object sender, EventArgs e)
        {
            frmLogin signout = new frmLogin();
            this.Close();
            signout.Show();
        }
    }
}
