Public Class PanelPropertiesTB

    Sub New(ControlName As String, labelText As String, initialText As String)
        InitializeComponent()

        Name = ControlName

        LabelDescription.Text = labelText
        Text = initialText
        TBValue.Text = initialText
    End Sub

    Private Sub TBValue_TextChanged(sender As Object, e As EventArgs) Handles TBValue.TextChanged
        Text = TBValue.Text
    End Sub
End Class
