using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MotherTravel.Data;

namespace Evaluacion_MotherTravel
{
    public partial class AltaFactura : System.Web.UI.Page
    {
        int cantidad;
        protected void Page_Load(object sender, EventArgs e)
        {
            HelperData datos = new HelperData();
            if (!IsPostBack)
            {
            
                ddlEmisor.DataSource = datos.ConsultaPersonaFiscal();
                ddlEmisor.DataTextField = "nombre";
                ddlEmisor.DataValueField = "idPersona";
                ddlEmisor.SelectedValue = "4";
                ddlEmisor.DataBind();

                ddlReceptor.DataSource = datos.ConsultaPersonaFiscal();
                ddlReceptor.DataTextField = "nombre";
                ddlReceptor.DataValueField = "idPersona";
                ddlReceptor.DataBind();

                ddlProductos.DataSource = datos.ConsultaProductos();
                ddlProductos.DataTextField = "nombre";
                ddlProductos.DataValueField = "idProducto";
                ddlProductos.DataBind();

            }



        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            HelperData datos = new HelperData();
            Producto producto = new Producto();
            Factura factura = new Factura();
            Detalle detalle = new Detalle();
           
            factura.idEmisor = int.Parse(ddlEmisor.SelectedValue);
            factura.idReceptor = int.Parse(ddlReceptor.SelectedValue);
            factura.fecha = DateTime.Now;
            factura.facturaXML = "";
            detalle.idProducto = int.Parse(ddlProductos.SelectedValue);
            producto = datos.ConsultaProducto(detalle.idProducto);
            detalle.cantidad = int.Parse(txtCantidad.Text);
            detalle.precio = producto.precio * detalle.cantidad;
            datos.InsertaFactura(factura,detalle);
            
            Response.Redirect("Index.aspx", true);
        }
    }
}