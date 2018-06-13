Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class CharacterPresetWindow

    Public Animations As New List(Of Animation)

    Public Overloads Function ShowDialog() As Character
        MyBase.ShowDialog()

        Dim newChar As New Character
        newChar.Name = tbName.Text
        newChar.TexturePath = pbTexture.ImageLocation

        Select Case cbCharType.Text
            Case "Friendly"
                newChar.CharacterType = Character.CharacterTypes.Friendly
            Case "Enemy"
                newChar.CharacterType = Character.CharacterTypes.Enemy
        End Select

        newChar.HealthPoints = CInt(nudHP.Value)

        Return newChar
    End Function

    Private Sub btnTextureSelect_Click(sender As Object, e As EventArgs) Handles btnTextureSelect.Click
        Dim ofd As New OpenFileDialog

        ofd.ShowDialog()

        If ofd.FileName <> "" Then
            pbTexture.ImageLocation = ofd.FileName
        End If
    End Sub

    Private Sub btnAddAnim_Click(sender As Object, e As EventArgs) Handles btnAddAnim.Click
        Animations.Add((New AnimationWindow).ShowDialog)
        AnimationsListChanged()
    End Sub

    Private Sub AnimationsListChanged()
        lvAnimations.Items.Clear()

        For Each _anim In Animations
            With lvAnimations.Items.Add(_anim.Name)
                .SubItems.Add(_anim.FrameDuration.ToString)
                .SubItems.Add(_anim.IterationCount.ToString)
                .SubItems.Add(_anim.FrameCount.ToString)
                .SubItems.Add(_anim.FrameRect.ToString)
            End With
        Next
    End Sub

    Private Sub btnDelAnim_Click(sender As Object, e As EventArgs) Handles btnDelAnim.Click
        Animations.RemoveAll(Function(x) x.Name = lvAnimations.SelectedItems(0).Name)
    End Sub
End Class