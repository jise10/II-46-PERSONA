Imports PERSONA.Models
Imports PERSONA.Utils

Public Class Persona
    Inherits System.Web.UI.Page

    Private dbPersona As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        ' VALIDAR FECHA

        If Not IsDate(txtFechaNac.Text) Then
            'lblMensaje.Text = "La fecha de nacimiento no es válida."
            ' lblMensaje.CssClass = "alert alert-danger"
            Return
        End If


        ' CREAR OBJETO PERSONA

        Dim persona As New Models.Persona()

        persona.Nombre = txtNombre.Text.Trim()
        persona.Apellidos = txtApellidos.Text.Trim()
        persona.Correo = txtCorreo.Text.Trim()
        persona.NumeroDocumento = txtNumeroDoc.Text.Trim()
        persona.TipoDocummento = ddlTipoDocumento.SelectedValue
        persona.FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text)


        ' GUARDAR EN BASE DE DATOS

        Dim id As Integer = dbPersona.CrearPersona(persona)

        If id > 0 Then

            gvPersonas.DataBind()

            SwalUtils.ShowSwal(Me,
                           "Persona creada",
                           $"La persona {persona.Nombre} {persona.Apellidos} ha sido creada exitosamente.",
                           "success")
            LimpiarFormulario()


        Else

            SwalUtils.ShowSwalError(Me,
                                "Error al crear persona",
                                "Ocurrió un error al intentar crear la persona.")

        End If


    End Sub




    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
        Dim result As Integer = dbPersona.EliminarPersona(id)

        If result Then
            SwalUtils.ShowSwal(Me, "Persona eliminada", "La persona ha sido eliminada exitosamente.")
        Else
            SwalUtils.ShowSwalError(Me, "Error al eliminar persona", "Ocurrió un error al intentar eliminar la persona. Por favor, inténtelo de nuevo.")
        End If

        gvPersonas.DataBind()
        e.Cancel = True
    End Sub


    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvPersonas.EditIndex = e.NewEditIndex
        txtNombre.Text = CType(gvPersonas.Rows(e.NewEditIndex).FindControl("txtNombreEdit"), TextBox).Text
        gvPersonas.DataBind()
    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

    End Sub

    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        '
        Dim persona As New Models.Persona()
        persona.Nombre = CType(gvPersonas.Rows(e.RowIndex).FindControl("txtNombreEdit"), TextBox).Text
        SwalUtils.ShowSwal(Me, persona.Nombre, "", "success")
        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()


    End Sub
    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)

        hfIdPersona.Value = gvPersonas.DataKeys(gvPersonas.SelectedIndex).Value
        Dim id As Integer = Convert.ToInt32(hfIdPersona.Value)

        Dim errorMessage As String = ""

        Dim p As Models.Persona = dbPersona.ConsultarPersona(id)

        If p Is Nothing Then
            SwalUtils.ShowSwalError(Me, If(errorMessage = "", "No se pudo cargar la persona.", errorMessage))
            Return
        End If

        txtNumeroDoc.Text = p.NumeroDocumento
        txtNombre.Text = p.Nombre
        txtApellidos.Text = p.Apellidos
        ddlTipoDocumento.SelectedValue = p.TipoDocummento
        txtCorreo.Text = p.Correo
        txtFechaNac.Text = p.FechaNacimiento.ToString("yyyy-MM-dd")
        btnGuardar.Visible = False
        btnActualizar.Visible = True
        BtnCancelar.Visible = True


    End Sub

    Protected Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        btnGuardar.Visible = True
        btnActualizar.Visible = False
        BtnCancelar.Visible = False
        LimpiarFormulario()

    End Sub

    Protected Sub LimpiarFormulario()
        txtNumeroDoc.Text = ""
        txtNombre.Text = ""
        txtApellidos.Text = ""
        ddlTipoDocumento.SelectedIndex = 0
        txtCorreo.Text = ""
        txtFechaNac.Text = ""
    End Sub








End Class