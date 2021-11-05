<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Evaluacion_MotherTravel.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h1>Listado Facturas</h1>
    <hr />
    <div> <asp:Button ID="btnCrear" runat="server" Text="Crear Factura" OnClick="btnCrear_Click" CssClass="btn btn-primary btn-sm" Height="29px" />

    </div>
    <div>
     
    <asp:GridView ID="gvFacturas" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" OnRowCommand="gvFacturas_RowCommand" OnPageIndexChanging="gvFacturas_PageIndexChanging" BorderStyle="None" 
    CssClass="table" 
    GridLines="Horizontal"  >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Emisor" HeaderText="Emisor" />
            <asp:BoundField DataField="Receptor" HeaderText="Receptor" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
            
            <asp:ButtonField CommandName="Actualizar" ShowHeader="True" Text="Actualizar">
            <ControlStyle CssClass="btn btn-warning btn-sm" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Eliminar" ShowHeader="True" Text="Eliminar">
            <ControlStyle CssClass="btn btn-danger btn-sm" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
        </div>

</asp:Content>
