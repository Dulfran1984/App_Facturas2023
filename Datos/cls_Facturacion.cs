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
            String consulta = "insert into tbl_facturas(FKId_tbl_clientes,Fecha,Subtotal,Iva,Total) " +
                "values ('" + id_cliente + "', current_date(), '"+subtotal+ "','" + iva + "','" + total + "')";
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
            obj_conexion.fnt_conectar();
            String consulta = "insert into tbl_det_tbl_facturas(FKN_Factura_tbl_facturas," +
                "FKCodigo_tbl_productos,Valor_unitario,Cantidad) " +
                "values ('" + factura + "', '"+cod_prod+ "', '"+valor + "','" + cant + "')";
            MySqlCommand comando = new MySqlCommand(consulta, obj_conexion.conex);
            MySqlDataReader lectura = comando.ExecuteReader();
            obj_conexion.fnt_Desconectar();
            consultarUltimaFactura();
        }
        public int getUltimaFactura() { return this.int_ultima; }
    }
}