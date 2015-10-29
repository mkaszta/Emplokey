using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emplokey
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();           
        }

        private void btnInstallCert_Click(object sender, EventArgs e)
        {
            var form_installCert = new Form_installCert();
            form_installCert.ShowDialog();
        }
    }
}
