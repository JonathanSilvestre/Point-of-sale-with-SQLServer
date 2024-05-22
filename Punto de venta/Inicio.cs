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
using FontAwesome.Sharp;
using CapaNegocio;
using Punto_de_venta.Modales;

namespace Punto_de_venta
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null) usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO",IdUsuario = 1};
            else
                usuarioActual = objusuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            foreach (IconMenuItem iconmenu in menuTitulo.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }
            lblUsuario.Text = usuarioActual.NombreCompleto;
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AbrirFormulario(IconMenuItem menu,Form formulario)
        {
            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if(FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor= Color.SteelBlue;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void UsuarioMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender,new FRMUsuarios());
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MantenimientoMenu, new FRMCategoria());
        }

        private void SubMenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MantenimientoMenu, new FRMProducto());
        }

        private void SubMenuRegistrarVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(VentasMenu, new FRMVentas(usuarioActual));
        }

        private void SubMenuDetallesVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(VentasMenu, new FRMDetalleVentas());
        }

        private void SubMenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(ComprasMenu, new FRMCompras(usuarioActual));
        }

        private void SubMenuDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(ComprasMenu, new FRMDetalleCompras());
        }

        private void ClientesMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FRMClientes());
        }

        private void ProveedoresMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FRMProveedores());
        }


        private void submenonegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MantenimientoMenu, new FRMNegocio());
        }

        private void AcercadeMenu_Click(object sender, EventArgs e)
        {
            mdAcercade md = new mdAcercade();
            md.ShowDialog();
        }
    }
}
