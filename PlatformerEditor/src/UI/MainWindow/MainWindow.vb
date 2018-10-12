Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.Xna.Framework.Graphics

Public Class MainWindow

    Public Shared Levels As New List(Of Level)
    Public Shared CharacterPresets As New List(Of Character)

    Private game As New LevelEditor.Main()

    Public Shared f As MainWindow

    Private WorldPath As String = ""

    Sub New()
        InitializeComponent()

        f = Me
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim StartWindow As New StartWindow With {.Owner = Me}
        StartWindow.ShowDialog()
    End Sub

    Private Sub btnAddLevel_Click(sender As Object, e As EventArgs) Handles btnAddLevel.Click
        LevelEditor.Main.LevelName = InputBox("Input new level name:")
        PlacedObjects.Clear()
    End Sub

    Public Sub LevelsListChanged()
        lvLevels.Items.Clear()

        For Each lvl In Levels
            With lvLevels.Items.Add(lvl.Name)
                .SubItems.Add(lvl.PlacedObjects.Count.ToString)
            End With
        Next
    End Sub

    Public Sub CharactersListChanged()
        lvCharacters.Items.Clear()

        For Each _char In CharacterPresets
            With lvCharacters.Items.Add(_char.Name)
                .SubItems.Add(_char.TexturePath)
                .SubItems.Add(_char.CharacterType.ToString)
            End With
        Next
    End Sub

    Private Sub lvLevels_DoubleClick(sender As Object, e As EventArgs) Handles lvLevels.DoubleClick
        LevelEditor.Main.LevelName = lvLevels.SelectedItems(0).Text
        WorldObjects = Levels.Find(Function(x) x.Name = lvLevels.SelectedItems(0).Text).WorldObjects

        For Each wObj In WorldObjects
            wObj.Texture = GlobalContent.Load(Of Texture2D)(wObj.TexturePath)
        Next

        game.Editor.RefreshBtnList()

        PlacedObjects = Levels.Find(Function(x) x.Name = lvLevels.SelectedItems(0).Text).PlacedObjects
        LightPolygons = Levels.Find(Function(x) x.Name = lvLevels.SelectedItems(0).Text).LightPolygons

        Form.FromHandle(game.Window.Handle).Focus()
    End Sub

    Private Sub MainWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        game.Run()
    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'If Windows.Forms.MessageBox.Show("Do you want to save the world?", "", Windows.Forms.MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

        'End If

        ' TODO: Add proper closing check to save
    End Sub

    Private Sub btnAddChar_Click(sender As Object, e As EventArgs) Handles btnAddChar.Click
        CharacterPresets.Add((New CharacterPresetWindow).ShowDialog())
        CharactersListChanged()
    End Sub

    Private Sub btnSaveWorld_Click(sender As Object, e As EventArgs) Handles btnSaveWorld.Click
        FileHandler.SaveWorld()
    End Sub

    Private Sub btnDeleteLevel_Click(sender As Object, e As EventArgs) Handles btnDeleteLevel.Click
        If lvLevels.SelectedItems IsNot Nothing Then
            Levels.Remove(Levels.Find(Function(x) x.Name = lvLevels.SelectedItems(0).Text))
            LevelsListChanged()
        End If

        ' TODO: Remove level file as well
    End Sub
End Class