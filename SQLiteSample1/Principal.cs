using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteSample1
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Form empleadoFrm = new Empleados();
            empleadoFrm.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Form clienteFrm = new Clientes();
            clienteFrm.ShowDialog();
        }
    }
}
