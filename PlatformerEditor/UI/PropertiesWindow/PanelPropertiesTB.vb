Public Class PanelPropertiesTB
    Public textbox As String

    Sub New(labelText As String)
        InitializeComponent()

        LabelDescription.Text = labelText
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TBValue.TextChanged
        textbox = TBValue.Text
    End Sub
End Class
