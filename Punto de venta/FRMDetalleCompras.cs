using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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
    public partial class FRMDetalleCompras : Form
    {
        public FRMDetalleCompras()
        {
            InitializeComponent();
        }

        private void FRMDetalleCompras_Load(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtbusqueda.Text);

            if(oCompra.IdCompra != 0)
            {
                txtnumerodocumento.Text = oCompra.NumeroDocumento;
                txttipodocumentocompra.Text = oCompra.TipoDocumento;
                txtfecha.Text = oCompra.FechaRegistro;
                txtusuario.Text = oCompra.oUsuario.NombreCompleto;
                txtdocproveedor.Text = oCompra.oProveedor.Documento;
                txtnombreproveedor.Text = oCompra.oProveedor.RazonSocial;

                dgvdata.Rows.Clear();

                foreach (DetalleCompra dc in oCompra.oDetalleCompras)
                {
                    dgvdata.Rows.Add(new object[] {dc.oProducto.Nombre,dc.PrecioCompra,dc.Cantidad,dc.MontoTotal});
                }

                txtmontototal.Text = oCompra.MontoTotal.ToString("0.00");

            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtfecha.Text = "";
            txttipodocumentocompra.Text = "";
            txtusuario.Text = "";
            txtdocproveedor.Text = "";
            txtnombreproveedor.Text = "";

            dgvdata .Rows.Clear();
            txtmontototal.Text = "0.00";
        }

        private void btndescargar_Click(object sender, EventArgs e)
        {
            if(txttipodocumentocompra.Text == "")
            {
                MessageBox.Show("No se encontraron resultados","Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();

             Negocio oDatos = new CN_Negocio().ObtenerDatos();
             Texto_Html = Texto_Html.Replace("@nombrenegocio", oDatos.NombreNegocio.ToUpper());
             Texto_Html = Texto_Html.Replace("@docnegocio",oDatos.RUC);
             Texto_Html = Texto_Html.Replace("@direcnegocio",oDatos.Direccion);
             
             Texto_Html = Texto_Html.Replace("@tipodocumento",txttipodocumentocompra.Text.ToUpper());
             Texto_Html = Texto_Html.Replace("@numerodocumento",txtnumerodocumento.Text);
              
             Texto_Html = Texto_Html.Replace("@docproveedor",txtdocproveedor.Text);
             Texto_Html = Texto_Html.Replace("@nombreproveedor",txtnombreproveedor.Text);
             Texto_Html = Texto_Html.Replace("@fecharegistro",txtfecha.Text);
             Texto_Html = Texto_Html.Replace("@usuarioregistro",txtusuario.Text);
              
             string filas = string.Empty;
             foreach(DataGridViewRow row in dgvdata.Rows)
             {
                  filas += "<tr>";
                  filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                  filas += "<td>" + row.Cells["Precio_Compra"].Value.ToString() + "</td>";
                  filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                  filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                  filas += "</tr>";
             }
             
             Texto_Html = Texto_Html.Replace("@filas",filas);
             Texto_Html = Texto_Html.Replace("@montototal",txtmontototal.Text);
             
             SaveFileDialog savefile = new SaveFileDialog();
             savefile.FileName = string.Format("Compra_{0}.pdf",txtnumerodocumento.Text);
             savefile.Filter = "Pdf files |*.pdf";
             if(savefile.ShowDialog() == DialogResult.OK) 
             { 
                  using (FileStream stream = new FileStream(savefile.FileName,FileMode.Create))
                  {
                      Document pdfDoc = new Document(PageSize.A4,25,25,25,25);
                      
                      PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                      pdfDoc.Open();
                     
                      bool obtenido = true;
                      byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);
                       
                      if(obtenido)
                      {
                          iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                          img.ScaleToFit(60,60);
                          img.Alignment = iTextSharp.text.Image.UNDERLYING;
                          img.SetAbsolutePosition(pdfDoc.Left,pdfDoc.GetTop(51));
                          pdfDoc.Add(img);
                      }
                      
                      using(StringReader sr = new StringReader(Texto_Html))
                      {
                          XMLWorkerHelper.GetInstance().ParseXHtml(writer,pdfDoc,sr);
                      }
                      
                      pdfDoc.Close();
                      stream.Close();
                      MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  }
             }
            
        }
    }
}
