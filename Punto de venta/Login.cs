using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace Punto_de_venta
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            List<Usuario> Test = new CN_Usuario().Listar();
            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();
            
            if(oUsuario != null)
            {
                Inicio form = new Inicio(oUsuario);

                form.Show();
                this.Hide();

                form.FormClosing += Frm_Closing;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }

        private void Frm_Closing(object sender, FormClosingEventArgs e)
         {

            txtdocumento.Text = "";
            txtclave.Text = "";

            this.Show();
        }
    }
}
