Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Namespace LevelEditor
    Public Class ContextMenu
        Inherits UIElement
        Dim MenuPoints As New List(Of String)
        Public Event ItemClicked(senderText As String)

        Sub New(_menuPoints As List(Of String))
            MenuPoints = _menuPoints

            'Get longest menu point
            Dim menuLength As Integer = 0
            For Each _mP In MenuPoints
                If FontKoot.MeasureString(_mP).X > menuLength Then
                    menuLength = CInt(FontKoot.MeasureString(_mP).X) + 10
                End If
            Next

            rect.Width = menuLength
            rect.Height = MenuPoints.Count * 30
            Diagnostics.Debug.WriteLine(rect.ToString)
        End Sub

        Public Sub SetPosition(_position As Vector2)
            rect.Location = _position.ToPoint
        End Sub

        Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
            If Visible Then
                ' Draw menu background
                Misc.DrawRectangle(theSpriteBatch, rect, Color.LightGray)

                If rect.Contains(Mouse.GetState.Position) Then ' if mouse in context menu
                    Dim MouseY As Integer = Mouse.GetState.Position.Y - rect.Y ' get mouse pos in menu
                    MouseY = CInt(Math.Floor(MouseY / 30)) ' get mouse hovering menu point index

                    Dim menuRect As New Rectangle(rect.X, rect.Y + MouseY * 30, rect.Width, 30) ' get the rect of the hovered menu point
                    Misc.DrawRectangle(theSpriteBatch, menuRect, Color.Gray) ' draw hover effect

                    If Mouse.GetState.LeftButton = ButtonState.Pressed Then
                        Misc.DrawRectangle(theSpriteBatch, menuRect, SubtractColors(Color.Gray, New Color(90, 90, 90))) ' draw click effect
                    End If

                    If MouseLastState.LeftButton = ButtonState.Pressed AndAlso Mouse.GetState.LeftButton = ButtonState.Released Then ' If mouse clicked
                        RaiseEvent ItemClicked(MenuPoints(MouseY))
                        Visible = False
                    End If
                End If

                For i As Integer = 0 To MenuPoints.Count - 1
                    theSpriteBatch.DrawString(FontKoot, MenuPoints(i), New Vector2(rect.X + 5, rect.Y + 30 * i + (30 - FontKoot.MeasureString(MenuPoints(i)).Y) / 2), Color.Black) ' draw menu point strings
                Next

                If Mouse.GetState.LeftButton = ButtonState.Pressed AndAlso Not rect.Contains(Mouse.GetState.Position) Then
                    Visible = False
                End If
            End If
        End Sub
    End Class
End Namespace