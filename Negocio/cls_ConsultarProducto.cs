using System;
using Datos;
namespace Negocio
{
    public class cls_ConsultarProducto
    {
        private int int_existencias;
        private float flt_valorU;
        private string str_descripcion;
        private string str_msn;
        public void fnt_Consultar(string codigo)
        {
            if(codigo == "")
            {
                str_msn = "Debe ingresar el código de busqueda";
            }
            else
            {
                Datos.cls_ConsultarProducto obj_consultarP = new Datos.cls_ConsultarProducto();
                obj_consultarP.fnt_ConsultarProducto(codigo);
                int_existencias = obj_consultarP.getExistencias();
                flt_valorU = obj_consultarP.getPrecio();
                str_descripcion = obj_consultarP.getDescripcion();
                str_msn = obj_consultarP.getMensaje();
            }
        }
        public string getMensaje() { return this.str_msn; }
        public int getExistencias() { return int_existencias; }
        public float getPrecio() { return flt_valorU; }
        public string getDescripcion() { return str_descripcion; }
    }
}