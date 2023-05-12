using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using System;
namespace Datos
{
    public class cls_Facturacion
    {
        private string str_msn;
        cls_Conexion obj_conexion = new cls_Conexion();
        public void fnt_Registrar_Enc_Factura(string id_cliente,float subtotal,float iva, float total)
        {
            try
            {
                string comando = "insert into tbl_facturas values " +
                "(@FKId_tbl_clientes,current_date(),@Subtotal,@Iva,@Total)";
                MySqlCommand cmd = new MySqlCommand(comando, obj_conexion.conex);
                cmd.Parameters.AddWithValue("@FKCodigo_tbl_clientes", id_cliente);
                cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                cmd.Parameters.AddWithValue("@Iva", iva);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.ExecuteNonQuery();
                str_msn = "Factura generada con éxito";
            }
            catch (Exception)
            {
                this.str_msn = "Problemas al generar factura";
            }
        }
        public void fnt_registrar_Det_factura(int factura,string cod_prod, float valor, int cant)
        {
            try
            {
                string comando = "insert into tbl_det_tbl_facturas values " +
                "(@FKN_Factura_tbl_facturas,@FKCodigo_tbl_productos,@Valor_unitario,@Cantidad)";
                MySqlCommand cmd = new MySqlCommand(comando, obj_conexion.conex);
                cmd.Parameters.AddWithValue("@FKN_Factura_tbl_facturas", factura);
                cmd.Parameters.AddWithValue("@FKCodigo_tbl_productos", cod_prod);
                cmd.Parameters.AddWithValue("@Valor_unitario", valor);
                cmd.Parameters.AddWithValue("@Cantidad", cant);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                this.str_msn = "Problemas al generar factura";
            }
        }
    }
}