using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using System;
using System.Data;

namespace Datos
{
    public class cls_Facturacion
    {
        private string str_msn;
        private int int_ultima;
        cls_Conexion obj_conexion = new cls_Conexion();
        public void fnt_Registrar_Enc_Factura(string id_cliente, double subtotal, double iva, double total)
        {
            obj_conexion.fnt_conectar();
            String consulta = "insert into tbl_registros(Numero_Semana,Cantidad,Yli,Yls,Severidad,Fecha,hora,FKUsuario_tbl_usuarios,FKCodigo_tbl_finca,Latitud,Longitud,Observaciones) values ('" + cbx_Semana.SelectedItem + "','" + txt_Cantidad.Text + "','" + txt_Yli.Text + "','" + txt_Yls.Text + "','" + txt_Severidad.Text + "',current_date(),current_time(),'" + lbl_Usuario.Text + "','" + cbx_Fincas.SelectedValue + "','" + lbl_Latitud.Text + "','" + lbl_Longitud.Text + "','" + txt_Observaciones.Text + "')";
            MySqlCommand comando = new MySqlCommand(consulta, obj_conexion.conex);
            MySqlDataReader lectura = comando.ExecuteReader();
            obj_conexion.fnt_Desconectar();
            consultarUltimaFactura();
        }
        public void consultarUltimaFactura()
        {
            cls_Conexion obj_Conectar = new cls_Conexion();
            obj_Conectar.fnt_conectar();
            string SQLbuscar;
            SQLbuscar = "select max(PKN_factura) as ultima from tbl_facturas;";
            MySqlCommand cmd = new MySqlCommand(SQLbuscar, obj_Conectar.conex);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader lectura = cmd.ExecuteReader();
            if (lectura.Read() == true)
            {
                this.int_ultima = Convert.ToInt16(lectura["ultima"].ToString());
            }
            obj_Conectar.fnt_Desconectar();
        }
        public void fnt_registrar_Det_factura(int factura,string cod_prod, double valor, int cant)
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
        public int getUltimaFactura() { return this.int_ultima; }
    }
}