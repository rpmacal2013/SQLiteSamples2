using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLibrary;
using System.IO;

namespace SQLiteSample1
{
    public partial class Empleados : Form
    {
        List<EmpleadoModel> empleado = new List<EmpleadoModel>();

        public Empleados()
        {
            InitializeComponent();

            if (!File.Exists(".\\db\\DemoDB.db"))

            if (!File.Exists("C:\\temp\\dbtmp\\demodb.db"))
                {
            MessageBox.Show("La BD no existe. \n Application.StartupPath: " + Application.StartupPath + "\n\n System.IO.Directory.GetCurrentDirectory: " + Directory.GetCurrentDirectory()
            + "\n\n Environment.CurrentDirectory: " + Environment.CurrentDirectory
            + "\n\n System.IO.Path.GetDirectory(Application.ExecutablePath:" + Path.GetDirectoryName(Application.ExecutablePath));
            //Application.Exit();
            }
            CargaListaEmpleados();
        }

        private void CargaListaEmpleados()
        {
            empleado = SqliteDataAccess.CargaEmpleados();

            EnlazaListaEmpleados();
        }

        private void EnlazaListaEmpleados()
        {
            lstEmpleados.DataSource = null;
            lstEmpleados.DataSource = empleado;
            lstEmpleados.DisplayMember = "nombreEmpleado";
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargaListaEmpleados();
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            EmpleadoModel emp = new EmpleadoModel();

            emp.nombreEmpleado = txtNombre.Text;
            emp.puesto = txtPuuesto.Text;
            emp.fechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);

            SqliteDataAccess.GuardaEmpleado(emp);

            txtNombre.Text = "";
            txtPuuesto.Text = "";
            txtFechaIngreso.Text = "";

            CargaListaEmpleados();
        }
    }
}
