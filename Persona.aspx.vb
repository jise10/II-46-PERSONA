Imports PERSONA.Utils

Public Class Persona
    Inherits System.Web.UI.Page

    Private dbHelper As New DbHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If txtNombre.Text.Trim().Equals("") Or
        txtApellidos.Text.Trim().Equals("") Or
         txtCorreo.Text.Trim().Equals("") Or
        txtNumeroDoc.Text.Trim().Equals("") Or
        txtFechaNac.Text.Trim().Equals("") Then

            lblMensaje.Text = "Por favor complete los campos obligatorios."
            lblMensaje.CssClass = "alert alert-danger"



            Return
        End If

        ' validar fecha code behidn
        ' tiene proioridad sobre el validador de la vista

        If IsDate(txtFechaNac.Text) = False Then
            lblMensaje.Text = "La fecha de nacimiento no es Validad"
            Return
        End If




        Dim persona = New Models.Persona()
        persona.Nombre = txtNombre.Text
        persona.Apellidos = txtApellidos.Text
        persona.Correo = txtCorreo.Text
        persona.FechaNacimiento = txtFechaNac.Text
        persona.NumeroDocumento = txtNumeroDoc.Text
        persona.TipoDocummento = ddlTipoDocumento.SelectedItem.Value

        'lblMensaje.Text = persona.Resumen()
        'lblMensaje.CssClass = "alert alert-success"
        Dim id As Integer = dbHelper.CrearPersona(persona)
        If id > 0 Then
            lblMensaje.Text = $"Persona creada con ID: {id}"
            lblMensaje.CssClass = "alert alert-success"
            ' actulizar el gridview o vincularlo a la base de datos
            gvPersonas.DataBind()
            SwalUtils.ShowSwal(Me, "Persona creada", $"La persona {persona.Nombre} {persona.Apellidos} ha sido creada exitosamente.", "success")
        Else
            lblMensaje.Text = "Error al crear la persona."
            lblMensaje.CssClass = "alert alert-danger"
        End If




    End Sub







End Class