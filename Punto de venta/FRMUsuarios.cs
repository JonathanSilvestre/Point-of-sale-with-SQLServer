using Punto_de_venta.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Punto_de_venta
{
    public partial class FRMUsuarios : Form
    {
        public FRMUsuarios()
        {
            InitializeComponent();
        }

        private void FRMUsuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Desactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (Rol item in listaRol)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion}) ;
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "BTNSeleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
        }

        private void BTNGuardar_Click(object sender, EventArgs e)
        {
            dgvdata.Rows.Add(new object[] {"",txtId.Text,txtDocumento.Text,txtNombreCompleto.Text,txtCorreo.Text,txtClave.Text,
                ((OpcionCombo)cboRol.SelectedItem).Valor.ToString(),((OpcionCombo)cboRol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),((OpcionCombo)cboEstado.SelectedItem).Texto.ToString()
            });
            Limpiar();
        }

        private void Limpiar()
        {
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }
    }
}
