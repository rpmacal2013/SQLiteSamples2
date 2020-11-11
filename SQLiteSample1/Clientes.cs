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
    public partial class Clientes : Form
    {
        List<ClienteModel> cliente = new List<ClienteModel>();

        public Clientes()
        {
            InitializeComponent();

            CargaListaClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ClienteModel cliente = new ClienteModel();

            cliente.claveCliente = txtClaveCliente.Text;
            cliente.nombreCliente = txtNombreCliente.Text;
            cliente.email = txtEmailCliente.Text;
            
            SqliteDataAccess.GuardaCliente(cliente);

            txtClaveCliente.Text = "";
            txtNombreCliente.Text = "";
            txtEmailCliente.Text = "";

            CargaListaClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargaListaClientes();
        }

        private void CargaListaClientes()
        {
            cliente = SqliteDataAccess.CargaClientes();

            EnlazaListaClientes();
        }

        private void EnlazaListaClientes()
        {
            lstClientes.DataSource = null;
            lstClientes.DataSource = cliente;
            lstClientes.DisplayMember = "nombreCliente";
        }
    }
}
