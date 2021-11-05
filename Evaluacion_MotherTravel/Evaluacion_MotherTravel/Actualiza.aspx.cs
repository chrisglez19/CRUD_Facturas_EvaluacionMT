using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MotherTravel.Data;

namespace Evaluacion_MotherTravel
{
    public partial class Actualiza : System.Web.UI.Page
    {
        string id;
        HelperData datos;
        Factura factura;
        List<PersonaFiscal> personas;
        List<Producto> productos;
        Detalle detalle;
        protected void Page_Load(object sender, EventArgs e)
        {
            datos = new HelperData();
            factura = new Factura();
            detalle = new Detalle();
            productos = new List<Producto>();
            personas = new List<PersonaFiscal>();
            id = Request.QueryString["id"] ?? "1";


            factura = datos.ConsultaFactura(int.Parse(id));
            detalle = datos.ConsultaDetalle(int.Parse(id));
            personas = datos.ConsultaPersonaFiscal();
            productos = datos.ConsultaProductos();
            var productoSelected = productos.Find(x => x.idProducto == detalle.idProducto);
            var emisorSelected = personas.Find(x => x.idPersona == factura.idEmisor);
            var receptorSelected = personas.Find(x => x.idPersona == factura.idReceptor);


            if (!IsPostBack)
            {


                ddlEmisor.DataSource = datos.ConsultaPersonaFiscal();
                ddlEmisor.DataTextField = "nombre";
                ddlEmisor.DataValueField = "idPersona";
                ddlEmisor.DataBind();

                ddlReceptor.DataSource = datos.ConsultaPersonaFiscal();
                ddlReceptor.DataTextField = "nombre";
                ddlReceptor.DataValueField = "idPersona";
                ddlReceptor.DataBind();

                ddlProductos.DataSource = datos.ConsultaProductos();
                ddlProductos.DataTextField = "nombre";
                ddlProductos.DataValueField = "idProducto";
                ddlProductos.DataBind();


                ddlEmisor.SelectedValue = emisorSelected.idPersona.ToString();
                ddlReceptor.SelectedValue = receptorSelected.idPersona.ToString();
                ddlProductos.SelectedValue = productoSelected.idProducto.ToString();
                txtCantidad.Text = detalle.cantidad.ToString();
                
            }
        }

        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HelperData datos = new HelperData();
                Producto producto = new Producto();
                Factura factura = new Factura();
                Detalle detalle = new Detalle();

                factura.idFactura = int.Parse(id);
                factura.idEmisor = int.Parse(ddlEmisor.SelectedValue);
                factura.idReceptor = int.Parse(ddlReceptor.SelectedValue);
                factura.fecha = DateTime.Now;
                factura.facturaXML = "";
                detalle.idProducto = int.Parse(ddlProductos.SelectedValue);
                producto = datos.ConsultaProducto(detalle.idProducto);
                detalle.cantidad = int.Parse(txtCantidad.Text);
                detalle.precio = producto.precio * detalle.cantidad;
                datos.ActualizaFactura(factura, detalle);

                Response.Redirect("Index.aspx", true);
            }
        }
    }
}