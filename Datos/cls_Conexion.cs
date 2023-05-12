using MySql.Data.MySqlClient;
using System;

namespace Datos
{
    public class cls_Conexion
    {
        public MySqlConnection conex;
        string cadenaconexion;
        public void fnt_conectar()
        {
            conex = new MySqlConnection();
            //************* CONEXION BASE DATOS ******************
            String servidor = "10.230.16.162";
            String bd = "dbs_Dulfran_Facturas";
            String usuario = "yoyito";
            String contraseña = "Sena2023";
            String puerto = "3306";
            cadenaconexion = "server=" + servidor + ";port=" + puerto + ";user id=" + usuario + ";password=" + contraseña + ";database=" + bd + ";";

            try
            {
                conex.ConnectionString = cadenaconexion;
                conex.Open();
            }
            catch (Exception)
            {
            }
        }
        public void fnt_Desconectar() { conex.Close(); }
    }
}