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
        private void fnt_CalcularSubtotal()
        {
            double suma = 0;
            for(int i = 0; i < dtg_Productos.RowCount; i++)
            {
                suma += Convert.ToDouble(dtg_Productos.Rows[i].Cells[1].Value) *
                    Convert.ToInt16(dtg_Productos.Rows[i].Cells[2].Value);
            }
            lbl_Subtotal.Text = Convert.ToString(suma);
            lbl_Iva.Text = Convert.ToString(suma * 0.19);
        }
        private void btn_AgregarCarrito_Click(object sender, EventArgs e)
        {
            if (txt_Codigo.Text == "" || txt_Cantidad.Text == "")
            {
                MessageBox.Show("Debe ingresar codigo y cantidad del producto", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean sw = false;
                int posi = 0;
                for (int i = 0; i < dtg_Productos.RowCount; i++)
                {
                    if(txt_Codigo.Text == Convert.ToString(dtg_Productos.Rows[i].Cells[0].Value))
                    {
                        posi = i;
                        sw = true;
                        break;
                    }
                }
                if(sw == true)
                {
                    int cant = Convert.ToInt16(dtg_Productos.Rows[posi].Cells[2].Value);
                    int new_cant = cant + Convert.ToInt16(txt_Cantidad.Text);
                    dtg_Productos.Rows[posi].Cells[2].Value = new_cant;
                    fnt_CalcularSubtotal();
                }
                else
                {
                    dtg_Productos.Rows.Add(txt_Codigo.Text, txt_Valor.Text, txt_Cantidad.Text);
                    fnt_CalcularSubtotal();
                }
            }
        }
    }
}
