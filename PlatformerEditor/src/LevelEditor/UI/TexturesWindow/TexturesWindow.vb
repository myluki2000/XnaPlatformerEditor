Imports System.Windows.Forms

Public Class TexturesWindow
    Public Shadows Sub ShowDialog(parent As LevelEditor.Screens.Editor.Editor)
        RefreshList()

        MyBase.ShowDialog()

        parent.RefreshBtnList()
    End Sub

    Private Sub btnAddTexture_Click(sender As Object, e As EventArgs) Handles btnAddTexture.Click
        ofdTextures.ShowDialog()

        For Each filePath In ofdTextures.FileNames

            If filePath <> "" Then
                If filePath.Contains("\Content\") Then ' Check if path is in content directory

                    filePath = filePath.Split(New String() {"\Content\"}, StringSplitOptions.None)(1)
                    filePath = filePath.Replace(".png", "")

                    If IO.File.Exists(IO.Path.Combine(Application.StartupPath, GlobalContent.RootDirectory, filePath) & ".png") Then
                        Dim objName As String = TextureNameWindow.ShowDialog(IO.Path.Combine(Application.StartupPath, GlobalContent.RootDirectory, filePath) & ".png")

                        If objName <> "" Then
                            Dim newObj As New WorldObject(objName, filePath)
                            newObj.rect.Width = newObj.Texture.Width
                            newObj.rect.Height = newObj.Texture.Height
                            WorldObjects.Add(newObj)
                        End If

                    Else

                        MsgBox("Texture file does not exist. (Must be .png)")
                    End If
                Else
                    MsgBox("Texture file must be placed in the Content folder or a subfolder")
                End If
            End If

        Next

        RefreshList()
    End Sub

    Private Sub btnDeleteTexture_Click(sender As Object, e As EventArgs) Handles btnDeleteTexture.Click
        For Each item As ListViewItem In lvTextures.SelectedItems
            WorldObjects.Remove(WorldObjects.Find(Function(x) x.Name = item.Text))
        Next

        RefreshList()
    End Sub

    Private Sub RefreshList()
        lvTextures.Items.Clear()

        Dim imgList As New ImageList()

        For Each wObj In WorldObjects
            ' Add texture of wObj to image list together with it's id
            imgList.Images.Add(wObj.Name, LevelEditor.Misc.Texture2DToBitmap(wObj.Texture))

            imgList.ImageSize = New Drawing.Size(150, 150)
            imgList.ColorDepth = ColorDepth.Depth16Bit

            lvTextures.SmallImageList = imgList
            lvTextures.LargeImageList = imgList

            ' Add world objects in list view
            With lvTextures.Items.Add(wObj.Name)
                .SubItems.Add(wObj.TexturePath)

                .ImageKey = wObj.Name
            End With


        Next
    End Sub

    Private Sub lvTextures_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvTextures.SelectedIndexChanged
        If lvTextures.SelectedItems.Count > 0 Then
            pnlProperties.Visible = True
            Dim selectedWObj = WorldObjects.Find(Function(x) x.Name = lvTextures.SelectedItems(0).Text)

            pbTexturePreview.Image = LevelEditor.Misc.Texture2DToBitmap(selectedWObj.Texture)

            lblTexturePath.Text = "Path: " & lvTextures.SelectedItems(0).SubItems(1).Text

            nudTileWidth.Value = selectedWObj.rect.Width
            nudTileHeight.Value = selectedWObj.rect.Height
            cbFoliage.Checked = selectedWObj.IsFoliage
            cbRandomRotation.Checked = selectedWObj.HasRandomTextureRotation
        Else
            pnlProperties.Visible = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If lvTextures.SelectedItems.Count > 0 Then
            Dim selectedWObj = WorldObjects.Find(Function(x) x.Name = lvTextures.SelectedItems(0).Text)

            selectedWObj.rect.Width = CInt(nudTileWidth.Value)
            selectedWObj.rect.Height = CInt(nudTileHeight.Value)
            selectedWObj.IsFoliage = cbFoliage.Checked
            selectedWObj.HasRandomTextureRotation = cbRandomRotation.Checked

            For Each selectedWObj In PlacedObjects.FindAll(Function(x) x.Name = lvTextures.SelectedItems(0).Text)
                selectedWObj.rect.Width = CInt(nudTileWidth.Value)
                selectedWObj.rect.Height = CInt(nudTileHeight.Value)
                selectedWObj.IsFoliage = cbFoliage.Checked
                selectedWObj.HasRandomTextureRotation = cbRandomRotation.Checked
            Next
        End If
    End Sub

    Private Sub btnHalveSize_Click(sender As Object, e As EventArgs) Handles btnHalveSize.Click
        nudTileHeight.Value /= 2
        nudTileWidth.Value /= 2
    End Sub
End Class