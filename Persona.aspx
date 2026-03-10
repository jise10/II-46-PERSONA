<%@ Page Title="Persona" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="Persona.aspx.vb"
    Inherits="PERSONA.Persona"
    ResponseEncoding="utf-8"
    ContentType="text/html; charset=utf-8" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Nombre -->
    <div class="mb-3">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre Completo" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
            CssClass="text-danger"
            Display="Dynamic"
            ControlToValidate="txtNombre"
            ErrorMessage="Pon el nombre" />
    </div>

    <!-- Apellidos -->
    <div class="mb-3">
        <asp:Label ID="lblApellidos" runat="server" Text="Apellidos:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtApellidos" runat="server" placeholder="Apellidos" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
            CssClass="text-danger"
            Display="Dynamic"
            ControlToValidate="txtApellidos"
            ErrorMessage="Pon el apellido" />
    </div>

    <!-- Fecha Nacimiento -->
    <div class="mb-3">
        <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
            CssClass="text-danger"
            Display="Dynamic"
            ControlToValidate="txtFechaNac"
            ErrorMessage="Pon la fecha de nacimiento" />
    </div>

    <!-- Correo -->
    <div class="mb-3">
        <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" placeholder="Correo" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server"
            CssClass="text-danger"
            Display="Dynamic"
            ControlToValidate="txtCorreo"
            ErrorMessage="Pon el correo" />
    </div>

    <!-- Tipo Documento -->
    <div class="mb-3">
        <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo Documento:" CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione un tipo de documento" Value="0"></asp:ListItem>
            <asp:ListItem Text="Cédula Física" Value="1"></asp:ListItem>
            <asp:ListItem Text="Pasaporte" Value="2"></asp:ListItem>
            <asp:ListItem Text="Cédula Jurídica" Value="3"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <!-- Número Documento -->
    <div class="mb-3">
        <asp:Label ID="lblNumeroDoc" runat="server" Text="Número Documento:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtNumeroDoc" runat="server" placeholder="Número de documento" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNumDoc" runat="server"
            CssClass="text-danger"
            Display="Dynamic"
            ControlToValidate="txtNumeroDoc"
            ErrorMessage="Pon el número de documento" />
    </div>
    <asp:HiddenField ID="hfIdPersona" runat="server" />
    <!-- Botones -->
    <div class="py-3">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
            CssClass="btn btn-primary me-2"
            OnClick="btnGuardar_Click" />

        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
            CssClass="btn btn-warning"
            OnClick="btnActualizar_Click" visible ="false"/>

        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar"
    CssClass="btn btn-danger"
    OnClick="BtnCancelar_Click" visible ="false"/>
    </div>

    <!-- Tabla -->
    <div class="table-responsive rounded-3 overflow-hidden border border-secondary bg-dark mt-4">
        <asp:GridView ID="gvPersonas" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id_Persona"
            DataSourceID="SqlDataSource1"
            OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged"
            OnRowDeleting="gvPersonas_RowDeleting"
            CssClass="table table-dark table-striped table-hover mb-0"
            GridLines="None">

            <Columns>
                <asp:CommandField
                    ShowSelectButton="True"
                    SelectText="Seleccionar"
                    ControlStyle-CssClass="btn btn-info btn-sm" />
                 
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" SelectText="<i class='bi bi-pencil-square'></i>" />
 
                <asp:BoundField DataField="Id_Persona" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />

                <asp:BoundField DataField="Fecha_Nacimiento"
                    HeaderText="Fecha Nacimiento"
                    DataFormatString="{0:dd/MM/yyyy}"
                    HtmlEncode="False" />

                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                <asp:BoundField DataField="Numero_Documento" HeaderText="Número Documento" />
                <asp:BoundField DataField="Tipo_Documento" HeaderText="Tipo Documento" />

                <asp:CommandField
                    ShowDeleteButton="True"
                    DeleteText="Eliminar"
                    ControlStyle-CssClass="btn btn-danger btn-sm" />
            </Columns>

        </asp:GridView>
    </div>

    <!-- DataSource -->
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:II_46ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:II_46ConnectionString.ProviderName %>"
        SelectCommand="SELECT * FROM [Personas] ORDER BY [Apellidos]">
    </asp:SqlDataSource>

</asp:Content>