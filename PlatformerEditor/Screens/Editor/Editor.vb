Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Namespace Screens
    Namespace Editor
        Public Class Editor
            Inherits Screen

#Region "UI Declarations"
            Dim WithEvents btnObjects As New Button With {.text = "Objects", .rect = New Rectangle(50, 10, 65, 30), .ToggleButton = True}
            Dim WithEvents btnTechnical As New Button With {.text = "Technical", .rect = New Rectangle(125, 10, 80, 30), .ToggleButton = True}
            Dim WithEvents btnListObjects As New ButtonList With {.rect = New Rectangle(50, 50, 120, 150), .btnWidth = 40, .btnHeight = 40}
            Dim WithEvents btnListTechnical As New ButtonList With {.rect = New Rectangle(100, 50, 300, 200), .btnWidth = 80, .btnHeight = 40}
            Dim WithEvents btnSnapToGrid As New Button With {.rect = New Rectangle(215, 10, 105, 30), .text = "Snap To Grid", .ToggleButton = True}
            Dim WithEvents btnClose As New Button With {.text = "X", .rect = New Rectangle(Main.graphics.PreferredBackBufferWidth - 40, 10, 30, 30)}
            Dim WithEvents btnCursor As New Button With {.ToggleButton = True, .Checked = True, .rect = New Rectangle(10, 10, 30, 30), .text = "", .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Cursor")}
            Dim WithEvents btnDelete As New Button With {.rect = New Rectangle(330, 10, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Delete"), .text = ""}
            Dim WithEvents btnSave As New Button With {.rect = New Rectangle(370, 10, 90, 30), .text = "Save Level"}
            Dim WithEvents btnLoad As New Button With {.rect = New Rectangle(470, 10, 90, 30), .text = "Load Level"}

            Dim WithEvents NUDzindex As New NumericUpDown(New Rectangle(Main.graphics.PreferredBackBufferWidth - 180, 10, 130, 30), "Z-Index:")
            Dim UIPanel As New UIPanel(New Rectangle(0, 0, Main.graphics.PreferredBackBufferWidth, 50))

            Dim WithEvents wObjContext As New ContextMenu(New List(Of String) From {"Edit Hitbox"})


            ' Hitbox Edit Mode
            Dim WithEvents btnHBAcceptEdit As New Button With {.rect = New Rectangle(10, Main.graphics.PreferredBackBufferHeight - 40, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Checkmark"), .text = "", .Visible = False}
            Dim WithEvents btnHBReset As New Button With {.rect = New Rectangle(50, Main.graphics.PreferredBackBufferHeight - 40, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/Reset"), .text = "", .Visible = False}
            Dim WithEvents btnHBAddCorner As New Button With {.rect = New Rectangle(90, Main.graphics.PreferredBackBufferHeight - 40, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("UI/AddCorner"), .text = "", .Visible = False}

            ' List for all UI elements
            Dim UIElements As New List(Of UIElement)

            ' List for Hitbox Editor UI elements
            Dim HBEditorElements As New List(Of UIElement)
#End Region

            Dim SelectedPlaceObject As String
            Dim SelectedObject As WorldObject

            Dim gameTime As GameTime

            Dim Dragging As Drag
            Dim DragMouseShift As Point

            Dim CollisionMapRT As New RenderTarget2D(Main.graphics.GraphicsDevice, 1000, 600)

            Private Enum Drag
                worldObject
                corner
                None
                placing
                EditingHitbox
            End Enum

            Sub New()
#Region "World Objects Init"
                ''Save WorldObjects to XML
                'WorldObjects.Add(New WorldObject("Brick", "Textures/Brick"))
                'WorldObjects.Add(New WorldObject("Grass", "Textures/Grass"))

                'Dim xele2 As New XElement("WorldObjects",
                '                                    From obj In WorldObjects
                '                                    Select New XElement("Object", New XAttribute("Name", obj.Name),
                '                                        New XElement("TexturePath", obj.TexturePath)))
                'xele2.Save("tes.xml")

                'Load WorldObjects from XML
                Dim xele As XElement = XElement.Load("tes.xml")
                For Each _wObj In xele.Elements
                    WorldObjects.Add(New WorldObject(_wObj.Attribute("Name").Value, _wObj.Element("TexturePath").Value))
                Next


                For Each _wObj In WorldObjects
                    _wObj.getTexture()
                    btnListObjects.btnList.Add(New Button With {.ToggleButton = True, .BackgroundTexture = _wObj.Texture, .Name = _wObj.Name, .text = ""})
                Next
#End Region


#Region "Technical Objects Init"
                TechnicalObjects.Add(New Spawner)
                TechnicalObjects.Add(New PlayerTrigger)

                For Each _tObj As TechnicalObject In TechnicalObjects
                    btnListTechnical.btnList.Add(New Button With {.Name = _tObj.Name, .text = _tObj.Name, .ToggleButton = True})
                Next
#End Region


#Region "Enemy Init"
                EnemyTypes.Add(New DebugEnemy)
#End Region

#Region "UI Init"
                For Each _btn In btnListObjects.btnList
                    AddHandler _btn.Clicked, AddressOf btnListObjectsButton_Click
                Next

                For Each _btn In btnListTechnical.btnList
                    AddHandler _btn.Clicked, AddressOf btnListTechnicalButton_Click
                Next

                UIElements.Add(UIPanel)
                UIElements.Add(btnListObjects)
                UIElements.Add(btnObjects)
                UIElements.Add(btnSnapToGrid)
                UIElements.Add(NUDzindex)
                UIElements.Add(btnClose)
                UIElements.Add(btnCursor)
                UIElements.Add(btnDelete)
                UIElements.Add(btnSave)
                UIElements.Add(btnLoad)
                UIElements.Add(btnTechnical)
                UIElements.Add(btnListTechnical)
                UIElements.Add(wObjContext)

                HBEditorElements.Add(btnHBAcceptEdit)
                HBEditorElements.Add(btnHBReset)
                HBEditorElements.Add(btnHBAddCorner)
#End Region
            End Sub

            Public Overrides Sub Update(_gameTime As GameTime)
                If KeyPress(Keys.Delete) Then
                    DeleteSelectedObject()
                End If

                lastKeyboardState = Keyboard.GetState
                gameTime = _gameTime
            End Sub

            Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
                ' No Drag if mouse not pressed
                If Mouse.GetState.LeftButton = ButtonState.Released AndAlso Dragging <> Drag.EditingHitbox Then
                    Dragging = Drag.None
                End If


                theSpriteBatch.Begin()

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

                ' Draw UI
                For Each UIele In UIElements
                    UIele.Draw(theSpriteBatch)
                Next




                ' Debug Feature: Draw Mouse Pos
                theSpriteBatch.DrawString(FontKoot, Mouse.GetState.Position.ToString, Vector2.Zero, Color.Black)

                If Dragging = Drag.EditingHitbox Then
                    HitboxEditMode(theSpriteBatch)
                End If


                ' DEBUG FEATURE - Draw render target used for collision map when "K" is pressed
                If Keyboard.GetState.IsKeyDown(Keys.K) Then
                    theSpriteBatch.Draw(CollisionMapRT, New Vector2(0, 0), Color.White)
                End If

                theSpriteBatch.End()


                ObjectDrag()

                If ClickHandler.CheckForDoubleClick(gameTime) Then
                    If SelectedObject IsNot Nothing Then
                        Dim propWindow As New PropertiesWindow
                        propWindow.ShowProperties(SelectedObject)
                    End If
                End If

                If Mouse.GetState.RightButton = ButtonState.Released AndAlso MouseLastState.RightButton = ButtonState.Pressed AndAlso SelectedObject IsNot Nothing Then
                    ' If mouse right clicked and placed obj selected
                    wObjContext.SetPosition(Mouse.GetState.Position.ToVector2 + New Vector2(10, 0))
                    wObjContext.Visible = True
                End If
            End Sub

            Private Sub SelectedObjectChanged()
                If SelectedObject IsNot Nothing Then
                    NUDzindex.Value = SelectedObject.zIndex
                End If
            End Sub

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

            Private Sub DeleteSelectedObject()
                If SelectedObject IsNot Nothing Then
                    PlacedObjects.Remove(SelectedObject)
                End If
            End Sub

            Private Sub NUDzIndex_ValueChanged() Handles NUDzindex.ValueChanged
                If SelectedObject IsNot Nothing Then
                    PlacedObjects(PlacedObjects.IndexOf(SelectedObject)).zIndex = NUDzindex.Value
                    SelectedObject.zIndex = NUDzindex.Value
                    PlacedObjects = PlacedObjects.OrderBy(Function(x) x.zIndex).ToList
                End If
            End Sub

            Private Sub btnClose_Click() Handles btnClose.Clicked
                ScreenHandler.SelectedScreen = New Screens.MainMenu.MainMenu
            End Sub

            Private Sub btnSave_Click() Handles btnSave.Clicked
                ' Compute CollisionMap
                InitCollisionMap()

                LevelFileHandler.SaveLevel(PlacedObjects)
            End Sub

            Private Sub btnLoad_Click() Handles btnLoad.Clicked
                'Dim loadingLevel As List(Of WorldObject)

                'loadingLevel = LevelFileHandler.LoadLevel
                'If loadingLevel IsNot Nothing Then
                '    PlacedObjects.Clear()
                '    PlacedObjects = loadingLevel

                '    For Each _obj In PlacedObjects
                '        _obj.Texture = WorldObjects.Find(Function(x) x.Name = _obj.Name).Texture
                '        _obj.TexturePath = WorldObjects.Find(Function(x) x.Name = _obj.Name).TexturePath
                '    Next
                'End If
                Throw New NotImplementedException
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
                                    Dim oldPos As Point = PlacedObjects(index).rect.Location
                                    PlacedObjects(index).rect.X = CInt(Math.Floor((Mouse.GetState.Position.X - DragMouseShift.X) / 30))
                                    PlacedObjects(index).rect.Y = CInt(Math.Floor((Mouse.GetState.Position.Y - DragMouseShift.Y) / 30))
                                    SelectedObject = PlacedObjects(index)
                                    ' Move the hitbox by the shift of the old block pos and new block pos * 30 (because the grid rect)
                                    PlacedObjects(index).Hitbox.MovePolygon(((PlacedObjects(index).rect.Location - oldPos) * New Point(30, 30)).ToVector2)

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
                        If Dragging <> Drag.EditingHitbox Then
                            Dragging = Drag.placing
                        End If

                        If IsNothing(PlacedObjects.Find(Function(x) x.rect.Location = New Point(CInt(Math.Floor((Mouse.GetState.Position.X) / 30)),
                                                                                      CInt(Math.Floor((Mouse.GetState.Position.Y) / 30))))) Then

                                ' If block at mouse pos is nothing (there is no block)
                                PlaceSelectedBlock()
                            Else
                                If PlacedObjects.Find(Function(x) x.rect.Location = New Point(CInt(Math.Floor((Mouse.GetState.Position.X) / 30)),
                                                                                      CInt(Math.Floor((Mouse.GetState.Position.Y) / 30)))).Name IsNot SelectedPlaceObject Then
                                    PlaceSelectedBlock()
                                End If
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
                        If SelectedPlaceObject Is Nothing AndAlso Dragging <> Drag.EditingHitbox Then
                            ' If Cursor selected

                            Dim BlockFound As Boolean = False
                            For i As Integer = PlacedObjects.Count - 1 To 0 Step -1
                                Dim _wObj As WorldObject = PlacedObjects(i)
                                If _wObj.getScreenRect.Contains(Mouse.GetState.Position) Then
                                    SelectedObject = _wObj
                                    SelectedObjectChanged()
                                    BlockFound = True
                                    Exit For
                                End If
                            Next

                            If BlockFound = False Then
                                SelectedObject = Nothing
                                If Dragging <> Drag.EditingHitbox Then
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
                        inUIEle = True
                    End If
                Next


                If SelectedPlaceObject IsNot Nothing AndAlso inUIEle = False Then
                    ' If Block selected

                    For Each _wObj In WorldObjects
                        If _wObj.Name = SelectedPlaceObject Then
                            Dim PlacingObject As WorldObject = _wObj.ShallowCopy()
                            PlacingObject.rect.X = CInt(Math.Floor(Mouse.GetState.Position.X / 30))
                            PlacingObject.rect.Y = CInt(Math.Floor(Mouse.GetState.Position.Y / 30))
                            PlacingObject.rect.Width = PlacingObject.Texture.Width
                            PlacingObject.rect.Height = PlacingObject.Texture.Height
                            PlacedObjects.Add(PlacingObject)
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
                            PlacedObjects.Add(PlacingObject)
                            Exit For
                        End If
                    Next

                    ' Initialize hitbox of new block
                    PlacedObjects.Last.InitHitbox()

                    ' Sort placed objects by z-index for correct drawing
                    PlacedObjects = PlacedObjects.OrderBy(Function(x) x.zIndex).ToList

                End If
            End Sub

            Private Sub wObjContext_ItemClicked(senderText As String) Handles wObjContext.ItemClicked
                Select Case senderText
                    Case "Edit Hitbox"
                        Dragging = Drag.EditingHitbox

                        For Each _uiEle In HBEditorElements
                            _uiEle.Visible = True
                        Next
                End Select
            End Sub

            Private Sub InitCollisionMap()
                ' Draw the collision map onto a render target for later conversion
                Dim tempSpriteBatch As New SpriteBatch(Main.graphics.GraphicsDevice)
                Main.graphics.GraphicsDevice.SetRenderTarget(CollisionMapRT)
                Main.graphics.GraphicsDevice.Clear(Color.White)

                tempSpriteBatch.Begin()
                For Each _wObj In PlacedObjects
                    _wObj.DrawHitbox(tempSpriteBatch, False)
                Next
                tempSpriteBatch.End()
                Main.graphics.GraphicsDevice.SetRenderTarget(Nothing)

                ' Loop over the render target's pixels, if they aren't white they are a hitbox -> set Boolean at pos to true
                CollisionMap = New Boolean(1000, 600) {}
                Dim tempColorArray(,) As Color = Misc.TextureTo2DArray(CollisionMapRT)
                For x As Integer = 0 To tempColorArray.GetUpperBound(0)
                    For y As Integer = 0 To tempColorArray.GetUpperBound(1)
                        If tempColorArray(x, y) <> Color.White Then
                            CollisionMap(x, y) = True
                        End If
                    Next
                Next
            End Sub

            Private Sub HitboxEditMode(theSpriteBatch As SpriteBatch)
                SelectedObject.DrawHitbox(theSpriteBatch, True)
                SelectedObject.EditHitbox()

                For Each _uiEle In HBEditorElements
                    _uiEle.Draw(theSpriteBatch)
                Next
                theSpriteBatch.DrawString(FontKoot, "Hitbox Editor Mode", New Vector2(10, Main.graphics.PreferredBackBufferHeight - 60), Color.Black)

            End Sub

            Private Sub btnHBAcceptEdit_Click() Handles btnHBAcceptEdit.Clicked
                For Each _uiEle In HBEditorElements
                    _uiEle.Visible = False
                    Dragging = Drag.None
                Next
            End Sub

            Private Sub btnHBReset_Click() Handles btnHBReset.Clicked
                SelectedObject.InitHitbox()
            End Sub

            Private Sub btnHBAddCorner_Click() Handles btnHBAddCorner.Clicked
                Dim corners = SelectedObject.Hitbox.corners
                Dim cornerPos As New Vector2
                cornerPos.X = (corners(0).X - corners.Last.X) / 2 + corners.Last.X
                cornerPos.Y = (corners(0).Y - corners.Last.Y) / 2 + corners.Last.Y
                SelectedObject.Hitbox.corners.Add(cornerPos)
            End Sub
        End Class
    End Namespace
End Namespace