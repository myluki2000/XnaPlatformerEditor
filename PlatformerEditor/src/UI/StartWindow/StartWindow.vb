Imports System.Windows.Forms

Public Class StartWindow
    Public EndExecution As Boolean = True

    Private Sub btnNewWorld_Click(sender As Object, e As EventArgs) Handles btnNewWorld.Click
        EndExecution = False
        Me.Close()
    End Sub

    Private Sub btnLoadWorld_Click(sender As Object, e As EventArgs) Handles btnLoadWorld.Click
        fbdWorldPath.ShowDialog()

        If fbdWorldPath.SelectedPath IsNot "" Then
            My.Settings.LastWorldPath = fbdWorldPath.SelectedPath
            My.Settings.Save()

            FileHandler.LoadWorld(fbdWorldPath.SelectedPath)

            EndExecution = False
            Me.Close()
        End If
    End Sub

    Private Sub StartWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If EndExecution Then
            End
        End If

        EndExecution = True
    End Sub

    Private Sub StartWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.LastWorldPath <> "" Then
            lblLastWorldPath.Text = "Last World: " & My.Settings.LastWorldPath
            btnLoadLast.Enabled = True
        End If
    End Sub

    Private Sub btnLoadLast_Click(sender As Object, e As EventArgs) Handles btnLoadLast.Click
        If My.Settings.LastWorldPath <> "" Then
            FileHandler.LoadWorld(My.Settings.LastWorldPath)

            EndExecution = False
            Me.Close()
        End If
    End Sub
End Class