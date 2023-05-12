using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Datos
{
    public class cls_ConsultarProducto
    {
        private int int_existencias;
        private float flt_valorU;
        private string str_descripcion;
        private string str_msn;
        public void fnt_ConsultarProducto(string codigo)
        {
            cls_Conexion obj_Conectar = new cls_Conexion();
            obj_Conectar.fnt_conectar();
            string SQLbuscar;
            SQLbuscar = "select Existencias as 'Exist', Valor_Unitario as 'Valor', Descripcion as 'Desc' from tbl_productos where PKCodigo = '"+codigo+"' and FKCodigo_tbl_estado = '1'";
            MySqlCommand cmd = new MySqlCommand(SQLbuscar, obj_Conectar.conex);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader lectura = cmd.ExecuteReader();
            if (lectura.Read() == true)
            {
                str_descripcion = lectura["Desc"].ToString();
                int_existencias = Convert.ToInt16(lectura["Exist"].ToString());
                flt_valorU = Convert.ToInt32(lectura["Valor"].ToString());
                this.str_msn = "";
            }
            else
            {
                this.str_msn = "Producto no disponible / no se encuentra registrado";
            }
            obj_Conectar.fnt_Desconectar();
        }
        public string getMensaje() { return this.str_msn; }
        public int getExistencias() { return int_existencias; }
        public float getPrecio() { return flt_valorU; }
        public string getDescripcion() { return str_descripcion; }
    }
}