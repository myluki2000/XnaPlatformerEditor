Public Class PanelPropertiesCB
    Public Checked As Boolean

    Sub New(ControlName As String, initalCheckedState As Boolean, label As String)
        InitializeComponent()

        Name = ControlName

        CBProperty.Text = label
        Checked = initalCheckedState
        CBProperty.Checked = initalCheckedState
    End Sub

    Private Sub CBProperty_CheckedChanged(sender As Object, e As EventArgs) Handles CBProperty.CheckedChanged
        Checked = CBProperty.Checked
    End Sub
End Class
