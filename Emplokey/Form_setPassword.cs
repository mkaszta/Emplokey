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
    public partial class Form_setPassword : Form
    {
        Form_certificates form_certManager;

        public Form_setPassword(Form_certificates _form_certManager)
        {
            InitializeComponent();
            form_certManager = _form_certManager;    
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            form_certManager.certPassword = textBoxPassword.Text;
            form_certManager.cancelPassword = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            form_certManager.cancelPassword = true;
            this.Close();
        }
    }
}
