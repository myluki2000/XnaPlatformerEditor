Public Class TextureNameWindow
    Public Overloads Shared Function ShowDialog(imgPath As String) As String
        Dim f As New TextureNameWindow
        f.pbImage.ImageLocation = imgPath
        f.lblTexturePath.Text = "Texture Path: " & imgPath
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            Return f.tbName.Text
        Else
            Return ""
        End If
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class