Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Namespace LevelEditor
    Namespace Screens
        Namespace Editor
            Public Class Editor
                Inherits Screen

#Region "UI Declarations"
                Dim WithEvents btnObjects As New Button With {.Text = "Objects", .rect = New Rectangle(50, 10, 65, 30), .ToggleButton = True}
                Dim WithEvents btnTechnical As New Button With {.Text = "Technical", .rect = New Rectangle(125, 10, 80, 30), .ToggleButton = True}
                Dim WithEvents btnListObjects As New ButtonList With {.rect = New Rectangle(50, 50, 120, 150), .btnWidth = 40, .btnHeight = 40}
                Dim WithEvents btnListTechnical As New ButtonList With {.rect = New Rectangle(100, 50, 300, 200), .btnWidth = 200, .btnHeight = 40}
                Dim WithEvents btnSnapToGrid As New Button With {.rect = New Rectangle(215, 10, 105, 30), .Text = "Snap To Grid", .ToggleButton = True}
                Dim WithEvents btnCursor As New Button With {.ToggleButton = True, .Checked = True, .rect = New Rectangle(10, 10, 30, 30), .Text = "", .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Cursor")}
                Dim WithEvents btnDelete As New Button With {.rect = New Rectangle(330, 10, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Delete"), .Text = ""}
                Dim WithEvents btnSave As New Button With {.rect = New Rectangle(370, 10, 90, 30), .Text = "Save Level"}
                Dim WithEvents btnTextures As New Button With {.rect = New Rectangle(470, 10, 90, 30), .Text = "Textures"}
                Dim WithEvents btnEditLight As New Button With {.rect = New Rectangle(570, 10, 100, 30), .Text = "Edit Lighting", .ToggleButton = True}
                Dim WithEvents btnLevelProperties As New Button With {.rect = New Rectangle(680, 10, 140, 30), .Text = "Level Properties"}

                Dim WithEvents NUDzindex As New NumericUpDown(New Rectangle(Main.graphics.PreferredBackBufferWidth - 140, 10, 130, 30), "Z-Index:")
                Dim UIPanel As New UIPanel(New Rectangle(0, 0, Main.graphics.PreferredBackBufferWidth, 50))


                ' Light Edit Mode
                Dim WithEvents btnELAcceptEdit As New Button With {.rect = New Rectangle(10, Main.graphics.PreferredBackBufferHeight - 40, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Checkmark"), .text = "", .Visible = False}
                Dim WithEvents btnELReset As New Button With {.rect = New Rectangle(50, Main.graphics.PreferredBackBufferHeight - 40, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Delete"), .text = "", .Visible = False}
                Dim WithEvents btnELAddCorner As New Button With {.rect = New Rectangle(90, Main.graphics.PreferredBackBufferHeight - 40, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/AddCorner"), .text = "", .Visible = False}
                Dim WithEvents btnELNewPolygon As New Button With {.rect = New Rectangle(130, Main.graphics.PreferredBackBufferHeight - 40, 110, 30), .text = "New Polygon", .Visible = False}

                Dim ELSelectedPolygon As Polygon

                ' List for all UI elements
                Dim UIElements As New List(Of UIElement)

                ' List for Hitbox Editor UI elements
                Dim ELElements As New List(Of UIElement)
#End Region



                Dim SelectedPlaceObject As String
                Dim SelectedObject As WorldObject

                Dim gameTime As GameTime

                Dim Dragging As Drag
                Dim DragMouseShift As Point

                Private Enum Drag
                    worldObject
                    corner
                    None
                    placing
                    EditingLighting
                End Enum

                Sub New()
                    'Load WorldObjects from XML
                    'Dim xele As XElement = XElement.Load("tes.xml")
                    'For Each _wObj In xele.Elements
                    '    WorldObjects.Add(New WorldObject With {.Name = _wObj.Attribute("Name").Value, .Texture = GlobalContent.Load(Of Texture2D)(_wObj.Element("TexturePath").Value), .TexturePath = _wObj.Element("TexturePath").Value})
                    'Next


                    RefreshBtnList()


                    TechnicalObjects.Add(New Spawner)
                    TechnicalObjects.Add(New PlayerTrigger)
                    TechnicalObjects.Add(New ParticleSpawner)
                    TechnicalObjects.Add(New PlayerSpawn)
                    TechnicalObjects.Add(New InfoBoxDisplay)
                    TechnicalObjects.Add(New LoadingZone)


#Region "UI Element init"
                    For Each _tObj As TechnicalObject In TechnicalObjects
                        btnListTechnical.btnList.Add(New Button With {.Name = _tObj.Name, .text = _tObj.Name, .ToggleButton = True})
                    Next


                    For Each _btn In btnListTechnical.btnList
                        AddHandler _btn.Clicked, AddressOf btnListTechnicalButton_Click
                    Next


                    UIElements.Add(UIPanel)
                    UIElements.Add(btnListObjects)
                    UIElements.Add(btnObjects)
                    UIElements.Add(btnSnapToGrid)
                    UIElements.Add(NUDzindex)
                    UIElements.Add(btnCursor)
                    UIElements.Add(btnDelete)
                    UIElements.Add(btnSave)
                    UIElements.Add(btnTechnical)
                    UIElements.Add(btnListTechnical)
                    UIElements.Add(btnTextures)
                    UIElements.Add(btnEditLight)
                    UIElements.Add(btnLevelProperties)

                    ELElements.Add(btnELAcceptEdit)
                    ELElements.Add(btnELReset)
                    ELElements.Add(btnELAddCorner)
                    ELElements.Add(btnELNewPolygon)
#End Region

                    Matrix.CreateTranslation(0, 0, 0, WorldMatrix)
                End Sub

                Public Overrides Sub Update(_gameTime As GameTime)
                    If KeyPress(Keys.Delete) Then
                        DeleteSelectedObject()
                    End If

                    lastKeyboardState = Keyboard.GetState
                    gameTime = _gameTime
                End Sub

                Dim DraggingCorner As Integer = -1
                Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
                    ' Check if mouse in UI
                    Dim inUIEle As Boolean = False
                    For Each ele In UIElements
                        If ele.rect.Contains(Mouse.GetState.Position) AndAlso ele.Visible Then
                            inUIEle = True
                        End If
                    Next


                    ' No Drag if mouse not pressed
                    If Mouse.GetState.LeftButton = ButtonState.Released AndAlso Dragging <> Drag.EditingLighting Then
                        Dragging = Drag.None
                    End If

                    theSpriteBatch.Begin(, , , , , , WorldMatrix)

                    ' Draw level objects
                    For Each _wObj In PlacedObjects
                        _wObj.Draw(theSpriteBatch)

                        ' Debug Feature: Draw outline around objects
                        ' Misc.DrawOutline(theSpriteBatch, _wObj.getScreenRect, Color.Red, 5)
                    Next

                    ' Draw outline around selected object + corner
                    Dim selectedObjIndex As Integer = PlacedObjects.IndexOf(SelectedObject)
                    If selectedObjIndex > -1 Then
                        Dim rect As Rectangle = PlacedObjects(selectedObjIndex).getScreenRect()
                        Misc.DrawOutline(theSpriteBatch, rect, Color.Red, 2)
                        Misc.DrawRectangle(theSpriteBatch, New Rectangle(rect.Right - 6, rect.Bottom - 6, 6, 6), Color.Blue)
                    End If

                    ' Draw preview of selected block at mouse cursor
                    If SelectedPlaceObject IsNot Nothing AndAlso Not inUIEle AndAlso WorldObjects.Find(Function(x) x.Name = SelectedPlaceObject) IsNot Nothing Then
                        Dim selectedObj As WorldObject = WorldObjects.Find(Function(x) x.Name = SelectedPlaceObject)
                        theSpriteBatch.Draw(selectedObj.Texture,
                                            New Rectangle(CInt(Math.Floor((Mouse.GetState.X - WorldMatrix.Translation.X) / 30) * 30), CInt(Math.Floor((Mouse.GetState.Y - WorldMatrix.Translation.Y) / 30) * 30), selectedObj.rect.Width, selectedObj.rect.Height),
                                            Color.White * 0.5F)
                    End If

                    ' Draw light edit mode if activated
                    If Dragging = Drag.EditingLighting Then
                        LightEditMode(theSpriteBatch)
                    End If

                    theSpriteBatch.End()


                    theSpriteBatch.Begin()

                    If Dragging = Drag.EditingLighting Then
                        For Each _uiEle In ELElements
                            _uiEle.Draw(theSpriteBatch)
                        Next
                        theSpriteBatch.DrawString(FontKoot, "Lighting Editor Mode", New Vector2(10, Main.graphics.PreferredBackBufferHeight - 60), Color.Black)
                    End If


                    For Each ele In UIElements
                        ele.Draw(theSpriteBatch)
                    Next

                    theSpriteBatch.End()



#Region "Light Polygon Edit Draging"
                    For Each p In LightPolygons
                        For Each _corner In p.corners
                            If New Rectangle(_corner.ToPoint - New Point(3, 3), New Point(6, 6)).Contains(Mouse.GetState.Position) AndAlso Mouse.GetState.LeftButton = ButtonState.Pressed AndAlso
                                    MouseLastState.LeftButton = ButtonState.Released Then
                                ' If mouse cursor is in the displayed corner rectangle and the left button is now pressed
                                DraggingCorner = p.corners.IndexOf(_corner)
                                ELSelectedPolygon = p
                            ElseIf Mouse.GetState.LeftButton = ButtonState.Released Then
                                DraggingCorner = -1
                            End If

                            If DraggingCorner > -1 AndAlso DraggingCorner < ELSelectedPolygon.corners.Count Then
                                ELSelectedPolygon.corners(DraggingCorner) = Mouse.GetState.Position.ToVector2
                                Exit For
                            End If
                        Next
                    Next
#End Region


                    ObjectDrag()
                    TransformMatrixDrag()

                    If ClickHandler.CheckForDoubleClick(gameTime) Then
                        If SelectedObject IsNot Nothing Then
                            Dim propWindow As New PropertiesWindow
                            propWindow.ShowProperties(SelectedObject)
                        End If
                    End If
                End Sub

                Dim StartPoint As Point
                Dim MatrixStart As Vector3
                Private Sub TransformMatrixDrag()
                    If Mouse.GetState.MiddleButton = ButtonState.Pressed AndAlso MouseLastState.MiddleButton = ButtonState.Released Then
                        StartPoint = Mouse.GetState.Position
                        MatrixStart = WorldMatrix.Translation
                    ElseIf Mouse.GetState.MiddleButton = ButtonState.Pressed Then
                        Dim diff As Vector2 = (Mouse.GetState.Position - StartPoint).ToVector2
                        WorldMatrix.Translation = MatrixStart + New Vector3(diff.X, diff.Y, 0)
                    End If
                End Sub

                Private Sub SelectedObjectChanged()
                    If SelectedObject IsNot Nothing Then
                        NUDzindex.Value = SelectedObject.zIndex
                    End If
                End Sub

#Region "Button Event Handlers"

                Private Sub btnListObjectsButton_Click(sender As Object)
                    Dim SenderBtn = DirectCast(sender, Button)

                    SelectedObject = Nothing

                    For Each _btn In btnListObjects.btnList
                        If _btn IsNot SenderBtn Then
                            _btn.Checked = False
                        End If
                    Next

                    For Each _btn In btnListObjects.btnList
                        If _btn.Checked Then
                            SelectedPlaceObject = _btn.Name
                        End If
                    Next

                    btnCursor.Checked = False
                End Sub

                Private Sub btnListTechnicalButton_Click(sender As Object)
                    Dim SenderBtn = DirectCast(sender, Button)

                    SelectedObject = Nothing

                    For Each _btn In btnListTechnical.btnList
                        If _btn IsNot SenderBtn Then
                            _btn.Checked = False
                        End If
                    Next

                    For Each _btn In btnListTechnical.btnList
                        If _btn.Checked Then
                            SelectedPlaceObject = _btn.Name
                        End If
                    Next

                    btnCursor.Checked = False
                End Sub

                Private Sub btnObjects_Click() Handles btnObjects.Clicked
                    If btnObjects.Checked Then
                        btnListTechnical.Visible = False
                        btnTechnical.Checked = False
                        btnListObjects.Visible = True
                    Else
                        btnListObjects.Visible = False
                    End If
                End Sub

                Private Sub btnTechnical_Click() Handles btnTechnical.Clicked
                    If btnTechnical.Checked Then
                        btnListObjects.Visible = False
                        btnObjects.Checked = False
                        btnListTechnical.Visible = True
                    Else
                        btnListTechnical.Visible = False
                    End If
                End Sub

                Private Sub btnCursor_Click() Handles btnCursor.Clicked
                    SelectedPlaceObject = Nothing

                    btnObjects.Checked = False
                    btnListObjects.Visible = False

                    btnTechnical.Checked = False
                    btnListTechnical.Visible = False

                    For Each _btn In btnListObjects.btnList
                        _btn.Checked = False
                    Next

                    For Each _btn In btnListTechnical.btnList
                        _btn.Checked = False
                    Next
                End Sub

                Private Sub btnDelete_Click() Handles btnDelete.Clicked
                    DeleteSelectedObject()
                End Sub

                Private Sub btnSave_Click() Handles btnSave.Clicked
                    Dim Level As Level = MainWindow.Levels.Find(Function(x) x.Name = Main.LevelName)

                    If Level Is Nothing Then
                        Level = New Level
                        MainWindow.Levels.Add(Level)

                        Level.Name = Main.LevelName
                    End If

                    Level.PlacedObjects = PlacedObjects
                    Level.WorldObjects = New List(Of WorldObject)(WorldObjects)
                    Level.LightPolygons = LightPolygons

                    MainWindow.f.LevelsListChanged()
                End Sub

                Private Sub btnTextures_Click() Handles btnTextures.Clicked
                    Dim texWindow As New TexturesWindow

                    texWindow.ShowDialog(Me)
                End Sub

                Private Sub btnEditLight_Clicked() Handles btnEditLight.Clicked
                    If btnEditLight.Checked Then
                        Dragging = Drag.EditingLighting

                        For Each _uiEle In ELElements
                            _uiEle.Visible = True
                        Next
                    Else
                        Dragging = Drag.None

                        For Each _uiEle In ELElements
                            _uiEle.Visible = False
                        Next
                    End If
                End Sub

                Private Sub btnLevelProperties_Clicked() Handles btnLevelProperties.Clicked
                    Dim f As New LevelPropertiesWindow
                    f.ShowDialog()
                End Sub
#End Region

                Private Sub DeleteSelectedObject()
                    If SelectedObject IsNot Nothing Then
                        PlacedObjects.Remove(SelectedObject)
                        SelectedObject = Nothing
                    End If
                End Sub

                Private Sub NUDzIndex_ValueChanged() Handles NUDzindex.ValueChanged
                    If SelectedObject IsNot Nothing Then
                        PlacedObjects(PlacedObjects.IndexOf(SelectedObject)).zIndex = NUDzindex.Value
                        SelectedObject.zIndex = NUDzindex.Value
                        PlacedObjects = PlacedObjects.OrderBy(Function(x) x.zIndex).ToList
                    End If
                End Sub



                Private Sub ObjectDrag()
                    If Mouse.GetState.LeftButton = ButtonState.Pressed Then
                        If SelectedObject IsNot Nothing Then

                            If SelectedObject.getScreenRect.Contains(Mouse.GetState.Position) AndAlso
                        New Rectangle(SelectedObject.getScreenRect.Right - 6, SelectedObject.getScreenRect.Bottom - 6, 6, 6).Contains(Mouse.GetState.Position) = False Then
                                If MouseLastState.LeftButton = ButtonState.Released Then
                                    ' Drag Start

                                    DragMouseShift = Mouse.GetState.Position - SelectedObject.rect.Location * New Point(30, 30)
                                End If

                                If Dragging = Drag.None Then
                                    Dragging = Drag.worldObject
                                End If
                            End If
                            If SelectedObject IsNot Nothing AndAlso New Rectangle(SelectedObject.getScreenRect.Right - 6, SelectedObject.getScreenRect.Bottom - 6, 6, 6).Contains(Mouse.GetState.Position) _
                        AndAlso Dragging = Drag.None Then
                                Dragging = Drag.corner
                            End If


                            Dim index As Integer = PlacedObjects.IndexOf(SelectedObject)
                            If index > -1 Then
                                Select Case Dragging
                                    Case Drag.worldObject
                                        PlacedObjects(index).rect.X = CInt(Math.Floor((Mouse.GetState.Position.X - DragMouseShift.X) / 30))
                                        PlacedObjects(index).rect.Y = CInt(Math.Floor((Mouse.GetState.Position.Y - DragMouseShift.Y) / 30))
                                        SelectedObject = PlacedObjects(index)

                                    Case Drag.corner
                                        If SelectedObject.Texture IsNot Nothing Then ' If SelectedObject has a texture (is scalable)
                                            Dim distFromStart As Integer
                                            Dim scale As Integer
                                            If Mouse.GetState.Position.X - PlacedObjects(index).getScreenRect.X < Mouse.GetState.Position.Y - PlacedObjects(index).getScreenRect.Y Then
                                                distFromStart = Mouse.GetState.Position.X - PlacedObjects(index).getScreenRect.X
                                                scale = CInt(distFromStart / PlacedObjects(index).Texture.Width)
                                            Else
                                                distFromStart = Mouse.GetState.Position.Y - PlacedObjects(index).getScreenRect.Y
                                                scale = CInt(distFromStart / PlacedObjects(index).Texture.Height)
                                            End If
                                            If scale < 1 Then
                                                scale = 1
                                            End If
                                            PlacedObjects(index).Scale = scale
                                        End If
                                End Select
                            End If
                        Else
                            ' No selected object
                            If Dragging <> Drag.EditingLighting Then
                                Dragging = Drag.placing
                            End If

                            If IsNothing(PlacedObjects.Find(Function(x) x.rect.Location = New Point(CInt(Math.Floor((Mouse.GetState.Position.X - WorldMatrix.Translation.X) / 30)),
                                                                                      CInt(Math.Floor((Mouse.GetState.Position.Y - WorldMatrix.Translation.Y) / 30))))) Then

                                ' If block at mouse pos is nothing (there is no block)
                                PlaceSelectedBlock()
                            End If
                        End If
                    End If

                    If Mouse.GetState.LeftButton = ButtonState.Released AndAlso Mouse.GetState.Position.X > -1 AndAlso Mouse.GetState.Position.Y > -1 AndAlso MouseLastState.LeftButton = ButtonState.Pressed Then
                        Dim inUIEle As Boolean = False
                        For Each ele In UIElements
                            If ele.rect.Contains(Mouse.GetState.Position) AndAlso ele.Visible Then
                                inUIEle = True
                            End If
                        Next

                        If inUIEle = False Then
                            If SelectedPlaceObject Is Nothing AndAlso Dragging <> Drag.EditingLighting Then
                                ' If Cursor selected

                                Dim BlockFound As Boolean = False
                                For i As Integer = PlacedObjects.Count - 1 To 0 Step -1
                                    Dim _wObj As WorldObject = PlacedObjects(i)
                                    If _wObj.getScreen1Rect.Contains(Mouse.GetState.Position) Then
                                        SelectedObject = _wObj
                                        SelectedObjectChanged()
                                        BlockFound = True
                                        Exit For
                                    End If
                                Next

                                If BlockFound = False Then
                                    SelectedObject = Nothing
                                    If Dragging <> Drag.EditingLighting Then
                                        Dragging = Drag.None
                                    End If
                                    DragMouseShift = New Point(0, 0)
                                End If
                            End If
                        End If

                    End If
                End Sub

                Private Sub PlaceSelectedBlock()
                    Dim inUIEle As Boolean = False
                    For Each ele In UIElements
                        If ele.rect.Contains(Mouse.GetState.Position) AndAlso ele.Visible Then
                            Return
                        End If
                    Next


                    If SelectedPlaceObject IsNot Nothing Then
                        ' If Block selected

                        For Each _wObj In WorldObjects
                            If _wObj.Name = SelectedPlaceObject Then
                                Dim PlacingObject As WorldObject = _wObj.ShallowCopy()
                                PlacingObject.rect.X = CInt(Math.Floor((Mouse.GetState.Position.X - WorldMatrix.Translation.X) / 30))
                                PlacingObject.rect.Y = CInt(Math.Floor((Mouse.GetState.Position.Y - WorldMatrix.Translation.Y) / 30))
                                PlacingObject.rect.Width = PlacingObject.rect.Width
                                PlacingObject.rect.Height = PlacingObject.rect.Height
                                PlacingObject.zIndex = NUDzindex.Value
                                PlacedObjects.Add(PlacingObject)
                                PlacedObjects = PlacedObjects.OrderBy(Function(x) x.zIndex).ToList
                                Exit For
                            End If
                        Next

                        For Each _wObj In TechnicalObjects
                            If _wObj.Name = SelectedPlaceObject Then
                                Dim PlacingObject As WorldObject = _wObj.ShallowCopy()
                                PlacingObject.rect.X = CInt(Math.Floor(Mouse.GetState.Position.X / 30))
                                PlacingObject.rect.Y = CInt(Math.Floor(Mouse.GetState.Position.Y / 30))
                                PlacingObject.rect.Width = 30
                                PlacingObject.rect.Height = 30
                                PlacingObject.zIndex = NUDzindex.Value

                                If Not CType(PlacingObject, TechnicalObject).ValuesAreSafe() Then
                                    Return
                                End If


                                PlacedObjects.Add(PlacingObject)
                                PlacedObjects = PlacedObjects.OrderBy(Function(x) x.zIndex).ToList
                                Exit For
                            End If
                        Next

                        '' Initialize all hitboxes if new block is placed
                        'For Each _wObj In PlacedObjects
                        '    _wObj.InitHitbox()
                        'Next
                    End If
                End Sub

#Region "Light Edit Mode"
                Private Sub LightEditMode(sb As SpriteBatch)
                    For Each p In LightPolygons
                        p.DrawOutline(sb, True)

                    Next
                End Sub

                Private Sub btnELAcceptEdit_Click() Handles btnELAcceptEdit.Clicked
                    For Each _uiEle In ELElements
                        _uiEle.Visible = False
                        Dragging = Drag.None
                    Next

                    btnEditLight.Checked = False
                End Sub

                Private Sub btnELReset_Click() Handles btnELReset.Clicked
                    If ELSelectedPolygon IsNot Nothing Then
                        LightPolygons.Remove(ELSelectedPolygon)
                    End If
                End Sub

                Private Sub btnELAddCorner_Click() Handles btnELAddCorner.Clicked
                    If ELSelectedPolygon IsNot Nothing Then
                        Dim corners = ELSelectedPolygon.corners
                        Dim cornerPos As New Vector2
                        cornerPos.X = (corners(0).X - corners.Last.X) / 2 + corners.Last.X
                        cornerPos.Y = (corners(0).Y - corners.Last.Y) / 2 + corners.Last.Y
                        ELSelectedPolygon.corners.Add(cornerPos)
                    End If
                End Sub

                Private Sub btnELNewPolygon_Click() Handles btnELNewPolygon.Clicked
                    LightPolygons.Add(New Polygon(New Rectangle(100, 100, 50, 50)))
                End Sub
#End Region



                Public Sub RefreshBtnList()
                    btnListObjects.btnList.Clear()

                    For Each _wObj In WorldObjects
                        btnListObjects.btnList.Add(New Button With {.ToggleButton = True, .BackgroundTexture = _wObj.Texture, .Name = _wObj.Name, .text = ""})
                    Next

                    ' Add Event handlers for all buttons in the list
                    For Each _btn In btnListObjects.btnList
                        AddHandler _btn.Clicked, AddressOf btnListObjectsButton_Click
                    Next
                End Sub


            End Class
        End Namespace
    End Namespace
End Namespace