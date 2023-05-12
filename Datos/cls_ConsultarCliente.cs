using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Datos
{
    public class cls_ConsultarCliente
    {
        private string str_nombre;
        private string str_direccion;
        private string str_msn;
        public void fnt_ConsultarCliente(string id)
        {
            cls_Conexion obj_Conectar = new cls_Conexion();
            obj_Conectar.fnt_conectar();
            string SQLbuscar;
            SQLbuscar = "select Nombre as 'Cliente', Direccion as 'Direccion' from tbl_clientes where PKId = '"+id+"'";
            MySqlCommand cmd = new MySqlCommand(SQLbuscar, obj_Conectar.conex);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader lectura = cmd.ExecuteReader();
            if (lectura.Read() == true)
            {
                str_nombre = lectura["Cliente"].ToString();
                str_direccion = lectura["Direccion"].ToString();
                this.str_msn = "";
            }
            else
            {
                this.str_msn = "Este Cliente no se encuentra registrado";
            }
            obj_Conectar.fnt_Desconectar();
        }
        public string getNombre() { return this.str_nombre; }
        public string getDireccion() { return this.str_direccion; }
        public string getMsn() { return this.str_msn; }
    }
}