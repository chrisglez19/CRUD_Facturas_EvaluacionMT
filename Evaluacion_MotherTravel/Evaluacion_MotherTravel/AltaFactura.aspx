<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaFactura.aspx.cs" Inherits="Evaluacion_MotherTravel.AltaFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <div style="margin-top: 20px";>
        <div class="form-group">
            <asp:Label ID="lblEmisor" class="control-label col-md-2" runat="server" Text="Emisor"></asp:Label>
            <asp:DropDownList ID="ddlEmisor" runat="server"></asp:DropDownList>

        </div>
         <div class="form-group">
            <asp:Label ID="lblReceptor" class="control-label col-md-2" runat="server" Text="Receptor"></asp:Label>
            <asp:DropDownList ID="ddlReceptor" runat="server"></asp:DropDownList>

        </div>
        <div class="form-group">
            <asp:Label ID="lblProductos" class="control-label col-md-2" runat="server" Text="Producto"></asp:Label>
            <asp:DropDownList ID="ddlProductos" runat="server"></asp:DropDownList>
        </div>

         <div class="form-group">
            <asp:Label ID="lblCantidad" class="control-label col-md-2" runat="server" Text="Cantidad"></asp:Label>
             <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnGenerar" runat="server" Text="Generar Factura" CssClass="btn btn-primary btn-sm" OnClick="btnGenerar_Click" />
        </div>

    </div>
</asp:Content>
