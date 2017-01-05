Public Class PanelPropertiesCB
    Public Checked As Boolean

    Sub New(initalCheckedState As Boolean, label As String)
        InitializeComponent()

        CBProperty.Text = label
        CBProperty.Checked = initalCheckedState
    End Sub

    Private Sub CBProperty_CheckedChanged(sender As Object, e As EventArgs) Handles CBProperty.CheckedChanged
        Checked = CBProperty.Checked
    End Sub
End Class
