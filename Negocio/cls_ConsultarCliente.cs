using System;
using Datos;
namespace Negocio
{
    public class cls_ConsultarCliente
    {
        private string str_nombre;
        private string str_direccion;
        private string str_msn;
        public void fnt_Consultar(string id)
        {
            if(id == "")
            {
                str_msn = "Debe ingresar la identificación del Cliente";
            }
            else
            {
                Datos.cls_ConsultarCliente obj_Consultar = new Datos.cls_ConsultarCliente();
                obj_Consultar.fnt_ConsultarCliente(id);
                str_nombre = obj_Consultar.getNombre();
                str_direccion = obj_Consultar.getDireccion();
                str_msn = obj_Consultar.getMsn();
            }
        }
        public string getNombre() { return this.str_nombre; }
        public string getDireccion() { return this.str_direccion; }
        public string getMsn() { return this.str_msn; }
    }
}