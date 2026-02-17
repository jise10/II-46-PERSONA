<%@ Page Title="Persona" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Persona.aspx.vb" Inherits="PERSONA.Persona" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--nombre--%>
    <div class="form-group">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre Completo" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtNombre" ErrorMessage="Pon el nombre"></asp:RequiredFieldValidator>
    <%--apellido--%>
    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Apellidos :" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtApellidos" runat="server" placeholder="Nombre Completo" CssClass="form-control"></asp:TextBox>
    </div>
     <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
     CssClass="text-danger"
     Display="Dynamic"
     ControlToValidate="txtApellidos" ErrorMessage="Pon el apellido"></asp:RequiredFieldValidator>


    <%--fechaNacimiento--%>
    <div class="form-group">
        <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de Nacimiento:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtFechaNac" runat="server" placeholder="01/01/2026" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
     <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
         CssClass="text-danger"
         Display="Dynamic"
         ControlToValidate="txtFechaNac" ErrorMessage="Pon la fecha de nacimiento"></asp:RequiredFieldValidator>

    <%--correo--%>
    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Correo Electrónico:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" Text="" placeholder="Correo" CssClass="form-control"></asp:TextBox>
    </div>
        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server"
            CssClass="text-danger"
            Display="Dynamic"
            ControlToValidate="txtCorreo" ErrorMessage="Pon el correo"></asp:RequiredFieldValidator>
    <%--tipoDocumento--%>
    <div class="form-group">
        <asp:Label ID="lblTipoDoc" runat="server" Text=" Tipo Documento" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione un tipo de documento " Value="0"></asp:ListItem>
            <asp:ListItem Text="Cédula Física" Value="1"></asp:ListItem>
            <asp:ListItem Text="Pasaporte" Value="2"></asp:ListItem>
            <asp:ListItem Text="Cédula Jurídica" Value="3"></asp:ListItem>
        </asp:DropDownList>

    </div>
    <div class="form-group">
        <asp:Label ID="lblNumeroDoc" runat="server" Text="Numero Documento:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNumeroDoc" runat="server" Text="" placeholder="Correo" CssClass="form-control"></asp:TextBox>
    </div>
        <asp:RequiredFieldValidator ID="rfvNumDoc" runat="server"
            CssClass="text-danger"
            Display="Dynamic"
            ControlToValidate="txtNumeroDoc" ErrorMessage="Pon el numero de documento"></asp:RequiredFieldValidator>
    
    <div class=" py-3">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />

    </div>
  <asp:Label ID="lblMensaje" runat="server"></asp:Label>
     
    <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Persona"
        OnRowDeleting="gvPersonas_RowDeleting"
        OnRowEditing="gvPersonas_RowEditing"
        OnRowCancelingEdit="gvPersonas_RowCancelingEdit"
        OnRowUpdating="gvPersonas_RowUpdating"
        DataSourceID="SqlDataSource1" Width="500px">
        <Columns>
            <asp:BoundField DataField="Id_Persona" HeaderText="Id_Persona" InsertVisible="False" ReadOnly="True" SortExpression="Id_Persona" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
            <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha_Nacimiento" SortExpression="Fecha_Nacimiento" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
            <asp:BoundField DataField="Numero_Documento" HeaderText="Numero_Documento" SortExpression="Numero_Documento" />
            <asp:BoundField DataField="Tipo_Documento" HeaderText="Tipo_Documento" SortExpression="Tipo_Documento" />
             <asp:CommandField ShowDeleteButton ="True" ShowEditButton ="true" />

        </Columns>
    </asp:GridView>




   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:II_46ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:II_46ConnectionString.ProviderName %>" 
    SelectCommand="SELECT * FROM [Personas] ORDER BY [Apellidos]"></asp:SqlDataSource>




   
</asp:Content>
