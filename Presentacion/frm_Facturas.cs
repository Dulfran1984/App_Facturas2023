using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frm_Facturas : Form
    {
        public frm_Facturas()
        {
            InitializeComponent();
        }

        private void txt_documento_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cls_ConsultarCliente obj_Consultar = new cls_ConsultarCliente();
                obj_Consultar.fnt_Consultar(txt_documento.Text);
                txt_Nombre.Text = obj_Consultar.getNombre();
                txt_direccion.Text = obj_Consultar.getDireccion();
                if (obj_Consultar.getMsn() != "")
                {
                    MessageBox.Show("" + obj_Consultar.getMsn(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_Codigo_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cls_ConsultarProducto obj_consultarP = new cls_ConsultarProducto();
                obj_consultarP.fnt_Consultar(txt_Codigo.Text);
                txt_Descripcion.Text = obj_consultarP.getDescripcion();
                txt_Existencias.Text = Convert.ToString(obj_consultarP.getExistencias());
                txt_Valor.Text = Convert.ToString(obj_consultarP.getPrecio());
                if (obj_consultarP.getMensaje() != "")
                {
                    MessageBox.Show("" + obj_consultarP.getMensaje(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
