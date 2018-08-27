Imports PlatformerEditor.LevelEditor

Public Class LevelPropertiesWindow
    Private Sub LevelPropertiesWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateControls()
    End Sub

    Private Sub PopulateControls()
        tbBackgroundImagePath.Text = MainWindow.Levels.Find(Function(x) x.Name = Main.LevelName).BackgroundImagePath
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        MainWindow.Levels.Find(Function(x) x.Name = Main.LevelName).BackgroundImagePath = tbBackgroundImagePath.Text
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class