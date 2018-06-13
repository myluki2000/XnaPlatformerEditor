Public Class EditSegmentForm
    Private EditType As EditTypes

    Public Enum EditTypes
        Create
        Edit
    End Enum

    Sub New(_et As EditTypes)
        InitializeComponent()

        EditType = _et
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        DialoguePropertiesForm.Segments.Add(New DialogueSegment With {.FaceSpritePath = tbPath.Text, .Text = tbText.Text, .DeactivateAfterSegment = cbDeactivate.Checked, .ResetAfterSegment = cbReset.Checked})
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class