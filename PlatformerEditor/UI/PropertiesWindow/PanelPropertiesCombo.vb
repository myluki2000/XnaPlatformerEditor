Public Class PanelPropertiesCombo
    Public SelectedItem As String

    Sub New(ControlName As String, labelText As String, SelectableItems() As String)
        InitializeComponent()

        Name = ControlName
        LabelDescription.Text = labelText


        ComboValue.Items.AddRange(SelectableItems)
        SelectedItem = SelectableItems(0)
    End Sub

    Private Sub ComboValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboValue.SelectedIndexChanged
        SelectedItem = ComboValue.SelectedItem.ToString
    End Sub
End Class
