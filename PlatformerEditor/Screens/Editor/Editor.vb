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

            Dim WithEvents btnObjects As New Button With {.text = "Objects", .rect = New Rectangle(50, 10, 70, 30), .ToggleButton = True}
            Dim WithEvents btnListObjects As New ButtonList With {.rect = New Rectangle(50, 50, 300, 200), .btnWidth = 40, .btnHeight = 40}
            Dim WithEvents btnSnapToGrid As New Button With {.rect = New Rectangle(130, 10, 110, 30), .text = "Snap To Grid", .ToggleButton = True}
            Dim WithEvents btnClose As New Button With {.text = "X", .rect = New Rectangle(Main.graphics.PreferredBackBufferWidth - 40, 10, 30, 30)}
            Dim WithEvents btnCursor As New Button With {.ToggleButton = True, .Checked = True, .rect = New Rectangle(10, 10, 30, 30), .text = "", .BackgroundTexture = GlobalContent.Load(Of Texture2D)("Cursor")}
            Dim WithEvents btnDelete As New Button With {.rect = New Rectangle(250, 10, 30, 30), .BackgroundTexture = GlobalContent.Load(Of Texture2D)("Delete"), .text = ""}
            Dim WithEvents NUDzindex As New NumericUpDown(New Rectangle(Main.graphics.PreferredBackBufferWidth - 180, 10, 130, 30), "Z-Index:")
            Dim UIPanel As New UIPanel(New Rectangle(0, 0, Main.graphics.PreferredBackBufferWidth, 50))

            Dim UIElements As New List(Of UIElement)

            Dim WorldObjects As New List(Of WorldObject)
            Dim PlacedObjects As New List(Of WorldObject)
            Dim SelectedPlaceObject As String
            Dim SelectedObject As WorldObject

            Dim Dragging As Drag
            Dim DragMouseShift As Point
            Private Enum Drag
                worldObject
                corner
                None
            End Enum

            Sub New()
                ' Save WorldObjects to XML
                'Dim xele As New XElement("WorldObjects",
                '                                    From obj In WorldObjects
                '                                    Select New XElement("Object", New XAttribute("Name", obj.Name),
                '                                        New XElement("TexturePath", obj.TexturePath)))
                '            xele.Save("E:\tes.xml")


                ' Load WorldObjects from XML
                Dim xele As XElement = XElement.Load("E:\tes.xml")
                For Each _wObj In xele.Elements
                    WorldObjects.Add(New WorldObject(_wObj.Attribute("Name").Value, _wObj.Element("TexturePath").Value))
                Next


                For Each _wObj In WorldObjects
                    _wObj.getTexture()
                    btnListObjects.btnList.Add(New Button With {.ToggleButton = True, .BackgroundTexture = _wObj.Texture, .Name = _wObj.Name})
                Next

                For Each _btn In btnListObjects.btnList
                    AddHandler _btn.Clicked, AddressOf btnListObjectsButton_Clicked
                Next

                UIElements.Add(UIPanel)
                UIElements.Add(btnListObjects)
                UIElements.Add(btnObjects)
                UIElements.Add(btnSnapToGrid)
                UIElements.Add(NUDzindex)
                UIElements.Add(btnClose)
                UIElements.Add(btnCursor)
                UIElements.Add(btnDelete)
            End Sub

            Dim lastKeyboardState As KeyboardState
            Public Overrides Sub Update(gameTime As GameTime)
                If KeyPress(Keys.Delete) Then
                    DeleteSelectedObject()
                End If

                lastKeyboardState = Keyboard.GetState
            End Sub

            Private Function KeyPress(k As Keys) As Boolean
                If Keyboard.GetState.IsKeyUp(k) AndAlso lastKeyboardState.IsKeyDown(k) Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
                theSpriteBatch.Begin()

                If Mouse.GetState.LeftButton = ButtonState.Released Then
                    Dragging = Drag.None
                End If


                For Each _wObj In PlacedObjects
                    _wObj.Draw(theSpriteBatch)

                    ' Debug Feature: Draw outline around objects
                    ' Misc.DrawOutline(theSpriteBatch, _wObj.getScreenRect, Color.Red, 5)
                Next

                Dim selectedObjIndex As Integer = PlacedObjects.IndexOf(SelectedObject)
                If selectedObjIndex > -1 Then
                    Dim rect As Rectangle = PlacedObjects(selectedObjIndex).getScreenRect()
                    Misc.DrawOutline(theSpriteBatch, rect, Color.Red, 2)
                    Misc.DrawRectangle(theSpriteBatch, New Rectangle(rect.Right - 6, rect.Bottom - 6, 6, 6), Color.Blue)
                End If

                For Each UIele In UIElements
                    UIele.Draw(theSpriteBatch)
                Next

                Diagnostics.Debug.WriteLine(Dragging)
                If Mouse.GetState.LeftButton = ButtonState.Pressed Then

                    If SelectedObject IsNot Nothing AndAlso Misc.PointInRect(Mouse.GetState.Position, SelectedObject.getScreenRect) AndAlso
                        Misc.PointInRect(Mouse.GetState.Position, New Rectangle(SelectedObject.getScreenRect.Right - 6, SelectedObject.getScreenRect.Bottom - 6, 6, 6)) = False Then
                        If MouseLastState.LeftButton = ButtonState.Released Then
                            ' Drag Start

                            DragMouseShift = Mouse.GetState.Position - SelectedObject.rect.Location * New Point(30, 30)
                        End If

                        If Dragging = Drag.None Then
                            Dragging = Drag.worldObject
                        End If
                    End If
                    If SelectedObject IsNot Nothing AndAlso Misc.PointInRect(Mouse.GetState.Position, New Rectangle(SelectedObject.getScreenRect.Right - 6, SelectedObject.getScreenRect.Bottom - 6, 6, 6)) _
                        AndAlso Dragging = Drag.None Then
                        Dragging = Drag.corner
                    End If
                End If

                Dim index As Integer = PlacedObjects.IndexOf(SelectedObject)
                If SelectedObject IsNot Nothing AndAlso index > -1 Then
                    Select Case Dragging
                        Case Drag.worldObject
                            PlacedObjects(index).rect.X = CInt(Math.Floor((Mouse.GetState.Position.X - DragMouseShift.X) / 30))
                            PlacedObjects(index).rect.Y = CInt(Math.Floor((Mouse.GetState.Position.Y - DragMouseShift.Y) / 30))
                            SelectedObject = PlacedObjects(index)

                        Case Drag.corner
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
                    End Select
                End If

                If Mouse.GetState.LeftButton = ButtonState.Released AndAlso Mouse.GetState.Position.X > -1 AndAlso Mouse.GetState.Position.Y > -1 AndAlso MouseLastState.LeftButton = ButtonState.Pressed Then
                    Dim inUIEle As Boolean = False
                    For Each ele In UIElements
                        If Misc.PointInRect(Mouse.GetState.Position, ele.rect) AndAlso ele.Visible Then
                            inUIEle = True
                        End If
                    Next

                    If inUIEle = False Then
                        If SelectedPlaceObject Is Nothing Then
                            ' If Cursor selected

                            Dim BlockFound As Boolean = False
                            For i As Integer = PlacedObjects.Count - 1 To 0 Step -1
                                Dim _wObj As WorldObject = PlacedObjects(i)
                                If Misc.PointInRect(Mouse.GetState.Position, _wObj.getScreenRect) Then
                                    SelectedObject = _wObj
                                    SelectedObjectChanged()
                                    BlockFound = True
                                    Exit For
                                End If
                            Next

                            If BlockFound = False Then
                                SelectedObject = Nothing
                                Dragging = Drag.None
                                DragMouseShift = New Point(0, 0)
                            End If

                        Else
                            ' If Block selected
                            Dim PlacingObject As New WorldObject
                            For Each _wObj In WorldObjects
                                If _wObj.Name = SelectedPlaceObject Then
                                    PlacingObject.Name = _wObj.Name
                                    PlacingObject.Texture = _wObj.Texture
                                    PlacingObject.rect.X = CInt(Math.Floor(Mouse.GetState.Position.X / 30))
                                    PlacingObject.rect.Y = CInt(Math.Floor(Mouse.GetState.Position.Y / 30))
                                    PlacingObject.rect.Width = PlacingObject.Texture.Width
                                    PlacingObject.rect.Height = PlacingObject.Texture.Height
                                    PlacingObject.zIndex = NUDzindex.Value
                                    PlacedObjects.Add(PlacingObject)
                                    PlacedObjects = PlacedObjects.OrderBy(Function(x) x.zIndex).ToList
                                    Exit For
                                End If
                            Next
                        End If
                    End If

                End If

                theSpriteBatch.DrawString(FontKoot, Mouse.GetState.Position.ToString, Vector2.Zero, Color.Black)
                theSpriteBatch.End()
            End Sub

            Private Sub SelectedObjectChanged()
                If SelectedObject IsNot Nothing Then
                    NUDzindex.Value = SelectedObject.zIndex
                End If
            End Sub

            Private Sub btnListObjectsButton_Clicked(sender As Object)
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

            Private Sub btnObjects_Click() Handles btnObjects.Clicked
                If btnObjects.Checked Then
                    btnListObjects.Visible = True
                Else
                    btnListObjects.Visible = False
                End If
            End Sub

            Private Sub btnCursor_Click() Handles btnCursor.Clicked
                SelectedPlaceObject = Nothing

                btnObjects.Checked = False
                btnListObjects.Visible = False

                For Each _btn In btnListObjects.btnList
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
        End Class
    End Namespace
End Namespace
