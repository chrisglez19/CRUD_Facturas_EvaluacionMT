using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotherTravel.Data
{
    public class HelperData
    {
        MotherTravelEntities DBContext;

        public HelperData()
        {
            DBContext = new MotherTravelEntities();
        }

        public List<PersonaFiscal> ConsultaPersonaFiscal()
        {
           
            return DBContext.PersonaFiscal.ToList();

        }

        public List<Producto> ConsultaProductos()
        {

            return DBContext.Producto.ToList();

        }

        public Producto ConsultaProducto(int id)
        {

            return DBContext.Producto.Find(id);

        }

        public List<Factura> ConsultaFacturas()
        {

            return DBContext.Factura.ToList();

        }

        public List<Detalle> ConsultaDetalles()
        {

            return DBContext.Detalle.ToList();

        }

        public Factura ConsultaFactura(int id)
        {

            return DBContext.Factura.Find(id);

        }

        public Detalle ConsultaDetalle(int id)
        {

            return DBContext.Detalle.Where(x=>x.idFactura==id).First();

        }
        public void InsertaPersonaFiscal(PersonaFiscal nuevaPersona)
        {
            DBContext.sp_InsertPersonaFiscal(nuevaPersona.nombre, nuevaPersona.apellido, nuevaPersona.rfc, nuevaPersona.razon_social, nuevaPersona.direccion, nuevaPersona.fecha_nacimiento, nuevaPersona.telefono, nuevaPersona.email, nuevaPersona.categoria, nuevaPersona.tipo_persona);
            
        }

        public void InsertaFactura(Factura nvaFactura, Detalle detalle)
        {
            DBContext.sp_AgregarFactura(nvaFactura.idEmisor, nvaFactura.idReceptor, detalle.idProducto, detalle.cantidad, detalle.precio);
            
        }



        public void ActualizaFactura(Factura nvaFactura, Detalle detalle)
        {
            DBContext.sp_ActualizaFactura(nvaFactura.idFactura, nvaFactura.idEmisor, nvaFactura.idReceptor, detalle.idProducto, detalle.cantidad, detalle.precio);
        }

        public void EliminaFactura(int id)
        {
            DBContext.sp_EliminaFactura(id);
        }

        public void InsertaDetalle(Detalle nvoDetalle)
        {
            DBContext.Detalle.Add(nvoDetalle);
            DBContext.SaveChanges();
        }


    }
}
