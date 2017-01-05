Public Class PanelPropertiesTB
    Public textbox As String

    Sub New(labelText As String, initialText As String)
        InitializeComponent()

        LabelDescription.Text = labelText
        textbox = initialText
        TBValue.Text = initialText
    End Sub

    Private Sub TBValue_TextChanged(sender As Object, e As EventArgs) Handles TBValue.TextChanged
        textbox = TBValue.Text
    End Sub
End Class
