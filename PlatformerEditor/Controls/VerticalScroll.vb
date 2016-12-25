﻿Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class VerticalScroll
    Inherits UIElement

    Public Value As Single = 0
    Public Dragging As Boolean = False
    Dim MouseDragShift As Integer
    Dim SliderRect As Rectangle

    Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
        SliderRect = New Rectangle(rect.X, CInt(rect.Y + Value * (rect.Height - 30)), rect.Width, 30) ' 30 = Slider height

        If Mouse.GetState.LeftButton = ButtonState.Pressed Then
            If Misc.PointInRect(Mouse.GetState.Position, SliderRect) Then
                ' If Mouse pressed (dragging)

                If MouseLastState.LeftButton = ButtonState.Released Then
                    ' If begin of drag
                    Dragging = True
                    MouseDragShift = Mouse.GetState.Position.Y - SliderRect.Y
                End If
            End If
        Else
            Dragging = False
        End If

        If Dragging Then
            ' Actual position relative to scroll.rect
            Dim actual As Integer = CInt(rect.Y + rect.Height * Value / 100) - rect.Y

            Value = CSng((Mouse.GetState.Position.Y - rect.Y - MouseDragShift) / (rect.Height - 30)) ' 30 = Slider height
            If Value < 0 Then
                Value = 0
            ElseIf Value > 1 Then
                Value = 1
            End If
        End If

        ' Background
        Misc.DrawRectangle(theSpriteBatch, rect, Color.DarkGray)

        ' Slider
        Misc.DrawRectangle(theSpriteBatch, SliderRect, Color.LightGray)
    End Sub
End Class
