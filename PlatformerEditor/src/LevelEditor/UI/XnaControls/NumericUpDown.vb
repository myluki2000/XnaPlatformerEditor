﻿Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class NumericUpDown
    Inherits UIElement
    Public Value As Integer = 0
    Public NUDArrows As Texture2D
    Public Label As String = ""
    Public MinValue As Integer = -50
    Public MaxValue As Integer = 50
    Event ValueChanged()

    Sub New(_destRect As Rectangle, _label As String)
        Label = _label
        rect = _destRect
        NUDArrows = TextureLoader.Load("Content/UI/NUDArrows")

        Visible = True
    End Sub

    Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
        If Visible Then
            LevelEditor.Misc.DrawRectangle(theSpriteBatch, New Rectangle(CInt(rect.Left + FontKoot.MeasureString(Label).X + 10), rect.Top, CInt(rect.Width - 10 - FontKoot.MeasureString(Label).X), rect.Height), Color.Gray)
            theSpriteBatch.DrawString(FontKoot, Label, New Vector2(rect.X, CSng(rect.Y + rect.Height / 2 - FontKoot.MeasureString(Label).Y / 2)), Color.Black)
            theSpriteBatch.DrawString(FontKoot, Value.ToString, New Vector2(rect.X + FontKoot.MeasureString(Label).X + 20, CSng(rect.Y + rect.Height / 2 - FontKoot.MeasureString(Value.ToString).Y / 2)), Color.Black)
            theSpriteBatch.Draw(NUDArrows, New Rectangle(rect.Right - 15, rect.Top, 15, 30), Color.White)

            If Mouse.GetState.LeftButton = ButtonState.Released AndAlso MouseLastState.LeftButton = ButtonState.Pressed Then
                If New Rectangle(rect.Right - 15, rect.Top, 15, 15).Contains(Mouse.GetState.Position) Then
                    If Value < MaxValue Then
                        Value += 1
                        RaiseEvent ValueChanged()
                    End If
                ElseIf New Rectangle(rect.Right - 15, rect.Top + 15, 15, 15).Contains(Mouse.GetState.Position) Then
                    If Value > MinValue Then
                        Value -= 1
                        RaiseEvent ValueChanged()
                    End If
                End If
                End If
        End If
    End Sub
End Class
