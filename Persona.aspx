<%@ Page Title="Persona" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Persona.aspx.vb" Inherits="PERSONA.Persona" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--nombre--%>
    <div class="form-group">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre Completo" CssClass="form-control"></asp:TextBox>
    </div>
    <%--apellido--%>
    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Apellidos :" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtApellidos" runat="server" placeholder="Nombre Completo" CssClass="form-control"></asp:TextBox>
    </div>

    <%--fechaNacimiento--%>
    <div class="form-group">
        <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de Nacimiento:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtFechaNac" runat="server" placeholder="01/01/2026" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
     <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
         CssClass= "text-danger"
         ControltoValidate="txtFechaNac.Text" ErrorMessage="Pon la fecha de nacimiento"></asp:RequiredFieldValidator>

    <%--correo--%>
    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Correo Electrónico:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" Text="" placeholder="Correo" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="lblTipoDoc" runat="server" Text=" Tipo Documento" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control">
            <asp:ListItem Text="Cédula Jurídica" Value="0"></asp:ListItem>
            <asp:ListItem Text="Cédula Física" Value="1"></asp:ListItem>
            <asp:ListItem Text="Pasaporte" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Label ID="lblNumeroDoc" runat="server" Text="Numero Documento:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNumeroDoc" runat="server" Text="" placeholder="Correo" CssClass="form-control"></asp:TextBox>
    </div>
    
    <div class=" py-3">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />

    </div>
  <asp:Label ID="lblMensaje" runat="server"></asp:Label>

   
</asp:Content>
