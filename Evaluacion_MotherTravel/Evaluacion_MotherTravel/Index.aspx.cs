using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MotherTravel.Data;

namespace Evaluacion_MotherTravel
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarGrid()
        {
            HelperData datos = new HelperData();
            List<Factura> facturas = new List<Factura>();
            List<Detalle> detalles = new List<Detalle>();
            List<Producto> productos = new List<Producto>();
            List<PersonaFiscal> personas = new List<PersonaFiscal>();
            detalles = datos.ConsultaDetalles();
            productos = datos.ConsultaProductos();
            personas = datos.ConsultaPersonaFiscal();
            facturas = datos.ConsultaFacturas();
            var lstFac =
                from fac in facturas
                join emisor in personas on fac.idEmisor equals emisor.idPersona
                join receptor in personas on fac.idReceptor equals receptor.idPersona
                join deta in detalles on fac.idFactura equals deta.idFactura
                join prodcs in productos on deta.idProducto equals prodcs.idProducto
                orderby fac.idFactura
                select new { Id = fac.idFactura, Emisor = emisor.nombre, Receptor = receptor.nombre, Producto =prodcs.nombre, Total = deta.precio};



            gvFacturas.DataSource = lstFac.ToList();
            gvFacturas.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect($"AltaFactura.aspx", false);
        }


        protected void gvFacturas_RowCommand(object sender, GridViewCommandEventArgs e)  //llenado de las columnas tomadas de la tabla facturas y agregado de botones actualizar y eliminar 
        {
            HelperData datos = new HelperData();
            if (e.CommandName == "Page")
            {
                return;
            }
            int idx = Convert.ToInt32(e.CommandArgument);  //Convirtiendo indice de fila a entero

            GridViewRow filaSeleccionada = gvFacturas.Rows[idx];
            TableCell idFactura = filaSeleccionada.Cells[0];
            string id = idFactura.Text;

            switch (e.CommandName)
            {
               
                case "Actualizar":
                    Response.Redirect($"Actualiza.aspx?id={id}", false);
                    break;
                case "Eliminar":
                    
                    datos.EliminaFactura(int.Parse(id));
                    Response.Redirect($"Index.aspx", false);
                    break;
            }
        }

        protected void gvFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e) //En caso de que los registros pasen de 5, se crean nuevas paginas en el Gridview en el qe se podra navegar
        {
            try
            {
                gvFacturas.PageIndex = e.NewPageIndex;
                cargarGrid();
            }
            catch (Exception exep)
            {
                throw exep;
            }
        }
    }
}