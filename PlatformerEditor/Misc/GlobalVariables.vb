﻿Imports Microsoft.Xna.Framework

Module GlobalVariables
    Public MouseLastState As Input.MouseState
    Public FontKoot As Graphics.SpriteFont
    Public GlobalContent As Content.ContentManager

    Public lastKeyboardState As Input.KeyboardState

    Public Function SubtractColors(color1 As Color, color2 As Color) As Color
        Dim returnColor As New Color
        returnColor.B = color1.B - color2.B
        returnColor.G = color1.G - color2.G
        returnColor.R = color1.R - color2.R
        returnColor.A = color1.A
        Return returnColor
    End Function

    Public Function KeyPress(k As Input.Keys) As Boolean
        If Input.Keyboard.GetState.IsKeyUp(k) AndAlso lastKeyboardState.IsKeyDown(k) Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
