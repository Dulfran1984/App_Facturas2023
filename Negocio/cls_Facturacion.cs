using System;

namespace Negocio
{
    public  class cls_Facturacion
    {
        private int int_ultima;
        public void fnt_Facturar(string id, double subtotal, double iva, double total)
        {
            Datos.cls_Facturacion obj_Factura = new Datos.cls_Facturacion();
            obj_Factura.fnt_Registrar_Enc_Factura(id, subtotal, iva, total);
            this.int_ultima = obj_Factura.getUltimaFactura();
        }
        public int getUltimaFactura() { return this.int_ultima; }
    }
}