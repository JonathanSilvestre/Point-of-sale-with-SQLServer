using CapaEntidad;
using CapaNegocio;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta
{
    public partial class FRMNegocio : Form
    {
        public FRMNegocio()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;
        }

        private void FRMNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimagen = new CN_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)
            {
                picLogo.Image = ByteToImage(byteimagen);
            }

            Negocio datos = new CN_Negocio().ObtenerDatos();

            txtnombre.Text = datos.NombreNegocio;
            txtruc.Text = datos.RUC;
            txtdireccion.Text = datos.Direccion;

        }

        private void btnsubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimage = File.ReadAllBytes(openFileDialog.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(byteimage,out mensaje);

                if(respuesta)
                {
                    picLogo.Image=ByteToImage(byteimage);
                }
                else
                {
                    MessageBox.Show(mensaje,"Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }

        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocio obj = new Negocio()
            {
                NombreNegocio = txtnombre.Text,
                RUC = txtruc.Text,
                Direccion = txtdireccion.Text
            };

            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Los cambios fueron guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }       
            else
            {
                MessageBox.Show("No se pudo guardar los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
